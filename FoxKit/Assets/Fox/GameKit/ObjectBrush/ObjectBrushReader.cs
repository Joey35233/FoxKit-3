using Fox.Core;
using Fox.Fio;
using Fox;
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

            var ObrType = dataNode.GetFlags();
            Debug.Assert(dataNode.GetNextNode() == null);
            Debug.Assert(dataNode.GetChildNode() == null);

            ObjectBrushAsset asset = ScriptableObject.CreateInstance<ObjectBrushAsset>();

            switch (ObrType)
            {
                //Parameters
                case 0:
                {
                    FoxDataParameterContext? blockIdParam = dataNode.FindParameter("blockId");
                    asset.blockId = blockIdParam.Value.GetUInt();
                
                    FoxDataParameterContext? flagsParam = dataNode.FindParameter("flags");
                    var flags = flagsParam.Value.GetUInt();
                    break;
                }
                case 1:
                {
                    FoxDataParameterContext? blockSizeWParam = dataNode.FindParameter("blockSizeW");
                    asset.blockSizeW = blockSizeWParam.Value.GetFloat();

                    FoxDataParameterContext? blockSizeHParam = dataNode.FindParameter("blockSizeH");
                    asset.blockSizeH = blockSizeHParam.Value.GetFloat();

                    FoxDataParameterContext? numBlocksWParam = dataNode.FindParameter("numBlocksW");
                    asset.numBlocksW = numBlocksWParam.Value.GetUInt();

                    FoxDataParameterContext? numBlocksHParam = dataNode.FindParameter("numBlocksH");
                    asset.numBlocksH = numBlocksHParam.Value.GetUInt();
                    break;
                }
            }

            FoxDataParameterContext? numObjectsParam = dataNode.FindParameter("numObjects");
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
