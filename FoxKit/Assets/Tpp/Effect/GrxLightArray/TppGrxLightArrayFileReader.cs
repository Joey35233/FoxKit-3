using Fox.Core;
using Fox.Fio;
using Fox.Kernel;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Tpp.Effect
{
    public class TppGrxLightArrayFileReader
    {
        public UnityEngine.SceneManagement.Scene? Read(FileStreamReader reader)
        {
            UnityEngine.SceneManagement.Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            // Read header
            uint signature = reader.ReadUInt32(); //FGxL or FGxO
            if (signature != 1282950982)
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
                    case "LP00": // rlc Light Probe - unlike LightProbe???
                        Debug.Assert(false);
                        break;
                    case "EP00": // rlc LightProbe
                        ReadLightProbe(reader);
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

            uint padding = reader.ReadUInt32();
            Debug.Assert(padding == 0);

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
                var locator = (Locator)(gameObject.AddComponent<FoxEntity>().Entity = new Locator());
                locator.size = 1;

                locator.SetTransform(transform);

                locator.InitializeGameObject(gameObject);

                return gameObject;
            }

            return null;
        }

        public void ReadLightProbe(FileStreamReader reader)
        {
            var lightGameObject = new GameObject();

            var lightEntity = (TppLightProbe)(lightGameObject.AddComponent<FoxEntity>().Entity = new TppLightProbe());
            lightEntity.name = new String(ReadName(reader));

            uint localFlags = reader.ReadUInt32();
            lightEntity.enable = FlagUtils.GetFlag(localFlags, 0);
            lightEntity.enable24hSH = FlagUtils.GetFlag(localFlags, 1);
            lightEntity.enableWeatherSH = FlagUtils.GetFlag(localFlags, 2);
            lightEntity.enableRelatedLightSH = FlagUtils.GetFlag(localFlags, 3);
            lightEntity.enableOcclusionMode = FlagUtils.GetFlag(localFlags, 4);

            lightEntity.shapeType = (TppLightProbe.TppLightProbe_ShapeType)reader.ReadUInt16();

            reader.Align(4);

            // Switched x scale for endianness
            lightEntity.innerScaleXNegative = reader.ReadHalf(); // innerScaleXPositive
            lightEntity.innerScaleYPositive = reader.ReadHalf();
            lightEntity.innerScaleZPositive = reader.ReadHalf();
            lightEntity.innerScaleXPositive = reader.ReadHalf(); // innerScaleXNegative
            lightEntity.innerScaleYNegative = reader.ReadHalf();
            lightEntity.innerScaleZNegative = reader.ReadHalf();

            var transform = new TransformEntity { scale = reader.ReadVector3(), rotQuat = reader.ReadRotationF(), translation = reader.ReadPositionF() };
            lightEntity.SetTransform(transform);
            lightEntity.InitializeGameObject(lightGameObject);

            uint innerAreaOffset = reader.ReadUInt32();
            if (innerAreaOffset != 0)
            {
                var iaTransform = new Fox.Core.Transform { scale = reader.ReadVector3(), rotation_quat = reader.ReadRotationF(), translation = reader.ReadPositionF() };

                Vector3 localIaPos = iaTransform.translation - transform.translation;
                var absIaScale = new Vector3(Mathf.Abs(iaTransform.scale.x), Mathf.Abs(iaTransform.scale.y), Mathf.Abs(iaTransform.scale.z));
                var posProbeScale = new Vector3(Mathf.Abs(transform.scale.x), Mathf.Abs(transform.scale.y), Mathf.Abs(transform.scale.z));
                Vector3 negProbeScale = -posProbeScale;

                Vector3 iaUpper = localIaPos + absIaScale;
                Vector3 iaLower = localIaPos - absIaScale;

                Vector3 iaMid = iaLower + iaUpper;

                var numP = Vector3.Max(localIaPos + absIaScale - iaMid, posProbeScale);

                var numN = Vector3.Min(localIaPos - absIaScale - iaMid, negProbeScale);

                lightEntity.innerScaleXPositive = numP.x / posProbeScale.x;
                lightEntity.innerScaleXNegative = numN.x / negProbeScale.x;

                lightEntity.innerScaleXPositive = numP.y / posProbeScale.y;
                lightEntity.innerScaleXNegative = numN.y / negProbeScale.y;

                lightEntity.innerScaleXPositive = numP.z / posProbeScale.z;
                lightEntity.innerScaleXNegative = numN.z / negProbeScale.z;
            }

            lightEntity.priority = reader.ReadInt16();

            _ = reader.ReadUInt16();

            _ = reader.ReadUInt16();

            _ = reader.ReadUInt16();

            if (lightEntity.enableOcclusionMode)
                lightEntity.occlusionModeOpenRate = reader.ReadSingle();
            else
                reader.Skip(4);
        }
    }
}
