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
            asset.blockSizeW = blockSizeWParam.Value.GetFloat();

            FoxDataParameterContext? blockSizeHParam = dataNode.FindParameter(new String("blockSizeH"));
            asset.blockSizeH = blockSizeHParam.Value.GetFloat();

            FoxDataParameterContext? numBlocksWParam = dataNode.FindParameter(new String("numBlocksW"));
            asset.numBlocksW = numBlocksWParam.Value.GetUInt();

            FoxDataParameterContext? numBlocksHParam = dataNode.FindParameter(new String("numBlocksH"));
            asset.numBlocksH = numBlocksHParam.Value.GetUInt();

            FoxDataParameterContext? numObjectsParam = dataNode.FindParameter(new String("numObjects"));
            float numObjects = numObjectsParam.Value.GetUInt();

            if (dataNode.GetDataPosition() is not long dataPosition)
                return null;

            //Payload
            reader.Seek(dataPosition);

            for (int i = 0; i < numObjects; i++)
            {
                var obj = new ObjectBrushObjectBinary(reader);
                asset.objects.Add(obj);
            }

            return asset;
        }
    }
}
