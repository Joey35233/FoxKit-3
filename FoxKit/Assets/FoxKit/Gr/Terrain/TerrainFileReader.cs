using System.IO;
using UnityEngine;

namespace FoxKit.Gr.Terrain
{
    public class TerrainFileReader
    {
        public TerrainFileReader(BinaryReader reader)
        {
            this.Reader = reader;
        }

        public TerrainFileAsset Read()
        {
            var ret = ScriptableObject.CreateInstance<TerrainFileAsset>();

            this.Reader.BaseStream.Seek(80, SeekOrigin.Begin);
            ret.Width = this.ReadUintParam();
            ret.Height = this.ReadUintParam();
            ret.HighPerLow = this.ReadUintParam();
            ret.MaxLodLevel = this.ReadUintParam();
            ret.GridDistance = this.ReadFloatParam();

            this.Reader.BaseStream.Seek(208, SeekOrigin.Begin);
            ret.HeightFormat = this.ReadUintParam();
            ret.HeightRangeMax = this.ReadFloatParam();
            ret.HeightRangeMin = this.ReadFloatParam();

            this.Reader.BaseStream.Seek(304, SeekOrigin.Begin);
            ret.ComboFormat = this.ReadUintParam();

            this.Reader.BaseStream.Seek(576, SeekOrigin.Begin);
            ret.WidthWorldSpace = this.Reader.ReadUInt32();
            ret.HeightWorldSpace = this.Reader.ReadUInt32();

            this.Reader.BaseStream.Seek(4, SeekOrigin.Current);
            ret.MaxHeightWorldSpace = this.Reader.ReadSingle();
            ret.MinHeightWorldSpace = this.Reader.ReadSingle();

            this.Reader.BaseStream.Seek(596, SeekOrigin.Begin);
            ret.LayoutDescriptionGridDistance = this.Reader.ReadSingle();
            ret.LayoutDescriptionUnknown2 = this.Reader.ReadUInt16();
            ret.LayoutDescriptionUnknown3 = this.Reader.ReadUInt16();
            ret.LayoutDescriptionUnknown4 = this.Reader.ReadUInt32();

            this.Reader.BaseStream.Seek(704, SeekOrigin.Begin);
            ret.LodParam = this.ReadR32G32B32A32Texture("lodParam", 128, 128);
            ret.MaxHeight = this.ReadR32Texture("maxHeight", 128, 128, ret.HeightRangeMin, ret.HeightRangeMax);
            ret.MinHeight = this.ReadR32Texture("minHeight", 128, 128, ret.HeightRangeMin, ret.HeightRangeMax);

            this.Reader.BaseStream.Seek(918208, SeekOrigin.Begin);
            ret.MaterialIds = this.ReadR8G8B8A8Texture("materialIds", 128, 128);
            ret.ConfigrationIds = this.ReadR8G8B8A8Texture("configrationIds", 128, 128);

            return ret;
        }

        private uint ReadUintParam()
        {
            this.Reader.BaseStream.Seek(12, SeekOrigin.Current);
            return this.Reader.ReadUInt32();
        }
        private float ReadFloatParam()
        {
            this.Reader.BaseStream.Seek(12, SeekOrigin.Current);
            return this.Reader.ReadSingle();
        }

        private Texture2D ReadR32G32B32A32Texture(string name, int width, int height)
        {
            var ret = new Texture2D(width, height, TextureFormat.RGBAFloat, true);
            ret.name = name;

            var pixels = new Color[height * width];

            for (var i = 0; i < height * width; i++)
            {
                var r = this.Reader.ReadSingle();
                var g = this.Reader.ReadSingle();
                var b = this.Reader.ReadSingle();
                var a = this.Reader.ReadSingle();

                pixels[i].r = r;
                pixels[i].g = g;
                pixels[i].b = b;
                pixels[i].a = a;
            }

            ret.SetPixels(pixels);
            ret.Apply();
            return ret;
        }

        private Texture2D ReadR32Texture(string name, int width, int height, float minHeight, float maxHeight)
        {
            var ret = new Texture2D(width, height, TextureFormat.RFloat, true);
            ret.name = name;
            var pixels = new Color[height * width];

            for (var i = 0; i < height * width; i++)
            {
                var r = this.Reader.ReadSingle();
                pixels[i].r = (r - minHeight) / (maxHeight - minHeight);
            }

            ret.SetPixels(pixels);
            ret.Apply();
            return ret;
        }
        private Texture2D ReadR8G8B8A8Texture(string name, int width, int height)
        {
            var ret = new Texture2D(width, height, TextureFormat.RGBA32, true);
            ret.name = name;

            var pixels = new Color[height * width];

            for (var i = 0; i < height * width; i++)
            {
                var r = this.Reader.ReadByte() / 255.0f;
                var g = this.Reader.ReadByte() / 255.0f;
                var b = this.Reader.ReadByte() / 255.0f;
                var a = this.Reader.ReadByte() / 255.0f;

                pixels[i] = new Color(r, g, b, a);
            }

            ret.SetPixels(pixels);
            ret.Apply();
            return ret;
        }

        public BinaryReader Reader { get; }
    }
}