using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;
using Fox.Core;
using Fox.Core.Utils;
using Scene = UnityEngine.SceneManagement.Scene;
using File = System.IO.File;
using Application = UnityEngine.Application;

[CreateAssetMenu(fileName = "NewPackFileList", menuName = "FoxKit/Pack File List")]
public class PackFileList : ScriptableObject
{
    public List<string> Files = new List<string>();     // FPK
    public List<string> Data = new List<string>();      // FPKD
    public List<string> Textures = new List<string>();  // PFTXS (optional/future)
    public List<string> References = new List<string>();
}

[CustomEditor(typeof(PackFileList))]
public class PackFileListEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GUILayout.Space(10);

        if (GUILayout.Button("Load All .fox2 Scenes"))
        {
            var packFileList = (PackFileList)target;

            foreach (string relativePath in packFileList.Data)
            {
                if (!relativePath.EndsWith(".fox2", System.StringComparison.OrdinalIgnoreCase))
                    continue;

                string gamePathRoot = Path.Combine(Application.dataPath, "Game");
                string fox2Path = Path.Combine(gamePathRoot, relativePath).Replace("\\", "/");

                if (!File.Exists(fox2Path))
                {
                    Debug.LogWarning($"[PackFileList] .fox2 file not found at: {fox2Path}");
                    continue;
                }

                Debug.Log($"[PackFileList] Importing: {relativePath}");

                // Import fox2 binary
                string scenePath = Path.Combine("Assets/Game", relativePath + ".unity").Replace("\\", "/");
                string sceneDirectory = Path.GetDirectoryName(scenePath);
                if (!Directory.Exists(sceneDirectory))
                    Directory.CreateDirectory(sceneDirectory);

                // Read .fox2 binary
                var fox2Reader = new DataSetFile2Reader();
                var logger = new TaskLogger(relativePath);
                byte[] fox2Bytes = File.ReadAllBytes(fox2Path);
                fox2Reader.Read(fox2Bytes, logger);

                // Create scene
                Scene foxScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
                foxScene.name = Path.GetFileNameWithoutExtension(relativePath);

                // Save scene
                EditorSceneManager.SaveScene(foxScene, scenePath);
                logger.LogToUnityConsole();

                Debug.Log($"[PackFileList] Imported and saved scene: {scenePath}");

                // Load scene
                EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Additive);
            }
        }
    }
}