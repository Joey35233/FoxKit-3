using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Fox.Kernel;
using Fox.Fio;
using String = Fox.Kernel.String;

namespace Tpp.GameKit
{
    /// <summary>
    /// Type of the locators stored in an LBA file. Each LBA file can only contain locators of a single type.
    /// </summary>
    public enum LocatorBinaryType
    {
        Invalid = -1,
        PowerCutArea = 0,
        Named = 2,
        Scaled = 3
    }

    /// <summary>
    /// Reads locator binary array (LBA) files.
    /// </summary>
    public sealed class LocatorFileReader
    {
        private readonly FileStreamReader reader;

        /// <summary>
        /// Size of an LBA file's header.
        /// </summary>
        private const int HeaderSize = 16;

        /// <summary>
        /// Size of an unscaled locator.
        /// </summary>
        private const int UnscaledLocatorSize = sizeof(float) * 4 * 2;

        /// <summary>
        /// Size of a scaled locator.
        /// </summary>
        private const int ScaledLocatorSize = UnscaledLocatorSize + (sizeof(float) * 3) + (sizeof(ushort) * 2);

        [UnityEditor.MenuItem("FoxKit/Debug/LBA/Import LBA")]
        public static void Import()
        {
            var assetPath = UnityEditor.EditorUtility.OpenFilePanel("Import asset", string.Empty, "lba");
            if (string.IsNullOrEmpty(assetPath))
            {
                return;
            }

            using (var reader = new FileStreamReader(new global::System.IO.FileStream(assetPath, global::System.IO.FileMode.Open)))
            {
                LocatorBinaryType type = (LocatorBinaryType)reader.ReadUInt32();

                LocatorFileReader locatorReader = new LocatorFileReader(reader);

                switch (type)
                {
                    case LocatorBinaryType.PowerCutArea:
                        {
                            var locators = locatorReader.ReadPowerCutAreaLocators();
                            var asset = ScriptableObject.CreateInstance<PowerCutAreaLocatorBinaryArrayAsset>() as PowerCutAreaLocatorBinaryArrayAsset;

                            AssetDatabase.CreateAsset(asset, "Assets/" + global::System.IO.Path.GetFileNameWithoutExtension(assetPath) + ".asset");
                            AssetDatabase.SaveAssets();

                            asset.locators = locators;
                        }

                        break;
                    case LocatorBinaryType.Named:
                        {
                            var locators = locatorReader.ReadNamedLocators();
                            var asset = ScriptableObject.CreateInstance<NamedLocatorBinaryArrayAsset>() as NamedLocatorBinaryArrayAsset;

                            AssetDatabase.CreateAsset(asset, "Assets/" + global::System.IO.Path.GetFileNameWithoutExtension(assetPath) + ".asset");
                            AssetDatabase.SaveAssets();

                            asset.locators = locators;
                        }
                        break;
                    case LocatorBinaryType.Scaled:
                        {
                            var locators = locatorReader.ReadScaledLocators();
                            var asset = ScriptableObject.CreateInstance<ScaledLocatorBinaryArrayAsset>() as ScaledLocatorBinaryArrayAsset;

                            AssetDatabase.CreateAsset(asset, "Assets/" + global::System.IO.Path.GetFileNameWithoutExtension(assetPath) + ".asset");
                            AssetDatabase.SaveAssets();

                            asset.locators = locators;
                        }
                        break;
                    default:
                        return;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the LocatorFileReader class based on the specified BinaryReader.
        /// </summary>
        public LocatorFileReader(FileStreamReader reader)
        {
            this.reader = reader;
        }

        /// <summary>
        /// Reads the contents of the file as an array of PowerCutAreaLocatorBinary.
        /// </summary>
        /// <returns>
        /// The parsed locators.
        /// </returns>
        /// <remarks>
        /// Does not check the type of the file before reading.
        /// </remarks>
        public List<PowerCutAreaLocatorBinary> ReadPowerCutAreaLocators()
        {
            var count = reader.ReadInt32();

            var result = new List<PowerCutAreaLocatorBinary>(count);
            for(var i = 0; i < count; i++)
            {
                var locator = this.ReadPowerCutAreaLocator();
                result.Add(locator);
            }

            return result;
        }

        /// <summary>
        /// Reads the contents of the file as an array of NamedLocatorBinary.
        /// </summary>
        /// <returns>
        /// The parsed locators.
        /// </returns>
        /// <remarks>
        /// Does not check the type of the file before reading.
        /// </remarks>
        public List<NamedLocatorBinary> ReadNamedLocators()
        {
            var count = reader.ReadInt32();

            reader.Seek(HeaderSize + (UnscaledLocatorSize * count));
            var hashes = this.ReadHashes(count);
            reader.Seek(HeaderSize);

            var result = new List<NamedLocatorBinary>(count);
            for(var i = 0; i < count; i++)
            {
                var locatorNameHash = hashes[2 * i];
                var dataSetNameHash = hashes[(2 * i) + 1];

                var locatorName = UnhashLocatorName(locatorNameHash);
                var dataSetName = UnhashDataSetName(dataSetNameHash);

                var locator = this.ReadNamedLocator(locatorName, dataSetName);
                result.Add(locator);
            }

            return result;
        }

        /// <summary>
        /// Reads the contents of the file as an array of ScaledLocatorBinary.
        /// </summary>
        /// <returns>
        /// The parsed locators.
        /// </returns>
        /// <remarks>
        /// Does not check the type of the file before reading.
        /// </remarks>
        public List<ScaledLocatorBinary> ReadScaledLocators()
        {
            var count = reader.ReadInt32();

            reader.Seek(HeaderSize + (ScaledLocatorSize * count));
            var hashes = this.ReadHashes(count);
            reader.Seek(HeaderSize);

            var result = new List<ScaledLocatorBinary>(count);
            for(var i = 0; i < count; i++)
            {
                var locatorNameHash = hashes[2 * i];
                var dataSetNameHash = hashes[(2 * i) + 1];

                var locatorName = UnhashLocatorName(locatorNameHash);
                var dataSetName = UnhashDataSetName(dataSetNameHash);

                var locator = this.ReadScaledLocator(locatorName, dataSetName);
                result.Add(locator);
            }

            return result;
        }

        private static String UnhashLocatorName(StrCode32 hash)
        {
            // TODO
            return new String(hash.ToString());
        }

        private static Path UnhashDataSetName(StrCode32 hash)
        {
            // TODO
            return new Path(hash.ToString());
        }

        private PowerCutAreaLocatorBinary ReadPowerCutAreaLocator()
        {
            var translation = reader.ReadWidePositionF();
            var rotation = reader.ReadRotationF();
            return new PowerCutAreaLocatorBinary(translation, rotation);
        }

        private NamedLocatorBinary ReadNamedLocator(String locatorName, Path dataSetName)
        {
            var translation = reader.ReadWidePositionF();
            var rotation = reader.ReadRotationF();
            return new NamedLocatorBinary(translation, rotation, locatorName, dataSetName);
        }

        private ScaledLocatorBinary ReadScaledLocator(String locatorName, Path dataSetName)
        {
            var translation = reader.ReadWidePositionF();
            var rotation = reader.ReadRotationF();
            var scale = reader.ReadVector3();
            var a = reader.ReadInt16();
            var b = reader.ReadInt16();
            return new ScaledLocatorBinary(translation, rotation, scale, a, b, locatorName, dataSetName);
        }

        private StrCode32[] ReadHashes(int locatorCount)
        {
            var result = new StrCode32[locatorCount * 2];
            for(var i = 0; i < locatorCount * 2; i++)
            {
                result[i] = reader.ReadStrCode32();
            }

            return result;
        }
    }
}