using Fox.Fio;

namespace Fox.GameKit
{
    public class ObjectBrushObjectReader
    {
        public static ObjectBrushObjectBinary Read(FileStreamReader reader)
        {
            var obj = new ObjectBrushObjectBinary(reader.ReadSingle(), reader.ReadInt16(), reader.ReadInt16(),
                Fox.Kernel.Math.FoxToUnityQuaternion(
                    new UnityEngine.Quaternion(reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf())),
                reader.ReadUInt16(),reader.ReadByte(),reader.ReadByte(), reader.ReadUInt32());

            return obj;
        }
    }
}
