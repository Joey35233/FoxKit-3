using Fox.Core;
using FoxKit.Utils;
using System;
using System.IO;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Path = Fox.Core.Path;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;
using Vector4 = UnityEngine.Vector4;

namespace Fox.FoxCore.Serialization
{
    public class DataSetFile2PropertyReader
    {
        private Func<ulong, string> unhashString;
        private RequestFilePtr requestFilePtr;
        private RequestEntityPtr requestEntityPtr;
        private RequestEntityHandle requestEntityHandle;
        private RequestEntityLink requestEntityLink;

        /// <summary>
        /// Sets the value of a property.
        /// </summary>
        /// <param name="propertyName">Name of the property whose value to set.</param>
        /// <param name="value">The value to assign to the property.</param>
        public delegate void SetProperty(string propertyName, Value value);

        public delegate Type GetPtrType(string propertyName);

        /// <summary>
        /// Sets the value of an array property at a given index.
        /// </summary>
        /// <param name="propertyName">Name of the property whose value to set.</param>
        /// <param name="index">The array index.</param>
        /// <param name="value">The value to assign to the property.</param>
        public delegate void SetPropertyElementByIndex(string propertyName, ushort index, Value value);

        /// <summary>
        /// Sets the value of a StringMap property at a given key.
        /// </summary>
        /// <param name="propertyName">Name of the property whose value to set.</param>
        /// <param name="key">The StringMap key.</param>
        /// <param name="value">The value to assign to the property.</param>
        public delegate void SetPropertyElementByKey(string propertyName, string key, Value value);

        public delegate void RequestFilePtr(ulong path, FilePtr<Core.File> ptr);
        public delegate void RequestEntityPtr(ulong address, IEntityPtr ptr);
        public delegate void RequestEntityHandle(ulong address, EntityHandle ptr);

        /// <summary>
        /// Callback to invoke when a property's name has been unhashed.
        /// </summary>
        /// <param name="type">Type of the property.</param>
        /// <param name="name">Unhashed name of the property.</param>
        /// <param name="arraySize">ArraySize of the property. Must be 1 unless a StaticArray.</param>
        /// <param name="container">Container type of the property.</param>
        public delegate void OnPropertyNameUnhashedCallback(PropertyInfo.PropertyType type, string name, ushort arraySize, PropertyInfo.ContainerType container);

        public delegate void RequestEntityLink(ulong address, ulong packagePath, ulong archivePath, ulong nameInArchive, EntityLink entityLink);

        public DataSetFile2PropertyReader(
            Func<ulong, string> unhashString,
            RequestEntityPtr requestEntityPtr,
            RequestEntityHandle requestEntityHandle,
            RequestFilePtr requestFilePtr,
            RequestEntityLink requestEntityLink)
        {
            this.unhashString = unhashString;
            this.requestFilePtr = requestFilePtr;
            this.requestEntityPtr = requestEntityPtr;
            this.requestEntityHandle = requestEntityHandle;
            this.requestEntityLink = requestEntityLink;
        }

        public void Read(
            BinaryReader reader,
            OnPropertyNameUnhashedCallback onPropertyNameUnhashed,
            GetPtrType getPtrType,
            SetProperty setProperty,
            SetPropertyElementByIndex setPropertyElementByIndex,
            SetPropertyElementByKey setPropertyElementByKey)
        {
            Debug.Assert(reader != null);
            Debug.Assert(getPtrType != null);
            Debug.Assert(setProperty != null);
            Debug.Assert(setPropertyElementByIndex != null);
            Debug.Assert(setPropertyElementByKey != null);

            var headerBytes = reader.ReadBytes(32);
            var nameHash = BitConverter.ToUInt64(headerBytes, 0);
            var dataType = (PropertyInfo.PropertyType)headerBytes[8];
            var containerType = (PropertyInfo.ContainerType)headerBytes[9];
            var arraySize = BitConverter.ToUInt16(headerBytes, 10);

            var name = this.unhashString(nameHash);
            onPropertyNameUnhashed(dataType, name, containerType == PropertyInfo.ContainerType.StaticArray ? arraySize : (ushort)1, containerType);

            var ptrType = getPtrType(name);

            if (containerType == PropertyInfo.ContainerType.StaticArray && arraySize == 1)
            {
                ReadProperty(reader, setProperty, name, dataType, ptrType);
            }
            else if (containerType == PropertyInfo.ContainerType.StringMap)
            {
                ReadStringMap(reader, setPropertyElementByKey, name, dataType, ptrType, arraySize);
            }
            else
            {
                ReadArray(reader, setPropertyElementByIndex, name, dataType, ptrType, arraySize);
            }

            reader.BaseStream.AlignRead(16);
        }

