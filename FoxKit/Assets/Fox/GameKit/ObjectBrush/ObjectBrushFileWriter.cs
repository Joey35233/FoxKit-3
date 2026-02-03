using Fox.Core;
using Fox.Fio;
using Fox;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    public class ObjectBrushFileWriter
    {
        public const ushort METERS_PER_BLOCK = 128 / 1;

        public static ushort PositionFWSToBlockIndex(Vector3 positionFWS, uint numBlocksH, uint numBlocksW)
        {
            // block indices [0,32) x [0,32)
            ushort blockX = (ushort)Mathf.FloorToInt(((METERS_PER_BLOCK * numBlocksH / 2) + positionFWS.x) / METERS_PER_BLOCK);
            ushort blockZ = (ushort)Mathf.FloorToInt(((METERS_PER_BLOCK * numBlocksW / 2) + positionFWS.z) / METERS_PER_BLOCK);

            // one-value block index [0, 32*32)
            return (ushort)((blockZ * numBlocksW) + blockX);
        }

        public static Vector3 GetBlockCenterPositionFWSFromBlockIndex(ushort blockIndex, uint numBlocksH, uint numBlocksW)
        {
            // block indices [0,32) x [0,32)
            ushort blockX = (ushort)(blockIndex % numBlocksH);
            ushort blockZ = (ushort)Mathf.Floor(blockIndex / numBlocksW);

            // block center position
            float x = METERS_PER_BLOCK * (blockX + 0.5f - (0.5f * numBlocksH));
            float z = METERS_PER_BLOCK * (blockZ + 0.5f - (0.5f * numBlocksW));
            return new Vector3(x, 0, z);
        }
        public static Vector3 GetBlockCenterPositionFWSFromPositionFWS(Vector3 positionFWS, uint numBlocksH, uint numBlocksW)
        {
            // block indices [0,32) x [0,32)
            ushort blockX = (ushort)Mathf.FloorToInt(((METERS_PER_BLOCK * numBlocksH / 2) + positionFWS.x) / METERS_PER_BLOCK);
            ushort blockZ = (ushort)Mathf.FloorToInt(((METERS_PER_BLOCK * numBlocksW / 2) + positionFWS.x) / METERS_PER_BLOCK);

            // block center position
            float xFWS = METERS_PER_BLOCK * (blockX + 0.5f - (0.5f * numBlocksH));
            float zFWS = METERS_PER_BLOCK * (blockZ + 0.5f - (0.5f * numBlocksW));
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

        private static Vector3 GetPositionFWSFromPositionEWS(short xEOS, float yFWS, short zEOS, ushort blockIndex, uint numBlocksH, uint numBlocksW)
        {
            // block indices [0,32) x [0,32)
            ushort blockX = (ushort)(blockIndex % numBlocksH);
            ushort blockZ = (ushort)Mathf.Floor(blockIndex / numBlocksW);

            // block center position
            float blockCenterXFWS = METERS_PER_BLOCK * (blockX + 0.5f - (0.5f * numBlocksH));
            float blockCenterZFWS = METERS_PER_BLOCK * (blockZ + 0.5f - (0.5f * numBlocksW));

            // output position FWS
            float xFWS = blockCenterXFWS + (OBR_POSITION_DECODE * xEOS);
            float zFWS = blockCenterZFWS + (OBR_POSITION_DECODE * zEOS);
            return new Vector3(xFWS, yFWS, zFWS);
        }

        private static (short xEWS, float yFWS, short zEWS, ushort blockIndex) GetPositionEWSFromPositionFWS(Vector3 positionFWS, uint numBlocksH, uint numBlocksW)
        {
            // block indices [0,64) x [0,64)
            ushort blockX = (ushort)Mathf.FloorToInt((numBlocksH / 2) + (positionFWS.x / METERS_PER_BLOCK));
            ushort blockZ = (ushort)Mathf.FloorToInt((numBlocksW / 2) + (positionFWS.x / METERS_PER_BLOCK));

            // one-value block index [0, 64*64)
            ushort blockIndex = (ushort)((blockX * numBlocksH) + blockZ);

            // block center position
            float blockCenterXFWS = METERS_PER_BLOCK * (blockX + 0.5f - (0.5f * numBlocksH));
            float blockCenterZFWS = METERS_PER_BLOCK * (blockZ + 0.5f - (0.5f * numBlocksW));

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

            if (Selection.activeGameObject.GetComponent<ObjectBrush>() is not { } objectBrush)
                return;

            string filePath = EditorUtility.SaveFilePanel("Export to OBR", "", objectBrush.name, "obr");

            if (System.String.IsNullOrWhiteSpace(filePath))
                return;

            var minMaxScaleValues = new List<Vector2>();
            var entries = new List<OBREntry>();
            var (numBlocksH, numBlocksW) = objectBrush.GetNumBlocks();
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

            //        Vector3 objectPositionFWS = Fox.Math.FoxToUnityVector3(transform.position);
            //        Quaternion objectRotation = Fox.Math.FoxToUnityQuaternion(transform.rotation);

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
                
                //0x100 = offset to payload after parameters. obrb = 0x80
                
                writer.Write(3);//3 = obr. 2 = obrb
                writer.Write(0x20);
                writer.Write(fileSize);
                writer.WriteStrCode32(new StrCode32("ObjectBrush"));
                writer.Write(0x50); //local offset to string. obrb is at the end of the file, before parameter strings.

                _ = writer.Seek(20, SeekOrigin.Current);

                writer.Write(1); //flags. obr = 1, obrb = 0
                writer.Write(0xE0); //offset to payload. obr = 0xE0, obrb = 0x60 
                writer.Write(dataSize);

                _ = writer.Seek(16, SeekOrigin.Current);

                writer.Write(0x40);//obr = 0x40, obrb = 0x30

                _ = writer.Seek(8, SeekOrigin.Current);

                writer.Write("ObjectBrush".ToCharArray());
                _ = writer.Seek(0x5, SeekOrigin.Current);

                //parameters. 0x4C = local offset to string. in obrb this is at the very end of the file
                //obrb parameters: uint blockId, uint numObjects, uint flags (what are flags? always 1?)
                
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
                writer.Write(numBlocksH);
                writer.Write((ushort)0);
                writer.Write((ushort)0x10);
                writer.WriteStrCode32(new StrCode32("numBlocksW"));
                writer.Write(0x4C);
                writer.Write(numBlocksW);
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
                
                //obrb writes strings here. new line. ObjectBrushBlock takes up the whole line, and 0x8 later start the parameters strings, aligned to 0x4.
            }
        }
        public static void WriteObjectBrush(ObjectBrush objectBrush)
        {
            var (minMaxScaleValues, entries) = GetEntries(objectBrush.transform, objectBrush);

            var filePath = Fox.Fs.FileSystem.GetExternalPathFromFoxPath(objectBrush.obrFile.path.String);

            var numBlocks = objectBrush.GetNumBlocks();

            WriteObr(filePath,entries,minMaxScaleValues,numBlocks,0);
        }

        private static void WriteObr(string filePath, List<OBREntry> entries, List<Vector2> minMaxScaleValues, (uint numBlocksH, uint numBlocksW) numBlocks, uint blockId)
        {
            bool isBlock = filePath.EndsWith("obrb");
            using (var writer = new BinaryWriter(new FileStream(filePath, FileMode.Create)))
            {
                // Refer to https://github.com/kapuragu/FoxEngineTemplates/blob/main/gr/obr.bt for more details
                uint dataSize = 0x18 * (uint)entries.Count;
                uint finalPadding = dataSize == 0 ? 0 : (16 - (dataSize % 16)) % 16;

                //0x100 = offset to payload after parameters. obrb = 0x80
                uint payloadOffset = 0x100; //obr
                if (isBlock)
                    payloadOffset = 0x80;
                uint fileSize = payloadOffset + dataSize + finalPadding;
                if (isBlock)
                    fileSize += 0x34;
                
                //3 = obr. 2 = obrb
                uint version = 3;
                if (isBlock)
                    version = 2;
                writer.Write(version);
                writer.Write(0x20);
                writer.Write(fileSize);

                StrCode32 headerNameHash = new StrCode32("ObjectBrush");
                if (isBlock)
                    headerNameHash = new StrCode32("ObjectBrushBlock");
                writer.WriteStrCode32(headerNameHash);

                uint headerNameStringOffset = 0x50; //local offset to string. obrb is at the end of the file, before parameter strings, at finalPadding.
                if (isBlock)
                    headerNameStringOffset = payloadOffset + dataSize - 0x4;
                writer.Write(headerNameStringOffset);

                if (!isBlock)
                {
                    _ = writer.Seek(20, SeekOrigin.Current);
                }
                else
                {
                    _ = writer.Seek(0xC, SeekOrigin.Current);
                    writer.WriteStrCode32(new StrCode32(""));
                    writer.Write(payloadOffset - 0x8 + dataSize);
                }

                uint flags = 1;//flags. obr = 1, obrb = 0
                if (isBlock)
                    flags = 0;
                writer.Write(flags);
                
                uint dataOffset = 0xE0; //offset to payload. obr = 0xE0, obrb = 0x60 
                if (isBlock)
                    dataOffset = 0x60;
                writer.Write(dataOffset);
                
                writer.Write(dataSize);

                _ = writer.Seek(16, SeekOrigin.Current);

                uint parametersOffset = 0x40;//obr = 0x40, obrb = 0x30
                if (isBlock)
                    parametersOffset = 0x30;
                writer.Write(parametersOffset);

                _ = writer.Seek(8, SeekOrigin.Current);

                if (!isBlock)
                {
                    writer.Write("ObjectBrush".ToCharArray());
                    _ = writer.Seek(0x5, SeekOrigin.Current);
                }

                //parameters. 0x4C = local offset to string. in obrb this is at the very end of the file
                //obrb parameters: uint blockId, uint numObjects, uint flags (what are flags? always 1?)

                if (!isBlock)
                {
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
                    writer.WriteStrCode32(new StrCode32("numBlocksW"));
                    writer.Write(0x4C);
                    writer.Write(numBlocks.numBlocksW);
                    writer.Write((ushort)0);
                    writer.Write((ushort)0x10);
                    writer.WriteStrCode32(new StrCode32("numBlocksH"));
                    writer.Write(0x4C);
                    writer.Write(numBlocks.numBlocksH);
                    writer.Write((ushort)0);
                    writer.Write((ushort)0x00);
                    writer.WriteStrCode32(new StrCode32("numObjects"));
                    writer.Write(0x4C);
                    writer.Write(entries.Count);

                    writer.Write("blockSizeW".ToCharArray());
                    _ = writer.Seek(0x6, SeekOrigin.Current);
                    writer.Write("blockSizeH".ToCharArray());
                    _ = writer.Seek(0x6, SeekOrigin.Current);
                    writer.Write("numBlocksW".ToCharArray());
                    _ = writer.Seek(0x6, SeekOrigin.Current);
                    writer.Write("numBlocksH".ToCharArray());
                    _ = writer.Seek(0x6, SeekOrigin.Current);
                    writer.Write("numObjects".ToCharArray());
                    _ = writer.Seek(0x6, SeekOrigin.Current);
                }
                else
                {
                    writer.Write((ushort)0);
                    writer.Write((ushort)0x10);
                    writer.WriteStrCode32(new StrCode32("blockId"));
                    writer.Write(payloadOffset - 0x54 + dataSize + finalPadding + 0x18);
                    writer.Write(blockId);
                    writer.Write((ushort)0);
                    writer.Write((ushort)0x10);
                    writer.WriteStrCode32(new StrCode32("numObjects"));
                    writer.Write(payloadOffset - 0x64 + dataSize + finalPadding + 0x20);
                    writer.Write(entries.Count);
                    writer.Write((ushort)0);
                    writer.Write((ushort)0x00);
                    writer.WriteStrCode32(new StrCode32("flags"));
                    writer.Write(payloadOffset - 0x74 + dataSize + finalPadding + 0x2C);
                    writer.Write(1);
                }

                WritePayload(writer,entries,minMaxScaleValues);

                for (uint i = 0; i < finalPadding; i++)
                    writer.Write((byte)0);

                //obrb writes strings here. new line. ObjectBrushBlock takes up the whole line, and 0x8 later start the parameters strings, aligned to 0x4.
                if (isBlock)
                {
                    writer.Write("ObjectBrushBlock".ToCharArray());
                    _ = writer.Seek(0x8, SeekOrigin.Current);
                    writer.Write("blockId".ToCharArray());
                    _ = writer.Seek(0x1, SeekOrigin.Current);
                    writer.Write("numObjects".ToCharArray());
                    _ = writer.Seek(0x2, SeekOrigin.Current);
                    writer.Write("flags".ToCharArray());
                    writer.AlignWrite(0x4,0);
                }
            }
        }
        private static void WritePayload(BinaryWriter writer, List<OBREntry> entries, List<Vector2> minMaxScaleValues)
        {
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
        }

        private static (List<Vector2> minMaxScaleValues, List<OBREntry> entries) GetEntries(UnityEngine.Transform gameObject, ObjectBrush objectBrush)
        {
            var minMaxScaleValues = new List<Vector2>();
            var entries = new List<OBREntry>();

            uint globalObjectIndex = 0;
            
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                var child = gameObject.transform.GetChild(i).gameObject;
                
                if (!PrefabUtility.IsAnyPrefabInstanceRoot(child))
                    continue;

                var plugin = PrefabUtility.GetCorrespondingObjectFromSource(child).GetComponent<ObjectBrushPlugin>();

                if (!objectBrush.pluginHandle.Contains(plugin))
                    continue;

                byte brushID = (byte)objectBrush.pluginHandle.IndexOf(plugin);

                var transform = child.transform;
            
                Vector2 minMaxScaleValue = new Vector2(float.PositiveInfinity, float.NegativeInfinity);

                float scalarScale = (transform.localScale.x + transform.localScale.y + transform.localScale.z) / 3;
                if (scalarScale < minMaxScaleValue.x)
                    minMaxScaleValue.x = scalarScale;
                else if (scalarScale > minMaxScaleValue.y)
                    minMaxScaleValue.y = scalarScale;

                Vector3 objectPositionFWS = Fox.Math.FoxToUnityVector3(transform.position);
                Quaternion objectRotation = Fox.Math.FoxToUnityQuaternion(transform.rotation);

                var (numBlocksH, numBlocksW) = objectBrush.GetNumBlocks();
                var encodedPositionEWS = GetPositionEWSFromPositionFWS(objectPositionFWS, numBlocksH, numBlocksW);

                OBREntry entry = new OBREntry
                {
                    YPositionFWS = encodedPositionEWS.yFWS,
                    XPositionEOS = encodedPositionEWS.xEWS,
                    ZPositionEOS = encodedPositionEWS.zEWS,

                    RotationX = (Half)objectRotation.x,
                    RotationY = (Half)objectRotation.y,
                    RotationZ = (Half)objectRotation.z,
                    RotationW = (Half)objectRotation.w,

                    BlockID = encodedPositionEWS.blockIndex,
                    BrushID = brushID,
                    AbsoluteScale = scalarScale,
                    GlobalObjectIndex = globalObjectIndex,
                };

                entries.Add(entry);
                minMaxScaleValues.Add(minMaxScaleValue);

                globalObjectIndex++;
                continue;
            }
            
            return (minMaxScaleValues, entries);
        }
        public static void WriteObjectBrush(ObjectBrushBlock objectBrushBlock)
        {
            uint blockId = objectBrushBlock.blockId;
                
            if (!FoxGameKitModule.ObjectBrushRegistry.TryGetValue(objectBrushBlock.objectBrushName,
                    out ObjectBrush objectBrush))
                return;

            var (minMaxScaleValues, entries) = GetEntries(objectBrushBlock.transform, objectBrush);

            var filePath = Fox.Fs.FileSystem.GetExternalPathFromFoxPath(objectBrushBlock.obrbFile.path.String);

            var numBlocks = objectBrush.GetNumBlocks();

            WriteObr(filePath,entries,minMaxScaleValues,numBlocks,blockId);
        }
    }
}