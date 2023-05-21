using Fox.Fio;
using System;
using System.Collections.Generic;
using System.IO;

namespace Fox.Core
{
    public static class BinaryWriterExtensions
    {
        public static void Write(this BinaryWriter writer, UnityEngine.Quaternion vec)
        {
            writer.Write(vec.x);
            writer.Write(vec.y);
            writer.Write(vec.z);
            writer.Write(vec.w);
        }

        public static void Write(this BinaryWriter writer, UnityEngine.Vector4 vec)
        {
            writer.Write(vec.x);
            writer.Write(vec.y);
            writer.Write(vec.z);
            writer.Write(vec.w);
        }

        public static void Write(this BinaryWriter writer, UnityEngine.Vector3 vec)
        {
            writer.Write(vec.x);
            writer.Write(vec.y);
            writer.Write(vec.z);
            writer.Write(0);
        }

        public static void Write(this BinaryWriter writer, UnityEngine.Matrix4x4 val)
        {
            writer.Write(val.GetColumn(0));
            writer.Write(val.GetColumn(1));
            writer.Write(val.GetColumn(2));
            writer.Write(val.GetColumn(3));
        }

        public static void Write(this BinaryWriter writer, FilePtr val)
        {
            writer.WritePathFileNameAndExtCode(val.path.Hash);
        }

        public static void WriteInt8PropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            sbyte uVal = entity.GetProperty<sbyte>(property);
            writer.Write(uVal);
        }

