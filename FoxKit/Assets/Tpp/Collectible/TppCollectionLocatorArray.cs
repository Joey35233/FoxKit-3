

using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;
using CsSystem = System;

namespace Tpp.Collectible
{
    public partial class TppCollectionLocatorArray
    {
        public enum TppCollection_Type : byte
        {
            TYPE_DIAMOND_SMALL = 1,
            TYPE_DIAMOND_LARGE = 2,
            TYPE_CASSETTE = 3,
            TYPE_DEVELOPMENT_FILE = 4,
            TYPE_EMBLEM = 5,
            TYPE_SHIPPING_LABEL = 6,
            TYPE_MATERIAL_CM_0 = 7,
            TYPE_MATERIAL_CM_1 = 8,
            TYPE_MATERIAL_CM_2 = 9,
            TYPE_MATERIAL_CM_3 = 10,
            TYPE_MATERIAL_CM_4 = 11,
            TYPE_MATERIAL_CM_5 = 12,
            TYPE_MATERIAL_CM_6 = 13,
            TYPE_MATERIAL_CM_7 = 14,
            TYPE_MATERIAL_MM_0 = 15,
            TYPE_MATERIAL_MM_1 = 16,
            TYPE_MATERIAL_MM_2 = 17,
            TYPE_MATERIAL_MM_3 = 18,
            TYPE_MATERIAL_MM_4 = 19,
            TYPE_MATERIAL_MM_5 = 20,
            TYPE_MATERIAL_MM_6 = 21,
            TYPE_MATERIAL_MM_7 = 22,
            TYPE_MATERIAL_PM_0 = 23,
            TYPE_MATERIAL_PM_1 = 24,
            TYPE_MATERIAL_PM_2 = 25,
            TYPE_MATERIAL_PM_3 = 26,
            TYPE_MATERIAL_PM_4 = 27,
            TYPE_MATERIAL_PM_5 = 28,
            TYPE_MATERIAL_PM_6 = 29,
            TYPE_MATERIAL_PM_7 = 30,
            TYPE_MATERIAL_FR_0 = 31,
            TYPE_MATERIAL_FR_1 = 32,
            TYPE_MATERIAL_FR_2 = 33,
            TYPE_MATERIAL_FR_3 = 34,
            TYPE_MATERIAL_FR_4 = 35,
            TYPE_MATERIAL_FR_5 = 36,
            TYPE_MATERIAL_FR_6 = 37,
            TYPE_MATERIAL_FR_7 = 38,
            TYPE_MATERIAL_BR_0 = 39,
            TYPE_MATERIAL_BR_1 = 40,
            TYPE_MATERIAL_BR_2 = 41,
            TYPE_MATERIAL_BR_3 = 42,
            TYPE_MATERIAL_BR_4 = 43,
            TYPE_MATERIAL_BR_5 = 44,
            TYPE_MATERIAL_BR_6 = 45,
            TYPE_MATERIAL_BR_7 = 46,
            TYPE_POSTER_SOL_AFGN = 47,
            TYPE_POSTER_SOL_MAFR = 48,
            TYPE_POSTER_SOL_ZRS = 49,
            TYPE_POSTER_GRAVURE_V = 50,
            TYPE_POSTER_GRAVURE_H = 51,
            TYPE_POSTER_MOE_V = 52,
            TYPE_POSTER_MOE_H = 53,
            TYPE_PICTURE_PAZ = 54,

            TYPE_HERB_G_CRESCENT = 100,
            TYPE_HERB_A_PEACH = 101,
            TYPE_HERB_DIGITALIS_P = 102,
            TYPE_HERB_DIGITALIS_R = 103,
            TYPE_HERB_B_CARROT = 104,
            TYPE_HERB_WORM_WOOD = 105,
            TYPE_HERB_TARRAGON = 106,
            TYPE_HERB_HAOMA = 107,
            TYPE_HERB_0 = 108,
            TYPE_HERB_1 = 109,

            TYPE_STATION = 130
        }
        private Quaternion DecompressQuaternion( uint retQuat )
        {
            float x = (float)((retQuat >> 10 & 0x3ff) * 0.0009775171);
            float y = (float)((retQuat & 0x3ff) * 0.0009775171);
            float z = (float)(1.0 - x) - y;
            if ((retQuat >> 0x1d & 1) != 0)
            {
                x = -x;
            }
            if (((byte)(retQuat >> 0x1d) & 2) != 0)
            {
                y = -y;
            }
            if ((retQuat >> 0x1d & 4) != 0)
            {
                z = -z;
            }
            float theta = (float)((retQuat >> 0x14 & 0x1ff) * 0.001956947 * 3.141593 * 0.5);
            float sqrted = (float)1.0 / Mathf.Sqrt(y * y + x * x + z * z);
            float sinfTheta = Mathf.Sin(theta);
            theta = Mathf.Cos(theta);
            return new Quaternion(sqrted * x * sinfTheta, sqrted * y * sinfTheta, sqrted * z * sinfTheta, theta).normalized;
        }
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            for (int i = 0; i < positions.Count; i++)
                positions[i] = Fox.Math.FoxToUnityVector3(positions[i]);

            //rlc TODO rotations editing
            CsSystem.Collections.Generic.List<Quaternion> rotationsQuat = new(rotations.Count);
            for (int i = 0; i < rotations.Count; i++)
                rotationsQuat.Insert(i, Fox.Math.FoxToUnityQuaternion(DecompressQuaternion(rotations[i])));

            for (int i = 0; i < positions.Count; i++)
            {
                GameObject colLocator = new($"TppCollectibleLocator{i:D4}");

                colLocator.transform.position = positions[i];

                colLocator.transform.rotation = rotationsQuat[i];

                TppCollection_Type typeId = (TppCollection_Type)(infos[i] >> 24);
                string typeName = CsSystem.Enum.GetName(typeof(TppCollection_Type), typeId);
                string locatorName = (infos[i] & 0xFFFFFF).ToString("x");
                colLocator.name = $"{typeName}|{locatorName}";

                colLocator.transform.parent = this.transform;
            }
        }
        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            CsSystem.Collections.Generic.List<Vector3> _positions = positions;
            for (int i = 0; i < positions.Count; i++)
                _positions[i] = Fox.Math.UnityToFoxVector3(positions[i]);

            context.OverrideProperty(nameof(positions), _positions);

            //rlc TODO rotation packing
        }
    }
}
