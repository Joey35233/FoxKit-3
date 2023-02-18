using Fox.Fio;
using Fox.Kernel;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
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
            string assetPath = UnityEditor.EditorUtility.OpenFilePanel("Import asset", global::System.String.Empty, "lba");
            if (global::System.String.IsNullOrEmpty(assetPath))
            {
                return;
            }

            using (var reader = new FileStreamReader(new global::System.IO.FileStream(assetPath, global::System.IO.FileMode.Open)))
            {
                var type = (LocatorBinaryType)reader.ReadUInt32();

                var locatorReader = new LocatorFileReader(reader);

                switch (type)
                {
                    case LocatorBinaryType.PowerCutArea:
                    {
                        List<PowerCutAreaLocatorBinary> locators = locatorReader.ReadPowerCutAreaLocators();
                        PowerCutAreaLocatorBinaryArrayAsset asset = ScriptableObject.CreateInstance<PowerCutAreaLocatorBinaryArrayAsset>();

                        AssetDatabase.CreateAsset(asset, "Assets/" + global::System.IO.Path.GetFileNameWithoutExtension(assetPath) + ".asset");
                        AssetDatabase.SaveAssets();

                        asset.locators = locators;
                    }

                    break;
                    case LocatorBinaryType.Named:
                    {
                        List<NamedLocatorBinary> locators = locatorReader.ReadNamedLocators();
                        NamedLocatorBinaryArrayAsset asset = ScriptableObject.CreateInstance<NamedLocatorBinaryArrayAsset>();

                        AssetDatabase.CreateAsset(asset, "Assets/" + global::System.IO.Path.GetFileNameWithoutExtension(assetPath) + ".asset");
                        AssetDatabase.SaveAssets();

                        asset.locators = locators;
                    }
                    break;
                    case LocatorBinaryType.Scaled:
                    {
                        List<ScaledLocatorBinary> locators = locatorReader.ReadScaledLocators();
                        ScaledLocatorBinaryArrayAsset asset = ScriptableObject.CreateInstance<ScaledLocatorBinaryArrayAsset>();

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
            int count = reader.ReadInt32();

            var result = new List<PowerCutAreaLocatorBinary>(count);
            for (int i = 0; i < count; i++)
            {
                PowerCutAreaLocatorBinary locator = ReadPowerCutAreaLocator();
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
            int count = reader.ReadInt32();

            reader.Seek(HeaderSize + (UnscaledLocatorSize * count));
            StrCode32[] hashes = ReadHashes(count);
            reader.Seek(HeaderSize);

            var result = new List<NamedLocatorBinary>(count);
            for (int i = 0; i < count; i++)
            {
                StrCode32 locatorNameHash = hashes[2 * i];
                StrCode32 dataSetNameHash = hashes[(2 * i) + 1];

                String locatorName = UnhashLocatorName(locatorNameHash);
                Path dataSetName = UnhashDataSetName(dataSetNameHash);

                NamedLocatorBinary locator = ReadNamedLocator(locatorName, dataSetName);
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
            int count = reader.ReadInt32();

            reader.Seek(HeaderSize + (ScaledLocatorSize * count));
            StrCode32[] hashes = ReadHashes(count);
            reader.Seek(HeaderSize);

            var result = new List<ScaledLocatorBinary>(count);
            for (int i = 0; i < count; i++)
            {
                StrCode32 locatorNameHash = hashes[2 * i];
                StrCode32 dataSetNameHash = hashes[(2 * i) + 1];

                String locatorName = UnhashLocatorName(locatorNameHash);
                Path dataSetName = UnhashDataSetName(dataSetNameHash);

                ScaledLocatorBinary locator = ReadScaledLocator(locatorName, dataSetName);
                result.Add(locator);
            }

            return result;
        }

        private static String UnhashLocatorName(StrCode32 hash) =>
            // TODO
            new(hash.ToString());

        private static Path UnhashDataSetName(StrCode32 hash) =>
            // TODO
            new(hash.ToString());

        private PowerCutAreaLocatorBinary ReadPowerCutAreaLocator()
        {
            Vector3 translation = reader.ReadPositionHF();
            Quaternion rotation = reader.ReadRotationF();
            return new PowerCutAreaLocatorBinary(translation, rotation);
        }

        private NamedLocatorBinary ReadNamedLocator(String locatorName, Path dataSetName)
        {
            Vector3 translation = reader.ReadPositionHF();
            Quaternion rotation = reader.ReadRotationF();
            return new NamedLocatorBinary(translation, rotation, locatorName, dataSetName);
        }

        private ScaledLocatorBinary ReadScaledLocator(String locatorName, Path dataSetName)
        {
            Vector3 translation = reader.ReadPositionHF();
            Quaternion rotation = reader.ReadRotationF();
            Vector3 scale = reader.ReadVector3();
            short a = reader.ReadInt16();
            short b = reader.ReadInt16();
            return new ScaledLocatorBinary(translation, rotation, scale, a, b, locatorName, dataSetName);
        }

        private StrCode32[] ReadHashes(int locatorCount)
        {
            var result = new StrCode32[locatorCount * 2];
            for (int i = 0; i < locatorCount * 2; i++)
            {
                result[i] = reader.ReadStrCode32();
            }

            return result;
        }
    }
}