        private void ReadArray(BinaryReader reader, SetPropertyElementByIndex setPropertyElementByIndex, string name, PropertyInfo.PropertyType dataType, Type ptrType, ushort arraySize)
        {
            for (ushort i = 0; i < arraySize; i++)
            {
                // Entity references can't be resolved until the referenced Entity is loaded.
                // Register a callback to assign the property value once the Entity has been loaded.
                SetProperty setProperty = (name, val) => setPropertyElementByIndex(name, i, val);
                if (dataType == PropertyInfo.PropertyType.EntityPtr)
                {
                    ReadEntityPtr(reader, setProperty, ptrType, name);
                }
                else if (dataType == PropertyInfo.PropertyType.EntityHandle)
                {
                    ReadEntityHandle(reader, setProperty, name);
                }
                else if (dataType == PropertyInfo.PropertyType.FilePtr)
                {
                    ReadFilePtr(reader, setProperty, name);
                }
                else if (dataType == PropertyInfo.PropertyType.EntityLink)
                {
                    ReadEntityLink(reader, setProperty, name);
                }
                else
                {
                    var value = ReadPropertyValue(reader, dataType);
                    setPropertyElementByIndex(name, i, value);
                }
            }
        }

        private void ReadStringMap(BinaryReader reader, SetPropertyElementByKey setPropertyElementByKey, string name, PropertyInfo.PropertyType dataType, Type ptrType, ushort arraySize)
        {
            for (var i = 0; i < arraySize; i++)
            {
                var keyHash = reader.ReadUInt64();
                var key = unhashString(keyHash);

                // Entity references can't be resolved until the referenced Entity is loaded.
                // Register a callback to assign the property value once the Entity has been loaded.
                SetProperty setProperty = (name, val) => setPropertyElementByKey(name, key, val);
                if (dataType == PropertyInfo.PropertyType.EntityPtr)
                {
                    ReadEntityPtr(reader, setProperty, ptrType, name);
                }
                else if (dataType == PropertyInfo.PropertyType.EntityHandle)
                {
                    ReadEntityHandle(reader, setProperty, name);
                }
                else if (dataType == PropertyInfo.PropertyType.FilePtr)
                {
                    ReadFilePtr(reader, setProperty, name);
                }
                else if (dataType == PropertyInfo.PropertyType.EntityLink)
                {
                    ReadEntityLink(reader, setProperty, name);
                }
                else
                {
                    var value = ReadPropertyValue(reader, dataType);
                    setPropertyElementByKey(name, key, value);
                }

                reader.BaseStream.AlignRead(16);
            }
        }

        private void ReadProperty(BinaryReader reader, SetProperty setProperty, string name, PropertyInfo.PropertyType dataType, Type ptrType)
        {
            // Entity references can't be resolved until the referenced Entity is loaded.
            // Register a callback to assign the property value once the Entity has been loaded.
            if (dataType == PropertyInfo.PropertyType.EntityPtr)
            {
                ReadEntityPtr(reader, setProperty, ptrType, name);
            }
            else if (dataType == PropertyInfo.PropertyType.EntityHandle)
            {
                ReadEntityHandle(reader, setProperty, name);
            }
            else if (dataType == PropertyInfo.PropertyType.FilePtr)
            {
                ReadFilePtr(reader, setProperty, name);
            }
            else if (dataType == PropertyInfo.PropertyType.EntityLink)
            {
                ReadEntityLink(reader, setProperty, name);
            }
            else
            {
                var value = ReadPropertyValue(reader, dataType);
                setProperty(name, value);
            }
        }

        private void ReadEntityLink(BinaryReader reader, SetProperty setProperty, string name)
        {
            var bytes = reader.ReadBytes(32);
            var packagePathHash = BitConverter.ToUInt64(bytes, 0);
            var archivePathHash = BitConverter.ToUInt64(bytes, 8);
            var nameInArchiveHash = BitConverter.ToUInt64(bytes, 16);
            var address = BitConverter.ToUInt64(bytes, 24);

            var entityLink = EntityLink.Empty();
            requestEntityLink((uint)address, packagePathHash, archivePathHash, nameInArchiveHash, entityLink);

            setProperty(name, new Value(entityLink));
        }

