using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using Fox.Core.Utils;
using UnityEngine;


namespace Fox.Gr
{
    public partial class FtexFile
    {
        [Flags]
        public enum FeatureFlags : uint
        {
            None = 0,
            Compressed = 0b0000000000000000000000001,
            SRGB = 0b0000000000000000000000010,
            Cube = 0b0000000000000000000000100,
            Normal = 0b0000000000000000000001000,
            Streamed = 0b1000000000000000000000000,
        }

        public enum PixelFormat : ushort
        {
            B8G8R8A8_UNORM = 0,
            A8_UNORM = 1,
            BC1_UNORM = 2,
            BC2_UNORM = 3,
            BC3_UNORM = 4,
            BC5_UNORM = 5,
            R32_FLOAT = 6,
            D16_UNORM = 7,
        }

        public enum FilterType : byte
        {
            MinMagMipPoint = 0,
            MinMagLinearMipPoint = 1,
            MinMagMipLinear = 2,
        }

        public enum AddressingMode : ushort
        {
            Clamp = 0x000,
            Wrap = 0x111,
            Mirror = 0x222,
            Border = 0x333,
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct FileHeader
        {
            public uint Signature; // "FTEX"
            public float Version;
            public PixelFormat PixelFormat;
            public ushort Width;
            public ushort Height;
            public ushort Depth;
            public byte MipmapCount;
            public FilterType FilterType;
            public AddressingMode AddressingMode;
            public ushort Unknown0;
            public ushort Padding0;
            public uint Padding1;
            public FeatureFlags FeatureFlags;
            public byte FtexsFileCount;
            public byte HighestMipMap;
            public ushort Padding2;
            public uint Padding3;
            public ulong Padding4;
            // 16 bytes padding follows
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct MipmapDef
        {
            public uint DataOffset;
            public uint UncompressedSize;
            public uint CompressedSize;
            public byte Index;
            public byte FileNumber;
            public ushort ChunkCount;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct MipmapChunkDef
        {
            public ushort CompressedChunkSize;
            public ushort UncompressedChunkSize;
            public uint DataOffset;
        }

        public static bool ConvertToDds(ReadOnlySpan<byte> ftexData, Func<int, BinaryReader> ftexsProvider, TaskLogger logger, string ddsPath)
        {
            FtexFileReader reader = new FtexFileReader();
            return reader.ConvertToDds(ftexData, ftexsProvider, logger, ddsPath);
        }

        public static FilterMode GetFilterMode(ReadOnlySpan<byte> ftexData)
        {
            FileHeader header = MemoryMarshal.Read<FileHeader>(ftexData);
            return FtexFileReader.ConvertFilterType(header.FilterType);
        }

        public static TextureWrapMode GetWrapMode(ReadOnlySpan<byte> ftexData)
        {
            FileHeader header = MemoryMarshal.Read<FileHeader>(ftexData);
            return FtexFileReader.ConvertAddressingMode(header.AddressingMode);
        }

        public static bool IsColorTexture(ReadOnlySpan<byte> ftexData)
        {
            FileHeader header = MemoryMarshal.Read<FileHeader>(ftexData);
            return (header.FeatureFlags & FeatureFlags.SRGB) != 0;
        }
    }

    internal struct FtexFileReader
    {
        private const int MipmapDefsOffset = 0x40;
        private const float SupportedVersion = 2.03f;

        private static uint ConvertPixelFormatToFourCC(FtexFile.PixelFormat format)
        {
            switch (format)
            {
                case FtexFile.PixelFormat.BC1_UNORM: return 0x31545844u; // "DXT1"
                case FtexFile.PixelFormat.BC2_UNORM: return 0x33545844u; // "DXT3"
                case FtexFile.PixelFormat.BC3_UNORM: return 0x35545844u; // "DXT5"
                case FtexFile.PixelFormat.BC5_UNORM: return 0x32495441u; // "ATI2"
                default: return 0;
            }
        }

        public bool ConvertToDds(ReadOnlySpan<byte> ftexData, Func<int, BinaryReader> ftexsProvider, TaskLogger logger, string ddsPath)
        {
            byte[] textureData = ReadTextureData(ftexData, ftexsProvider, logger, out FtexFile.FileHeader header, out uint mip0Size);
            if (textureData == null)
                return false;

            uint fourCC = ConvertPixelFormatToFourCC(header.PixelFormat);
            bool isCubemap = (header.FeatureFlags & FtexFile.FeatureFlags.Cube) != 0;
            if (fourCC == 0 || isCubemap || header.Depth != 1)
            {
                logger.AddWarning($"DDS export doesn't support {header.PixelFormat} (cubemap {isCubemap}, depth {header.Depth}) yet.");
                return false;
            }

            bool isNormalMap = (header.FeatureFlags & FtexFile.FeatureFlags.Normal) != 0;
            if (isNormalMap && fourCC == 0x35545844u) // "DXT5"
                SetNormalMapRedToFull(textureData);

            WriteDds(ddsPath, header.Width, header.Height, header.MipmapCount, fourCC, mip0Size, textureData);
            return true;
        }

        private static void SetNormalMapRedToFull(byte[] textureData)
        {
            for (int block = 0; block < textureData.Length; block += Bc2Bc3Bc5BlockSizeInBytes)
            {
                textureData[block + Bc3Color0HighByteOffset] |= Rgb565RedBitsInHighByte;
                textureData[block + Bc3Color1HighByteOffset] |= Rgb565RedBitsInHighByte;
            }
        }

        private static byte[] ReadTextureData(ReadOnlySpan<byte> ftexData, Func<int, BinaryReader> ftexsProvider, TaskLogger logger, out FtexFile.FileHeader header, out uint mip0Size)
        {
            header = default;
            mip0Size = 0;

            unsafe
            {
                fixed (byte* dataPtr = ftexData)
                {
                    if (ftexData.Length < MipmapDefsOffset)
                    {
                        logger.AddError($"File is too small for an FTEX header ({ftexData.Length} bytes).");
                        return null;
                    }

                    // Read header
                    header = *(FtexFile.FileHeader*)dataPtr;

                    // Validate signature
                    if (header.Signature != 0x58455446u) // "FTEX"
                    {
                        logger.AddError("Invalid FTEX signature.");
                        return null;
                    }

                    if (header.Version != SupportedVersion)
                    {
                        logger.AddError($"Unsupported FTEX version {header.Version}, only {SupportedVersion} is supported.");
                        return null;
                    }

                    if (header.Width == 0 || header.Height == 0 || header.MipmapCount == 0)
                    {
                        logger.AddError($"Invalid FTEX size {header.Width}x{header.Height} with {header.MipmapCount} mipmaps.");
                        return null;
                    }

                    // Read mipmap definitions
                    int faceCount = (header.FeatureFlags & FtexFile.FeatureFlags.Cube) != 0 ? 6 : 1;
                    int mipmapDefCount = header.MipmapCount * faceCount;
                    if (ftexData.Length < MipmapDefsOffset + mipmapDefCount * sizeof(FtexFile.MipmapDef))
                    {
                        logger.AddError($"File is too small for its {mipmapDefCount} mipmap definitions ({ftexData.Length} bytes).");
                        return null;
                    }
                    FtexFile.MipmapDef* mipmapDefs = (FtexFile.MipmapDef*)(dataPtr + MipmapDefsOffset);

                    // Calculate total size
                    uint totalSize = 0;
                    for (int i = 0; i < mipmapDefCount; i++)
                        totalSize += mipmapDefs[i].UncompressedSize;

                    byte[] textureData = new byte[totalSize];
                    uint currentOffset = 0;

                    // Read mipmaps
                    for (int i = 0; i < mipmapDefCount; i++)
                    {
                        FtexFile.MipmapDef mipmapDef = mipmapDefs[i];

                        using (BinaryReader ftexsReader = ftexsProvider(mipmapDef.FileNumber))
                        {
                            if ((header.FeatureFlags & FtexFile.FeatureFlags.Compressed) != 0 && mipmapDef.ChunkCount > 0)
                            {
                                DecompressMipmap(ftexsReader, mipmapDef, textureData, currentOffset, logger);
                            }
                            else
                            {
                                ftexsReader.BaseStream.Seek(mipmapDef.DataOffset, SeekOrigin.Begin);
                                int bytesRead = ftexsReader.Read(textureData, (int)currentOffset, (int)mipmapDef.UncompressedSize);
                                if (bytesRead != mipmapDef.UncompressedSize)
                                    logger.AddWarning($"Mipmap {i}: expected {mipmapDef.UncompressedSize} bytes, got {bytesRead}.");
                            }
                        }

                        currentOffset += mipmapDef.UncompressedSize;
                    }

                    mip0Size = mipmapDefs[0].UncompressedSize;
                    return textureData;
                }
            }
        }

        private static void DecompressMipmap(BinaryReader ftexsReader, FtexFile.MipmapDef mipmapDef, byte[] outputData, uint outputOffset, TaskLogger logger)
        {
            ftexsReader.BaseStream.Seek(mipmapDef.DataOffset, SeekOrigin.Begin);
            uint bytesWritten = 0;

            for (int chunkIndex = 0; chunkIndex < mipmapDef.ChunkCount; chunkIndex++)
            {
                ushort compressedChunkSize = ftexsReader.ReadUInt16();
                ushort uncompressedChunkSize = ftexsReader.ReadUInt16();
                uint dataOffset = ftexsReader.ReadUInt32();
                bool isCompressed = (dataOffset & 0x80000000) == 0;
                uint actualOffset = dataOffset & 0x7FFFFFFF;

                long currentPos = ftexsReader.BaseStream.Position;
                ftexsReader.BaseStream.Seek(mipmapDef.DataOffset + actualOffset, SeekOrigin.Begin);
                int targetOffset = (int)(outputOffset + bytesWritten);

                if (isCompressed)
                {
                    ftexsReader.ReadBytes(2);
                    using (DeflateStream deflateStream = new DeflateStream(ftexsReader.BaseStream, CompressionMode.Decompress, true))
                    {
                        int totalRead = 0;
                        while (totalRead < uncompressedChunkSize)
                        {
                            int bytesToRead = uncompressedChunkSize - totalRead;
                            int bytesRead = deflateStream.Read(outputData, targetOffset + totalRead, bytesToRead);

                            if (bytesRead == 0)
                            {
                                logger.AddWarning($"DeflateStream ended early on chunk {chunkIndex}. Expected {uncompressedChunkSize}, got {totalRead}.");
                                break;
                            }
                            totalRead += bytesRead;
                        }
                        bytesWritten += (uint)totalRead;
                    }
                }
                else
                {
                    int bytesRead = ftexsReader.Read(outputData, targetOffset, uncompressedChunkSize);
                    if (bytesRead != uncompressedChunkSize)
                        logger.AddWarning($"Uncompressed chunk {chunkIndex} read {bytesRead}/{uncompressedChunkSize} bytes.");
                    bytesWritten += (uint)bytesRead;
                }

                ftexsReader.BaseStream.Seek(currentPos, SeekOrigin.Begin);
            }
        }

        internal static FilterMode ConvertFilterType(FtexFile.FilterType filterType)
        {
            return filterType switch
            {
                FtexFile.FilterType.MinMagMipPoint => FilterMode.Point,
                FtexFile.FilterType.MinMagLinearMipPoint => FilterMode.Bilinear,
                FtexFile.FilterType.MinMagMipLinear => FilterMode.Trilinear,
                _ => FilterMode.Bilinear
            };
        }

        internal static TextureWrapMode ConvertAddressingMode(FtexFile.AddressingMode mode)
        {
            return mode switch
            {
                FtexFile.AddressingMode.Clamp => TextureWrapMode.Clamp,
                FtexFile.AddressingMode.Wrap => TextureWrapMode.Repeat,
                FtexFile.AddressingMode.Mirror => TextureWrapMode.Mirror,
                FtexFile.AddressingMode.Border => TextureWrapMode.Clamp,
                _ => TextureWrapMode.Repeat
            };
        }
        [Flags]
        private enum DdsHeaderFlags : uint
        {
            Caps = 0x1,
            Height = 0x2,
            Width = 0x4,
            PixelFormat = 0x1000,
            MipMapCount = 0x20000,
            LinearSize = 0x80000,
        }

        [Flags]
        private enum DdsPixelFormatFlags : uint
        {
            FourCC = 0x4,
        }

        [Flags]
        private enum DdsCaps : uint
        {
            Complex = 0x8,
            Texture = 0x1000,
            MipMap = 0x400000,
        }

        private const uint DdsHeaderSize = 124;
        private const uint DdsPixelFormatSize = 32;
        private const int DdsReservedFieldCount = 11;
        private const int DdsUnusedPixelFormatFieldCount = 5;
        private const int DdsUnusedCapsFieldCount = 4;
        private const int BlockWidthInPixels = 4;
        private const int Bc1BlockSizeInBytes = 8;
        private const int Bc2Bc3Bc5BlockSizeInBytes = 16;
        private const int BlockPixelCount = 16;
        private const int BitsPerByte = 8;
        private const byte Opaque = 255;
        private const int AlphaPartSizeInBytes = 8;
        private const int ColorEndpoint1Offset = 2;
        private const int ColorIndicesOffset = 4;
        private const int ColorIndexBitCount = 2;
        private const int ColorIndexMask = 0x3;
        private const int AlphaEndpoint1Offset = 1;
        private const int AlphaIndicesOffset = 2;
        private const int AlphaIndexByteCount = 6;
        private const int AlphaIndexBitCount = 3;
        private const int AlphaIndexMask = 0x7;
        private const int AlphaPaletteSize = 8;
        private const int EightAlphaModeDivisor = 7;
        private const int SixAlphaModeDivisor = 5;
        private const int ExplicitAlphaBitCount = 4;
        private const int Rgb565RedShift = 11;
        private const int Rgb565GreenShift = 5;
        private const int Rgb565RedBitCount = 5;
        private const int Rgb565GreenBitCount = 6;
        private const int Rgb565BlueBitCount = 5;
        private const int Bc3Color0HighByteOffset = 9;
        private const int Bc3Color1HighByteOffset = 11;
        private const byte Rgb565RedBitsInHighByte = 0xF8;

        private struct Rgba32
        {
            public byte R;
            public byte G;
            public byte B;
            public byte A;
        }

        private static void WriteDds(string ddsPath, int width, int height, int mipCount, uint fourCC, uint mip0Size, byte[] textureData)
        {
            int fullMipCount = mipCount;
            if (mipCount > 1)
                fullMipCount = CountFullMipChain(width, height);

            DdsHeaderFlags flags = DdsHeaderFlags.Caps | DdsHeaderFlags.Height | DdsHeaderFlags.Width | DdsHeaderFlags.PixelFormat | DdsHeaderFlags.LinearSize;
            DdsCaps caps = DdsCaps.Texture;
            if (mipCount > 1)
            {
                flags |= DdsHeaderFlags.MipMapCount;
                caps |= DdsCaps.MipMap | DdsCaps.Complex;
            }

            uint depth = 0;

            using (BinaryWriter writer = new BinaryWriter(System.IO.File.Create(ddsPath)))
            {
                writer.Write(0x20534444u); // "DDS "
                writer.Write(DdsHeaderSize);
                writer.Write((uint)flags);
                writer.Write((uint)height);
                writer.Write((uint)width);
                writer.Write(mip0Size);
                writer.Write(depth);
                writer.Write((uint)fullMipCount);
                for (int i = 0; i < DdsReservedFieldCount; i++)
                {
                    writer.Write(0u);
                }

                writer.Write(DdsPixelFormatSize);
                writer.Write((uint)DdsPixelFormatFlags.FourCC);
                writer.Write(fourCC);
                for (int i = 0; i < DdsUnusedPixelFormatFieldCount; i++)
                {
                    writer.Write(0u);
                }

                writer.Write((uint)caps);
                for (int i = 0; i < DdsUnusedCapsFieldCount; i++)
                {
                    writer.Write(0u);
                }

                writer.Write(textureData);
                WriteMissingMipmaps(writer, width, height, mipCount, fullMipCount, fourCC, textureData);
            }
        }

        private static int CountFullMipChain(int width, int height)
        {
            int mipCount = 1;
            for (int size = System.Math.Max(width, height); size > 1; size /= 2)
                mipCount++;
            return mipCount;
        }

        private static int GetBlockSize(uint fourCC)
        {
            if (fourCC == 0x31545844u) // "DXT1"
                return Bc1BlockSizeInBytes;
            return Bc2Bc3Bc5BlockSizeInBytes;
        }

        private static int CountBlocks(int pixels)
        {
            return System.Math.Max(1, (pixels + BlockWidthInPixels - 1) / BlockWidthInPixels);
        }

        private static void WriteMissingMipmaps(BinaryWriter writer, int width, int height, int mipCount, int fullMipCount, uint fourCC, byte[] textureData)
        {
            if (mipCount >= fullMipCount)
                return;

            int lastMipWidth = System.Math.Max(1, width >> (mipCount - 1));
            int lastMipHeight = System.Math.Max(1, height >> (mipCount - 1));
            int lastMipSize = CountBlocks(lastMipWidth) * CountBlocks(lastMipHeight) * GetBlockSize(fourCC);
            Rgba32 average = AverageMipmap(fourCC, textureData, textureData.Length - lastMipSize, lastMipWidth, lastMipHeight);
            byte[] averageBlock = EncodeSolidBlock(fourCC, average);

            for (int mip = mipCount; mip < fullMipCount; mip++)
            {
                int mipWidth = System.Math.Max(1, width >> mip);
                int mipHeight = System.Math.Max(1, height >> mip);
                int blockCount = CountBlocks(mipWidth) * CountBlocks(mipHeight);
                for (int block = 0; block < blockCount; block++)
                    writer.Write(averageBlock);
            }
        }

        private static Rgba32 AverageMipmap(uint fourCC, byte[] data, int offset, int width, int height)
        {
            int blockSize = GetBlockSize(fourCC);
            int blocksPerRow = CountBlocks(width);
            int blockRows = CountBlocks(height);
            var pixels = new Rgba32[BlockPixelCount];
            long red = 0;
            long green = 0;
            long blue = 0;
            long alpha = 0;
            int pixelCount = 0;

            for (int blockRow = 0; blockRow < blockRows; blockRow++)
            {
                for (int blockColumn = 0; blockColumn < blocksPerRow; blockColumn++)
                {
                    DecodeBlock(fourCC, data, offset + (blockRow * blocksPerRow + blockColumn) * blockSize, pixels);
                    for (int pixel = 0; pixel < BlockPixelCount; pixel++)
                    {
                        int x = blockColumn * BlockWidthInPixels + pixel % BlockWidthInPixels;
                        int y = blockRow * BlockWidthInPixels + pixel / BlockWidthInPixels;
                        if (x >= width || y >= height)
                            continue;

                        red += pixels[pixel].R;
                        green += pixels[pixel].G;
                        blue += pixels[pixel].B;
                        alpha += pixels[pixel].A;
                        pixelCount++;
                    }
                }
            }

            Rgba32 average;
            average.R = (byte)((red + pixelCount / 2) / pixelCount);
            average.G = (byte)((green + pixelCount / 2) / pixelCount);
            average.B = (byte)((blue + pixelCount / 2) / pixelCount);
            average.A = (byte)((alpha + pixelCount / 2) / pixelCount);
            return average;
        }

        private static void DecodeBlock(uint fourCC, byte[] data, int offset, Rgba32[] pixels)
        {
            var channel = new byte[BlockPixelCount];
            switch (fourCC)
            {
                case 0x31545844u: // "DXT1"
                    DecodeColorBlock(data, offset, true, pixels);
                    break;
                case 0x33545844u: // "DXT3"
                    DecodeColorBlock(data, offset + AlphaPartSizeInBytes, false, pixels);
                    for (int pixel = 0; pixel < BlockPixelCount; pixel++)
                    {
                        int explicitAlpha = (data[offset + pixel / 2] >> (ExplicitAlphaBitCount * (pixel % 2))) & ((1 << ExplicitAlphaBitCount) - 1);
                        pixels[pixel].A = ExpandToByte(explicitAlpha, ExplicitAlphaBitCount);
                    }
                    break;
                case 0x35545844u: // "DXT5"
                    DecodeColorBlock(data, offset + AlphaPartSizeInBytes, false, pixels);
                    DecodeAlphaBlock(data, offset, channel);
                    for (int pixel = 0; pixel < BlockPixelCount; pixel++)
                        pixels[pixel].A = channel[pixel];
                    break;
                case 0x32495441u: // "ATI2"
                    DecodeAlphaBlock(data, offset, channel);
                    for (int pixel = 0; pixel < BlockPixelCount; pixel++)
                        pixels[pixel].R = channel[pixel];
                    DecodeAlphaBlock(data, offset + AlphaPartSizeInBytes, channel);
                    for (int pixel = 0; pixel < BlockPixelCount; pixel++)
                    {
                        pixels[pixel].G = channel[pixel];
                        pixels[pixel].B = 0;
                        pixels[pixel].A = Opaque;
                    }
                    break;
            }
        }

        private static void DecodeColorBlock(byte[] data, int offset, bool allowsThreeColorMode, Rgba32[] pixels)
        {
            ushort color0 = BitConverter.ToUInt16(data, offset);
            ushort color1 = BitConverter.ToUInt16(data, offset + ColorEndpoint1Offset);
            uint indices = BitConverter.ToUInt32(data, offset + ColorIndicesOffset);

            var palette = new Rgba32[4];
            palette[0] = ExpandRgb565(color0);
            palette[1] = ExpandRgb565(color1);
            if (allowsThreeColorMode && color0 <= color1)
            {
                palette[2] = MixColors(palette[0], palette[1], 1, 2);
                palette[3] = new Rgba32();
            }
            else
            {
                palette[2] = MixColors(palette[0], palette[1], 1, 3);
                palette[3] = MixColors(palette[0], palette[1], 2, 3);
            }

            for (int pixel = 0; pixel < BlockPixelCount; pixel++)
                pixels[pixel] = palette[(indices >> (ColorIndexBitCount * pixel)) & ColorIndexMask];
        }

        private static void DecodeAlphaBlock(byte[] data, int offset, byte[] values)
        {
            byte alpha0 = data[offset];
            byte alpha1 = data[offset + AlphaEndpoint1Offset];
            ulong indices = 0;
            for (int i = 0; i < AlphaIndexByteCount; i++)
                indices |= (ulong)data[offset + AlphaIndicesOffset + i] << (BitsPerByte * i);

            var palette = new byte[AlphaPaletteSize];
            palette[0] = alpha0;
            palette[1] = alpha1;
            if (alpha0 > alpha1)
            {
                for (int step = 1; step < EightAlphaModeDivisor; step++)
                    palette[step + 1] = Mix(alpha0, alpha1, step, EightAlphaModeDivisor);
            }
            else
            {
                for (int step = 1; step < SixAlphaModeDivisor; step++)
                    palette[step + 1] = Mix(alpha0, alpha1, step, SixAlphaModeDivisor);
                palette[AlphaPaletteSize - 2] = 0;
                palette[AlphaPaletteSize - 1] = Opaque;
            }

            for (int pixel = 0; pixel < BlockPixelCount; pixel++)
                values[pixel] = palette[(indices >> (AlphaIndexBitCount * pixel)) & AlphaIndexMask];
        }

        private static byte[] EncodeSolidBlock(uint fourCC, Rgba32 color)
        {
            int packedColor = (ShrinkFromByte(color.R, Rgb565RedBitCount) << Rgb565RedShift)
                | (ShrinkFromByte(color.G, Rgb565GreenBitCount) << Rgb565GreenShift)
                | ShrinkFromByte(color.B, Rgb565BlueBitCount);

            var block = new byte[GetBlockSize(fourCC)];
            int colorOffset = 0;
            if (fourCC == 0x33545844u) // "DXT3"
            {
                byte alphaPair = ExpandToByte(ShrinkFromByte(color.A, ExplicitAlphaBitCount), ExplicitAlphaBitCount);
                for (int i = 0; i < AlphaPartSizeInBytes; i++)
                    block[i] = alphaPair;
                colorOffset = AlphaPartSizeInBytes;
            }
            else if (fourCC == 0x35545844u) // "DXT5"
            {
                block[0] = color.A;
                block[AlphaEndpoint1Offset] = color.A;
                colorOffset = AlphaPartSizeInBytes;
            }
            else if (fourCC == 0x32495441u) // "ATI2"
            {
                block[0] = color.R;
                block[AlphaEndpoint1Offset] = color.R;
                block[AlphaPartSizeInBytes] = color.G;
                block[AlphaPartSizeInBytes + AlphaEndpoint1Offset] = color.G;
                return block;
            }

            block[colorOffset] = (byte)packedColor;
            block[colorOffset + 1] = (byte)(packedColor >> BitsPerByte);
            block[colorOffset + ColorEndpoint1Offset] = (byte)packedColor;
            block[colorOffset + ColorEndpoint1Offset + 1] = (byte)(packedColor >> BitsPerByte);
            return block;
        }

        private static Rgba32 ExpandRgb565(ushort color)
        {
            Rgba32 result;
            result.R = ExpandToByte(color >> Rgb565RedShift, Rgb565RedBitCount);
            result.G = ExpandToByte((color >> Rgb565GreenShift) & ((1 << Rgb565GreenBitCount) - 1), Rgb565GreenBitCount);
            result.B = ExpandToByte(color & ((1 << Rgb565BlueBitCount) - 1), Rgb565BlueBitCount);
            result.A = Opaque;
            return result;
        }

        private static Rgba32 MixColors(Rgba32 first, Rgba32 second, int weightOfSecond, int totalWeight)
        {
            Rgba32 result;
            result.R = Mix(first.R, second.R, weightOfSecond, totalWeight);
            result.G = Mix(first.G, second.G, weightOfSecond, totalWeight);
            result.B = Mix(first.B, second.B, weightOfSecond, totalWeight);
            result.A = Mix(first.A, second.A, weightOfSecond, totalWeight);
            return result;
        }

        private static byte Mix(byte first, byte second, int weightOfSecond, int totalWeight)
        {
            return (byte)((first * (totalWeight - weightOfSecond) + second * weightOfSecond) / totalWeight);
        }

        private static byte ExpandToByte(int value, int bitCount)
        {
            return (byte)((value << (BitsPerByte - bitCount)) | (value >> (2 * bitCount - BitsPerByte)));
        }

        private static int ShrinkFromByte(byte value, int bitCount)
        {
            int maximum = (1 << bitCount) - 1;
            return (value * maximum + byte.MaxValue / 2) / byte.MaxValue;
        }
    }
}
