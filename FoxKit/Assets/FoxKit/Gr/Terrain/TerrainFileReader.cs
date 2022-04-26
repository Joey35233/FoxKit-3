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


        public BinaryReader Reader { get; }
    }
}