        private void ReadFilePtr(BinaryReader reader, SetProperty setProperty, string name)
        {
            var address = reader.ReadUInt64();
            var ptr = FilePtr<Core.File>.Empty();
            requestFilePtr(address, ptr);

            setProperty(name, new Value(ptr));
        }

        private void ReadEntityHandle(BinaryReader reader, SetProperty setProperty, string name)
        {
            var address = reader.ReadUInt64();
            var ptr = EntityHandle.Empty();
            requestEntityHandle(address, ptr);

            setProperty(name, new Value(ptr));
        }

        private void ReadEntityPtr(BinaryReader reader, SetProperty setProperty, Type ptrType, string name)
        {
            var address = reader.ReadUInt64();
            IEntityPtr ptr = Activator.CreateInstance(typeof(EntityPtr<>).MakeGenericType(ptrType)) as IEntityPtr;
            requestEntityPtr(address, ptr);

            setProperty(name, new Value(ptr));
        }

        private Value ReadPropertyValue(BinaryReader reader, PropertyInfo.PropertyType type)
        {
            switch (type)
            {
                case PropertyInfo.PropertyType.Int8:
                    return new Value(reader.ReadSByte());
                case PropertyInfo.PropertyType.UInt8:
                    return new Value(reader.ReadByte());
                case PropertyInfo.PropertyType.Int16:
                    return new Value(reader.ReadInt16());
                case PropertyInfo.PropertyType.UInt16:
                    return new Value(reader.ReadUInt16());
                case PropertyInfo.PropertyType.Int32:
                    return new Value(reader.ReadInt32());
                case PropertyInfo.PropertyType.UInt32:
                    return new Value(reader.ReadUInt32());
                case PropertyInfo.PropertyType.Int64:
                    return new Value(reader.ReadInt64());
                case PropertyInfo.PropertyType.UInt64:
                    return new Value(reader.ReadUInt64());
                case PropertyInfo.PropertyType.Float:
                    return new Value(reader.ReadSingle());
                case PropertyInfo.PropertyType.Double:
                    return new Value(reader.ReadDouble());
                case PropertyInfo.PropertyType.Bool:
                    return new Value(reader.ReadBoolean());
                case PropertyInfo.PropertyType.String:
                    return new Value(unhashString(reader.ReadUInt64()));
                case PropertyInfo.PropertyType.Path:
                    return new Value(Path.FromFilePath(unhashString(reader.ReadUInt64())));
                case PropertyInfo.PropertyType.Vector3:
                    return new Value(ReadVector3(reader));
                case PropertyInfo.PropertyType.Vector4:
                    return new Value(ReadVector4(reader));
                case PropertyInfo.PropertyType.Quat:
                    return new Value(ReadQuaternion(reader));
                case PropertyInfo.PropertyType.Matrix4:
                    return new Value(ReadMatrix4(reader));
                case PropertyInfo.PropertyType.Color:
                    return new Value(ReadColor(reader));
                case PropertyInfo.PropertyType.Matrix3:
                case PropertyInfo.PropertyType.PropertyInfo:
                case PropertyInfo.PropertyType.WideVector3:
                    throw new NotImplementedException();
                default:
                    Debug.LogError($"Unexpected property type: {type}");
                    throw new InvalidOperationException();
            }
        }

        private static Vector3 ReadVector3(BinaryReader reader)
        {
            //Translaiton, so inverting X
            var bytes = reader.ReadBytes(4 * 4);
            var x = BitConverter.ToSingle(bytes, 0);
            var y = BitConverter.ToSingle(bytes, 4);
            var z = BitConverter.ToSingle(bytes, 8);

            return new Vector3(-x, y, z);
        }

        private static Vector4 ReadVector4(BinaryReader reader)
        {
            //Translaiton, so inverting X
            var bytes = reader.ReadBytes(4 * 4);
            var x = BitConverter.ToSingle(bytes, 0);
            var y = BitConverter.ToSingle(bytes, 4);
            var z = BitConverter.ToSingle(bytes, 8);
            var w = BitConverter.ToSingle(bytes, 12);

            return new Vector4(-x, y, z, w);
        }

