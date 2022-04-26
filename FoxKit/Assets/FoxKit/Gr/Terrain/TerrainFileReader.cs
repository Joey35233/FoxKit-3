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
            ret.HeighRangeMax = this.ReadFloatParam();
            ret.HeighRangeMin = this.ReadFloatParam();

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
            ret.LodParam = ReadR32G32B32A32Texture(128, 128, 0, 10);

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

        private Texture2D ReadR32G32B32A32Texture(int width, int height, float maxHeight, float minHeight)
        {
            var ret = new Texture2D(width, height, TextureFormat.RGBA32, true);

            var pixels = new Color[height * width];

            // FIXME Is this needed?
            float heightUNORM8Scale = (float)byte.MaxValue / (maxHeight - minHeight);
            float heightUNORM8Bias = (float)byte.MaxValue * minHeight / (minHeight - maxHeight);

            for (var i = 0; i < height * width; i++)
            {
                var r = this.Reader.ReadSingle();
                var g = this.Reader.ReadSingle();
                var b = this.Reader.ReadSingle();
                var a = this.Reader.ReadSingle();

                pixels[i].r = r;// (r * heightUNORM8Scale + heightUNORM8Bias);
                pixels[i].g = g;// (g * heightUNORM8Scale + heightUNORM8Bias);
                pixels[i].b = b;// (b * heightUNORM8Scale + heightUNORM8Bias);
                pixels[i].a = a;// (a * heightUNORM8Scale + heightUNORM8Bias);
            }

            ret.SetPixels(pixels);
            ret.Apply();
            return ret;
        }


        public BinaryReader Reader { get; }
    }
}