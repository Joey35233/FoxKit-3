using Fox.Core;
using Fox.Fio;
using Fox.Kernel;
using UnityEngine;

namespace Fox.GameKit
{
    public class ObjectBrushReader
    {
        public static ObjectBrushAsset Read(FileStreamReader reader)
        {
            var foxDataHeader = new FoxDataHeaderContext(reader, reader.BaseStream.Position);
            foxDataHeader.Validate(version: 3, flags: 0);

            if (foxDataHeader.GetFirstNode() is not FoxDataNodeContext dataNode)
                return null;

            Debug.Assert(dataNode.GetFlags() == 1);
            Debug.Assert(dataNode.GetNextNode() == null);
            Debug.Assert(dataNode.GetChildNode() == null);

            ObjectBrushAsset asset = ScriptableObject.CreateInstance<ObjectBrushAsset>();

            //Parameters
            FoxDataParameterContext? blockSizeWParam = dataNode.FindParameter(new String("blockSizeW"));
            Debug.Assert(blockSizeWParam.HasValue);
            asset.blockSizeW = blockSizeWParam.Value.GetFloat();
            Debug.Assert(asset.blockSizeW == 128, $"blockSizeW isn't 128: {asset.blockSizeW}");

            FoxDataParameterContext? blockSizeHParam = dataNode.FindParameter(new String("blockSizeH"));
            Debug.Assert(blockSizeHParam.HasValue);
            asset.blockSizeH = blockSizeHParam.Value.GetFloat();
            Debug.Assert(asset.blockSizeH == 128, $"blockSizeH isn't 128: {asset.blockSizeH}");

            FoxDataParameterContext? numBlocksWParam = dataNode.FindParameter(new String("numBlocksW"));
            Debug.Assert(numBlocksWParam.HasValue);
            asset.numBlocksW = numBlocksWParam.Value.GetUInt();
            Debug.Assert(asset.numBlocksW > 0, $"numBlocksW isn't more than 0: {asset.numBlocksW}");

            FoxDataParameterContext? numBlocksHParam = dataNode.FindParameter(new String("numBlocksH"));
            Debug.Assert(numBlocksHParam.HasValue);
            asset.numBlocksH = numBlocksHParam.Value.GetUInt();
            Debug.Assert(asset.numBlocksH > 0, $"numBlocksH isn't more than 0: {asset.numBlocksH}");

            FoxDataParameterContext? numObjectsParam = dataNode.FindParameter(new String("numObjects"));
            Debug.Assert(numObjectsParam.HasValue);
            float numObjects = numObjectsParam.Value.GetUInt();
            Debug.Assert(numObjects > 0, $"numBlocksH isn't more than 0: {numObjects}");

            if (dataNode.GetDataPosition() is not long dataPosition)
                return null;

            //Payload
            reader.Seek(dataPosition);

            for (int i = 0; i < numObjects; i++)
            {
                ObjectBrushObjectBinary obj = ObjectBrushObjectReader.Read(reader);
                if (obj != null)
                {
                    asset.objects.Add(obj);
                }
            }

            return asset;
        }
    }
}
