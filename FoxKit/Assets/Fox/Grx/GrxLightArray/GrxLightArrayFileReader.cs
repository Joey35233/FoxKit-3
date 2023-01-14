using Fox.Core;
using Fox.Fio;
using Fox.Kernel;
using System.IO;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Fox.Grx
{
    public class GrxLightArrayFileReader
    {
        public UnityEngine.SceneManagement.Scene? Read(FileStreamReader reader)
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            // Read header
            uint signature = reader.ReadUInt32(); //FGxL or FGxO
            if (signature != 1282950982 && signature != 1333282630)
            {
                Debug.LogError("Wrong GrxLA signature, not a GrxLA file?");
                return null;
            }

            uint padding = reader.ReadUInt32(); Debug.Assert(padding == 0);

            long nextLightOffset = reader.ReadUInt32();
            long lightPosition = nextLightOffset;

            uint version = reader.ReadUInt32(); Debug.Assert(version == 1);

            while (true)
            {
                reader.Seek(lightPosition);

                string lightType = new string(reader.ReadChars(4));

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

        public string ReadName(FileStreamReader reader)
        {
            StrCode hash = reader.ReadStrCode();
            long offsetPos = reader.BaseStream.Position;
            uint stringOffset = reader.ReadUInt32();

            reader.Seek(offsetPos + stringOffset);

            string result = stringOffset == 0 ? hash.ToString() : reader.ReadNullTerminatedCString();

            reader.Seek(offsetPos + 4);

            uint padding = reader.ReadUInt32(); Debug.Assert(padding == 0);

            return result;
        }

        public TransformEntity ReadTransform(FileStreamReader reader)
        {
            long rewindPos = reader.BaseStream.Position;

            TransformEntity transform = null;

            uint offset = reader.ReadUInt32();
            if (offset > 0)
            {
                reader.Seek(rewindPos + offset);

                transform = new TransformEntity { scale = reader.ReadVector3(), rotQuat = reader.ReadRotationF(), translation = reader.ReadPositionF() };
            }

            reader.Seek(rewindPos + 4);

            return transform;
        }

        public GameObject ReadLocator(FileStreamReader reader)
        {
            if (ReadTransform(reader) is TransformEntity transform)
            {
                var gameObject = new GameObject();
                Locator locator = (Locator)(gameObject.AddComponent<FoxEntity>().Entity = new Locator());
                locator.size = 1;

                locator.SetTransform(transform);

                locator.InitializeGameObject(gameObject);

                return gameObject;
            }

            return null;
        }

        public void ReadPointLight(FileStreamReader reader)
        {
            var lightGameObject = new GameObject();

            PointLight lightEntity = (PointLight)(lightGameObject.AddComponent<FoxEntity>().Entity = new PointLight());
            lightEntity.name = new String(ReadName(reader));

            uint lightFlags = reader.ReadUInt32();
            lightEntity.enable = FlagUtils.GetFlag(lightFlags, 0);
            lightEntity.castShadow = FlagUtils.GetFlag(lightFlags, 1);
            lightEntity.hasSpecular = FlagUtils.GetFlag(lightFlags, 3);

            uint UnknownFlags = reader.ReadUInt32();

            if (ReadLocator(reader) is GameObject lightArea)
            {
                Locator locator = lightArea.GetComponent<FoxEntity>().Entity as Locator;
                locator.name = new String(lightEntity.name + "_LA");
                lightEntity.lightArea = new EntityLink
                (
                    EntityHandle.Get(locator),
                    new Kernel.Path(""),
                    new Kernel.Path(""),
                    locator.name
                );
                lightArea.name = locator.name.CString;
            }

            TransformEntity transform = new TransformEntity { translation = reader.ReadPositionF(), rotQuat = Quaternion.identity, scale = Vector3.one };
            lightEntity.SetTransform(transform);
            lightEntity.InitializeGameObject(lightGameObject);

            lightEntity.outerRange = reader.ReadHalf();
            lightEntity.innerRange = reader.ReadHalf();
            lightEntity.dimmer = reader.ReadHalf();
            lightEntity.color = new Color(reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf());
            lightEntity.temperature = reader.ReadHalf();
            lightEntity.colorDeflection = reader.ReadHalf();

            reader.Align(4);

            lightEntity.lumen = reader.ReadSingle();
            lightEntity.lightSize = reader.ReadHalf();
            lightEntity.shadowBias = reader.ReadHalf();
            lightEntity.LodShadowDrawRate = reader.ReadHalf();
            lightEntity.LodFarSize = reader.ReadHalf();
            lightEntity.LodNearSize = reader.ReadHalf();

            reader.Align(4);

            lightEntity.lodRadiusLevel = (PointLight_LodRadiusLevel)reader.ReadInt32();
            lightEntity.lodFadeType = (byte)reader.ReadInt32();

            lightEntity.reachPoint = new Vector3(0, -lightEntity.outerRange, 0);

            if (ReadLocator(reader) is GameObject irradiationPoint)
            {
                Locator locator = irradiationPoint.GetComponent<FoxEntity>().Entity as Locator;
                locator.name = new String(lightEntity.name + "_IP");
                lightEntity.lightArea = new EntityLink
                (
                    EntityHandle.Get(locator),
                    new Kernel.Path(""),
                    new Kernel.Path(""),
                    locator.name
                );
                irradiationPoint.name = locator.name.CString;
                Object.DestroyImmediate(irradiationPoint.GetComponent<Core.BoxGizmo>());
            }
        }

        public void ReadSpotLight(FileStreamReader reader)
        {
            var lightGameObject = new GameObject();

            SpotLight lightEntity = (SpotLight)(lightGameObject.AddComponent<FoxEntity>().Entity = new SpotLight());
            lightEntity.name = new String(ReadName(reader));

            uint lightFlags = reader.ReadUInt32();
            lightEntity.enable = FlagUtils.GetFlag(lightFlags, 0);
            lightEntity.castShadow = FlagUtils.GetFlag(lightFlags, 1);
            lightEntity.hasSpecular = FlagUtils.GetFlag(lightFlags, 3);

            uint UnknownFlags = reader.ReadUInt32();

            if (ReadLocator(reader) is GameObject lightArea)
            {
                Locator locator = lightArea.GetComponent<FoxEntity>().Entity as Locator;
                locator.name = new String(lightEntity.name + "_LA");
                lightEntity.lightArea = new EntityLink
                (
                    EntityHandle.Get(locator),
                    new Kernel.Path(""),
                    new Kernel.Path(""),
                    locator.name
                );
                lightArea.name = locator.name.CString;
            }

            Vector3 position = reader.ReadPositionF();
            lightEntity.reachPoint = reader.ReadPositionF();
            TransformEntity transform = new TransformEntity { translation = position, rotQuat = reader.ReadRotationF(), scale = Vector3.one };
            lightEntity.SetTransform(transform);
            lightEntity.InitializeGameObject(lightGameObject);

            lightEntity.outerRange = reader.ReadHalf();
            lightEntity.innerRange = reader.ReadHalf();
            lightEntity.umbraAngle = reader.ReadHalf();
            lightEntity.penumbraAngle = reader.ReadHalf();
            lightEntity.attenuationExponent = reader.ReadHalf();

            lightEntity.dimmer = reader.ReadHalf();
            lightEntity.color = new Color(reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf());
            lightEntity.temperature = reader.ReadHalf();
            lightEntity.colorDeflection = reader.ReadHalf();
            lightEntity.lumen = reader.ReadSingle();

            lightEntity.lightSize = reader.ReadHalf();

            lightEntity.shadowUmbraAngle = reader.ReadHalf();
            lightEntity.shadowPenumbraAngle = reader.ReadHalf();
            lightEntity.shadowAttenuationExponent = reader.ReadHalf();

            lightEntity.shadowBias = reader.ReadHalf();
            lightEntity.viewBias = reader.ReadHalf();

            lightEntity.LodShadowDrawRate = reader.ReadHalf();

            lightEntity.LodFarSize = reader.ReadHalf();
            lightEntity.LodNearSize = reader.ReadHalf();

            reader.Align(4);

            lightEntity.powerScale = 1;

            lightEntity.lodRadiusLevel = (SpotLight_LodRadiusLevel)reader.ReadInt32();
            lightEntity.lodFadeType = (byte)reader.ReadInt32();

            if (ReadLocator(reader) is GameObject irradiationPoint)
            {
                Locator locator = irradiationPoint.GetComponent<FoxEntity>().Entity as Locator;
                locator.name = new String(lightEntity.name + "_IP");
                lightEntity.irradiationPoint = new EntityLink
                (
                    EntityHandle.Get(locator),
                    new Kernel.Path(""),
                    new Kernel.Path(""),
                    locator.name
                );
                irradiationPoint.name = locator.name.CString;
                Object.DestroyImmediate(irradiationPoint.GetComponent<Core.BoxGizmo>());
            }
        }

        public void ReadOccluder(FileStreamReader reader)
        {
            var lightGameObject = new GameObject();
            lightGameObject.name = ReadName(reader);

            OccluderEx occluderEntity = (OccluderEx)(lightGameObject.AddComponent<FoxEntity>().Entity = new OccluderEx());

            int unknown = reader.ReadInt32();
            int offsetToFaces = reader.ReadInt32();
            uint faceCount = reader.ReadUInt32();
            int offsetToNodes = reader.ReadInt32();
            uint nodeCount = reader.ReadUInt32();

            Vector3[] nodes = new Vector3[nodeCount];
            for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
                nodes[nodeIndex] = reader.ReadPositionHF();

            for (int faceIndex = 0; faceIndex < faceCount; faceIndex++)
            {
                short unk0 = reader.ReadInt16();
                short unk1 = reader.ReadInt16();
                short vertexIndex = reader.ReadInt16();
                short size = reader.ReadInt16();
            }

            //do
        }
    }
}
