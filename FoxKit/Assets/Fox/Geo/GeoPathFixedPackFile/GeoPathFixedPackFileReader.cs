using Fox.Core;
using UnityEditor.SceneManagement;
using UnityEngine;
using Fox.Fio;

namespace Fox.Geo
{
    public class GeoPathFixedPackFileReader
    {
        public UnityEngine.SceneManagement.Scene? Read(FileStreamReader reader)
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            FoxDataHeaderContext foxDataHeader = new FoxDataHeaderContext(reader, reader.BaseStream.Position);
            foxDataHeader.Validate(version: 201209110, flags: 0);

            if (foxDataHeader.GetFirstNode() is not FoxDataNodeContext dataNode)
                return null;

            Debug.Assert(dataNode.GetFlags() == 12);
            Debug.Assert(dataNode.GetNextNode() == null);
            Debug.Assert(dataNode.GetChildNode() == null);

            if (dataNode.GetDataPosition() is not long dataPosition)
                return scene;

            //Payload
            reader.Seek(dataPosition);

            // Skip past BVH stuff for now
            reader.Skip(60);

            uint dataOffset = reader.ReadUInt32();

            reader.Seek(dataPosition + dataOffset);

            uint pathCount = reader.ReadUInt32();
            uint firstShapeSize = reader.ReadUInt32(); // For debug purposes
            for (uint i = 0; i < pathCount; i++)
            {
                reader.Seek(dataPosition + dataOffset + 8 + 4 * i);

                uint shapeOffset = reader.ReadUInt32();
                reader.Seek(dataPosition + shapeOffset);

                GeomHeaderContext header = new GeomHeaderContext(reader, dataPosition + shapeOffset, GeomHeaderContext.OffsetSize.Bytes);
                Debug.Assert(header.Name != 0);
                Debug.Assert(header.NextHeaderOffset == 0);
                Debug.Assert(header.PreviousHeaderOffset == 0);
                Debug.Assert(header.ChildHeaderOffset == 0);
                if (header.Type == GeoPrimType.Path && GeomHeaderContext.Deserialize(header) is Entity shape)
                {
                    GameObject gameObject = new GameObject(header.Name.ToString());
                    gameObject.AddComponent<FoxEntity>().Entity = shape;
                    shape.InitializeGameObject(gameObject);
                }
                else
                {
                    return null;
                }
            }

            return scene;
        }
    }
}
