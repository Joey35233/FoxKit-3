using System;
using UnityEngine;
using System.Collections.Generic;

namespace Tpp.Effect
{
    public class TppLightWeatherAnimData : ScriptableObject
    {
        public List<LightAnimKeyframe> ClearTracks;
        public List<LightAnimKeyframe> CloudyTracks;
        public List<LightAnimKeyframe> RainyTracks;
        public List<LightAnimKeyframe> FoggyTracks;
        public List<LightAnimKeyframe> SandStomTracks;
        enum WEATHER_TYPE : uint
        {
            Clear=0,
            Cloudy=1,
            Rainy=2,
            Foggy=3,
            SandStom=4,//[sic]
        }

        /*
		public static TppLightWeatherAnimData Read(List<uint> bynaryData)
        {
            TppLightWeatherAnimData ret = new();
            
            var version = bynaryData[0];
            var totalSize = bynaryData[1];
            var weatherCount = bynaryData[2];

            for (int i = 0; i < weatherCount; i++)
            {
                var j = 2 + (3 * i);
                WEATHER_TYPE weatherType = (WEATHER_TYPE)bynaryData[j];
                var keyframeCount = bynaryData[j + 1];
                var dataOffset = bynaryData[j + 2];

                List<LightAnimKeyframe> weatherTrack = new();

                var k = dataOffset/sizeof(uint);
                for (int l = 0; l < keyframeCount; l++)
                {
                    LightAnimKeyframe animKeyframe = new();

                    animKeyframe.Time = bynaryData[(int)(k + l)];

                    uint packedColor = bynaryData[(int)(k + l + 1)];

                    byte[] unpackedColor = BitConverter.GetBytes(packedColor);
                    
                    animKeyframe.Color = new()
                    {
                        r = (float)unpackedColor[0]/0xFF,
                        g = (float)unpackedColor[1]/0xFF,
                        b = (float)unpackedColor[2]/0xFF,
                        a = (float)unpackedColor[3]/0xFF,
                    };

                    animKeyframe.Scale = BitConverter.Int32BitsToSingle((int)bynaryData[(int)(k + l + 2)]);
                    
                    weatherTrack.Add(animKeyframe);
                }

                switch (weatherType)
                {
                    case WEATHER_TYPE.Clear:
                    default:
                        ret.ClearTracks = weatherTrack;
                        break;
                    case WEATHER_TYPE.Cloudy:
                        ret.CloudyTracks = weatherTrack;
                        break;
                    case WEATHER_TYPE.Rainy:
                        ret.RainyTracks = weatherTrack;
                        break;
                    case WEATHER_TYPE.Foggy:
                        ret.FoggyTracks = weatherTrack;
                        break;
                    case WEATHER_TYPE.SandStom:
                        ret.SandStomTracks = weatherTrack;
                        break;
                }
            }
            
            return ret;
        }
		*/
            
        struct LightAnimHeader
        {
            uint Version;

            uint TotalSize;

            internal uint WeatherCount;
        };
        
        struct LightAnimTrack
        {
            internal WEATHER_TYPE WeatherType;

            internal uint KeyframeCount;

            internal uint DataOffset;
        };
        struct LightAnimKeyframePacked
        {
            public uint Time;
            public uint Color;
            public float Scale;
        }

        public static TppLightWeatherAnimData ReadUnsafe(List<uint> bynaryData)
        {
            TppLightWeatherAnimData ret = new();

            byte[] fileData = new byte[bynaryData.Count*sizeof(uint)];

            for (int i = 0; i < bynaryData.Count; i++)
            {
                byte[] bytes = BitConverter.GetBytes(bynaryData[i]);
                for (uint j = 0; j < bytes.Length; j++)
                {
                    fileData[i * sizeof(uint) + j]=bytes[j];
                }
            }
            
            unsafe
            {
                fixed (byte* data = fileData)
                {
                    LightAnimHeader* header = (LightAnimHeader*)data;

                    LightAnimTrack* tracks = (LightAnimTrack*)(header + 1);
                    for (uint i = 0; i < header->WeatherCount; i++)
                    {
                        LightAnimTrack* track = tracks + i;
                        
                        List<LightAnimKeyframe> weatherTrack = new();

                        LightAnimKeyframePacked* keyframes = (LightAnimKeyframePacked*)(data + track->DataOffset);
                        for (uint j = 0; j < track->KeyframeCount; j++)
                        {
                            LightAnimKeyframePacked* keyframe = keyframes + j;
                            
                            LightAnimKeyframe animKeyframe = new();

                            animKeyframe.Time = keyframe->Time;

                            byte[] unpackedColor = BitConverter.GetBytes(keyframe->Color);
                    
                            animKeyframe.Color = new()
                            {
                                r = (float)unpackedColor[0]/0xFF,
                                g = (float)unpackedColor[1]/0xFF,
                                b = (float)unpackedColor[2]/0xFF,
                                a = (float)unpackedColor[3]/0xFF,
                            };

                            animKeyframe.Scale = keyframe->Scale;
                    
                            weatherTrack.Add(animKeyframe);
                        }

                        switch (track->WeatherType)
                        {
                            case WEATHER_TYPE.Clear:
                            default:
                                ret.ClearTracks = weatherTrack;
                                break;
                            case WEATHER_TYPE.Cloudy:
                                ret.CloudyTracks = weatherTrack;
                                break;
                            case WEATHER_TYPE.Rainy:
                                ret.RainyTracks = weatherTrack;
                                break;
                            case WEATHER_TYPE.Foggy:
                                ret.FoggyTracks = weatherTrack;
                                break;
                            case WEATHER_TYPE.SandStom:
                                ret.SandStomTracks = weatherTrack;
                                break;
                        }
                    }
                }
            }
            
            return ret;
        }
    }
    public struct LightAnimKeyframe
    {
        public uint Time;
        public Color Color;
        public float Scale;
    }
}