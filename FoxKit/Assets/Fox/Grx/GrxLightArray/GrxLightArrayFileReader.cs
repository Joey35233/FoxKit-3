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
                throw new ArgumentOutOfRangeException("Wrong signature!!! Not a FGx file?");
            reader.Skip(12);

            for (int lightIndex = 0; reader.BaseStream.Position<reader.BaseStream.Length; lightIndex++)
            {
                long startOfLightPos = reader.BaseStream.Position;
                string lightType = reader.ReadChars(4).ToString();
                int lightSizeInBytes = reader.ReadInt32();
                switch(lightType)
                {
                    case "CM00": //rlc Header entry type; at the start of every file
                        break;
                    case "": // rlc Terminator Entry; this will be at the end of every file
                        break;
                    case "DL00": // rlc Directional Light - does it even exist?
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
                    case "LP00": // rlc Light Probe - unlike LightProbe???
                        break;
                    case "EP00": // rlc LightProbe
                        ReadLightProbe(reader);
                        break;
                    case "OC00": // Occluder entry (.grxoc)
                        ReadOccluder(reader);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Unknown LightArrayEntry.lightType!!!!");
                }
                reader.Seek(startOfLightPos + lightSizeInBytes);
            }

            return scene;
        }
        public void ReadPointLight(FileStreamReader reader)
        {
            long seekPos = reader.BaseStream.Position;
            reader.Skip(8);
            int offsetToNameString = reader.ReadInt32();
            if (offsetToNameString > 0)
            {
                reader.Seek(seekPos + offsetToNameString);
                string lightName = reader.ReadNullTerminatedCString();
                reader.Seek(seekPos + 12);
            }

            uint flags = reader.ReadUInt32();
            uint lightFlags = reader.ReadUInt32();
            uint flags2 = reader.ReadUInt32();

            seekPos = reader.BaseStream.Position;
            int offsetToLightArea = reader.ReadInt32();
            if (offsetToLightArea > 0)
            {
                reader.Seek(seekPos + offsetToLightArea);
                Vector3 lightAreaScale = reader.ReadVector3();
                Quaternion lightAreaQuat = reader.ReadQuaternion();
                Vector3 lightAreaPosition = reader.ReadPositionF();
                reader.Seek(seekPos + 4);
            }

            Vector3 translation = reader.ReadPositionF();
            Vector3 reachPoint = new Vector3(reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf());
            Color color = new Color(reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf());
            float temperature = reader.ReadHalf();
            float colorDeflection = reader.ReadSingle();
            float lumen = reader.ReadSingle();
            float lightSize = reader.ReadHalf();
            float dimmer = reader.ReadHalf();
            float shadowBias = reader.ReadHalf();
            float lodFarSize = reader.ReadHalf();
            float lodNearSize = reader.ReadHalf();
            float lodShadowDrawRate = reader.ReadHalf();
            int lodRadiusLevel = reader.ReadInt32();
            int lodFadeType = reader.ReadInt32();

            seekPos = reader.BaseStream.Position;
            int offsetToIrraditationTransform = reader.ReadInt32();
            if (offsetToIrraditationTransform > 0)
            {
                reader.Seek(seekPos + offsetToIrraditationTransform);
                Vector3 lightAreaScale = reader.ReadVector3();
                Quaternion lightAreaQuat = reader.ReadQuaternion();
                Vector3 lightAreaPosition = reader.ReadPositionF();
            }

            //do
        }
        public void ReadSpotLight(FileStreamReader reader)
        {
            long seekPos = reader.BaseStream.Position;
            reader.Skip(8);
            int offsetToNameString = reader.ReadInt32();
            if (offsetToNameString > 0)
            {
                reader.Seek(seekPos + offsetToNameString);
                string lightName = reader.ReadNullTerminatedCString();
                reader.Seek(seekPos + 12);
            }

            uint flags = reader.ReadUInt32();
            uint lightFlags = reader.ReadUInt32();
            uint flags2 = reader.ReadUInt32();

            seekPos = reader.BaseStream.Position;
            int offsetToLightArea = reader.ReadInt32();
            if (offsetToLightArea > 0)
            {
                reader.Seek(seekPos + offsetToLightArea);
                Vector3 lightAreaScale = reader.ReadVector3();
                Quaternion lightAreaQuat = reader.ReadQuaternion();
                Vector3 lightAreaPosition = reader.ReadPositionF();
                reader.Seek(seekPos + 4);
            }

            Vector3 translation = reader.ReadPositionF();
            Vector3 reachPoint = new Vector3(reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf());
            Quaternion rotation = reader.ReadQuaternion();

            float outerRange = reader.ReadHalf();
            float innerRange = reader.ReadHalf();
            float umbraAngle = reader.ReadHalf();
            float penumbraAngle = reader.ReadHalf();
            float attenuationExponent = reader.ReadHalf();

            float dimmer = reader.ReadHalf();
            Color color = new Color(reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf(), reader.ReadHalf());
            float temperature = reader.ReadHalf();
            float colorDeflection = reader.ReadSingle();
            float lightSize = reader.ReadHalf();

            float unk0 = reader.ReadHalf();

            float shadowUmbraAngle = reader.ReadHalf();
            float shadowPenumbraAngle = reader.ReadHalf();
            float shadowAttenuationExponent = reader.ReadHalf();

            float shadowBias = reader.ReadHalf();

            float viewBias = reader.ReadHalf();
            float powerScale = reader.ReadHalf();

            float lodFarSize = reader.ReadHalf();
            float lodNearSize = reader.ReadHalf();
            float lodShadowDrawRate = reader.ReadHalf();
            int lodRadiusLevel = reader.ReadInt32();
            int lodFadeType = reader.ReadInt32();

            seekPos = reader.BaseStream.Position;
            int offsetToIrraditationTransform = reader.ReadInt32();
            if (offsetToIrraditationTransform > 0)
            {
                reader.Seek(seekPos + offsetToIrraditationTransform);
                Vector3 lightAreaScale = reader.ReadVector3();
                Quaternion lightAreaQuat = reader.ReadQuaternion();
                Vector3 lightAreaPosition = reader.ReadPositionF();
            }

            //do
        }
        public void ReadLightProbe(FileStreamReader reader)
        {
            long seekPos = reader.BaseStream.Position;
            reader.Skip(8);
            int offsetToNameString = reader.ReadInt32();
            if (offsetToNameString > 0)
            {
                reader.Seek(seekPos + offsetToNameString);
                string lightName = reader.ReadNullTerminatedCString();
                reader.Seek(seekPos + 12);
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
        public void ReadOccluder(FileStreamReader reader)
        {
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
