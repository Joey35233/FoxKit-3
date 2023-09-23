using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using Fox.Kernel;
using UnityEditor.SceneManagement;
using UnityEngine;
using Transform = UnityEngine.Transform;

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

            if (foxDataHeader.GetFirstNode() is not { } dataNode)
                return null;

            Debug.Assert(dataNode.GetFlags() == 1);
            Debug.Assert(dataNode.GetNextNode() == null);
            Debug.Assert(dataNode.GetChildNode() == null);

            if (dataNode.GetDataPosition() is not { } dataPosition)
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
                        GeoTriggerTrap triggerTrap = new GameObject(header.Name.ToString()).AddComponent<GeoTriggerTrap>();
                        triggerTrap.enable = true;
                        triggerTrap.groupTags = TagUtils.GetEnumTags<GeoTriggerTrap.Tags>((ulong)header.GetTags<GeoTriggerTrap.Tags>());
                        triggerTrap.SetTransform(TransformEntity.GetDefault());

                        for (int j = 0; j < header.PrimCount; j++)
                        {
                            reader.Seek(header.GetDataPosition() + (96 * j));

                            BoxShape shape = new GameObject($"BoxShape{j:D4}").AddComponent<BoxShape>();
                            shape.size = reader.ReadScaleHF();

                            Vector4 padding = reader.ReadVector4();
                            Debug.Assert(padding == Vector4.zero);
                            Matrix4x4 matrix = reader.ReadMatrix4F();

                            TransformEntity transform = new GameObject().AddComponent<TransformEntity>();
                            transform.rotQuat = matrix.rotation;
                            transform.translation = matrix.GetPosition();
                            shape.SetTransform(transform);

                            triggerTrap.AddChild(shape);
                        }
                    }
                    else if (header.Type == GeoPrimType.AreaPath && GeomHeaderContext.Deserialize(header) is { } trap)
                    {
                        (trap as MonoBehaviour).name = header.Name.ToString();

                        for (int j = 0; j < (trap as MonoBehaviour).transform.childCount; j++)
                            (trap as MonoBehaviour).transform.gameObject.name = $"GeoxTrapAreaPath{j:D4}";
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