        private static Quaternion ReadQuaternion(BinaryReader reader)
        {
            //Quaternion conversion from FoxKit-1's FoxUtils.cs - inverting Euler X
            var bytes = reader.ReadBytes(4 * 4);
            var x = BitConverter.ToSingle(bytes, 0);
            var y = BitConverter.ToSingle(bytes, 4);
            var z = BitConverter.ToSingle(bytes, 8);
            var w = BitConverter.ToSingle(bytes, 12);

            var angle = 0.0f;
            var axis = Vector3.zero;
            var unityQuaternion = new Quaternion(x, y, z, w);
            unityQuaternion.ToAngleAxis(out angle, out axis);
            axis.x = -axis.x;
            var newQuat = Quaternion.AngleAxis(-angle, axis);

            return new Quaternion(newQuat.x, newQuat.y, newQuat.z, newQuat.w);
        }

        private static Color ReadColor(BinaryReader reader)
        {
            var bytes = reader.ReadBytes(4 * 4);
            var r = BitConverter.ToSingle(bytes, 0);
            var g = BitConverter.ToSingle(bytes, 4);
            var b = BitConverter.ToSingle(bytes, 8);
            var a = BitConverter.ToSingle(bytes, 12);

            return new UnityEngine.Color(r, g, b, a);
        }

        private static UnityEngine.Matrix4x4 ReadMatrix4(BinaryReader reader)
        {
            var bytes = reader.ReadBytes(4 * 4 * 4);

            var m11 = BitConverter.ToSingle(bytes, 0);
            var m12 = BitConverter.ToSingle(bytes, 4);
            var m13 = BitConverter.ToSingle(bytes, 8);
            var m14 = BitConverter.ToSingle(bytes, 12);

            var m21 = BitConverter.ToSingle(bytes, 16);
            var m22 = BitConverter.ToSingle(bytes, 20);
            var m23 = BitConverter.ToSingle(bytes, 24);
            var m24 = BitConverter.ToSingle(bytes, 28);

            var m31 = BitConverter.ToSingle(bytes, 32);
            var m32 = BitConverter.ToSingle(bytes, 36);
            var m33 = BitConverter.ToSingle(bytes, 40);
            var m34 = BitConverter.ToSingle(bytes, 44);

            var m41 = BitConverter.ToSingle(bytes, 48);
            var m42 = BitConverter.ToSingle(bytes, 52);
            var m43 = BitConverter.ToSingle(bytes, 56);
            var m44 = BitConverter.ToSingle(bytes, 60);

            var column0 = new Vector4(m11, m12, m13, m14);
            var column1 = new Vector4(m21, m22, m23, m24);
            var column2 = new Vector4(m31, m32, m33, m34);
            var column3 = new Vector4(m41, m42, m43, m44);

            var foxMatrix = new Matrix4x4();
            foxMatrix.SetColumn(0, column0);
            foxMatrix.SetColumn(1, column1);
            foxMatrix.SetColumn(2, column2);
            foxMatrix.SetColumn(3, column3);

            //Convert translation from foxMatrix to unityMatrix - just invert X:
            var foxMatrixTransform = foxMatrix.GetColumn(3);
            var unityMatrixTransform = new Vector3(-foxMatrixTransform.x, foxMatrixTransform.y, foxMatrixTransform.z);

            //Convert rotation from foxMatrix to unityMatrix:
			// TODO: further testing when this can be visualized: whether Unity's Matrix4x4.rotation can properly get Fox quats from Fox Matrix4.
			// Testing with FoxKit-1 was kind of confusing, but StaticModelArray.cs had its already working pre-built in Matrix4 > Quaternion conversion
			// which used Quaternion.LookRotation on columns 0 and 1 as Vector3s to get properly working Unity rotation Quaternions.
            var angle = 0.0f;
            var axis = Vector3.zero;
            var foxMatrixQuaternion = foxMatrix.rotation;
            foxMatrixQuaternion.ToAngleAxis(out angle, out axis);
            axis.x = -axis.x;
            var unityMatrixQuaternion = Quaternion.AngleAxis(-angle, axis);

            //Get scale from foxMatrix to unityMatrix:
			// TODO: further testing when this can be visualized: whether X actually has to be inverted.
			// Testing this with FoxKit-1 was kind of confusing, but StaticModelArray.cs had to invert X on its own,
			// despite any edits to this conversion in FoxUtils.cs.
            var unityMatrixScale = new Vector3(-foxMatrix.lossyScale.x, foxMatrix.lossyScale.y, foxMatrix.lossyScale.z);

            var unityMatrix = new Matrix4x4();
            unityMatrix.SetTRS(unityMatrixTransform, unityMatrixQuaternion, unityMatrixScale);

            return unityMatrix;
        }
    }
}