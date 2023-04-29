using Fox.Fio;
using System;
using System.IO;
using System.Text;

namespace Fox.Core
{
    public class DataSetFile2EntityWriter
    {
        private const short HeaderSize = 64;
        private const uint MagicNumber = 0x746e65;

        public void Write(Entity entity, ulong address, ulong id, Stream output)
        {
            var writer = new BinaryWriter(output, Encoding.Default, true);
            long headerPosition = output.Position;
            output.Position += HeaderSize;

            EntityInfo info = entity.GetClassEntityInfo();
            foreach (System.Collections.Generic.KeyValuePair<Kernel.String, PropertyInfo> staticProperty in info.StaticProperties)
            {
                WriteProperty(entity, staticProperty.Value, writer);
            }

            uint staticDataSize = (uint)(output.Position - headerPosition);
            /**
             * TODO
             * foreach (var dynamicProperty in entity.DynamicProperties)
            {
                dynamicProperty.Write(output);
            }*/

            long endPosition = output.Position;
            uint dataSize = (uint)(endPosition - headerPosition);
            output.Position = headerPosition;

            writer.Write(HeaderSize);
            writer.Write(info.Id);
            writer.WriteZeros(2); // padding1
            writer.Write(MagicNumber);
            writer.Write(address);
            writer.Write(id);
            writer.Write(info.Version);

            writer.Write(Kernel.HashingBitConverter.StrCodeToUInt64(info.Name.Hash));
            writer.Write(Convert.ToUInt16(info.StaticProperties.Count));
            writer.Write(Convert.ToUInt16(0)); // TODO DynamicProperties count
            writer.Write((int)HeaderSize);
            writer.Write(staticDataSize);
            writer.Write(dataSize);
            output.AlignWrite(16, 0x00);
            output.Position = endPosition;
        }

        private void WriteProperty(Entity entity, PropertyInfo property, BinaryWriter writer)
        {
            Stream output = writer.BaseStream;
            long headerPosition = output.Position;
            output.Position += 32;

            // TODO Handle arrays, stringmaps
            WriteProperty(entity, property, writer);

            output.AlignWrite(16, 0x00);
            long endPosition = output.Position;
            ushort size = (ushort)(endPosition - headerPosition);
            output.Position = headerPosition;

            writer.Write(Kernel.HashingBitConverter.StrCodeToUInt64(property.Name.Hash));
            writer.Write((byte)property.Type);
            writer.Write((byte)property.Container);
            writer.Write((ushort)property.ArraySize);
            writer.Write((ushort)32);
            writer.Write(size);
            writer.WriteZeros(16);
            output.Position = endPosition;
        }

        public void WritePropertyValue(Entity entity, PropertyInfo property, BinaryWriter writer)
        {
            switch (property.Type)
            {
                case PropertyInfo.PropertyType.UInt8:
                    byte uVal = entity.GetProperty<byte>(property);
                    writer.Write(uVal);
                    break;
                case PropertyInfo.PropertyType.Int16:
                    short shortVal = entity.GetProperty<short>(property);
                    writer.Write(shortVal);
                    break;
                case PropertyInfo.PropertyType.UInt16:
                    ushort uShortVal = entity.GetProperty<ushort>(property);
                    writer.Write(uShortVal);
                    break;
                case PropertyInfo.PropertyType.Int32:
                    int intVal = entity.GetProperty<int>(property);
                    writer.Write(intVal);
                    break;
                case PropertyInfo.PropertyType.UInt32:
                    uint uIntVal = entity.GetProperty<uint>(property);
                    writer.Write(uIntVal);
                    break;
                case PropertyInfo.PropertyType.Int64:
                    long longVal = entity.GetProperty<long>(property);
                    writer.Write(longVal);
                    break;
                case PropertyInfo.PropertyType.UInt64:
                    ulong uLongVal = entity.GetProperty<ulong>(property);
                    writer.Write(uLongVal);
                    break;
                case PropertyInfo.PropertyType.Float:
                    float floatVal = entity.GetProperty<float>(property);
                    writer.Write(floatVal);
                    break;
                case PropertyInfo.PropertyType.Double:
                    double doubleVal = entity.GetProperty<double>(property);
                    writer.Write(doubleVal);
                    break;
                case PropertyInfo.PropertyType.Bool:
                    bool boolVal = entity.GetProperty<bool>(property);
                    writer.Write(boolVal);
                    break;
                case PropertyInfo.PropertyType.String:
                    Kernel.String strVal = entity.GetProperty<Kernel.String>(property);
                    writer.WriteStrCode(strVal.Hash);
                    break;
                case PropertyInfo.PropertyType.Path:
                    Kernel.Path pathVal = entity.GetProperty<Kernel.Path>(property);
                    writer.WritePathFileNameAndExtCode(pathVal.Hash);
                    break;
                case PropertyInfo.PropertyType.EntityPtr:
                    // TODO
                    break;
                case PropertyInfo.PropertyType.Vector3:
                    UnityEngine.Vector3 vec3Val = entity.GetProperty<UnityEngine.Vector3>(property);
                    writer.Write(vec3Val.x);
                    writer.Write(vec3Val.y);
                    writer.Write(vec3Val.z);
                    writer.Write(0.0f);
                    break;
                case PropertyInfo.PropertyType.Vector4:
                    UnityEngine.Vector4 vec4Val = entity.GetProperty<UnityEngine.Vector3>(property);
                    writer.Write(vec4Val.x);
                    writer.Write(vec4Val.y);
                    writer.Write(vec4Val.z);
                    writer.Write(vec4Val.w);
                    break;
                case PropertyInfo.PropertyType.Quat:
                    UnityEngine.Quaternion quatVal = entity.GetProperty<UnityEngine.Quaternion>(property);
                    writer.Write(quatVal.x);
                    writer.Write(quatVal.y);
                    writer.Write(quatVal.z);
                    writer.Write(quatVal.w);
                    break;
                case PropertyInfo.PropertyType.Matrix3:
                    // TODO
                    break;
                case PropertyInfo.PropertyType.Matrix4:
                    // TODO
                    break;
                case PropertyInfo.PropertyType.Color:
                    UnityEngine.Color colorVal = entity.GetProperty<UnityEngine.Color>(property);
                    writer.Write(colorVal.r);
                    writer.Write(colorVal.g);
                    writer.Write(colorVal.b);
                    writer.Write(colorVal.a);
                    break;
                case PropertyInfo.PropertyType.FilePtr:
                    FilePtr filePtrVal = entity.GetProperty<FilePtr>(property);
                    writer.WritePathFileNameAndExtCode(filePtrVal.path.Hash);
                    break;
                case PropertyInfo.PropertyType.EntityHandle:
                    // TODO
                    break;
                case PropertyInfo.PropertyType.EntityLink:
                    EntityLink entityLinkVal = entity.GetProperty<EntityLink>(property);
                    writer.WritePathFileNameAndExtCode(entityLinkVal.packagePath.Hash);
                    writer.WritePathFileNameAndExtCode(entityLinkVal.archivePath.Hash);
                    writer.WriteStrCode(entityLinkVal.nameInArchive.Hash);
                    // TODO Write EntityHandle
                    break;
            }
        }
    }
}
