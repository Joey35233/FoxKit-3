using Fox.Core;
using System;
using System.IO;
using UnityEditor.SceneManagement;
using UnityEngine;
using static UnityEngine.Debug;

namespace Fox.Geo
{
    public class GeoTrapFileReader
    {
        public UnityEngine.SceneManagement.Scene Read(BinaryReader reader)
        {
            // Header
            uint version = reader.ReadUInt32();
            Assert(version == 201406020);

            uint entryDefinitionsOffset = reader.ReadUInt32();
            uint fileSize = reader.ReadUInt32();
            uint dataSetName = reader.ReadUInt32(); // TODO HASH

            reader.BaseStream.Position = entryDefinitionsOffset;

            // EntryDefinitions
            reader.BaseStream.Position += 8;

            Assert(reader.ReadUInt32() == 1);

            uint offsetsOffset = reader.ReadUInt32(); Assert(offsetsOffset == 48);

            Assert(reader.ReadUInt32() == fileSize + 16);

            reader.BaseStream.Position += 16;

            uint entryCount = reader.ReadUInt32();

            // EntryDefinitions.Offsets
            reader.BaseStream.Position = entryDefinitionsOffset + offsetsOffset;

            uint[] offsets = new uint[entryCount];
            for (uint i = 0; i < entryCount; i++)
            {
                offsets[i] = reader.ReadUInt32();
            }
            
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            uint boxShapeCount = 0;
            uint pathShapeCount = 0;

            // Entries
            for (uint i = 0; i < entryCount; i++)
            {
                reader.BaseStream.Position = entryDefinitionsOffset + offsetsOffset + offsets[i];

                var gameObject = new GameObject();
                gameObject.name = $"GeoTriggerTrap{i.ToString("D4")}";
                var foxEntityComponent = gameObject.AddComponent<FoxEntity>();
                GeoTriggerTrap geoTriggerTrapEntity = (GeoTriggerTrap)(foxEntityComponent.Entity = new GeoTriggerTrap());

                uint flags = reader.ReadUInt32();
                geoTriggerTrapEntity.enable = (flags & 0x01) == 1 ? true : false;
                // No idea what flags[1] is .
                GeoTriggerTrap_ShapeType shapeType = (GeoTriggerTrap_ShapeType)((flags >> 3) & 0x03);
                Assert(((flags >> 8) & 0xFFFF) == 0x8000);
                byte shapeCount = (byte)((flags >> 24) & 0xFF);

                reader.BaseStream.Position += 12;

                GeoTriggerTrap_Tags tags = (GeoTriggerTrap_Tags)reader.ReadUInt64();

                uint hash = reader.ReadUInt32();

                reader.BaseStream.Position += 4;

                if (shapeType == GeoTriggerTrap_ShapeType.Box)
                {
                    for (byte j = 0; j < shapeCount; j++)
                    {
                        var shapeGameObject = new GameObject();
                        shapeGameObject.name = $"BoxShape{boxShapeCount.ToString("D4")}";
                        var shapeFoxEntityComponent = shapeGameObject.AddComponent<FoxEntity>();
                        BoxShape boxShapeEntity = (BoxShape)(shapeFoxEntityComponent.Entity = new BoxShape());

                        Vector4 scale = new Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

                        reader.BaseStream.Position += 16;

                        var colMat = new Matrix4x4(new Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()), new Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()), new Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()), new Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()));
                        Matrix4x4 transform = colMat;

                        shapeGameObject.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                        shapeGameObject.transform.position = FoxKit.FoxUtils.UnityVectorFromFoxCoordinates(transform.GetPosition());
                        shapeGameObject.transform.rotation = FoxKit.FoxUtils.UnityQuaternionFromFoxCoordinates(transform.rotation);
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
                        float yMax = reader.ReadSingle();

                        var shapeGameObject = new GameObject();
                        shapeGameObject.name = $"GeoxTrapAreaPath{pathShapeCount.ToString("D4")}";
                        var shapeFoxEntityComponent = shapeGameObject.AddComponent<FoxEntity>();
                        // Geox.GeoxTrapAreaPath trapAreaPathEntity = (Geox.GeoxTrapAreaPath)(shapeFoxEntityComponent.Entity = new Geox.GeoxTrapAreaPath());

                        uint pointCount = reader.ReadUInt32();
                        uint pointsOffset = reader.ReadUInt32();

                        reader.BaseStream.Position = selfPosition + pointsOffset;

                        for (uint h = 0; h < pointCount; h++)
                        {
                            var nodeGameObject = new GameObject();
                            nodeGameObject.transform.position = new Vector3(-reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                            shapeGameObject.transform.SetParent(shapeGameObject.transform, true);
                        }

                        pathShapeCount++;
                    }
                }
            }

            return scene;
        }
    }
}
