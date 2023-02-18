using Fox.Core;
using Fox.Fio;
using UnityEngine;

namespace Tpp.GameKit
{
    public class CoverPointFileReader
    {
        private const uint TCVP_SIGNATURE = 0x50564354;
        private const float USHORT_QUANTA_PER_DEGREE = (global::System.UInt16.MaxValue + 1) / 360f;
        private const float DEGREE_PER_USHORT_QUANTA = 360f / (global::System.UInt16.MaxValue + 1);

        private enum TCVPFileFormat : ushort
        {
            GZ = 0,
            TPP = 1,
        }

        public GameObject[] Read(FileStreamReader reader)
        {
            Debug.Assert(reader.ReadUInt32() == TCVP_SIGNATURE, "Invalid TCVP file.");

            Debug.Assert((TCVPFileFormat)reader.ReadUInt16() == TCVPFileFormat.TPP, "Invalid TCVP version.");

            ushort entryCount = reader.ReadUInt16();

            reader.Seek(reader.ReadUInt32());

            var coverPointObjects = new GameObject[entryCount];

            for (ushort i = 0; i < entryCount; i++)
            {
                var coverPointObject = new GameObject
                {
                    name = $"TppCoverPoint{i:0000}"
                };
                FoxEntity component = coverPointObject.AddComponent<FoxEntity>();
                var coverPoint = new TppCoverPoint();
                component.Entity = coverPoint;
                coverPoint.InitializeGameObject(coverPointObject);

                coverPointObject.transform.position = reader.ReadPositionF();

                var direction = new Vector3((float)reader.ReadInt16() / global::System.Int16.MaxValue, (float)reader.ReadInt16() / global::System.Int16.MaxValue, (float)reader.ReadInt16() / global::System.Int16.MaxValue);
                Quaternion rotation = Quaternion.identity;
                rotation.SetLookRotation(Fox.Kernel.Math.FoxToUnityVector3(direction));
                coverPointObject.transform.rotation = rotation;

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

                coverPointObjects[i] = coverPointObject;
            }

            return coverPointObjects;
        }
    }
}