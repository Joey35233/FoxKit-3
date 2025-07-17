using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using UnityEngine;

namespace Tpp.GameKit
{
    public class CoverPointFileReader
    {
        private readonly TaskLogger logger = new TaskLogger("ImportTCVP");

        private const uint TCVP_SIGNATURE = 0x50564354;
        private const float USHORT_QUANTA_PER_DEGREE = (global::System.UInt16.MaxValue + 1) / 360f;
        private const float DEGREE_PER_USHORT_QUANTA = 360f / (global::System.UInt16.MaxValue + 1);

        private enum TCVPFileFormat : ushort
        {
            GZ = 0,
            TPP = 1,
        }

        public void Read(FileStreamReader reader)
        {
            Debug.Assert(reader.ReadUInt32() == TCVP_SIGNATURE, "Invalid TCVP file.");

            Debug.Assert((TCVPFileFormat)reader.ReadUInt16() == TCVPFileFormat.TPP, "Invalid TCVP version.");

            ushort entryCount = reader.ReadUInt16();

            reader.Seek(reader.ReadUInt32());

            for (ushort i = 0; i < entryCount; i++)
            {
                TppCoverPoint coverPoint = new GameObject($"TppCoverPoint{i:0000}").AddComponent<TppCoverPoint>();

                var transform = TransformEntity.GetDefault();
                transform.translation = reader.ReadPositionF();

                var direction = new Vector3((float)reader.ReadInt16() / global::System.Int16.MaxValue, (float)reader.ReadInt16() / global::System.Int16.MaxValue, (float)reader.ReadInt16() / global::System.Int16.MaxValue);
                Quaternion rotation = Quaternion.identity;
                rotation.SetLookRotation(Fox.Math.FoxToUnityVector3(direction));
                transform.rotQuat = rotation;

                coverPoint.SetTransform(transform);

                ushort flags = reader.ReadUInt16();
                coverPoint.isLeftOpen = (flags & (1 << 0)) != 0;
                coverPoint.isRightOpen = (flags & (1 << 1)) != 0;
                coverPoint.isUpOpen = (flags & (1 << 2)) != 0;
                // coverPoint.isStandable = (flags & (1 << 3)) != 0; GZ only
                coverPoint.isUnVaultable = (flags & (1 << 4)) != 0;
                coverPoint.isUseVip = (flags & (1 << 5)) != 0;
                coverPoint.isUseSniper = (flags & (1 << 6)) != 0;
                coverPoint.isBreakDisable = (flags & (1 << 7)) != 0;
                coverPoint.isBreakEnable = (flags & (1 << 8)) != 0;
            }
        }
    }
}