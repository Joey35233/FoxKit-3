using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using Fox;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Tpp.Effect
{
    public class TppGrxLightArrayFileReader
    {
        private readonly TaskLogger logger = new TaskLogger("ImportGRXLA");

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

        private void ReadLightProbe(FileStreamReader reader)
        {
            var lightGameObject = new GameObject();

            TppLightProbe lightProbe = new GameObject(ReadName(reader)).AddComponent<TppLightProbe>();

            uint localFlags = reader.ReadUInt32();
            lightProbe.enable = FlagUtils.GetFlag(localFlags, 0);
            lightProbe.enable24hSH = FlagUtils.GetFlag(localFlags, 1);
            lightProbe.enableWeatherSH = FlagUtils.GetFlag(localFlags, 2);
            lightProbe.enableRelatedLightSH = FlagUtils.GetFlag(localFlags, 3);
            lightProbe.enableOcclusionMode = FlagUtils.GetFlag(localFlags, 4);

            lightProbe.shapeType = (TppLightProbe.TppLightProbe_ShapeType)reader.ReadUInt16();

            reader.Align(4);

            // Switched x scale for endianness
            lightProbe.innerScaleXNegative = reader.ReadHalf(); // innerScaleXPositive
            lightProbe.innerScaleYPositive = reader.ReadHalf();
            lightProbe.innerScaleZPositive = reader.ReadHalf();
            lightProbe.innerScaleXPositive = reader.ReadHalf(); // innerScaleXNegative
            lightProbe.innerScaleYNegative = reader.ReadHalf();
            lightProbe.innerScaleZNegative = reader.ReadHalf();

            TransformEntity transform = new GameObject().AddComponent<TransformEntity>();
            transform.scale = reader.ReadVector3();
            transform.rotQuat = reader.ReadRotationF();
            transform.translation = reader.ReadPositionF();
            lightProbe.SetTransform(transform);

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

                lightProbe.innerScaleXPositive = numP.x / posProbeScale.x;
                lightProbe.innerScaleXNegative = numN.x / negProbeScale.x;

                lightProbe.innerScaleXPositive = numP.y / posProbeScale.y;
                lightProbe.innerScaleXNegative = numN.y / negProbeScale.y;

                lightProbe.innerScaleXPositive = numP.z / posProbeScale.z;
                lightProbe.innerScaleXNegative = numN.z / negProbeScale.z;
            }

            lightProbe.priority = reader.ReadInt16();

            _ = reader.ReadUInt16();

            _ = reader.ReadUInt16();

            _ = reader.ReadUInt16();

            if (lightProbe.enableOcclusionMode)
                lightProbe.occlusionModeOpenRate = reader.ReadSingle();
            else
                reader.Skip(4);
        }
    }
}
