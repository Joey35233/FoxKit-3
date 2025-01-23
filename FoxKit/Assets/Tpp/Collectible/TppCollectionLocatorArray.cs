

using Fox.Core;
using Fox.Core.Utils;
using System;
using System.Globalization;
using System.Linq;
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
        private enum TppCollection_GroupType : byte
        {
            TYPE_NORMAL = 0,
            TYPE_HERB = 1,
            TYPE_STATION = 2,
        }
        private FilePtr GetModelFilePath(TppCollection_Type type)
        {
            string pathString = "";
            switch (type)
            {
                case TppCollection_Type.TYPE_DIAMOND_SMALL:
                case TppCollection_Type.TYPE_DIAMOND_LARGE:
                    pathString = "/Assets/tpp/item/dia/Scenes/dia1_main0_def.fmdl";
                    break;
                case TppCollection_Type.TYPE_CASSETTE:
                    pathString = "/Assets/tpp/item/cct/Scenes/cct0_main1_def.fmdl";
                    break;
                case TppCollection_Type.TYPE_DEVELOPMENT_FILE:
                case TppCollection_Type.TYPE_EMBLEM:
                    pathString = "/Assets/tpp/item/ibo/Scenes/ibo6_main0_def.fmdl";
                    break;
                case TppCollection_Type.TYPE_SHIPPING_LABEL:
                    pathString = "/Assets/tpp/environ/object/middle_africa/pallet/mafr_pllt002/scenes/mafr_pllt002_vrtn004.fmdl";
                    break;
                default:
                    if (type >= TppCollection_Type.TYPE_MATERIAL_CM_0 && type <= TppCollection_Type.TYPE_MATERIAL_BR_7)
                        pathString = "/Assets/tpp/item/ibo/Scenes/ibo3_main0_def.fmdl";
                    break;
                case TppCollection_Type.TYPE_POSTER_SOL_AFGN:
                case TppCollection_Type.TYPE_POSTER_SOL_MAFR:
                case TppCollection_Type.TYPE_POSTER_SOL_ZRS:
                case TppCollection_Type.TYPE_POSTER_GRAVURE_V:
                case TppCollection_Type.TYPE_POSTER_MOE_V:
                    pathString = "/Assets/tpp/item/cbx/Scenes/cbx0_post1_def.fmdl";
                    break;
                case TppCollection_Type.TYPE_POSTER_GRAVURE_H:
                case TppCollection_Type.TYPE_POSTER_MOE_H:
                    pathString = "/Assets/tpp/item/cbx/Scenes/cbx0_post0_def.fmdl";
                    break;
                case TppCollection_Type.TYPE_PICTURE_PAZ:
                    pathString = "/Assets/tpp/item/pik/Scenes/pik6_main1_sta.fmdl";
                    break;
                case TppCollection_Type.TYPE_HERB_G_CRESCENT:
                    pathString = "/Assets/tpp/environ/object/afghanistan/flower/afgh_flwr005/scenes/afgh_flwr005.fmdl";
                    break;
                case TppCollection_Type.TYPE_HERB_A_PEACH:
                    pathString = "/Assets/tpp/environ/object/middle_africa/flower/mafr_flwr002/scenes/mafr_flwr002.fmdl";
                    break;
                case TppCollection_Type.TYPE_HERB_DIGITALIS_P:
                    pathString = "/Assets/tpp/environ/object/middle_africa/flower/mafr_flwr001/scenes/mafr_flwr001.fmdl";
                    break;
                case TppCollection_Type.TYPE_HERB_DIGITALIS_R:
                    pathString = "/Assets/tpp/environ/object/middle_africa/flower/mafr_flwr001/scenes/mafr_flwr001_vrtn002.fmdl";
                    break;
                case TppCollection_Type.TYPE_HERB_B_CARROT:
                    pathString = "/Assets/tpp/environ/object/afghanistan/flower/afgh_flwr004/scenes/afgh_flwr004.fmdl";
                    break;
                case TppCollection_Type.TYPE_HERB_WORM_WOOD:
                    pathString = "/Assets/tpp/environ/object/afghanistan/flower/afgh_flwr001/scenes/afgh_flwr001.fmdl";
                    break;
                case TppCollection_Type.TYPE_HERB_TARRAGON:
                    pathString = "/Assets/tpp/environ/object/afghanistan/flower/afgh_flwr003/scenes/afgh_flwr003.fmdl";
                    break;
                case TppCollection_Type.TYPE_HERB_HAOMA:
                    pathString = "/Assets/tpp/environ/object/afghanistan/flower/afgh_flwr002/scenes/afgh_flwr002.fmdl";
                    break;
                case TppCollection_Type.TYPE_STATION:
                    break;
            };
            return new FilePtr(new Fox.Path(pathString));
        }
        private Quaternion DecompressQuaternion( uint retQuat )
        {
            float x = (float)((retQuat >> 10 & 0x3ff) * 0.0009775171);
            float y = (float)((retQuat & 0x3ff) * 0.0009775171);
            float z = (float)(1.0 - x) - y;

            if ((retQuat >> 0x1d & 1) != 0)
                x = -x;

            if (((byte)(retQuat >> 0x1d) & 2) != 0)
                y = -y;

            if ((retQuat >> 0x1d & 4) != 0)
                z = -z;

            float theta = (float)((retQuat >> 0x14 & 0x1ff) * 0.001956947 * 3.141593 * 0.5);
            float sqrted = (float)1.0 / Mathf.Sqrt(y * y + x * x + z * z);
            float sinfTheta = Mathf.Sin(theta);
            theta = Mathf.Cos(theta);
            return new Quaternion(sqrted * x * sinfTheta, sqrted * y * sinfTheta, sqrted * z * sinfTheta, theta);
        }
        private uint CompressQuaternion(Quaternion rotQuat)
        {
            float x = rotQuat.x; float y = rotQuat.y;
            float z = rotQuat.z; float w = rotQuat.w;

            if(w<0)
            {
                x=-x; 
                y=-y;
                z=-z;
                w=-w;
            }
            byte signs=0;
            if (x < 0 )
                signs = 1; x = -x;

            if (y < 0)
                signs |= 2; y = -y;

            if (z < 0)
                signs |= 4; z = -z;

            float normFactor = 1.0f / (x + y + z);
            x *= normFactor;
            y *= normFactor;
            z *= normFactor;

            float wCompressed = Mathf.Acos(w) * (2.0f * 0.3183099f * 511.0f) + 0.5f;
            float xCompressed = x * 1023.0f + 0.5f;
            float yCompressed = y * 1023.0f + 0.5f;
                                                    
            int wInt = Mathf.FloorToInt(wCompressed);
            int xInt = Mathf.FloorToInt(xCompressed);
            int yInt = Mathf.FloorToInt(yCompressed);

            return (uint)((yInt & 0x3FF) | ((xInt & 0x3FF) << 10) | ((wInt & 0x3FF) << 20) | (signs << 29));
        }
        private TppCollection_GroupType GetGroupId(TppCollection_Type type)
        {
            if (type < TppCollection_Type.TYPE_STATION)
                if (type > TppCollection_Type.TYPE_PICTURE_PAZ)
                    return TppCollection_GroupType.TYPE_HERB;
                else
                    return TppCollection_GroupType.TYPE_NORMAL;
            else
                return TppCollection_GroupType.TYPE_STATION;
        }
        private const ushort NUM_BLOCKS = 64;
        private static ushort GetSegmentIndex(Vector3 position)
        {
            int blockIdx = Mathf.FloorToInt(position.x / NUM_BLOCKS);
            float blockX = Mathf.Clamp(blockIdx + NUM_BLOCKS, 0, NUM_BLOCKS * 2 - 1);
            int blockIdz = Mathf.FloorToInt(position.z / NUM_BLOCKS);
            float blockZ = Mathf.Clamp(blockIdz + NUM_BLOCKS, 0, NUM_BLOCKS * 2 - 1);

            return (ushort)(blockZ * 0x80 + blockX);
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
                TppCollection_Type typeId = (TppCollection_Type)(infos[i] >> 24);
                string uniqueId = (infos[i] & 0xFFFFFF).ToString("x");

                TppCollectionLocator colLocator = new GameObject(uniqueId).AddComponent<TppCollectionLocator>();

                FilePtr modelFile = GetModelFilePath(typeId);
                //TODO load relevant model
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.parent = colLocator.transform;

                colLocator.transform.parent = gameObject.transform;

                colLocator.transform.SetPositionAndRotation(positions[i], rotationsQuat[i]);

                colLocator.type = typeId;
            }
        }
        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            /*CsSystem.Collections.Generic.List<Vector3> _positions = positions;
            for (int i = 0; i < positions.Count; i++)
                _positions[i] = Fox.Math.UnityToFoxVector3(positions[i]);

            context.OverrideProperty(nameof(positions), _positions);*/

            Override(context);

            //rlc TODO rotation packing
        }
        public void Override(EntityExportContext context)
        {
            var locators = this.GetComponentsInChildren<TppCollectionLocator>().ToList();
            locators.OrderBy(x => x.type).ThenBy(x=>GetSegmentIndex(Fox.Math.UnityToFoxVector3(x.transform.position)));

            int locatorsCount = locators.Count;

            CsSystem.Collections.Generic.List<Vector3> _positions = new(locatorsCount);
            CsSystem.Collections.Generic.List<uint> _rotations = new(locatorsCount);
            CsSystem.Collections.Generic.List<uint> _infos = new(locatorsCount);

            CsSystem.Collections.Generic.List<ushort> _segmentIndices = new();
            CsSystem.Collections.Generic.List<ushort> _locatorIndices = new();
            CsSystem.Collections.Generic.List<ushort> _locatorCounts = new();

            CsSystem.Collections.Generic.List<byte> _groupIds = new();
            CsSystem.Collections.Generic.List<ushort> _segmentInfoIndices = new();
            CsSystem.Collections.Generic.List<ushort> _segmentInfoCounts = new();

            int locatorGroupIndex = 0;
            foreach (TppCollection_GroupType groupType in CsSystem.Enum.GetValues(typeof(TppCollection_GroupType)))
            {
                CsSystem.Collections.Generic.List<ushort> groupSegmentIndices = new();
                CsSystem.Collections.Generic.List<ushort> groupLocatorIndices = new();
                CsSystem.Collections.Generic.List<ushort> groupLocatorCounts = new();
                for (int i = 0; i < locators.Count; i++)
                {
                    if (groupType == GetGroupId(locators[i].type))
                    {
                        //Encode Locators:
                        //  Position
                        Vector3 position = Fox.Math.UnityToFoxVector3(locators[i].transform.position);
                        _positions.Insert(locatorGroupIndex, position);

                        //  Rotation
                        Quaternion rotQuat = Fox.Math.UnityToFoxQuaternion(locators[i].transform.rotation);
                        _rotations.Insert(locatorGroupIndex, CompressQuaternion(rotQuat));

                        //  Info
                        TppCollection_Type type = locators[i].type;
                        string name = locators[i].name;
                        if (!uint.TryParse(name, NumberStyles.HexNumber, null, out uint nameHash))
                            nameHash = (uint)new Fox.StrCode32(name).GetHashCode();
                        uint infos = (nameHash & 0xFFFFFF) | ((uint)type << 24);
                        _infos.Insert(locatorGroupIndex, infos);

                        //Segment index
                        ushort segmentIndex = GetSegmentIndex(Fox.Math.UnityToFoxVector3(locators[i].transform.position));

                        if (!groupSegmentIndices.Contains(segmentIndex))
                        {
                            groupSegmentIndices.Add(segmentIndex);
                            ushort segmentInfoIndex = (ushort)groupSegmentIndices.IndexOf(segmentIndex);
                            groupLocatorIndices.Add((ushort)locatorGroupIndex);
                            groupLocatorCounts.Insert(segmentInfoIndex,0);
                            if (!_groupIds.Contains((byte)groupType))
                            {
                                _groupIds.Add((byte)groupType);
                                ushort groupIndex = (ushort)_groupIds.IndexOf((byte)groupType);
                                _segmentInfoIndices.Add((ushort)groupSegmentIndices.IndexOf(segmentIndex));
                                _segmentInfoCounts.Insert(groupIndex, 0);
                            }
                            _segmentInfoCounts[_groupIds.IndexOf((byte)groupType)]++;
                        }
                        groupLocatorCounts[groupSegmentIndices.IndexOf(segmentIndex)]++;

                        locatorGroupIndex++;
                    }
                }
                _segmentIndices.AddRange(groupSegmentIndices);
                _locatorIndices.AddRange(groupLocatorIndices);
                _locatorCounts.AddRange(groupLocatorCounts);
            }

            context.OverrideProperty(nameof(positions), _positions);
            context.OverrideProperty(nameof(rotations), _rotations);
            context.OverrideProperty(nameof(infos), _infos);

            context.OverrideProperty(nameof(segmentIndices), _segmentIndices);
            context.OverrideProperty(nameof(locatorIndices), _locatorIndices);
            context.OverrideProperty(nameof(locatorCounts), _locatorCounts);

            context.OverrideProperty(nameof(groupIds), _groupIds);
            context.OverrideProperty(nameof(segmentInfoIndices), _segmentInfoIndices);
            context.OverrideProperty(nameof(segmentInfoCounts), _segmentInfoCounts);
        }
    }
}
