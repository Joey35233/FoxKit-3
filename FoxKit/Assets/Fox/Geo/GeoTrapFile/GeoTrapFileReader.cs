using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using Fox.Kernel;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Fox.Geo
{
    public class GeoTrapFileReader
    {
        private readonly TaskLogger logger = new TaskLogger("ReadTRAP");

        public UnityEngine.SceneManagement.Scene? Read(FileStreamReader reader)
        {
            UnityEngine.SceneManagement.Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            var foxDataHeader = new FoxDataHeaderContext(reader, reader.BaseStream.Position);
            foxDataHeader.Validate(version: 201406020, flags: 0);

            if (foxDataHeader.GetFirstNode() is not FoxDataNodeContext dataNode)
                return null;

            Debug.Assert(dataNode.GetFlags() == 1);
            Debug.Assert(dataNode.GetNextNode() == null);
            Debug.Assert(dataNode.GetChildNode() == null);

            if (dataNode.GetDataPosition() is not long dataPosition)
                return scene;

            for (uint i = 0; i < dataNode.GetParametersOffset(); i++)
            {
                reader.Seek(dataPosition + (4 * i));
                uint shapeOffset = reader.ReadUInt32();

                var header = new GeomHeaderContext(reader, dataPosition + shapeOffset, GeomHeaderContext.OffsetSize.Bytes);
                Debug.Assert(header.Name != 0);
                Debug.Assert(header.NextHeaderOffset == 0);
                Debug.Assert(header.PreviousHeaderOffset == 0);
                Debug.Assert(header.ChildHeaderOffset == 0);
                Debug.Assert(header.VertexBufferOffset == 0);
                if (header.Type is GeoPrimType.Box or GeoPrimType.AreaPath)
                {

                    if (header.Type == GeoPrimType.Box)
                    {
                        var triggerTrapGameObject = new GameObject(header.Name.ToString());
                        var triggerTrap = new GeoTriggerTrap();
                        triggerTrapGameObject.AddComponent<FoxEntity>().Entity = triggerTrap;
                        var triggerTrapTransformEntity = TransformEntity.GetDefault();
                        triggerTrap.inheritTransform = false;
                        triggerTrap.SetTransform(triggerTrapTransformEntity);
                        triggerTrap.InitializeGameObject(triggerTrapGameObject, logger);

                        triggerTrap.name = new Kernel.String(header.Name.ToString());
                        triggerTrap.enable = true;
                        triggerTrap.groupTags = TagUtils.GetEnumTags<GeoTriggerTrap.Tags>((ulong)header.GetTags<GeoTriggerTrap.Tags>());

                        for (int j = 0; j < header.PrimCount; j++)
                        {
                            reader.Seek(header.GetDataPosition() + (96 * j));

                            Vector3 size = reader.ReadScaleHF();
                            Vector4 padding = reader.ReadVector4();
                            Debug.Assert(padding == Vector4.zero);
                            Matrix4x4 matrix = reader.ReadMatrix4F();

                            var shapeGameObject = new GameObject($"BoxShape{j:D4}");
                            var shapeEntity = new BoxShape
                            {
                                inheritTransform = true,
                                visibility = true
                            };

                            var transform = new TransformEntity
                            {
                                rotQuat = matrix.rotation,
                                translation = matrix.GetPosition()
                            };

                            shapeEntity.SetTransform(transform);
                            shapeEntity.size = size;

                            triggerTrap.AddChild(shapeEntity);

                            shapeGameObject.AddComponent<FoxEntity>().Entity = shapeEntity;
                            shapeEntity.InitializeGameObject(shapeGameObject, logger);

                            shapeGameObject.transform.SetParent(triggerTrapGameObject.transform);
                        }
                    }
                    else if (header.Type == GeoPrimType.AreaPath && GeomHeaderContext.Deserialize(header) is TransformData trap)
                    {
                        var gameObject = new GameObject(header.Name.ToString());
                        gameObject.AddComponent<FoxEntity>().Entity = trap;
                        trap.InitializeGameObject(gameObject, logger);

                        for (int j = 0; j < trap.GetChildren().Count; j++)
                        {
                            Entity childEntity = trap.GetChildren()[j].Entity;

                            var child = new GameObject($"GeoxTrapAreaPath{j:D4}");
                            child.AddComponent<FoxEntity>().Entity = childEntity;
                            childEntity.InitializeGameObject(child, logger);
                            child.transform.SetParent(gameObject.transform);
                        }
                    }
                    else
                    {
                        return null;
                    }
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
