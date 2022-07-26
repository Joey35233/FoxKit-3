using System;
using System.Collections.Generic;
using System.Reflection;

namespace Fox.Editor
{
    public static class ObjectSelector
    {
        private static Type ObjectSelectorType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.ObjectSelector");
        private static PropertyInfo ObjectSelectorGetProperty = ObjectSelectorType.GetProperty("get", BindingFlags.Public | BindingFlags.Static);
        private static MethodInfo ObjectSelectorShowMethod = ObjectSelectorType.GetMethod("Show", BindingFlags.NonPublic | BindingFlags.Instance, null,
                new Type[]
                {
                    typeof(UnityEngine.Object),
                    typeof(Type),
                    typeof(UnityEngine.Object),
                    typeof(bool),
                    typeof(List<int>),
                    typeof(Action<UnityEngine.Object>),
                    typeof(Action<UnityEngine.Object>)
                }
                , new ParameterModifier[0]
            );

        private static object ObjectSelectorInstance = ObjectSelectorGetProperty.GetValue(null);

        public static void ShowObjectPicker<T>(T obj, T objectBeingEdited, bool allowSceneObjects, List<int> allowedInstanceIDs = null, Action<UnityEngine.Object> onObjectSelectorClosed = null, Action<UnityEngine.Object> onObjectSelectedUpdated = null) where T : UnityEngine.Object
        {
            Show(obj, typeof(T), objectBeingEdited, allowSceneObjects, allowedInstanceIDs, onObjectSelectorClosed, onObjectSelectedUpdated);
        }

        public static void Show(UnityEngine.Object obj, Type requiredType, UnityEngine.Object objectBeingEdited, bool allowSceneObjects, List<int> allowedInstanceIDs = null, Action<UnityEngine.Object> onObjectSelectorClosed = null, Action<UnityEngine.Object> onObjectSelectedUpdated = null)
        {
            ObjectSelectorShowMethod.Invoke(ObjectSelectorInstance, new object[] { obj, requiredType, objectBeingEdited, allowSceneObjects, allowedInstanceIDs, onObjectSelectorClosed, onObjectSelectedUpdated });
        }
    }
}
