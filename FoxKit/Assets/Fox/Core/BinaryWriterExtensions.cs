using Fox.Fio;
using System;
using System.IO;

namespace Fox.Core
{
    public static class BinaryWriterExtensions
    {
        public static void Write(this BinaryWriter writer, UnityEngine.Vector4 vec)
        {
            writer.Write(vec.x);
            writer.Write(vec.y);
            writer.Write(vec.z);
            writer.Write(vec.w);
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

        public static void WriteStringPropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            Kernel.String strVal = entity.GetProperty<Kernel.String>(property);
            writer.WriteStrCode(strVal.Hash);
        }

        public static void WritePathPropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            Kernel.Path pathVal = entity.GetProperty<Kernel.Path>(property);
            writer.WritePathFileNameAndExtCode(pathVal.Hash);
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

        public static void WriteFilePtrPropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            FilePtr filePtrVal = entity.GetProperty<FilePtr>(property);
            writer.WritePathFileNameAndExtCode(filePtrVal.path.Hash);
        }

        public static void WriteEntityPtrPropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            // TODO
        }

        public static void WriteEntityHandlePropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            // TODO
        }

        public static void WriteEntityLinkPropertyValue(this BinaryWriter writer, Entity entity, PropertyInfo property)
        {
            EntityLink entityLinkVal = entity.GetProperty<EntityLink>(property);
            writer.WritePathFileNameAndExtCode(entityLinkVal.packagePath.Hash);
            writer.WritePathFileNameAndExtCode(entityLinkVal.archivePath.Hash);
            writer.WriteStrCode(entityLinkVal.nameInArchive.Hash);
            // TODO Write EntityHandle
        }
    }
}
