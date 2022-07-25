

namespace Fox
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using UnityEngine;
    using UnityEditor;
    using FoxKit;
    using String = Fox.FoxKernel.String;


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
        /// <summary>
        /// The binary file contents.
        /// </summary>
        private readonly byte[] buffer;

        /// <summary>
        /// Current offset in the buffer.
        /// </summary>
        private int position = 0;

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

            var fileContent = System.IO.File.ReadAllBytes(assetPath);
            var loader = new LocatorFileReader(fileContent);
            var type = loader.ReadType();

            switch (type)
            {
                case LocatorBinaryType.PowerCutArea:
                    {
                        var locators = loader.ReadPowerCutAreaLocators();
                        var asset = ScriptableObject.CreateInstance<PowerCutAreaLocatorBinaryArrayAsset>() as PowerCutAreaLocatorBinaryArrayAsset;

                        AssetDatabase.CreateAsset(asset, "Assets/" + System.IO.Path.GetFileNameWithoutExtension(assetPath) + ".asset");
                        AssetDatabase.SaveAssets();

                        asset.locators = locators;
                    }

                    break;
                case LocatorBinaryType.Named:
                    {
                        var locators = loader.ReadNamedLocators();
                        var asset = ScriptableObject.CreateInstance<NamedLocatorBinaryArrayAsset>() as NamedLocatorBinaryArrayAsset;

                        AssetDatabase.CreateAsset(asset, "Assets/" + System.IO.Path.GetFileNameWithoutExtension(assetPath) + ".asset");
                        AssetDatabase.SaveAssets();

                        asset.locators = locators;
                    }
                    break;
                case LocatorBinaryType.Scaled:
                    {
                        var locators = loader.ReadScaledLocators();
                        var asset = ScriptableObject.CreateInstance<ScaledLocatorBinaryArrayAsset>() as ScaledLocatorBinaryArrayAsset;

                        AssetDatabase.CreateAsset(asset, "Assets/" + System.IO.Path.GetFileNameWithoutExtension(assetPath) + ".asset");
                        AssetDatabase.SaveAssets();

                        asset.locators = locators;
                    }
                    break;
                default:
                    return;
            }
        }

        /// <summary>
        /// Initializes a new instance of the LocatorFileReader class based on the specified LBA buffer.
        /// </summary>
        /// <param name="buffer">Binary contents of the LBA file to read.</param>
        public LocatorFileReader(byte[] buffer)
        {
            Debug.Assert(buffer != null);

            if (buffer.Length < HeaderSize)
            {
                Debug.LogError("LBA file buffer too short. Invalid or unrecognized format.");
                return;
            }

            this.buffer = buffer;
        }

        /// <summary>
        /// Reads the type of locators stored in the file.
        /// </summary>
        /// <returns>
        /// The type of locators stored in the file.
        /// </returns>
        public LocatorBinaryType ReadType()
        {
            var type = BitConverter.ToInt32(this.buffer, 4);
            if (IsTypeValid(type))
            {
                return (LocatorBinaryType)type;
            }

            Debug.LogError("LBA format unrecognized.");
            return LocatorBinaryType.Invalid; 
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
            var count = BitConverter.ToInt32(this.buffer, 0);

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
            var count = BitConverter.ToInt32(this.buffer, 0);

            this.position = HeaderSize + (UnscaledLocatorSize * count);
            var hashes = this.ReadHashes(count);
            this.position = HeaderSize;

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
            var count = BitConverter.ToInt32(this.buffer, 0);

            this.position = HeaderSize + (ScaledLocatorSize * count);
            var hashes = this.ReadHashes(count);
            this.position = HeaderSize;

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

        private static String UnhashLocatorName(uint hash)
        {
            // TODO
            return new String(hash.ToString());
        }

        private static String UnhashDataSetName(uint hash)
        {
            // TODO
            return new String(hash.ToString());
        }

        private PowerCutAreaLocatorBinary ReadPowerCutAreaLocator()
        {
            var translation = this.ReadVector4();
            var rotation = this.ReadQuaternion();
            return new PowerCutAreaLocatorBinary(translation, rotation);
        }

        private NamedLocatorBinary ReadNamedLocator(String locatorName, String dataSetName)
        {
            var translation = this.ReadVector4();
            var rotation = this.ReadQuaternion();
            return new NamedLocatorBinary(translation, rotation, locatorName, dataSetName);
        }

        private ScaledLocatorBinary ReadScaledLocator(String locatorName, String dataSetName)
        {
            var translation = this.ReadVector4();
            var rotation = this.ReadQuaternion();
            var scale = this.ReadVector3();
            var a = this.ReadInt16();
            var b = this.ReadInt16();
            return new ScaledLocatorBinary(translation, rotation, scale, a, b, locatorName, dataSetName);
        }

        private uint[] ReadHashes(int locatorCount)
        {
            var result = new uint[locatorCount * 2];
            for(var i = 0; i < locatorCount * 2; i++)
            {
                result[i] = this.ReadUInt32();
            }

            return result;
        }

        private Vector4 ReadVector4()
        {
            var x = this.ReadFloat();
            var y = this.ReadFloat();
            var z = this.ReadFloat();
            var w = this.ReadFloat();

            return FoxUtils.UnityVectorFromFoxCoordinates(x, y, z, w);
        }

        private Quaternion ReadQuaternion()
        {
            var x = this.ReadFloat();
            var y = this.ReadFloat();
            var z = this.ReadFloat();
            var w = this.ReadFloat();

            return FoxUtils.UnityQuaternionFromFoxCoordinates(x, y, z, w);
        }

        private Vector3 ReadVector3()
        {
            var x = this.ReadFloat();
            var y = this.ReadFloat();
            var z = this.ReadFloat();

            return new Vector3(x, y, z);
        }

        private short ReadInt16()
        {
            var result = BitConverter.ToInt16(this.buffer, this.position);
            this.position += 2;
            return result;
        }

        private float ReadFloat()
        {
            var result = BitConverter.ToSingle(this.buffer, this.position);
            this.position += 4;
            return result;
        }

        private uint ReadUInt32()
        {
            var result = BitConverter.ToUInt32(this.buffer, this.position);
            this.position += 4;
            return result;
        }

        private static bool IsTypeValid(int type)
        {
            if (type < 0)
            {
                return false;
            }

            if (type == 1)
            {
                return false;
            }

            if (type > 3)
            {
                return false;
            }

            return true;
        }
    }
}