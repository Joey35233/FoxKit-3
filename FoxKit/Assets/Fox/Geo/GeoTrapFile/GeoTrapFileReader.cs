using Fox.Core;
using UnityEditor.SceneManagement;
using UnityEngine;
using Fox.Fio;
using Fox.Kernel;
using UnityEngine.Rendering;

namespace Fox.Geo
{
    public class GeoTrapFileReader
    {
        public UnityEngine.SceneManagement.Scene? Read(FileStreamReader reader)
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            FoxDataHeaderContext foxDataHeader = new FoxDataHeaderContext(reader, reader.BaseStream.Position);
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
                reader.Seek(dataPosition + 4 * i);
                uint shapeOffset = reader.ReadUInt32();

                GeomHeaderContext header = new GeomHeaderContext(reader, dataPosition + shapeOffset, GeomHeaderContext.OffsetSize.Bytes);
                Debug.Assert(header.Name != 0);
                Debug.Assert(header.NextHeaderOffset == 0);
                Debug.Assert(header.PreviousHeaderOffset == 0);
                Debug.Assert(header.ChildHeaderOffset == 0);
                Debug.Assert(header.VertexBufferOffset == 0);
                if (header.Type == GeoPrimType.Box || header.Type == GeoPrimType.AreaPath)
                {

                    if (header.Type == GeoPrimType.Box)
                    {
                        GameObject triggerTrapGameObject = new GameObject(header.Name.ToString());
                        GeoTriggerTrap triggerTrap = new GeoTriggerTrap();
                        triggerTrapGameObject.AddComponent<FoxEntity>().Entity = triggerTrap;
                        TransformEntity triggerTrapTransformEntity = TransformEntity.GetDefault();
                        triggerTrap.inheritTransform = false;
                        triggerTrap.SetTransform(triggerTrapTransformEntity);
                        triggerTrap.InitializeGameObject(triggerTrapGameObject);

                        triggerTrap.name = new Kernel.String(header.Name.ToString());
                        triggerTrap.enable = true;
                        triggerTrap.groupTags = TagUtils.GetEnumTags<GeoTriggerTrap.Tags>((ulong)header.GetTags<GeoTriggerTrap.Tags>());

                        for (int j = 0; j < header.PrimCount; j++)
                        {
                            reader.Seek(header.GetDataPosition() + 96 * j);

                            Vector3 size = reader.ReadScaleHF();
                            Vector4 padding = reader.ReadVector4(); Debug.Assert(padding == Vector4.zero);
                            Matrix4x4 matrix = reader.ReadMatrix4F();

                            GameObject shapeGameObject = new GameObject($"BoxShape{j:D4}");
                            BoxShape shapeEntity = new BoxShape();
                            shapeEntity.inheritTransform = true;
                            shapeEntity.visibility = true;

                            TransformEntity transform = new TransformEntity();
                            transform.rotQuat = matrix.rotation;
                            transform.translation = matrix.GetPosition();

                            shapeEntity.SetTransform(transform);
                            shapeEntity.size = size;

                            triggerTrap.AddChild(shapeEntity);

                            shapeGameObject.AddComponent<FoxEntity>().Entity = shapeEntity;
                            shapeEntity.InitializeGameObject(shapeGameObject);

                            shapeGameObject.transform.SetParent(triggerTrapGameObject.transform);
                        }
                    }
                    else if (header.Type == GeoPrimType.AreaPath && GeomHeaderContext.Deserialize(header) is TransformData trap)
                    {
                        GameObject gameObject = new GameObject(header.Name.ToString());
                        gameObject.AddComponent<FoxEntity>().Entity = trap;
                        trap.InitializeGameObject(gameObject);

                        for (int j = 0; j < trap.GetChildren().Count; j++)
                        {
                            Entity childEntity = trap.GetChildren()[j].Entity;

                            GameObject child = new GameObject($"GeoxTrapAreaPath{j:D4}");
                            child.AddComponent<FoxEntity>().Entity = childEntity;
                            childEntity.InitializeGameObject(child);
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
    /*
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

                var trapCount = realNode.GetParametersOffset();

                reader.BaseStream.Position = realNode.Position+realNode.GetDataOffset();

                uint[] offsets = new uint[trapCount];
                for (uint i = 0; i < trapCount; i++)
                    offsets[i] = reader.ReadUInt32();

                uint boxShapeCount = 0;
                uint pathShapeCount = 0;

                for (uint trapIndex = 0; trapIndex < trapCount; trapIndex++)
                {
                    reader.BaseStream.Position = realNode.Position + realNode.GetDataOffset() + offsets[trapIndex];

                    var gameObject = new GameObject();
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
                    gameObject.name = hash.ToString();

                    reader.BaseStream.Position += 4;

                    if (shapeType == GeoTriggerTrap_ShapeType.Box)
                    {
                        for (byte shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
                        {
                            var shapeGameObject = new GameObject();
                            shapeGameObject.name = $"BoxShape{boxShapeCount.ToString("D4")}";
                            var shapeFoxEntityComponent = shapeGameObject.AddComponent<FoxEntity>();
                            shapeFoxEntityComponent.Entity = EntityInfo.ConstructEntity(new String("BoxShape"));
                            BoxShape shapeFoxEntity = shapeFoxEntityComponent.Entity as BoxShape;

                            shapeFoxEntity.InitializeGameObject(shapeGameObject);

                            shapeFoxEntity.parent = EntityHandle.Get(geoTriggerTrapEntity);

                            TransformEntity shapeFoxTransform = new TransformEntity();
                            shapeFoxTransform.owner = EntityHandle.Get(shapeFoxEntity);
                            shapeFoxEntity.transform = new EntityPtr<TransformEntity>(shapeFoxTransform);

                            Vector4 scale = reader.ReadWideVector3();

                            reader.BaseStream.Position += 16;

                            Matrix4x4 transform = reader.ReadMatrix4F();

                            shapeGameObject.transform.localScale = scale;
                            shapeGameObject.transform.position = transform.GetPosition();
                            shapeGameObject.transform.rotation = transform.rotation;
                            shapeGameObject.transform.SetParent(gameObject.transform);

                            boxShapeCount++;
                        }
                    }
                    else if (shapeType == GeoTriggerTrap_ShapeType.Path)
                    {
                        for (byte shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
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

                            shapeGameObject.transform.localScale = Vector3.one;

                            ////TODO add nodes and edges when the class gets out
                            //EntityHandle prevNodeHandle;
                            //for (int pointIndex = 0; pointIndex < pointCount; pointIndex++)
                            //{
                            //    var nodePos = reader.ReadVector3();
                            //    reader.Skip(4);

                            //    var nodeFoxEntity = new GraphxSpatialGraphDataNode();
                            //    var nodeFoxHandle = EntityHandle.Get(nodeFoxEntity);
                            //    var nodeFoxPtr = new EntityPtr<GraphxSpatialGraphDataNode>(nodeFoxEntity);
                            //    nodeFoxEntity.owner=shapeFoxPtr;

                            //    if (pointIndex == 0)
                            //    {
                            //        shapeGameObject.transform.position = Kernel.Math.FoxToUnityVector3(nodePos);
                            //        nodeFoxEntity.position = new Vector3(0, nodePos.y - shapeGameObject.transform.position.y, 0);
                            //    }
                            //    else
                            //        nodeFoxEntity.position = nodePos - Kernel.Math.UnityToFoxVector3(shapeGameObject.transform.position);

                            //    //How does one SetProperty on a DynamicArray container type?
                            //    shapeFoxEntity.SetPropertyElement(new String("nodes"), (ushort)pointIndex, new Value(nodeFoxPtr));

                            //    var edgeFoxEntity = new GraphxSpatialGraphDataEdge();
                            //    edgeFoxEntity.owner = shapeFoxPtr;
                            //    var edgeFoxPtr = new EntityPtr<GraphxSpatialGraphDataEdge>(edgeFoxEntity);

                            //    if (pointIndex > 0)
                            //    {
                            //        edgeFoxEntity.prevNode = prevNodeHandle;
                            //    }

                            //    if (pointIndex < pointCount - 1)
                            //    {
                            //        edgeFoxEntity.nextNode = nodeFoxHandle;
                            //        prevNodeHandle = nodeFoxHandle;
                            //    }

                            //    shapeFoxEntity.SetPropertyElement(new String("edges"), (ushort)pointIndex, new Value(edgeFoxPtr));
                            //}

                            shapeGameObject.transform.SetParent(gameObject.transform);

                            shapeFoxEntity.SetProperty(new String("parent"), new Value(EntityHandle.Get(geoTriggerTrapEntity)));

                            pathShapeCount++;
                        }
                    }
                }
            }

            return scene;
        }
    }
    */
}
