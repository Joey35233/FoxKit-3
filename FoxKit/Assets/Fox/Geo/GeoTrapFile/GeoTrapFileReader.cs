using Fox.Kernel;
using Fox.Core;
using System;
using System.IO;
using UnityEditor.SceneManagement;
using UnityEngine;
using static UnityEngine.Debug;
using String = Fox.Kernel.String;
using Fox.Fio;

namespace Fox.Geo
{
    public class GeoTrapFileReader
    {
        public UnityEngine.SceneManagement.Scene Read(FileStreamReader reader)
        {
            // Header
            FoxDataHeaderContext header = new FoxDataHeaderContext(reader, reader.BaseStream.Position);
            header.Validate(version: 201406020, flags: 0);

            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            // Entries
            for (FoxDataNodeContext? node = header.GetFirstNode(); node.HasValue; node = node.Value.GetNextNode())
            {
                FoxDataNodeContext realNode = node.Value;

                var entryCount = realNode.GetParametersOffset();

                reader.BaseStream.Position = realNode.Position+realNode.GetDataOffset();

                uint[] offsets = new uint[entryCount];
                for (uint i = 0; i < entryCount; i++)
                    offsets[i] = reader.ReadUInt32();

                uint boxShapeCount = 0;
                uint pathShapeCount = 0;

                for (uint i = 0; i < entryCount; i++)
                {
                    reader.BaseStream.Position = realNode.Position + realNode.GetDataOffset() + offsets[i];

                    var gameObject = new GameObject();
                    gameObject.name = $"GeoTriggerTrap{i.ToString("D4")}";
                    var foxEntityComponent = gameObject.AddComponent<FoxEntity>();
                    GeoTriggerTrap geoTriggerTrapEntity = (GeoTriggerTrap)(foxEntityComponent.Entity = new GeoTriggerTrap());

                    TransformEntity geoTriggerTrapTransform = new TransformEntity();
                    geoTriggerTrapTransform.owner = EntityHandle.Get(geoTriggerTrapEntity);
                    geoTriggerTrapEntity.transform = new EntityPtr<TransformEntity>(geoTriggerTrapTransform);
                    //initialzing the go breaks the translation of the children here???

                    uint flags = reader.ReadUInt32();
                    geoTriggerTrapEntity.enable = (flags & 0x01) == 1 ? true : false;
                    // No idea what flags[1] is .
                    GeoTriggerTrap_ShapeType shapeType = (GeoTriggerTrap_ShapeType)((flags >> 3) & 0x03);
                    Assert(((flags >> 8) & 0xFFFF) == 0x8000);
                    byte shapeCount = (byte)((flags >> 24) & 0xFF);

                    reader.BaseStream.Position += 12;

                    GeoTriggerTrap_Tags tags = (GeoTriggerTrap_Tags)reader.ReadUInt64();
                    foreach (GeoTriggerTrap_Tags tag in Enum.GetValues(tags.GetType()))
                        if (tags.HasFlag(tag))
                            geoTriggerTrapEntity.groupTags.Add(new String(tag.ToString()));

                    uint hash = reader.ReadUInt32();

                    reader.BaseStream.Position += 4;

                    if (shapeType == GeoTriggerTrap_ShapeType.Box)
                    {
                        for (byte j = 0; j < shapeCount; j++)
                        {
                            var shapeGameObject = new GameObject();
                            shapeGameObject.name = $"BoxShape{boxShapeCount.ToString("D4")}";
                            var shapeFoxEntityComponent = shapeGameObject.AddComponent<FoxEntity>();
                            shapeFoxEntityComponent.Entity = EntityInfo.ConstructEntity(new String("BoxShape"));
                            BoxShape shapeFoxEntity = shapeFoxEntityComponent.Entity as BoxShape;

                            TransformEntity shapeFoxTransform = new TransformEntity();
                            shapeFoxTransform.owner = EntityHandle.Get(shapeFoxEntity);
                            shapeFoxEntity.transform = new EntityPtr<TransformEntity>(shapeFoxTransform);

                            shapeFoxEntity.InitializeGameObject(shapeGameObject);

                            Vector4 scale = reader.ReadWideVector3();

                            reader.BaseStream.Position += 16;

                            Matrix4x4 transform = reader.ReadMatrix4F();

                            shapeGameObject.transform.localScale = scale;
                            shapeGameObject.transform.position = Kernel.Math.FoxToUnityVector3(transform.GetPosition());
                            shapeGameObject.transform.rotation = Kernel.Math.FoxToUnityQuaternion(transform.rotation);
                            shapeGameObject.transform.SetParent(gameObject.transform);

                            boxShapeCount++;
                        }
                    }
                    else if (shapeType == GeoTriggerTrap_ShapeType.Path)
                    {
                        for (byte j = 0; j < shapeCount; j++)
                        {
                            long selfPosition = reader.BaseStream.Position;

                            float yMin = reader.ReadSingle();
                            //height property TODO
                            float yMax = reader.ReadSingle();

                            var shapeGameObject = new GameObject();
                            shapeGameObject.name = $"GeoxTrapAreaPath{pathShapeCount.ToString("D4")}";
                            var shapeFoxEntityComponent = shapeGameObject.AddComponent<FoxEntity>();
                            shapeFoxEntityComponent.Entity = EntityInfo.ConstructEntity(new String("GeoxTrapAreaPath"));
                            var shapeFoxEntity = shapeFoxEntityComponent.Entity;
                            var shapeFoxPtr = EntityHandle.Get(shapeFoxEntity);

                            shapeFoxEntity.SetProperty(new String("height"),new Value(yMax-yMin));
                            TransformEntity shapeTransformEntity = new TransformEntity();
                            shapeTransformEntity.owner = shapeFoxPtr;
                            shapeFoxEntity.SetProperty(new String("transform"), new Value(new EntityPtr<TransformEntity>(shapeTransformEntity)));

                            shapeFoxEntity.InitializeGameObject(shapeGameObject);

                            uint pointCount = reader.ReadUInt32();
                            uint pointsOffset = reader.ReadUInt32();

                            reader.BaseStream.Position = selfPosition + pointsOffset;

                            shapeGameObject.transform.position = new Vector3(0, yMin, 0);

                            //TODO add nodes and edges when the class gets out
                            var nodes = new DataElement[pointCount];
                            for (uint h = 0; h < pointCount; h++)
                            {
                                var nodePos = reader.ReadVector3(); reader.ReadUInt32();
                                Debug.Log($"{h}={nodePos}");
                            }

                            shapeGameObject.transform.SetParent(gameObject.transform);

                            pathShapeCount++;
                        }
                    }
                }
            }

            return scene;
        }
    }
}
