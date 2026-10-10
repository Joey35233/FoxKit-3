using Fox.Core;
using Fox.Geo;
using static Fox.Geo.GeoGeom;
using System;
using UnityEditor.AssetImporters;
using UnityEngine;

namespace Fox.Geox
{
    [ScriptedImporter(100, "trap")]
    public unsafe class GeoTrapFileReader : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext context)
        {
            var main = new GameObject(global::System.IO.Path.GetFileName(context.assetPath));

            if (!Read(global::System.IO.File.ReadAllBytes(assetPath), main))
                context.LogImportError("TRAP import failed.");

            context.AddObjectToAsset(main.name, main);
            context.SetMainObject(main);
        }

        // Shared reading: walks the file and builds the traps under `parent`. Used by both this
        // ScriptedImporter (parent = asset root) and the FoxKit/Import/GeoTrapFile menu (parent = scene root).
        public static bool Read(ReadOnlySpan<byte> fileData, GameObject parent)
        {
            if (fileData.IsEmpty || fileData.Length < sizeof(FoxDataHeader))
                return false;

            fixed (byte* data = fileData)
            {
                var header = (FoxDataHeader*)data;

                if (header->Version != 201406020)
                    return false;

                for (FoxDataNode* node = header->GetNodes(); node != null; node = node->GetNext())
                {
                    byte* shapeTable = node->GetData();
                    if (shapeTable == null)
                        continue;

                    uint shapeCount = (uint)node->ParametersOffset;
                    for (uint i = 0; i < shapeCount; i++)
                    {
                        GeomHeader* geomHeader = (GeomHeader*)(shapeTable + ((uint*)shapeTable)[i]);

                        GeoPrimType type = (GeoPrimType)(geomHeader->Info & 0xF);
                        switch (type)
                        {
                            case GeoPrimType.Box:
                                ReadBox(geomHeader, parent);
                                break;
                            case GeoPrimType.FreeArea:
                                GeoxTrapAreaPath.Deserialize((IntPtr)geomHeader, parent);
                                break;
                            default:
                                Debug.LogError($"GeoTrapFile: unsupported prim type {type}");
                                break;
                        }
                    }
                }
            }

            return true;
        }

        private static void ReadBox(GeomHeader* geomHeader, GameObject parent)
        {
            byte primCount = (byte)(geomHeader->Info >> 24 & 0xFF);

            GeoTriggerTrap triggerTrap = new GameObject(geomHeader->Name.ToString()).AddComponent<GeoTriggerTrap>();
            triggerTrap.transform.parent = parent.transform;
            triggerTrap.enable = true;
            TagUtils.AddEnumTags<GeoTriggerTrap.Tags>(triggerTrap.groupTags, (ulong)geomHeader->Tags);
            triggerTrap.SetTransform(TransformEntity.GetDefault());

            byte* payload = (byte*)(geomHeader + 1);
            for (int j = 0; j < primCount; j++)
            {
                byte* prim = payload + (96 * j);

                BoxShape shape = new GameObject($"{triggerTrap.name}|BoxShape{j:D4}").AddComponent<BoxShape>();
                shape.SetTransform(TransformEntity.GetDefault());

                shape.transform.localScale = (*(Vector3*)prim) * 2;

                Matrix4x4 matrix = Fox.Math.FoxToUnityMatrix(*(Matrix4x4*)(prim + 32));
                shape.transform.rotation = matrix.rotation;
                shape.transform.position = matrix.GetPosition();

                triggerTrap.AddChild(shape);
            }
        }
    }
}
