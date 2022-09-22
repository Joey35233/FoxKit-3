using Fox.Core;
using Fox.Fio;
using System.IO;
using UnityEngine;

namespace Tpp.GameKit
{
    public class CoverPointFileReader
    {
        private const uint TCVP_SIGNATURE = 0x50564354;
        private const float USHORT_QUANTA_PER_DEGREE = (ushort.MaxValue + 1) / 360f;
        private const float DEGREE_PER_USHORT_QUANTA = 360f / (ushort.MaxValue + 1);

        enum TCVPFileFormat : ushort
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

            GameObject[] coverPointObjects = new GameObject[entryCount];

            for (ushort i = 0; i < entryCount; i++)
            {
                GameObject coverPointObject = new GameObject();
                coverPointObject.name = $"TppCoverPoint{i.ToString("0000")}";
                FoxEntity component = coverPointObject.AddComponent<FoxEntity>();
                TppCoverPoint coverPoint = new TppCoverPoint();
                component.Entity = coverPoint;

                coverPointObject.AddComponent<TppCoverPointGizmo>();

                coverPointObject.transform.position = reader.ReadPositionF();

                Vector3 direction = new Vector3((float)reader.ReadInt16() / short.MaxValue, (float)reader.ReadInt16() / short.MaxValue, (float)reader.ReadInt16() / short.MaxValue);
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