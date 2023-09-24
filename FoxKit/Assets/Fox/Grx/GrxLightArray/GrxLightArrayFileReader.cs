using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using Fox.Kernel;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Fox.Grx
{
    public class GrxLightArrayFileReader
    {
        private readonly TaskLogger logger = new TaskLogger("ImportGRXLA");
        public UnityEngine.SceneManagement.Scene? Read(FileStreamReader reader)
        {
            UnityEngine.SceneManagement.Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            // Read header
            uint signature = reader.ReadUInt32(); //FGxL or FGxO
            if (signature is not 1282950982 and not 1333282630)
            {
                Debug.LogError("Wrong GrxLA signature, not a GrxLA file?");
                return null;
            }

            uint padding = reader.ReadUInt32();
            Debug.Assert(padding == 0);

            long nextLightOffset = reader.ReadUInt32();
            long lightPosition = nextLightOffset;

            uint version = reader.ReadUInt32();
            Debug.Assert(version == 1);

            while (true)
            {
                reader.Seek(lightPosition);

                string lightType = new(reader.ReadChars(4));

                nextLightOffset = reader.ReadInt32();
                lightPosition += nextLightOffset;

                switch (lightType)
                {
                    case "CM00": //rlc Header entry type; at the start of every file
                        break;
                    case "\0\0\0\0":
                        return scene;
                    case "DL00": // rlc Directional Light - does it even exist?
                        Debug.Assert(false);
                        break;
                    case "PL01": // rlc PointLight GZ TPP
                    case "PL02":
                    case "PL03":
                        ReadPointLight(reader);
                        break;
                    case "SL01": // rlc SpotLight GZ TPP
                    case "SL02":
                    case "SL03":
                        ReadSpotLight(reader);
                        break;
                    case "OC00": // Occluder entry (.grxoc)
                        ReadOccluder(reader);
                        break;
                    default:
                        Debug.LogError($"Unknown GrxLA light type at {reader.BaseStream.Position}.");
                        return null;
                }
            }
        }

        private string ReadName(FileStreamReader reader)
        {
            StrCode hash = reader.ReadStrCode();
            long offsetPos = reader.BaseStream.Position;
            uint stringOffset = reader.ReadUInt32();

            reader.Seek(offsetPos + stringOffset);

            string result = stringOffset == 0 ? hash.ToString() : reader.ReadNullTerminatedCString();

            reader.Seek(offsetPos + 4);

            uint padding = reader.ReadUInt32();
            Debug.Assert(padding == 0);

            return result;
        }

        private static TransformEntity ReadTransform(FileStreamReader reader)
        {
            long rewindPos = reader.BaseStream.Position;

            TransformEntity transform = null;

            uint offset = reader.ReadUInt32();
            if (offset > 0)
            {
                reader.Seek(rewindPos + offset);

                transform = new GameObject().AddComponent<TransformEntity>();
                transform.scale = reader.ReadVector3();
                transform.rotQuat = reader.ReadRotationF();
                transform.translation = reader.ReadPositionF();
            }

            reader.Seek(rewindPos + 4);

            return transform;
        }

        private Locator ReadLocator(FileStreamReader reader)
        {
            if (ReadTransform(reader) is { } transform)
            {
                Locator locator = new GameObject().AddComponent<Locator>();
                locator.size = 1;

                locator.SetTransform(transform);

                return locator;
            }

            return null;
        }

        private void ReadPointLight(FileStreamReader reader)
        {
            PointLight pointLight = new GameObject(ReadName(reader)).AddComponent<PointLight>();

            uint lightFlags = reader.ReadUInt32();
            pointLight.enable = FlagUtils.GetFlag(lightFlags, 0);
            pointLight.castShadow = FlagUtils.GetFlag(lightFlags, 1);
            pointLight.hasSpecular = FlagUtils.GetFlag(lightFlags, 3);

            _ = reader.ReadUInt32();

            if (ReadLocator(reader) is { } lightArea)
            {
                lightArea.name = new String(pointLight.name + "_LA");
                pointLight.lightArea = new EntityLink
                (
                    EntityHandle.Get(lightArea),
                    new Kernel.Path(""),
                    new Kernel.Path(""),
                    lightArea.name
                );
            }

            {
                TransformEntity transform = new GameObject().AddComponent<TransformEntity>();
                transform.scale = Vector3.one;
                transform.rotQuat = Quaternion.identity;
                transform.translation = reader.ReadPositionF();
                pointLight.SetTransform(transform);
            }

            pointLight.outerRange = reader.ReadHalf();
            pointLight.innerRange = reader.ReadHalf();
            pointLight.dimmer = reader.ReadHalf();
            pointLight.color = new Color(reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf());
            pointLight.temperature = reader.ReadHalf();
            pointLight.colorDeflection = reader.ReadHalf();

            reader.Align(4);

            pointLight.lumen = reader.ReadSingle();
            pointLight.lightSize = reader.ReadHalf();
            pointLight.shadowBias = reader.ReadHalf();
            pointLight.LodShadowDrawRate = reader.ReadHalf();
            pointLight.LodFarSize = reader.ReadHalf();
            pointLight.LodNearSize = reader.ReadHalf();

            reader.Align(4);

            pointLight.lodRadiusLevel = (PointLight_LodRadiusLevel)reader.ReadInt32();
            pointLight.lodFadeType = (byte)reader.ReadInt32();

            pointLight.reachPoint = new Vector3(0, -pointLight.outerRange, 0);

            if (ReadLocator(reader) is { } irradiationPoint)
            {
                irradiationPoint.name = new String(pointLight.name + "_IP");
                pointLight.lightArea = new EntityLink
                (
                    EntityHandle.Get(irradiationPoint),
                    new Kernel.Path(""),
                    new Kernel.Path(""),
                    irradiationPoint.name
                );
            }
        }

        private void ReadSpotLight(FileStreamReader reader)
        {
            SpotLight spotLight = new GameObject(ReadName(reader)).AddComponent<SpotLight>();

            uint lightFlags = reader.ReadUInt32();
            spotLight.enable = FlagUtils.GetFlag(lightFlags, 0);
            spotLight.castShadow = FlagUtils.GetFlag(lightFlags, 1);
            spotLight.hasSpecular = FlagUtils.GetFlag(lightFlags, 3);

            _ = reader.ReadUInt32();

            if (ReadLocator(reader) is { } lightArea)
            {
                lightArea.name = new String(spotLight.name + "_LA");
                spotLight.lightArea = new EntityLink
                (
                    EntityHandle.Get(lightArea),
                    new Kernel.Path(""),
                    new Kernel.Path(""),
                    lightArea.name
                );
            }

            {
                Vector3 position = reader.ReadPositionF();
                spotLight.reachPoint = reader.ReadPositionF();

                TransformEntity transform = new GameObject().AddComponent<TransformEntity>();
                transform.scale = Vector3.one;
                transform.rotQuat = reader.ReadRotationF();
                transform.translation = position;
                spotLight.SetTransform(transform);
            }

            spotLight.outerRange = reader.ReadHalf();
            spotLight.innerRange = reader.ReadHalf();
            spotLight.umbraAngle = reader.ReadHalf();
            spotLight.penumbraAngle = reader.ReadHalf();
            spotLight.attenuationExponent = reader.ReadHalf();

            spotLight.dimmer = reader.ReadHalf();
            spotLight.color = new Color(reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf());
            spotLight.temperature = reader.ReadHalf();
            spotLight.colorDeflection = reader.ReadHalf();
            spotLight.lumen = reader.ReadSingle();

            spotLight.lightSize = reader.ReadHalf();

            spotLight.shadowUmbraAngle = reader.ReadHalf();
            spotLight.shadowPenumbraAngle = reader.ReadHalf();
            spotLight.shadowAttenuationExponent = reader.ReadHalf();

            spotLight.shadowBias = reader.ReadHalf();
            spotLight.viewBias = reader.ReadHalf();

            spotLight.LodShadowDrawRate = reader.ReadHalf();

            spotLight.LodFarSize = reader.ReadHalf();
            spotLight.LodNearSize = reader.ReadHalf();

            reader.Align(4);

            spotLight.powerScale = 1;

            spotLight.lodRadiusLevel = (SpotLight_LodRadiusLevel)reader.ReadInt32();
            spotLight.lodFadeType = (byte)reader.ReadInt32();

            if (ReadLocator(reader) is { } irradiationPoint)
            {
                irradiationPoint.name = new String(spotLight.name + "_IP");
                spotLight.irradiationPoint = new EntityLink
                (
                    EntityHandle.Get(irradiationPoint),
                    new Kernel.Path(""),
                    new Kernel.Path(""),
                    irradiationPoint.name
                );
            }
        }

        private void ReadOccluder(FileStreamReader reader)
        {
            OccluderEx occluder = new GameObject(ReadName(reader)).AddComponent<OccluderEx>();

            _ = reader.ReadInt32();

            _ = reader.ReadInt32();
            uint faceCount = reader.ReadUInt32();

            _ = reader.ReadInt32();
            uint nodeCount = reader.ReadUInt32();

            var nodes = new Vector3[nodeCount];
            for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
                nodes[nodeIndex] = reader.ReadPositionHF();

            for (int faceIndex = 0; faceIndex < faceCount; faceIndex++)
            {
                _ = reader.ReadInt16();

                _ = reader.ReadInt16();

                _ = reader.ReadInt16();

                _ = reader.ReadInt16();
            }

            //do
        }
    }
}