        public static void WriteUInt8PropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            byte uVal = entity.GetProperty<byte>(property);
            writer.Write(uVal);
        }

        public static void WriteInt16PropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            short shortVal = entity.GetProperty<short>(property);
            writer.Write(shortVal);
        }

        public static void WriteUInt16PropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            ushort uShortVal = entity.GetProperty<ushort>(property);
            writer.Write(uShortVal);
        }

        public static void WriteInt32PropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            int intVal = entity.GetProperty<int>(property);
            writer.Write(intVal);
        }

        public static void WriteUInt32PropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            uint uIntVal = entity.GetProperty<uint>(property);
            writer.Write(uIntVal);
        }

        public static void WriteInt64PropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            long longVal = entity.GetProperty<long>(property);
            writer.Write(longVal);
        }

        public static void WriteUInt64PropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            ulong uLongVal = entity.GetProperty<ulong>(property);
            writer.Write(uLongVal);
        }

        public static void WriteFloatPropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            float floatVal = entity.GetProperty<float>(property);
            writer.Write(floatVal);
        }

        public static void WriteDoublePropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            double doubleVal = entity.GetProperty<double>(property);
            writer.Write(doubleVal);
        }

        public static void WriteBoolPropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            bool boolVal = entity.GetProperty<bool>(property);
            writer.Write(boolVal);
        }

        public static Kernel.String WriteStringPropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            Kernel.String strVal = entity.GetProperty<Kernel.String>(property);
            writer.WriteStrCode(strVal.Hash);
            return strVal;
        }

        public static Kernel.String WritePathPropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            Kernel.Path pathVal = entity.GetProperty<Kernel.Path>(property);
            writer.WritePathFileNameAndExtCode(pathVal.Hash);
            return new Kernel.String(pathVal.CString);
        }

        public static void WriteVector3PropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            UnityEngine.Vector3 vec3Val = entity.GetProperty<UnityEngine.Vector3>(property);
            writer.Write(vec3Val.x);
            writer.Write(vec3Val.y);
            writer.Write(vec3Val.z);
            writer.Write(0.0f);
        }

        public static void WriteVector4PropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            UnityEngine.Vector4 vec4Val = entity.GetProperty<UnityEngine.Vector4>(property);
            writer.Write(vec4Val.x);
            writer.Write(vec4Val.y);
            writer.Write(vec4Val.z);
            writer.Write(vec4Val.w);
        }

        public static void WriteQuatPropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            UnityEngine.Quaternion quatVal = entity.GetProperty<UnityEngine.Quaternion>(property);
            writer.Write(quatVal.x);
            writer.Write(quatVal.y);
            writer.Write(quatVal.z);
            writer.Write(quatVal.w);
        }

        public static void WriteColorPropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            UnityEngine.Color colorVal = entity.GetProperty<UnityEngine.Color>(property);
            writer.Write(colorVal.r);
            writer.Write(colorVal.g);
            writer.Write(colorVal.b);
            writer.Write(colorVal.a);
        }

        public static void WriteMatrix3PropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            throw new NotImplementedException();
        }

        public static void WriteMatrix4PropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {

            UnityEngine.Matrix4x4 val = entity.GetProperty<UnityEngine.Matrix4x4>(property);
            writer.Write(val.GetColumn(0));
            writer.Write(val.GetColumn(1));
            writer.Write(val.GetColumn(2));
            writer.Write(val.GetColumn(3));
        }

        public static Kernel.String WriteFilePtrPropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            FilePtr filePtrVal = entity.GetProperty<FilePtr>(property);
            writer.WritePathFileNameAndExtCode(filePtrVal.path.Hash);
            return new Kernel.String(filePtrVal.path.CString);
        }

        public static void WriteEntityPtrPropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property, IDictionary<Entity, ulong> addresses)
        {
            IEntityPtr val = entity.GetProperty<IEntityPtr>(property);
            ulong address = 0;
            if (val.Get() != null)
            {
                address = addresses[val.Get()];
            }

            writer.Write(address);
        }

        public static void WriteEntityPtr(this BinaryWriter writer, IEntityPtr ptr, IDictionary<Entity, ulong> addresses)
        {
            ulong address = 0;
            if (ptr.Get() != null)
            {
                address = addresses[ptr.Get()];
            }

            writer.Write(address);
        }

        public static void WriteEntityHandlePropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property, IDictionary<Entity, ulong> addresses)
        {
            EntityHandle val = entity.GetProperty<EntityHandle>(property);
            ulong address = 0;
            if (val.Entity != null)
            {
                address = addresses[val.Entity];
            }

            writer.Write(address);
        }

        public static void WriteEntityHandle(this BinaryWriter writer, EntityHandle val, IDictionary<Entity, ulong> addresses)
        {
            ulong address = 0;
            if (val.Entity != null)
            {
                address = addresses[val.Entity];
            }

            writer.Write(address);
        }

        public static List<Kernel.String> WriteEntityLinkPropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property, IDictionary<Entity, ulong> addresses)
        {
            EntityLink entityLinkVal = entity.GetProperty<EntityLink>(property);
            writer.WritePathFileNameAndExtCode(entityLinkVal.packagePath.Hash);
            writer.WritePathFileNameAndExtCode(entityLinkVal.archivePath.Hash);
            writer.WriteStrCode(entityLinkVal.nameInArchive.Hash);

            ulong address = 0;
            if (entityLinkVal.handle.Entity != null)
            {
                address = addresses[entityLinkVal.handle.Entity];
            }

            writer.Write(address);

            var strings = new List<Kernel.String>();
            strings.Add(new Kernel.String(entityLinkVal.packagePath.CString));
            strings.Add(new Kernel.String(entityLinkVal.archivePath.CString));
            strings.Add(new Kernel.String(entityLinkVal.nameInArchive.CString));
            return strings;
        }

        public static void WriteEntityLink(this BinaryWriter writer, EntityLink entityLinkVal, IDictionary<Entity, ulong> addresses)
        {
            writer.WritePathFileNameAndExtCode(entityLinkVal.packagePath.Hash);
            writer.WritePathFileNameAndExtCode(entityLinkVal.archivePath.Hash);
            writer.WriteStrCode(entityLinkVal.nameInArchive.Hash);

            ulong address = 0;
            if (entityLinkVal.handle.Entity != null)
            {
                address = addresses[entityLinkVal.handle.Entity];
            }

            writer.Write(address);
        }
    }
}
