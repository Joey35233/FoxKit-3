using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using Fox;
using UnityEditor.SceneManagement;
using UnityEngine;
using System;

namespace Tpp.Effect
{
    public class TppGrxLightArrayFileReader
    {
        private readonly TaskLogger logger = new TaskLogger("ImportGRXLA");

        public UnityEngine.SceneManagement.Scene? Read(FileStreamReader reader)
        {
            UnityEngine.SceneManagement.Scene scene;
            try
            {
                scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
            }
            catch (InvalidOperationException)
            {
                scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            }
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
            TppLightProbe lightProbe = new GameObject(ReadName(reader)).AddComponent<TppLightProbe>();
            lightProbe.SetTransform(TransformEntity.GetDefault());

            uint localFlags = reader.ReadUInt32();
            lightProbe.Enable = FlagUtils.GetFlag(localFlags, 0);
            lightProbe.enable24hSH = FlagUtils.GetFlag(localFlags, 1);
            lightProbe.enableWeatherSH = FlagUtils.GetFlag(localFlags, 2);
            lightProbe.enableRelatedLightSH = FlagUtils.GetFlag(localFlags, 3);
            lightProbe.enableOcclusionMode = FlagUtils.GetFlag(localFlags, 4);

            lightProbe.ShapeType = (TppLightProbe.TppLightProbe_ShapeType)reader.ReadUInt16();

            reader.Align(4);

            // Switched x scale for endianness
            lightProbe.InnerScaleXNegative = reader.ReadHalf(); // innerScaleXPositive
            lightProbe.InnerScaleYPositive = reader.ReadHalf();
            lightProbe.InnerScaleZPositive = reader.ReadHalf();
            lightProbe.InnerScaleXPositive = reader.ReadHalf(); // innerScaleXNegative
            lightProbe.InnerScaleYNegative = reader.ReadHalf();
            lightProbe.InnerScaleZNegative = reader.ReadHalf();

            lightProbe.transform.localScale = reader.ReadVector3();
            lightProbe.transform.rotation = reader.ReadRotationF();
            lightProbe.transform.position = reader.ReadPositionF();

            uint innerAreaOffset = reader.ReadUInt32();
            if (innerAreaOffset != 0)
            {
                Vector3 iaScale = reader.ReadVector3();
                _ = reader.ReadRotationF();
                Vector3 iaTranslation = reader.ReadPositionF();

                Vector3 localIaPos = iaTranslation - lightProbe.transform.position;
                var absIaScale = new Vector3(Mathf.Abs(iaScale.x), Mathf.Abs(iaScale.y), Mathf.Abs(iaScale.z));
                var posProbeScale = new Vector3(Mathf.Abs(lightProbe.transform.localScale.x), Mathf.Abs(lightProbe.transform.localScale.y), Mathf.Abs(lightProbe.transform.localScale.z));
                Vector3 negProbeScale = -posProbeScale;

                Vector3 iaUpper = localIaPos + absIaScale;
                Vector3 iaLower = localIaPos - absIaScale;

                Vector3 iaMid = iaLower + iaUpper;

                var numP = Vector3.Max(localIaPos + absIaScale - iaMid, posProbeScale);

                var numN = Vector3.Min(localIaPos - absIaScale - iaMid, negProbeScale);

                lightProbe.InnerScaleXPositive = numP.x / posProbeScale.x;
                lightProbe.InnerScaleXNegative = numN.x / negProbeScale.x;

                lightProbe.InnerScaleXPositive = numP.y / posProbeScale.y;
                lightProbe.InnerScaleXNegative = numN.y / negProbeScale.y;

                lightProbe.InnerScaleXPositive = numP.z / posProbeScale.z;
                lightProbe.InnerScaleXNegative = numN.z / negProbeScale.z;
            }

            lightProbe.Priority = reader.ReadInt16();

            _ = reader.ReadUInt16();

            _ = reader.ReadUInt16();

            _ = reader.ReadUInt16();

            if (lightProbe.enableOcclusionMode)
                lightProbe.OcclusionModeOpenRate = reader.ReadSingle();
            else
                reader.Skip(4);
        }
    }
}
