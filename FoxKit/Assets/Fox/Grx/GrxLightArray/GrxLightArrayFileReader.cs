using Fox.Core;
using Fox.Fio;
using System;
using System.Diagnostics;
using System.IO;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Fox.Grx
{
    public class GrxLightArrayFileReader
    {
        public UnityEngine.SceneManagement.Scene Read(FileStreamReader reader)
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            // Read header
            uint signature = reader.ReadUInt32(); //FGxL or FGxO
            if (signature != 1282950982 && signature != 1333282630)
            {
                UnityEngine.Debug.LogError("Wrong GrxLA signature, not a GrxLA file?");
                return UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            }
            reader.Skip(12);

            for (int lightIndex = 0; reader.BaseStream.Position < reader.BaseStream.Length - 8; lightIndex++)
            {
                long startOfLightPos = reader.BaseStream.Position;
                string lightType = new string(reader.ReadChars(4));
                int lightSizeInBytes = reader.ReadInt32();
                switch(lightType)
                {
                    case "CM00": //rlc Header entry type; at the start of every file
                        break;
                    case "DL00": // rlc Directional Light - does it even exist?
                        break;
                    case "PL01": // rlc PointLight GZ TPP
                    case "PL02":
                    case "PL03":
                        ReadPointLight(reader, lightIndex);
                        break;
                    case "SL01": // rlc SpotLight GZ TPP
                    case "SL02":
                    case "SL03":
                        ReadSpotLight(reader, lightIndex);
                        break;
                    case "LP00": // rlc Light Probe - unlike LightProbe???
                        break;
                    case "EP00": // rlc LightProbe
                        ReadLightProbe(reader, lightIndex);
                        break;
                    case "OC00": // Occluder entry (.grxoc)
                        ReadOccluder(reader, lightIndex);
                        break;
                    default:
                        UnityEngine.Debug.LogError($"@{reader.BaseStream.Position} Unknown GrxLA light type");
                        return scene;
                }
                reader.Seek(startOfLightPos + lightSizeInBytes);
            }

            return scene;
        }
        public void ReadPointLight(FileStreamReader reader, int lightIndex)
        {
            var lightGameObject = new GameObject();
            lightGameObject.name = $"PointLight{lightIndex:D4}"; ;

            PointLight lightEntity = (PointLight)(lightGameObject.AddComponent<FoxEntity>().Entity = new PointLight());
            lightEntity.InitializeGameObject(lightGameObject);

            TransformEntity lightTransform = new TransformEntity();
            lightTransform.owner = EntityHandle.Get(lightEntity);
            lightEntity.transform = new EntityPtr<TransformEntity>(lightTransform);

            reader.Skip(8);
            long seekPos = reader.BaseStream.Position;
            int offsetToNameString = reader.ReadInt32();
            if (offsetToNameString > 0)
            {
                reader.Seek(seekPos + offsetToNameString);
                lightGameObject.name = reader.ReadNullTerminatedCString();
                reader.Seek(seekPos + 4);
            }

            //TODO flags
            uint flags = reader.ReadUInt32();
            uint lightFlags = reader.ReadUInt32();
            uint flags2 = reader.ReadUInt32();

            seekPos = reader.BaseStream.Position;
            int offsetToLightArea = reader.ReadInt32();
            if (offsetToLightArea > 0)
            {
                var lightAreaGameObject = new GameObject();
                lightAreaGameObject.name = lightGameObject.name + "_LA";
                Locator lightAreaEntity = (Locator)(lightAreaGameObject.AddComponent<FoxEntity>().Entity = new Locator());
                lightAreaEntity.size = 1;
                lightAreaEntity.InitializeGameObject(lightAreaGameObject);

                TransformEntity lightAreaTransform = new TransformEntity();
                lightAreaTransform.owner = EntityHandle.Get(lightAreaEntity);
                lightAreaEntity.transform = new EntityPtr<TransformEntity>(lightAreaTransform);

                reader.Seek(seekPos + offsetToLightArea);

                lightAreaGameObject.transform.localScale = reader.ReadVector3();
                lightAreaGameObject.transform.rotation = reader.ReadRotationF();
                lightAreaGameObject.transform.position = reader.ReadPositionF();

                lightEntity.lightArea = new EntityLink(
                    EntityHandle.Get(lightAreaEntity),
                    new Kernel.Path(""), 
                    new Kernel.Path(""), 
                    new Kernel.String(lightAreaGameObject.name)
                );

                reader.Seek(seekPos + 4);
            }

            lightGameObject.transform.position = reader.ReadPositionF();
            lightEntity.reachPoint = new Vector3(reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf());
            lightEntity.color = new Color(reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf());
            lightEntity.temperature = reader.ReadHalf();
            lightEntity.colorDeflection = reader.ReadSingle();
            lightEntity.lumen = reader.ReadSingle();
            lightEntity.lightSize = reader.ReadHalf();
            lightEntity.dimmer = reader.ReadHalf();
            lightEntity.shadowBias = reader.ReadHalf();
            lightEntity.LodFarSize = reader.ReadHalf();
            lightEntity.LodNearSize = reader.ReadHalf();
            lightEntity.LodShadowDrawRate = reader.ReadHalf();
            lightEntity.lodRadiusLevel = (PointLight_LodRadiusLevel)reader.ReadInt32();
            lightEntity.lodFadeType = (byte)reader.ReadInt32(); //byte int innit??

            seekPos = reader.BaseStream.Position;
            int offsetToIrraditationTransform = reader.ReadInt32();
            if (offsetToIrraditationTransform > 0)
            {
                var irradiationPointGameObject = new GameObject();
                irradiationPointGameObject.name = lightGameObject.name + "_IP";
                Locator irradiationPointEntity = (Locator)(irradiationPointGameObject.AddComponent<FoxEntity>().Entity = new Locator());
                irradiationPointEntity.size = 1;
                irradiationPointEntity.InitializeGameObject(irradiationPointGameObject);

                TransformEntity irradiationPointTransform = new TransformEntity();
                irradiationPointTransform.owner = EntityHandle.Get(irradiationPointEntity);
                irradiationPointEntity.transform = new EntityPtr<TransformEntity>(irradiationPointTransform);

                reader.Seek(seekPos + offsetToIrraditationTransform);

                irradiationPointGameObject.transform.localScale = reader.ReadVector3();
                irradiationPointGameObject.transform.rotation = reader.ReadRotationF();
                irradiationPointGameObject.transform.position = reader.ReadPositionF();

                lightEntity.irradiationPoint = new EntityLink(
                    EntityHandle.Get(irradiationPointEntity),
                    new Kernel.Path(""),
                    new Kernel.Path(""),
                    new Kernel.String(irradiationPointGameObject.name)
                );
            }
        }
        public void ReadSpotLight(FileStreamReader reader, int lightIndex)
        {
            var lightGameObject = new GameObject();
            lightGameObject.name = $"SpotLight{lightIndex.ToString("D4")}"; ;

            var lightComponent = lightGameObject.AddComponent<FoxEntity>();
            SpotLight lightEntity = (SpotLight)(lightComponent.Entity = new SpotLight());
            lightEntity.InitializeGameObject(lightGameObject);

            TransformEntity lightTransform = new TransformEntity();
            lightTransform.owner = EntityHandle.Get(lightEntity);
            lightEntity.transform = new EntityPtr<TransformEntity>(lightTransform);

            reader.Skip(8);
            long seekPos = reader.BaseStream.Position;
            int offsetToNameString = reader.ReadInt32();
            if (offsetToNameString > 0)
            {
                reader.Seek(seekPos + offsetToNameString);
                lightGameObject.name = reader.ReadNullTerminatedCString();
                reader.Seek(seekPos + 4);
            }

            //TODO flags
            uint flags = reader.ReadUInt32();
            uint lightFlags = reader.ReadUInt32();
            uint flags2 = reader.ReadUInt32();

            seekPos = reader.BaseStream.Position;
            int offsetToLightArea = reader.ReadInt32();
            if (offsetToLightArea > 0)
            {
                var lightAreaGameObject = new GameObject();
                lightAreaGameObject.name = lightGameObject.name + "_LA";
                Locator lightAreaEntity = (Locator)(lightAreaGameObject.AddComponent<FoxEntity>().Entity = new Locator());
                lightAreaEntity.size = 1;
                lightAreaEntity.InitializeGameObject(lightAreaGameObject);

                TransformEntity lightAreaTransform = new TransformEntity();
                lightAreaTransform.owner = EntityHandle.Get(lightAreaEntity);
                lightAreaEntity.transform = new EntityPtr<TransformEntity>(lightAreaTransform);

                reader.Seek(seekPos + offsetToLightArea);

                lightAreaGameObject.transform.localScale = reader.ReadVector3();
                lightAreaGameObject.transform.rotation = reader.ReadRotationF();
                lightAreaGameObject.transform.position = reader.ReadPositionF();

                lightEntity.lightArea = new EntityLink(
                    EntityHandle.Get(lightAreaEntity),
                    new Kernel.Path(""),
                    new Kernel.Path(""),
                    new Kernel.String(lightAreaGameObject.name)
                );

                reader.Seek(seekPos + 4);
            }
            lightGameObject.transform.position = reader.ReadPositionF();
            lightEntity.reachPoint = reader.ReadVector3();
            lightGameObject.transform.rotation = reader.ReadRotationF();

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
            lightEntity.powerScale = reader.ReadHalf();

            lightEntity.LodFarSize = reader.ReadHalf();
            lightEntity.LodNearSize = reader.ReadHalf();
            lightEntity.LodShadowDrawRate = reader.ReadHalf();
            lightEntity.lodRadiusLevel = (SpotLight_LodRadiusLevel)reader.ReadInt32();
            lightEntity.lodFadeType = (byte)reader.ReadInt32();

            seekPos = reader.BaseStream.Position;
            int offsetToIrraditationTransform = reader.ReadInt32();
            if (offsetToIrraditationTransform > 0)
            {
                var irradiationPointGameObject = new GameObject();
                irradiationPointGameObject.name = lightGameObject.name + "_IP";
                Locator irradiationPointEntity = (Locator)(irradiationPointGameObject.AddComponent<FoxEntity>().Entity = new Locator());
                irradiationPointEntity.size = 1;
                irradiationPointEntity.InitializeGameObject(irradiationPointGameObject);

                TransformEntity irradiationPointTransform = new TransformEntity();
                irradiationPointTransform.owner = EntityHandle.Get(irradiationPointEntity);
                irradiationPointEntity.transform = new EntityPtr<TransformEntity>(irradiationPointTransform);

                reader.Seek(seekPos + offsetToIrraditationTransform);

                irradiationPointGameObject.transform.localScale = reader.ReadVector3();
                irradiationPointGameObject.transform.rotation = reader.ReadRotationF();
                irradiationPointGameObject.transform.position = reader.ReadPositionF();

                lightEntity.irradiationPoint = new EntityLink(
                    EntityHandle.Get(irradiationPointEntity),
                    new Kernel.Path(""),
                    new Kernel.Path(""),
                    new Kernel.String(irradiationPointGameObject.name)
                );
            }
        }
        public void ReadLightProbe(FileStreamReader reader, int lightIndex)
        {
            //TppLightProbe is Tpp.Effect :sob:
            var lightGameObject = new GameObject();
            lightGameObject.name = $"TppLightProbe{lightIndex:D4}";

            reader.Skip(8);
            long seekPos = reader.BaseStream.Position;
            int offsetToNameString = reader.ReadInt32();
            if (offsetToNameString > 0)
            {
                reader.Seek(seekPos + offsetToNameString);
                lightGameObject.name = reader.ReadNullTerminatedCString();
                reader.Seek(seekPos + 4);
            }

            uint flags = reader.ReadUInt32();
            uint lightFlags = reader.ReadUInt32();
            uint flags2 = reader.ReadUInt32();

            float innerScaleXPositive = reader.ReadHalf();
            float innerScaleYPositive = reader.ReadHalf();
            float innerScaleZPositive = reader.ReadHalf();
            float innerScaleXNegative = reader.ReadHalf();
            float innerScaleYNegative = reader.ReadHalf();
            float innerScaleZNegative = reader.ReadHalf();

            Vector3 scale = reader.ReadVector3();
            Quaternion quat = reader.ReadQuaternion();
            Vector3 translation = reader.ReadPositionF();

            float unknown0 = reader.ReadSingle(); //translation's w?

            short priority = reader.ReadInt16();
            ushort shapeType = reader.ReadUInt16();
            ushort relatedLightIndex = reader.ReadUInt16(); // some other kind of index? sometimes it increases with entries, sometimes skips
            ushort shDataIndex = reader.ReadUInt16();

            float lightSize = reader.ReadSingle();
            float unknown1 = reader.ReadSingle();

            //do
        }
        public void ReadOccluder(FileStreamReader reader, int lightIndex)
        {
            var lightGameObject = new GameObject();
            lightGameObject.name = $"OccluderEx{lightIndex.ToString("D4")}"; ;

            OccluderEx occluderEntity = lightGameObject.AddComponent<FoxEntity>().Entity as OccluderEx;

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
