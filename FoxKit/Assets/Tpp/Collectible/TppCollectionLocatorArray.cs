

using Fox.Core;
using Fox.Core.Utils;
using System.Globalization;
using UnityEngine;
using System.Collections.Generic;

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

        private Fox.Path GetModelFilePath(TppCollection_Type type)
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
                    if (type <= TppCollection_Type.TYPE_MATERIAL_BR_7)
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
            return new Fox.Path(pathString);
        }

        private Quaternion DecompressQuaternion(uint retQuat)
        {
            uint signs = retQuat >> 29;
            float x = (retQuat >> 10 & 0x3ff) * 0.0009775171f;
            float y = (retQuat & 0x3ff) * 0.0009775171f;
            float theta = (retQuat >> 0x14 & 0x1ff) * 0.001956947f * 3.141593f;

            float z = 1.0f - x - y;

            if ((signs & 1) != 0)
                x = -x;

            if ((signs & 2) != 0)
                y = -y;

            if ((signs & 4) != 0)
                z = -z;

            float thetaDiv2 = theta / 2.0f;
            float normFac = 1.0f / Mathf.Sqrt(y * y + x * x + z * z);
            float sinThetaDiv2 = Mathf.Sin(thetaDiv2);
            float cosThetaDiv2 = Mathf.Cos(thetaDiv2);

            return new Quaternion(x * normFac * sinThetaDiv2, y * normFac * sinThetaDiv2, z * normFac * sinThetaDiv2, cosThetaDiv2);
        }

        private uint CompressQuaternion(Quaternion rotQuat)
        {
            float x = rotQuat.x;
            float y = rotQuat.y;
            float z = rotQuat.z;
            float w = rotQuat.w;

            if (w < 0.0f)
            {
                x = -x;
                y = -y;
                z = -z;
                w = -w;
            }

            uint signs = 0;
            if (x < 0)
            {
                x = -x;
                signs |= 1;
            }

            if (y < 0)
            {
                y = -y;
                signs |= 2;
            }

            if (z < 0)
            {
                z = -z;
                signs |= 4;
            }

            float normFactor = 1.0f / (x + y + z);
            x *= normFactor;
            y *= normFactor;

            float xCompressed = x * 1023.0f + 0.5f;
            float yCompressed = y * 1023.0f + 0.5f;
            float wCompressed = Mathf.Acos(w) * 2.0f * 0.3183099f * 511.0f + 0.5f;

            uint xInt = (uint)Mathf.FloorToInt(xCompressed);
            uint yInt = (uint)Mathf.FloorToInt(yCompressed);
            uint wInt = (uint)Mathf.FloorToInt(wCompressed);

            return (signs << 29) | (wInt << 20) | (xInt << 10) | (yInt << 0);
        }
        private byte GetGroupId(TppCollection_Type type)
        {
            if (type < TppCollection_Type.TYPE_STATION)
                if (type > TppCollection_Type.TYPE_PICTURE_PAZ)
                    return 1;
                else
                    return 0;
            else
                return 2;
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
        private uint EncodeInfos(TppCollection_Type type, string uniqueIdName)
        {
            if (!uint.TryParse(uniqueIdName, NumberStyles.HexNumber, null, out uint nameHash))
                nameHash = (uint)new Fox.StrCode32(uniqueIdName).GetHashCode();
            return (nameHash & 0xFFFFFF) | ((uint)type << 24);
        }
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            for (int i = 0; i < positions.Count; i++)
            {
                positions[i] = Fox.Math.FoxToUnityVector3(positions[i]);

                TppCollection_Type typeId = (TppCollection_Type)(infos[i] >> 24);
                uint uniqueId = infos[i] & 0xFFFFFF;

                TppCollectionLocator colLocator = new GameObject($"0x{uniqueId:x}").AddComponent<TppCollectionLocator>();

                FilePtr modelFile = new(GetModelFilePath(typeId));
                //TODO load relevant model
                GameObject.CreatePrimitive(PrimitiveType.Cube).transform.parent = colLocator.transform;

                colLocator.transform.parent = gameObject.transform;

                Quaternion rotation = Fox.Math.FoxToUnityQuaternion(DecompressQuaternion(rotations[i]));
                colLocator.transform.SetPositionAndRotation(positions[i], rotation);

                colLocator.type = typeId;
            }
        }
        
        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            /*CsSystem.Collections.Generic.List<Vector3> _positions = positions;
            for (int i = 0; i < positions.Count; i++)
                _positions[i] = Fox.Math.UnityToFoxVector3(positions[i]);

            context.OverrideProperty(nameof(positions), _positions);*/

            Override(context);
        }
        
        private void Override(EntityExportContext context)
        {
            var locators = this.GetComponentsInChildren<TppCollectionLocator>();

            int locatorsCount = locators.Length;

            //Locator-size arrays
            Vector3[] _positions = new Vector3[locatorsCount];
            uint[] _rotations = new uint[locatorsCount];
            uint[] _infos = new uint[locatorsCount];

            //Segment-size arrays
            List<ushort> _segmentIndices = new();
            List<ushort> _locatorIndices = new();
            List<ushort> _locatorCounts = new();

            //Group-size arrays
            List<byte> _groupIds = new();
            List<ushort> _segmentInfoIndices = new();
            List<ushort> _segmentInfoCounts = new();

            ushort locatorId = 0;
            ushort segmentId = 0;
            ushort groupImplIndex = 0; //index of implemented group (if no herbs, stations would be 1 instead of 2)
            for (byte groupId = 0; groupId < 3; groupId++)
            {
                //Group-specific segment arrays
                ushort groupSegmentIndex = 0;
                List<ushort> groupSegmentIndices = new();
                List<ushort> groupLocatorIndices = new();
                List<ushort> groupLocatorCounts = new();
                for (byte blockZ = 1; blockZ < NUM_BLOCKS*2; blockZ++)
                {
                    for (byte blockX = 1; blockX < NUM_BLOCKS*2; blockX++)
                    {
                        for (int i = 0; i < locatorsCount; i++)
                        {
                            if (groupId == GetGroupId(locators[i].type))
                            {
                                ushort segmentIndex = GetSegmentIndex(Fox.Math.UnityToFoxVector3(locators[i].transform.position));
                                if (segmentIndex == (blockZ * 0x80 + blockX))
                                {
                                    //Encode Locators:
                                    //  Position
                                    Vector3 position = Fox.Math.UnityToFoxVector3(locators[i].transform.position);
                                    _positions.SetValue(position,locatorId);

                                    //  Rotation
                                    Quaternion rotQuat = Fox.Math.UnityToFoxQuaternion(locators[i].transform.rotation);
                                    _rotations.SetValue(CompressQuaternion(rotQuat),locatorId);

                                    //  Info
                                    _infos.SetValue(EncodeInfos(locators[i].type, locators[i].name), locatorId);

                                    //Serializing into segment
                                    //  Does a segment with this index not exist yet in this group?
                                    if (!groupSegmentIndices.Contains(segmentIndex))
                                    {
                                        //Add segment index, specify first index
                                        //And start counting the locators in it
                                        groupSegmentIndices.Add(segmentIndex);
                                        groupLocatorIndices.Add(locatorId);
                                        groupLocatorCounts.Insert(groupSegmentIndex, 0);

                                        //Does a group with this type not exist yet?
                                        if (!_groupIds.Contains(groupId))
                                        {
                                            //Add group type, specify first segment index
                                            //And start counting segments in it
                                            _groupIds.Add(groupId);
                                            _segmentInfoIndices.Add(segmentId);
                                            _segmentInfoCounts.Insert(groupImplIndex, 0);
                                            groupImplIndex++;
                                        }
                                        //Count segments in the group and globally
                                        _segmentInfoCounts[groupImplIndex - 1]++;
                                        groupSegmentIndex++;
                                        segmentId++;
                                    }
                                    //Count locators in the segment and globally
                                    groupLocatorCounts[groupSegmentIndex - 1]++;
                                    locatorId++;

                                }//if (segmentIndex == (blockZ * 0x80 + blockX))

                            }//if (groupType == GetGroupId(locators[i].type))

                        }//for (int i = 0; i < locatorsCount; i++)

                    }//for (byte blockX = 1; blockX < NUM_BLOCKS*2; blockX++)

                }//for (byte blockZ = 1; blockZ < NUM_BLOCKS*2; blockZ++)

                //End of group - append group-specific segment arrays to the end of globals
                _segmentIndices.AddRange(groupSegmentIndices);
                _locatorIndices.AddRange(groupLocatorIndices);
                _locatorCounts.AddRange(groupLocatorCounts);
            }//foreach (TppCollection_GroupType groupType in CsSystem.Enum.GetValues(typeof(TppCollection_GroupType)))

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
