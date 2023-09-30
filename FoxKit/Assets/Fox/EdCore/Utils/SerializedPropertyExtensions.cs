﻿using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

// Provide simple value get/set methods for SerializedProperty.  Can be used with
// any data types and with arbitrarily deeply-pathed properties.
public static class SerializedPropertyExtensions
{
    /// (Extension) Get the value of the serialized property.
    public static object GetValue(this SerializedProperty property)
    {
        string propertyPath = property.propertyPath;
        object value = property.serializedObject.targetObject;
        int i = 0;
        while (NextPathComponent(propertyPath, ref i, out PropertyPathComponent token))
            value = GetPathComponentValue(value, token);
        return value;
    }

    /// (Extension) Set the value of the serialized property.
    public static void SetValue(this SerializedProperty property, object value)
    {
        Undo.RecordObject(property.serializedObject.targetObject, $"Set {property.name}");

        SetValueNoRecord(property, value);

        EditorUtility.SetDirty(property.serializedObject.targetObject);
        _ = property.serializedObject.ApplyModifiedProperties();
    }

    /// (Extension) Set the value of the serialized property, but do not record the change.
    /// The change will not be persisted unless you call SetDirty and ApplyModifiedProperties.
    public static void SetValueNoRecord(this SerializedProperty property, object value)
    {
        string propertyPath = property.propertyPath;
        object container = property.serializedObject.targetObject;

        int i = 0;
        _ = NextPathComponent(propertyPath, ref i, out PropertyPathComponent deferredToken);
        while (NextPathComponent(propertyPath, ref i, out PropertyPathComponent token))
        {
            container = GetPathComponentValue(container, deferredToken);
            deferredToken = token;
        }
        //Debug.Assert(!container.GetType().IsValueType, $"Cannot use SerializedObject.SetValue on a struct object, as the result will be set on a temporary.  Either change {container.GetType().Name} to a class, or use SetValue with a parent member.");
        SetPathComponentValue(container, deferredToken, value);
    }

    // Union type representing either a property name or array element index.  The element
    // index is valid only if propertyName is null.
    private struct PropertyPathComponent
    {
        public string propertyName;
        public int elementIndex;
    }

    private static readonly Regex arrayElementRegex = new(@"\GArray\.data\[(\d+)\]", RegexOptions.Compiled);

    // Parse the next path component from a SerializedProperty.propertyPath.  For simple field/property access,
    // this is just tokenizing on '.' and returning each field/property name.  Array/list access is via
    // the pseudo-property "Array.data[N]", so this method parses that and returns just the array/list index N.
    //
    // Call this method repeatedly to access all path components.  For example:
    //
    //      string propertyPath = "quests.Array.data[0].goal";
    //      int i = 0;
    //      NextPropertyPathToken(propertyPath, ref i, out var component);
    //          => component = { propertyName = "quests" };
    //      NextPropertyPathToken(propertyPath, ref i, out var component)
    //          => component = { elementIndex = 0 };
    //      NextPropertyPathToken(propertyPath, ref i, out var component)
    //          => component = { propertyName = "goal" };
    //      NextPropertyPathToken(propertyPath, ref i, out var component)
    //          => returns false
    private static bool NextPathComponent(string propertyPath, ref int index, out PropertyPathComponent component)
    {
        component = new PropertyPathComponent();

        if (index >= propertyPath.Length)
            return false;

        Match arrayElementMatch = arrayElementRegex.Match(propertyPath, index);
        if (arrayElementMatch.Success)
        {
            index += arrayElementMatch.Length + 1; // Skip past next '.'
            component.elementIndex = System.Int32.Parse(arrayElementMatch.Groups[1].Value);
            return true;
        }

        int dot = propertyPath.IndexOf('.', index);
        if (dot == -1)
        {
            component.propertyName = propertyPath[index..];
            index = propertyPath.Length;
        }
        else
        {
            component.propertyName = propertyPath[index..dot];
            index = dot + 1; // Skip past next '.'
        }

        return true;
    }

    private static object GetPathComponentValue(object container, PropertyPathComponent component)
    {
        return component.propertyName == null
            ? ((IList)container)[component.elementIndex]
            : GetMemberValue(container, component.propertyName);
    }

    private static void SetPathComponentValue(object container, PropertyPathComponent component, object value)
    {
        if (component.propertyName == null)
            ((IList)container)[component.elementIndex] = value;
        else
            SetMemberValue(container, component.propertyName, value);
    }

    private static object GetMemberValue(object container, string name)
    {
        if (container == null)
            return null;
        System.Type type = container.GetType();
        MemberInfo[] members = type.GetMember(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        if (members.Length == 0 && name.EndsWith(">k__BackingField"))
            members = type.GetMember(name.Substring(1, name.Length - 17));
        for (int i = 0; i < members.Length; ++i)
        {
            if (members[i] is FieldInfo field)
                return field.GetValue(container);
            else if (members[i] is PropertyInfo property)
                return property.GetValue(container);
        }
        return null;
    }

    private static void SetMemberValue(object container, string name, object value)
    {
        System.Type type = container.GetType();
        MemberInfo[] members = type.GetMember(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        for (int i = 0; i < members.Length; ++i)
        {
            if (members[i] is FieldInfo field)
            {
                field.SetValue(container, value);
                return;
            }
            else if (members[i] is PropertyInfo property)
            {
                property.SetValue(container, value);
                return;
            }
        }
        Debug.Assert(false, $"Failed to set member {container}.{name} via reflection");
    }

    /// <summary>
    /// Gets all children of `SerializedProperty` at 1 level depth.
    /// </summary>
    /// <param name="serializedProperty">Parent `SerializedProperty`.</param>
    /// <returns>Collection of `SerializedProperty` children.</returns>
    public static IEnumerable<SerializedProperty> GetChildren(this SerializedProperty serializedProperty)
    {
        SerializedProperty currentProperty = serializedProperty.Copy();
        SerializedProperty nextSiblingProperty = serializedProperty.Copy();
        {
            _ = nextSiblingProperty.Next(false);
        }

        if (currentProperty.Next(true))
        {
            do
            {
                if (SerializedProperty.EqualContents(currentProperty, nextSiblingProperty))
                    break;

                yield return currentProperty;
            }
            while (currentProperty.Next(false));
        }
    }

    /// <summary>
    /// Gets visible children of `SerializedProperty` at 1 level depth.
    /// </summary>
    /// <param name="serializedProperty">Parent `SerializedProperty`.</param>
    /// <returns>Collection of `SerializedProperty` children.</returns>
    public static IEnumerable<SerializedProperty> GetVisibleChildren(this SerializedProperty serializedProperty)
    {
        SerializedProperty currentProperty = serializedProperty.Copy();
        SerializedProperty nextSiblingProperty = serializedProperty.Copy();
        {
            _ = nextSiblingProperty.NextVisible(false);
        }

        if (currentProperty.NextVisible(true))
        {
            do
            {
                if (SerializedProperty.EqualContents(currentProperty, nextSiblingProperty))
                    break;

                yield return currentProperty;
            }
            while (currentProperty.NextVisible(false));
        }
    }
}