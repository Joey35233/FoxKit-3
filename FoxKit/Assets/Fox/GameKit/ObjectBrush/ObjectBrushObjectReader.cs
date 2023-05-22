using Fox.Fio;

namespace Fox.GameKit
{
    public class ObjectBrushObjectReader
    {
        public static ObjectBrushObjectBinary Read(FileStreamReader reader)
        {
            float yPos = reader.ReadSingle();
            var foxRotation = new UnityEngine.Quaternion(reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf());
            UnityEngine.Quaternion rotation = Fox.Kernel.Math.FoxToUnityQuaternion(foxRotation);
            var obj = new ObjectBrushObjectBinary(yPos, reader.ReadInt16(), reader.ReadInt16(), rotation,
                reader.ReadUInt16(),reader.ReadByte(),reader.ReadByte(), reader.ReadUInt32());

            return obj;
        }
    }
}
