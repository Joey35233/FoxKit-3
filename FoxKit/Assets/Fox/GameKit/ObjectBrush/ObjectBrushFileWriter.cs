using Fox.Core;
using Fox.Fio;
using Fox.Kernel;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    public class ObjectBrushFileWriter
    {
        public const ushort NUM_BLOCKS_X = 64;
        public const ushort NUM_BLOCKS_Z = 64;
        public const ushort METERS_PER_BLOCK = 128 / 1;

        public static ushort PositionFWSToBlockIndex(Vector3 positionFWS)
        {
            // block indices [0,32) x [0,32)
            ushort blockX = (ushort)Mathf.FloorToInt(((METERS_PER_BLOCK * NUM_BLOCKS_X / 2) + positionFWS.x) / METERS_PER_BLOCK);
            ushort blockZ = (ushort)Mathf.FloorToInt(((METERS_PER_BLOCK * NUM_BLOCKS_Z / 2) + positionFWS.z) / METERS_PER_BLOCK);

            // one-value block index [0, 32*32)
            return (ushort)((blockZ * NUM_BLOCKS_Z) + blockX);
        }

        public static Vector3 GetBlockCenterPositionFWSFromBlockIndex(ushort blockIndex)
        {
            // block indices [0,32) x [0,32)
            ushort blockX = (ushort)(blockIndex % NUM_BLOCKS_X);
            ushort blockZ = (ushort)Mathf.Floor(blockIndex / NUM_BLOCKS_Z);

            // block center position
            float x = METERS_PER_BLOCK * (blockX + 0.5f - (0.5f * NUM_BLOCKS_X));
            float z = METERS_PER_BLOCK * (blockZ + 0.5f - (0.5f * NUM_BLOCKS_Z));
            return new Vector3(x, 0, z);
        }
        public static Vector3 GetBlockCenterPositionFWSFromPositionFWS(Vector3 positionFWS)
        {
            // block indices [0,32) x [0,32)
            ushort blockX = (ushort)Mathf.FloorToInt(((METERS_PER_BLOCK * NUM_BLOCKS_X / 2) + positionFWS.x) / METERS_PER_BLOCK);
            ushort blockZ = (ushort)Mathf.FloorToInt(((METERS_PER_BLOCK * NUM_BLOCKS_Z / 2) + positionFWS.x) / METERS_PER_BLOCK);

            // block center position
            float xFWS = METERS_PER_BLOCK * (blockX + 0.5f - (0.5f * NUM_BLOCKS_X));
            float zFWS = METERS_PER_BLOCK * (blockZ + 0.5f - (0.5f * NUM_BLOCKS_Z));
            return new Vector3(xFWS, 0, zFWS);
        }

        private struct OBREntry
        {
            public float YPositionFWS;
            public short XPositionEOS;
            public short ZPositionEOS;

            public Half RotationX;
            public Half RotationY;
            public Half RotationZ;
            public Half RotationW;

            public ushort BlockID;
            public byte BrushID;
            //public byte NormalizedScale; // lerp(ObjectBrushPluginClone.minSize, ObjectBrushPluginClone.maxSize, NormalizedScale)
            public float AbsoluteScale;
            public uint GlobalObjectIndex;
        }

        // 32640 is magic number
        private const float OBR_POSITION_ENCODE = 32640 / METERS_PER_BLOCK;
        private const float OBR_POSITION_DECODE = METERS_PER_BLOCK / 32640;

        private static Vector3 GetPositionFWSFromPositionEWS(short xEOS, float yFWS, short zEOS, ushort blockIndex)
        {
            // block indices [0,32) x [0,32)
            ushort blockX = (ushort)(blockIndex % NUM_BLOCKS_X);
            ushort blockZ = (ushort)Mathf.Floor(blockIndex / NUM_BLOCKS_Z);

            // block center position
            float blockCenterXFWS = METERS_PER_BLOCK * (blockX + 0.5f - (0.5f * NUM_BLOCKS_X));
            float blockCenterZFWS = METERS_PER_BLOCK * (blockZ + 0.5f - (0.5f * NUM_BLOCKS_Z));

            // output position FWS
            float xFWS = blockCenterXFWS + (OBR_POSITION_DECODE * xEOS);
            float zFWS = blockCenterZFWS + (OBR_POSITION_DECODE * zEOS);
            return new Vector3(xFWS, yFWS, zFWS);
        }

        private static (short xEWS, float yFWS, short zEWS, ushort blockIndex) GetPositionEWSFromPositionFWS(Vector3 positionFWS)
        {
            // block indices [0,64) x [0,64)
            ushort blockX = (ushort)Mathf.FloorToInt((NUM_BLOCKS_X / 2) + (positionFWS.x / METERS_PER_BLOCK));
            ushort blockZ = (ushort)Mathf.FloorToInt((NUM_BLOCKS_Z / 2) + (positionFWS.x / METERS_PER_BLOCK));

            // one-value block index [0, 64*64)
            ushort blockIndex = (ushort)((blockX * NUM_BLOCKS_X) + blockZ);

            // block center position
            float blockCenterXFWS = METERS_PER_BLOCK * (blockX + 0.5f - (0.5f * NUM_BLOCKS_X));
            float blockCenterZFWS = METERS_PER_BLOCK * (blockZ + 0.5f - (0.5f * NUM_BLOCKS_Z));

            // encoded position EOS
            short xEOS = (short)(OBR_POSITION_ENCODE * (positionFWS.x - blockCenterXFWS));
            short zEOS = (short)(OBR_POSITION_ENCODE * (positionFWS.z - blockCenterZFWS));
            return (xEOS, positionFWS.y, zEOS, blockIndex);
        }

        [MenuItem("FoxKit/Export Object Brush", false)]
        public static void ExportObjectBrush()
        {
            if (Selection.activeGameObject is null)
                return;

            FoxEntity obrGameObject = Selection.activeGameObject.GetComponent<FoxEntity>();

            if (obrGameObject?.Entity is not ObjectBrush)
                return;

            string filePath = EditorUtility.SaveFilePanel("Export to OBR", "", Selection.activeGameObject.name, "obr");

            if (System.String.IsNullOrWhiteSpace(filePath))
                return;

            var minMaxScaleValues = new List<Vector2>();
            var entries = new List<OBREntry>();
            //foreach (var gameObject in obrGameObject.GetCompo  GetEntityComponent<Fox.GameKit.ObjectBrushPlugin>().c)
            //{
            //    Vector2 minMaxScaleValue = new Vector2(float.PositiveInfinity, float.NegativeInfinity);

            //    foreach (Transform transform in grassPluginGameObjects.transform)
            //    {
            //        float scalarScale = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3;
            //        if (scalarScale < minMaxScaleValue.x)
            //            minMaxScaleValue.x = scalarScale;
            //        else if (scalarScale > minMaxScaleValue.y)
            //            minMaxScaleValue.y = scalarScale;

            //        Vector3 objectPositionFWS = Fox.Kernel.Math.FoxToUnityVector3(transform.position);
            //        Quaternion objectRotation = Fox.Kernel.Math.FoxToUnityQuaternion(transform.rotation);

            //        var encodedPositionEWS = GetPositionEWSFromPositionFWS(objectPositionFWS);

            //        OBREntry entry = new OBREntry
            //        {
            //            YPositionFWS = encodedPositionEWS.yFWS,
            //            XPositionEOS = encodedPositionEWS.xEWS,
            //            ZPositionEOS = encodedPositionEWS.zEWS,

            //            RotationX = (Half)objectRotation.x,
            //            RotationY = (Half)objectRotation.y,
            //            RotationZ = (Half)objectRotation.z,
            //            RotationW = (Half)objectRotation.w,

            //            BlockID = encodedPositionEWS.blockIndex,
            //            BrushID = brushID,
            //            AbsoluteScale = scalarScale,
            //            GlobalObjectIndex = globalObjectIndex,
            //        };

            //        entries.Add(entry);

            //        globalObjectIndex++;
            //        continue;
            //    }

            //    minMaxScaleValues.Add(minMaxScaleValue);
            //    brushID++;
            //}

            using (var writer = new BinaryWriter(new FileStream(filePath, FileMode.Create)))
            {
                // Refer to https://github.com/kapuragu/FoxEngineTemplates/blob/main/gr/obr.bt for more details
                uint dataSize = 0x18 * (uint)entries.Count;
                uint finalPadding = dataSize == 0 ? 0 : 16 - (dataSize % 16);
                uint fileSize = 0x100 + dataSize + finalPadding;

                writer.Write(3);
                writer.Write(0x20);
                writer.Write(fileSize);
                writer.WriteStrCode32(new StrCode32("ObjectBrush"));
                writer.Write(0x50);

                _ = writer.Seek(20, SeekOrigin.Current);

                writer.Write(1);
                writer.Write(0xE0);
                writer.Write(dataSize);

                _ = writer.Seek(16, SeekOrigin.Current);

                writer.Write(0x40);

                _ = writer.Seek(8, SeekOrigin.Current);

                writer.Write("ObjectBrush".ToCharArray());
                _ = writer.Seek(0x5, SeekOrigin.Current);

                writer.Write((ushort)2);
                writer.Write((ushort)0x10);
                writer.WriteStrCode32(new StrCode32("blockSizeW"));
                writer.Write(0x4C);
                writer.Write((float)METERS_PER_BLOCK);
                writer.Write((ushort)2);
                writer.Write((ushort)0x10);
                writer.WriteStrCode32(new StrCode32("blockSizeH"));
                writer.Write(0x4C);
                writer.Write((float)METERS_PER_BLOCK);
                writer.Write((ushort)0);
                writer.Write((ushort)0x10);
                writer.WriteStrCode32(new StrCode32("numBlocksH"));
                writer.Write(0x4C);
                writer.Write((uint)NUM_BLOCKS_X);
                writer.Write((ushort)0);
                writer.Write((ushort)0x10);
                writer.WriteStrCode32(new StrCode32("numBlocksW"));
                writer.Write(0x4C);
                writer.Write((uint)NUM_BLOCKS_Z);
                writer.Write((ushort)0);
                writer.Write((ushort)0x00);
                writer.WriteStrCode32(new StrCode32("numObjects"));
                writer.Write(0x4C);
                writer.Write(entries.Count);

                writer.Write("blockSizeW".ToCharArray());
                _ = writer.Seek(0x6, SeekOrigin.Current);
                writer.Write("blockSizeH".ToCharArray());
                _ = writer.Seek(0x6, SeekOrigin.Current);
                writer.Write("numBlocksH".ToCharArray());
                _ = writer.Seek(0x6, SeekOrigin.Current);
                writer.Write("numBlocksW".ToCharArray());
                _ = writer.Seek(0x6, SeekOrigin.Current);
                writer.Write("numObjects".ToCharArray());
                _ = writer.Seek(0x6, SeekOrigin.Current);

                for (int i = 0; i < entries.Count; i++)
                {
                    OBREntry entry = entries[i];
                    writer.Write(entry.YPositionFWS);
                    writer.Write(entry.XPositionEOS);
                    writer.Write(entry.ZPositionEOS);

                    writer.Write(Half.GetBits(entry.RotationX));
                    writer.Write(Half.GetBits(entry.RotationY));
                    writer.Write(Half.GetBits(entry.RotationZ));
                    writer.Write(Half.GetBits(entry.RotationW));

                    writer.Write(entry.BlockID);
                    writer.Write(entry.BrushID);
                    byte scaleUNorm = (byte)(255 * (minMaxScaleValues[entry.BrushID].x - entry.AbsoluteScale) / (minMaxScaleValues[entry.BrushID].x - minMaxScaleValues[entry.BrushID].y));
                    writer.Write(scaleUNorm);
                    writer.Write(entry.GlobalObjectIndex);
                }

                for (uint i = 0; i < finalPadding; i++)
                    writer.Write((byte)0);
            }
        }
    }
}