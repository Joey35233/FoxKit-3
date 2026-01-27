using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using GzsTool.Core.Qar;
using GzsTool.Core.Fpk;
using GzsTool.Core.Utility;
using GzsTool.Core.Common;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace FoxKit.Windows
{
    [System.Serializable]
    public class PackFileList : ScriptableObject
    {
        public List<string> Files = new List<string>();
        public List<string> Data = new List<string>();
        public List<string> References = new List<string>();
    }

    public class ArchiveTransferrerWindow : EditorWindow
    {
        private string gameDir;
        private string outputFolderName;
        private bool exePathValid;

        // UI / state
        private bool abortRequested = false;
        private bool _isRunning = false;
        private CancellationTokenSource _cts;

        private Dictionary<string, bool> ignoredFilesMap = new Dictionary<string, bool>();
        private Dictionary<string, bool> ignoredExtensionsMap = new Dictionary<string, bool>();

        private Vector2 scrollPosFiles;
        private Vector2 scrollPosExts;

        private bool showFilesList = true;
        private bool showExtensionsList = true;

        // Hardcoded ignored .dat files
        private static readonly string[] hardcodedIgnoredDatFiles =
        {
            "e2f8e499bc8f3606",
            "e2f9a1fda590d087",
            "e2faa449a7e0781d",
            "e2fb02c35da41a21",
            "e2fbebbd66f86086"
        };

        // MGSV file extensions
        private static readonly string[] defaultExtensions =
        {
            ".adm",".atsh",".bnk",".bnd",".caar",".cani",".chnk",".clo",".dat",".des",".dfrm",
            ".ends",".enchnk",".evf",".exchnk",".fclo",".fcnp",".fdes",".ffnt",".fmdl",".fmtt",
            ".fnt",".fox2",".fpk",".fpkd",".fpkl",".frdv",".frig",".frl",".frld",".frt",".fsd",
            ".fsm",".fsop",".fstb",".ftdp",".ftex",".ftexs",".fv2",".gani",".geobv",".geom",".geoms",
            ".gpfp",".grxla",".grxoc",".gskl",".htre",".json",".lad",".ladb",".las",".lba",".lng",
            ".lng2",".lpsh",".ls",".lua",".mbl",".mog",".mtar",".mtard",".nav2",".nta",".obr",".obrb",
            ".parts",".pcsp",".pftxs",".ph",".phsd",".rdf",".sab",".sand",".sani",".sbp",".sdf",
            ".sim",".spch",".st",".stp",".subp",".tcvp",".tgt",".trap",".tre2",".trk",".twpf",
            ".uia",".uif",".uigb",".uilb",".veh",".vfx",".vfxlb",".vfxlf",".wem"
        };

        [MenuItem("FoxKit/Archive Transferrer", false, 100)]
        public static void ShowWindow() => GetWindow<ArchiveTransferrerWindow>("Archive Transferrer");

        private void OnEnable()
        {
            outputFolderName = SettingsManager.LooseBasePath;
            ValidateExePath();
            RefreshIgnoreLists();
        }

        private void OnDisable()
        {
            // Cleanup
            try { _cts?.Cancel(); } catch { }
            try { _cts?.Dispose(); } catch { }
            _cts = null;
        }

        private void ValidateExePath()
        {
            string exePath = SettingsManager.GameDirBasePath;
            exePathValid = !string.IsNullOrEmpty(exePath) && File.Exists(exePath);
        }

        private void RefreshIgnoreLists()
        {
            ignoredFilesMap.Clear();
            ignoredExtensionsMap.Clear();

            HashSet<string> hardcodedSet = new HashSet<string>(hardcodedIgnoredDatFiles);
            string exePath = SettingsManager.GameDirBasePath;

            if (!string.IsNullOrEmpty(exePath) && File.Exists(exePath))
            {
                string masterDir = Path.Combine(Path.GetDirectoryName(exePath), "master");
                if (Directory.Exists(masterDir))
                {
                    string[] datFiles = Directory.GetFiles(masterDir, "*.dat", SearchOption.AllDirectories);
                    foreach (string datFile in datFiles)
                    {
                        string name = Path.GetFileNameWithoutExtension(datFile);
                        if (!hardcodedSet.Contains(name))
                        {
                            string relativePath = datFile
                                .Replace(masterDir + Path.DirectorySeparatorChar, "")
                                .Replace("\\", "/");
                            ignoredFilesMap[relativePath] = false;
                        }
                    }
                }
            }

            // Default: NOT ignored (otherwise you extract almost nothing)
            foreach (string ext in defaultExtensions)
                ignoredExtensionsMap[ext] = false;
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.HelpBox(
                "Transfers and extracts MGSV archive files (.dat, .fpk) into your Unity project.\n" +
                "You can manage ignored files and extensions below.",
                MessageType.Info
            );
            EditorGUILayout.EndVertical();

            // Game exe
            EditorGUILayout.LabelField("Game Executable Path", EditorStyles.boldLabel);
            GUI.enabled = false;
            string exePath = SettingsManager.GameDirBasePath;
            EditorGUILayout.TextField(exePath);
            GUI.enabled = true;

            if (!exePathValid)
            {
                EditorGUILayout.HelpBox("Invalid MGSV executable path. Configure it in FoxKit > Settings.", MessageType.Warning);
                if (GUILayout.Button("Open FoxKit Settings"))
                    SettingsManager.ShowSettingsWindow();
                return;
            }

            EditorGUILayout.Space();

            // Output folder
            EditorGUILayout.LabelField("Output Folder", EditorStyles.boldLabel);
            GUI.enabled = false;
            EditorGUILayout.TextField(SettingsManager.LooseBasePath);
            GUI.enabled = true;

            DrawSeparator();

            // Ignore lists
            showFilesList = EditorGUILayout.Foldout(showFilesList, "Ignored Archives (.dat)", true, EditorStyles.foldoutHeader);
            if (showFilesList)
            {
                EditorGUILayout.BeginVertical("box");
                DrawIgnoreList(ignoredFilesMap, ref scrollPosFiles);
                EditorGUILayout.EndVertical();
            }

            showExtensionsList = EditorGUILayout.Foldout(showExtensionsList, "Ignored Extensions", true, EditorStyles.foldoutHeader);
            if (showExtensionsList)
            {
                EditorGUILayout.BeginVertical("box");
                DrawIgnoreList(ignoredExtensionsMap, ref scrollPosExts);
                EditorGUILayout.EndVertical();
            }

            GUILayout.FlexibleSpace();
            DrawSeparator();

            // Buttons
            EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
            GUILayout.FlexibleSpace();

            GUI.enabled = !_isRunning;
            if (GUILayout.Button("Transfer Archive", GUILayout.Width(200), GUILayout.Height(35)))
            {
                abortRequested = false;
                _cts?.Dispose();
                _cts = new CancellationTokenSource();
                TransferArchive(exePath, _cts.Token);
            }

            GUI.enabled = _isRunning;
            if (GUILayout.Button("Abort", GUILayout.Width(120), GUILayout.Height(35)))
            {
                abortRequested = true;
                try { _cts?.Cancel(); } catch { }
            }
            GUI.enabled = true;

            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();
        }

        private void DrawIgnoreList(Dictionary<string, bool> dict, ref Vector2 scrollPos)
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Select All", GUILayout.Width(100))) SetAll(dict, true);
            if (GUILayout.Button("Deselect All", GUILayout.Width(100))) SetAll(dict, false);
            if (GUILayout.Button("Refresh", GUILayout.Width(100))) RefreshIgnoreLists();
            GUILayout.FlexibleSpace();
            EditorGUILayout.EndHorizontal();

            float listHeight = Mathf.Min(180, dict.Count * 22 + 10);
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(listHeight));
            {
                if (dict.Count == 0)
                    EditorGUILayout.HelpBox("No items found.", MessageType.Info);
                else
                {
                    var keys = new List<string>(dict.Keys);
                    keys.Sort(StringComparer.OrdinalIgnoreCase);
                    foreach (var key in keys)
                        dict[key] = EditorGUILayout.ToggleLeft(key, dict[key]);
                }
            }
            EditorGUILayout.EndScrollView();
        }

        private void SetAll(Dictionary<string, bool> dict, bool value)
        {
            var keys = new List<string>(dict.Keys);
            foreach (var key in keys)
                dict[key] = value;
        }

        private void DrawSeparator()
        {
            Rect rect = EditorGUILayout.GetControlRect(false, 2);
            EditorGUI.DrawRect(rect, new Color(0.25f, 0.25f, 0.25f, 1f));
        }

        private async void TransferArchive(string exePath, CancellationToken token)
        {
            ValidateExePath();
            if (!exePathValid) return;

            _isRunning = true;

            gameDir = Path.GetDirectoryName(exePath);
            string destinationPath = Path.Combine(
                Directory.GetParent(Application.dataPath).FullName,
                SettingsManager.LooseBasePath
            );

            string masterPath = Path.Combine(gameDir, "master");
            if (!Directory.Exists(masterPath))
            {
                _isRunning = false;
                return;
            }

            string dictPath = Path.Combine(Application.dataPath, "Plugin", "GzsTool", "qar_dictionary.txt");
            if (File.Exists(dictPath))
            {
                try { Hashing.ReadDictionary(dictPath); } catch { /* ignore */ }
            }

            // Build ignore sets
            var ignoredFiles = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var kv in ignoredFilesMap)
                if (kv.Value)
                    ignoredFiles.Add(Path.GetFileNameWithoutExtension(kv.Key));
            foreach (string h in hardcodedIgnoredDatFiles)
                ignoredFiles.Add(h);

            var ignoredExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var kv in ignoredExtensionsMap)
                if (kv.Value)
                    ignoredExtensions.Add(kv.Key);

            // Build ordered .dat list
            List<string> orderedDatFiles = new List<string>();
            string[] baseOrder =
            {
                "chunk0.dat", "chunk1.dat", "chunk2.dat", "chunk4.dat",
                "data1.dat",
                "texture0.dat", "texture1.dat", "texture2.dat", "texture3.dat", "texture4.dat"
            };

            foreach (string name in baseOrder)
            {
                string fullPath = Path.Combine(masterPath, name);
                if (File.Exists(fullPath))
                    orderedDatFiles.Add(fullPath);
            }

            string patch0Path = Path.Combine(masterPath, "0");
            if (Directory.Exists(patch0Path))
                orderedDatFiles.AddRange(Directory.GetFiles(patch0Path, "*.dat", SearchOption.AllDirectories));

            string updatePath = Path.Combine(masterPath, "1", "MGSVTUPDATEV0110");
            if (Directory.Exists(updatePath))
                orderedDatFiles.AddRange(Directory.GetFiles(updatePath, "*.dat", SearchOption.AllDirectories));

            int total = orderedDatFiles.Count;
            int done = 0;

            // Temp root for deterministic merge
            string tempRoot = Path.Combine(Path.GetTempPath(), "FoxKitExtract");
            try { if (Directory.Exists(tempRoot)) Directory.Delete(tempRoot, true); } catch { }
            Directory.CreateDirectory(tempRoot);

            // Store per-dat temp output so we can merge in correct order
            string[] tempDirs = new string[total];

            // Main-thread progress updater
            void UpdateProgress()
            {
                float progress = (float)done / Mathf.Max(1, total);
                EditorUtility.DisplayProgressBar(
                    "Extracting Archives",
                    $"Processing... ({done}/{total})",
                    progress
                );
            }
            EditorApplication.update += UpdateProgress;

            // Throttle parallelism
            int maxParallel = Mathf.Clamp(Environment.ProcessorCount - 1, 1, 6);
            using var gate = new SemaphoreSlim(maxParallel);

            try
            {
                AssetDatabase.StartAssetEditing();

                var tasks = new List<Task>(total);

                for (int i = 0; i < total; i++)
                {
                    string datFile = orderedDatFiles[i];

                    if (token.IsCancellationRequested || abortRequested)
                        break;

                    string fileNameOnly = Path.GetFileNameWithoutExtension(datFile);
                    if (ignoredFiles.Contains(fileNameOnly))
                    {
                        Interlocked.Increment(ref done);
                        continue;
                    }

                    string datTempDir = Path.Combine(tempRoot, $"{i:D4}_{fileNameOnly}");
                    tempDirs[i] = datTempDir;

                    tasks.Add(Task.Run(async () =>
                    {
                        await gate.WaitAsync(token).ConfigureAwait(false);
                        try
                        {
                            token.ThrowIfCancellationRequested();

                            Directory.CreateDirectory(datTempDir);

                            using (FileStream stream = File.OpenRead(datFile))
                            {
                                if (!QarFile.IsQarFile(stream))
                                    return;

                                QarFile qar = new QarFile { Name = Path.GetFileName(datFile) };
                                stream.Position = 0;
                                qar.Read(stream);

                                FileSystemDirectory outputDir = new FileSystemDirectory(datTempDir);

                                foreach (var qarEntry in qar.ExportFiles(stream))
                                {
                                    token.ThrowIfCancellationRequested();

                                    string qarExt = Path.GetExtension(qarEntry.FileName).ToLowerInvariant();
                                    if (ignoredExtensions.Contains(qarExt))
                                        continue;

                                    outputDir.WriteFile(qarEntry.FileName, qarEntry.DataStream);

                                    if (qarExt == ".fpk" || qarExt == ".fpkd")
                                    {
                                        string fpkOnDisk = Path.Combine(datTempDir, qarEntry.FileName);
                                        if (!File.Exists(fpkOnDisk))
                                            continue;

                                        using (FileStream fpkStream = File.OpenRead(fpkOnDisk))
                                        {
                                            FpkFile fpk = new FpkFile();
                                            fpk.Read(fpkStream);

                                            foreach (var fpkEntry in fpk.ExportFiles(fpkStream))
                                            {
                                                token.ThrowIfCancellationRequested();

                                                string entryExt = Path.GetExtension(fpkEntry.FileName).ToLowerInvariant();
                                                if (ignoredExtensions.Contains(entryExt))
                                                    continue;

                                                string extractedPath = Path.Combine(datTempDir, fpkEntry.FileName);
                                                Directory.CreateDirectory(Path.GetDirectoryName(extractedPath));

                                                using (Stream src = fpkEntry.DataStream())
                                                using (FileStream outStream = File.Create(extractedPath))
                                                    src.CopyTo(outStream);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (OperationCanceledException)
                        {
                            // user aborted
                        }
                        catch (Exception e)
                        {
                            Debug.LogWarning($"Error unpacking {datFile}: {e.Message}");
                        }
                        finally
                        {
                            gate.Release();
                            Interlocked.Increment(ref done);
                        }
                    }, token));
                }

                await Task.WhenAll(tasks);

                if (token.IsCancellationRequested || abortRequested)
                {
                    Debug.LogWarning("Extraction aborted by user.");
                    return;
                }

                // Merge in correct order (later dat overrides earlier)
                Directory.CreateDirectory(destinationPath);

                for (int i = 0; i < total; i++)
                {
                    string dir = tempDirs[i];
                    if (string.IsNullOrEmpty(dir) || !Directory.Exists(dir))
                        continue;

                    foreach (string file in Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories))
                    {
                        string rel = file.Substring(dir.Length + 1).Replace("\\", "/");
                        string dest = Path.Combine(destinationPath, rel);

                        Directory.CreateDirectory(Path.GetDirectoryName(dest));
                        File.Copy(file, dest, true);
                    }
                }

                Debug.Log($"Extraction complete: {destinationPath}");
            }
            finally
            {
                EditorApplication.update -= UpdateProgress;
                EditorUtility.ClearProgressBar();

                try { if (Directory.Exists(tempRoot)) Directory.Delete(tempRoot, true); } catch { }

                AssetDatabase.StopAssetEditing();
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                _isRunning = false;
            }
        }
    }
}