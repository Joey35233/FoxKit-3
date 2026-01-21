using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Fox.Core.Utils;
using Fox.Fio;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fox.Core
{
    public partial class DataSetFile2 : Fox.Core.EntityFile
    {
        private partial Fox.Core.DataSet Get_dataSet() => throw new System.NotImplementedException();

        [StructLayout(LayoutKind.Sequential, Size = 0x20)]
        internal struct FileHeader
        {
            public uint Unknown0;
            public uint Unknown1;
            
            public uint EntityCount;
            public int StringTableOffset;

            public int EntitiesOffset;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x40)]
        internal struct EntityDef
        {
            [FieldOffset(0x0)] public ushort HeaderSize;
            [FieldOffset(0x2)] public uint ClassId;
            [FieldOffset(0x6)] public uint Signature;
            [FieldOffset(0xA)] public ulong Address;
            [FieldOffset(0x12)] public ulong Id;
            [FieldOffset(0x1A)] public ushort Version;
            
            [FieldOffset(0x1C)] public StrCode ClassName;
            [FieldOffset(0x24)] public ushort StaticPropertyCount;
            [FieldOffset(0x26)] public ushort DynamicPropertyCount;

            [FieldOffset(0x28)] public uint StaticPropertiesOffset;
            [FieldOffset(0x2C)] public uint DynamicPropertiesOffset;
            
            [FieldOffset(0x30)] public uint NextEntityOffset;
        }
        
        [StructLayout(LayoutKind.Sequential, Size = 0x20)]
        internal struct PropertyDef
        {
            public StrCode Name;
            
            public PropertyInfo.PropertyType DataType;
            public PropertyInfo.ContainerType ContainerType;

            public ushort ArraySize;

            public ushort PayloadOffset;
            public ushort NextPropertyOffset;
        }
        
        [StructLayout(LayoutKind.Explicit, Size = 0xC)]
        internal struct StringData
        {
            [FieldOffset(0x0)]
            public StrCode Hash;
            
            [FieldOffset(0x8)]
            public int Length;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x20)]
        internal struct EntityLinkDef
        {
            [FieldOffset(0x0)]
            public StrCode PackagePathHash;
            [FieldOffset(0x8)]
            public StrCode ArchivePathHash;
            [FieldOffset(0x10)]
            public StrCode NameInArchiveHash;
            [FieldOffset(0x18)]
            public ulong Address;
        }

        public enum SceneLoadMode
        {
            ForceSingle,
            Additive,
            Auto,
        }

        private static UnityEngine.SceneManagement.Scene CreateScene(SceneLoadMode mode)
        {
            switch (mode)
            {
                case SceneLoadMode.ForceSingle:
                    return EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
                case SceneLoadMode.Additive:
                    return EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
                default:
                {
                    UnityEngine.SceneManagement.Scene scene;
                    if (EditorSceneManager.EnsureUntitledSceneHasBeenSaved("Please save existing scene."))
                    {
                        scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
                    }
                    else
                    {
                        scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
                    }

                    return scene;
                }
            }
        }

        public static UnityEngine.SceneManagement.Scene Read(ReadOnlySpan<byte> data, SceneLoadMode sceneMode, TaskLogger logger)
        {
            UnityEngine.SceneManagement.Scene scene = CreateScene(sceneMode);
            
            DataSetFile2Reader reader = new DataSetFile2Reader();
            _ = reader.Read(data, logger);

            return scene;
        }

        public static GameObject GetPrefab(FilePtr filepath)
        {
            var logger = new TaskLogger("GetPrefab");

            GameObject prefab = PrefabUtility.LoadPrefabContents(filepath.path.String+".asset");
            
            if (prefab==null)
            {
                //create it
                DataSetFile2Reader reader = new DataSetFile2Reader();
                var data = Fox.Fs.FileSystem.ReadExternalFile(filepath.path.String);
                ReadOnlySpan<Entity> entities = reader.Read(data, logger);

                GameObject parent = null;

                foreach (Entity obj in entities)
                {
                    if (obj is DataSet set)
                    {
                        parent = set.gameObject;
                        break;
                    }
                }

                parent ??= new("dummy");


                // Loop through every GameObject in the array above
                foreach (Entity obj in entities)
                {
                    GameObject gameObject = obj.gameObject;
                    if (gameObject.transform.parent is null)
                        gameObject.transform.SetParent(parent.transform);
                }

                // Create the new Prefab and log whether Prefab was saved successfully.
                prefab = PrefabUtility.SaveAsPrefabAssetAndConnect(parent, filepath.path.String+".asset", InteractionMode.UserAction, out var prefabSuccess);
                if (prefabSuccess != true)
                    logger.AddError("Prefab failed to save" + false);

                Destroy(parent);

                //return it
            }

            return prefab;
        }

        public static UnityEngine.SceneManagement.Scene Read(ReadOnlySpan<byte> data, SceneLoadMode sceneMode, TaskLogger logger, out ReadOnlySpan<Entity> entities)
        {
            UnityEngine.SceneManagement.Scene scene = CreateScene(sceneMode);
            
            DataSetFile2Reader reader = new DataSetFile2Reader();
            entities = reader.Read(data, logger);

            return scene;
        }
    }
}