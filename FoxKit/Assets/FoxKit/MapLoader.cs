using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Fox.Core.Utils;
using Fox.Fs;
using Fox.Core;
using UnityEditor.SceneManagement;
using Application = UnityEngine.Application;

namespace FoxKit.Windows
{
    public class MapLoader : EditorWindow
    {
        private const int CellWidth = 14;
        private const int CellHeight = 14;

        private static readonly List<string> Locations = new List<string> { "AFGH", "CYPR", "MAFR", "MBQF" };

        private static readonly Dictionary<string, MapBounds> BoundsByLocation = new Dictionary<string, MapBounds>
        {
            { "AFGH", new MapBounds(101, 101, 164, 164) },
            { "CYPR", new MapBounds(1,   1,   1,   9)   },
            { "MAFR", new MapBounds(101, 101, 164, 164) },
            { "MBQF", new MapBounds(101, 101, 102, 102) },
        };

        private Label selectedLabel;
        private Label hoverLabel;
        private VisualElement gridHost;

        // Prevent importing the same file multiple times
        private readonly HashSet<string> importedExternalFox2 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        [MenuItem("FoxKit/Import/Map Loader")]
        public static void Open()
        {
            MapLoader window = GetWindow<MapLoader>();
            window.titleContent = new GUIContent("Map Loader");
            window.minSize = new Vector2(700, 520);
        }

        public void CreateGUI()
        {
            VisualElement root = rootVisualElement;
            root.style.paddingLeft = 6;
            root.style.paddingRight = 6;
            root.style.paddingTop = 6;
            root.style.paddingBottom = 6;

            var header = new VisualElement();
            header.style.flexDirection = FlexDirection.Row;
            header.style.alignItems = Align.Center;
            header.style.marginBottom = 6;

            header.Add(new Label("Location:"));

            var locationDropdown = new PopupField<string>(Locations, 0);
            locationDropdown.name = "locationDropdown";
            locationDropdown.style.minWidth = 120;
            header.Add(locationDropdown);

            selectedLabel = new Label("Selected: none");
            selectedLabel.style.unityFontStyleAndWeight = FontStyle.Bold;
            selectedLabel.style.marginLeft = 12;
            header.Add(selectedLabel);

            hoverLabel = new Label("Hover: none");
            hoverLabel.style.marginLeft = 14;
            header.Add(hoverLabel);

            root.Add(header);

            var scroll = new ScrollView(ScrollViewMode.VerticalAndHorizontal);
            scroll.style.flexGrow = 1;
            root.Add(scroll);

            gridHost = new VisualElement();
            scroll.Add(gridHost);

            RebuildGrid(locationDropdown.value);
            locationDropdown.RegisterValueChangedCallback(evt => RebuildGrid(evt.newValue));
        }

        private void RebuildGrid(string location)
        {
            MapBounds bounds;
            if (!BoundsByLocation.TryGetValue(location, out bounds))
                bounds = new MapBounds(101, 101, 164, 164);

            selectedLabel.text = "Selected: none";
            hoverLabel.text = "Hover: none";

            gridHost.Clear();

            var grid = new HoverGrid(bounds, CellWidth, CellHeight);

            grid.SelectionChanged += (mapX, mapY, index0) =>
            {
                selectedLabel.text =
                    "Selected: X=" + mapX + ", Y=" + mapY +
                    " | Index0=" + index0 + " | Index1=" + (index0 + 1);

                ImportFox2ForTile(location, mapX, mapY);
            };

            grid.HoverChanged += (mapX, mapY, index0) =>
            {
                if (index0 < 0)
                {
                    hoverLabel.text = "Hover: none";
                    return;
                }
                else
                { 
                hoverLabel.text =
                    "Hover: X=" + mapX + ", Y=" + mapY +
                    " | Index0=" + index0 + " | Index1=" + (index0 + 1);
                }
            };

            gridHost.Add(grid);
        }

        private struct MapBounds
        {
            public int StartX, StartY, EndX, EndY;

            public MapBounds(int startX, int startY, int endX, int endY)
            {
                StartX = startX; StartY = startY; EndX = endX; EndY = endY;
            }

            public int Cols { get { return (EndX - StartX) + 1; } }
            public int Rows { get { return (EndY - StartY) + 1; } }
        }

        private sealed class HoverGrid : VisualElement
        {
            public event Action<int, int, int> SelectionChanged;
            public event Action<int, int, int> HoverChanged;

            private readonly MapBounds bounds;
            private readonly int rows, cols;
            private readonly int cellW, cellH;

            private int selectedRow = -1, selectedCol = -1;
            private int hoverRow = -1, hoverCol = -1;

            private static readonly Color Bg = new Color(0f, 0f, 0f, 0.08f);
            private static readonly Color Line = new Color(0f, 0f, 0f, 0.25f);

            private static readonly Color SelFill = new Color(0.25f, 0.6f, 1f, 0.45f);
            private static readonly Color SelBorder = new Color(0.25f, 0.6f, 1f, 0.95f);
            private static readonly Color HoverBorder = new Color(1f, 1f, 1f, 0.55f);

            public HoverGrid(MapBounds bounds, int cellWidth, int cellHeight)
            {
                this.bounds = bounds;

                rows = Mathf.Max(1, bounds.Rows);
                cols = Mathf.Max(1, bounds.Cols);

                cellW = Mathf.Max(2, cellWidth);
                cellH = Mathf.Max(2, cellHeight);

                style.width = cols * cellW + 1;
                style.height = rows * cellH + 1;

                pickingMode = PickingMode.Position;

                generateVisualContent += Draw;

                RegisterCallback<MouseDownEvent>(OnMouseDown);
                RegisterCallback<MouseMoveEvent>(OnMouseMove);
                RegisterCallback<MouseLeaveEvent>(OnMouseLeave);
            }

            private void OnMouseLeave(MouseLeaveEvent _)
            {
                if (hoverRow == -1 && hoverCol == -1)
                    return;

                hoverRow = -1;
                hoverCol = -1;

                if (HoverChanged != null)
                    HoverChanged(0, 0, -1);

                MarkDirtyRepaint();
            }

            private void OnMouseMove(MouseMoveEvent e)
            {
                int r, c;
                if (!TryGetCell(e.mousePosition, out r, out c))
                {
                    if (hoverRow != -1 || hoverCol != -1)
                        OnMouseLeave(null);
                    return;
                }

                if (hoverRow == r && hoverCol == c)
                    return;

                hoverRow = r;
                hoverCol = c;

                int mapX, mapY, index0;
                GetCellInfo(r, c, out mapX, out mapY, out index0);

                if (HoverChanged != null)
                    HoverChanged(mapX, mapY, index0);

                MarkDirtyRepaint();
            }

            private void OnMouseDown(MouseDownEvent e)
            {
                if (e.button != 0)
                    return;

                int r, c;
                if (!TryGetCell(e.mousePosition, out r, out c))
                    return;

                if (selectedRow == r && selectedCol == c)
                    return;

                selectedRow = r;
                selectedCol = c;

                int mapX, mapY, index0;
                GetCellInfo(r, c, out mapX, out mapY, out index0);

                if (SelectionChanged != null)
                    SelectionChanged(mapX, mapY, index0);

                MarkDirtyRepaint();
                e.StopPropagation();
            }

            private void GetCellInfo(int row, int col, out int mapX, out int mapY, out int index0)
            {
                mapX = bounds.StartX + col;
                mapY = bounds.StartY + row;
                index0 = (row * cols) + col;
            }

            private bool TryGetCell(Vector2 mouseWorld, out int row, out int col)
            {
                row = -1;
                col = -1;

                Vector2 local = mouseWorld - new Vector2(worldBound.xMin, worldBound.yMin);

                col = Mathf.FloorToInt(local.x / cellW);
                row = Mathf.FloorToInt(local.y / cellH);

                if (row < 0 || row >= rows || col < 0 || col >= cols)
                    return false;

                return true;
            }

            private static void RectPath(Painter2D p, Rect r)
            {
                p.BeginPath();
                p.MoveTo(new Vector2(r.xMin, r.yMin));
                p.LineTo(new Vector2(r.xMax, r.yMin));
                p.LineTo(new Vector2(r.xMax, r.yMax));
                p.LineTo(new Vector2(r.xMin, r.yMax));
                p.LineTo(new Vector2(r.xMin, r.yMin));
            }

            private void Draw(MeshGenerationContext ctx)
            {
                Painter2D p = ctx.painter2D;

                float gridW = cols * cellW;
                float gridH = rows * cellH;

                p.fillColor = Bg;
                RectPath(p, new Rect(0, 0, gridW, gridH));
                p.Fill();

                if (hoverRow >= 0 && hoverCol >= 0)
                {
                    float x = hoverCol * cellW;
                    float y = hoverRow * cellH;

                    p.strokeColor = HoverBorder;
                    p.lineWidth = 1f;
                    RectPath(p, new Rect(x, y, cellW, cellH));
                    p.Stroke();
                }

                if (selectedRow >= 0 && selectedCol >= 0)
                {
                    float x = selectedCol * cellW;
                    float y = selectedRow * cellH;

                    p.fillColor = SelFill;
                    RectPath(p, new Rect(x, y, cellW, cellH));
                    p.Fill();

                    p.strokeColor = SelBorder;
                    p.lineWidth = 2f;
                    RectPath(p, new Rect(x, y, cellW, cellH));
                    p.Stroke();
                }

                p.strokeColor = Line;
                p.lineWidth = 1f;

                p.BeginPath();
                for (int c = 0; c <= cols; c++)
                {
                    float x = c * cellW;
                    p.MoveTo(new Vector2(x, 0));
                    p.LineTo(new Vector2(x, gridH));
                }
                p.Stroke();

                p.BeginPath();
                for (int r = 0; r <= rows; r++)
                {
                    float y = r * cellH;
                    p.MoveTo(new Vector2(0, y));
                    p.LineTo(new Vector2(gridW, y));
                }
                p.Stroke();
            }
        }

        private void ImportFox2ForTile(string location, int mapX, int mapY)
        {
            string internalRoot = Path.Combine(
                Application.dataPath,
                "Game", "Assets", "tpp", "level", "location",
                location.ToLowerInvariant()
            );

            List<string> tileFolders = FindTileDirs(internalRoot, location, mapX, mapY);

            bool anyInternalScenes = false;

            if (tileFolders != null && tileFolders.Count > 0)
            {
                for (int i = 0; i < tileFolders.Count; i++)
                {
                    string folder = tileFolders[i];

                    if (!Directory.Exists(folder))
                        continue;

                    // contains at least one .unity file, we're good!!!
                    var e = Directory.EnumerateFiles(folder, "*.unity", SearchOption.AllDirectories).GetEnumerator();
                    if (e.MoveNext())
                    {
                        anyInternalScenes = true;
                        break;
                    }
                }
            }

            if (tileFolders == null || tileFolders.Count == 0 || anyInternalScenes == false)
            {
                string externalRoot = SettingsManager.ExternalBasePath;

                if (string.IsNullOrEmpty(externalRoot) || !Directory.Exists(externalRoot))
                {
                    Debug.LogError("[MapLoader] ExternalBasePath is not set or invalid. Open FoxKit settings and set it.");
                    FoxKit.SettingsManager.ShowSettingsWindow();
                    return;
                }

                string locationRoot = Path.Combine(
                    externalRoot,
                    "Assets", "tpp", "level", "location",
                    location.ToLowerInvariant()
                );

                if (!Directory.Exists(locationRoot))
                {
                    Debug.LogWarning("[MapLoader] Location folder not found: " + locationRoot);
                    return;
                }

                tileFolders = FindTileDirs(locationRoot, location, mapX, mapY);

                if (tileFolders == null || tileFolders.Count == 0)
                {
                    Debug.LogWarning("[MapLoader] Tile folder not found for " + location +
                                     " X=" + mapX + " Y=" + mapY + " in block_small/block_extraSmall.");
                    return;
                }

                List<string> fox2Files = CollectFox2Files(tileFolders);

                if (fox2Files.Count == 0)
                {
                    Debug.LogWarning("[MapLoader] No .fox2 files found for " + location +
                                     " X=" + mapX + " Y=" + mapY + ".");
                    return;
                }

                ImportFox2FilesWithProgress(location, mapX, mapY, fox2Files);
                return;
            }

            string dataPathNorm = Application.dataPath.Replace('\\', '/');
            List<string> sceneAssetPaths = new List<string>();

            for (int i = 0; i < tileFolders.Count; i++)
            {
                string folder = tileFolders[i];

                if (!Directory.Exists(folder))
                    continue;

                foreach (string fullPath in Directory.EnumerateFiles(folder, "*.unity", SearchOption.AllDirectories))
                {
                    string norm = fullPath.Replace('\\', '/');

                    if (!norm.StartsWith(dataPathNorm))
                        continue;

                    string relative = norm.Substring(dataPathNorm.Length);
                    string assetPath = "Assets" + relative;

                    if (!sceneAssetPaths.Contains(assetPath))
                        sceneAssetPaths.Add(assetPath);
                }
            }

            for (int i = 0; i < sceneAssetPaths.Count; i++)
            {
                EditorSceneManager.OpenScene(sceneAssetPaths[i], OpenSceneMode.Additive);
            }

            Debug.Log("Opened internal tile scenes additively (import skipped).");
        }

        private static List<string> CollectFox2Files(List<string> tileDirs)
        {
            var unique = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < tileDirs.Count; i++)
            {
                string dir = tileDirs[i];
                foreach (string file in Directory.EnumerateFiles(dir, "*.fox2", SearchOption.AllDirectories))
                    unique.Add(file);
            }

            var list = new List<string>(unique);
            list.Sort(StringComparer.OrdinalIgnoreCase);
            return list;
        }

        private void ImportFox2FilesWithProgress(string location, int mapX, int mapY, List<string> fox2Files)
        {
            TaskLogger logger = new TaskLogger("Import Tile FOX2 [" + location + "] " + mapX + "_" + mapY);

            int imported = 0;
            int failed = 0;

            try
            {
                int total = fox2Files.Count;
                int processed = 0;

                for (int i = 0; i < total; i++)
                {
                    string externalFile = fox2Files[i];

                    if (importedExternalFox2.Contains(externalFile))
                        continue;

                    processed++;

                    EditorUtility.DisplayProgressBar(
                        "Importing FOX2",
                        location + " " + mapX + "_" + mapY + " (" + processed + ")\n" + Path.GetFileName(externalFile),
                        total > 0 ? (float)processed / (float)total : 1f
                    );

                    try
                    {
                        ImportOneFox2(externalFile, logger, true);
                        importedExternalFox2.Add(externalFile);
                        imported++;
                    }
                    catch (Exception ex)
                    {
                        failed++;
                        logger.AddError("Failed importing: " + externalFile + "\n" + ex);
                    }
                }
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }

            logger.LogToUnityConsole();
            Debug.Log("[MapLoader] Import complete for " + location + " " + mapX + "_" + mapY +
                      ". Imported=" + imported + ", Failed=" + failed);
        }

        private static void ImportOneFox2(string externalFile, TaskLogger logger, bool keepScenesOpen)
        {
            string foxPath = Fox.Fs.FileSystem.GetFoxPathFromExternalPath(externalFile);
            foxPath = NormalizeFoxPath(foxPath);

            DataSetFile2.SceneLoadMode loadMode;
            if (keepScenesOpen)
                loadMode = DataSetFile2.SceneLoadMode.Additive;
            else
                loadMode = DataSetFile2.SceneLoadMode.Auto;

            if (!string.IsNullOrEmpty(foxPath) && foxPath.StartsWith("/Assets/"))
            {
                ReadOnlySpan<byte> data = Fox.Fs.FileSystem.ReadExternalFile(foxPath);
                UnityEngine.SceneManagement.Scene scene = DataSetFile2.Read(data, loadMode, logger);
                Fox.Fs.FileSystem.TryImportAsset(scene, foxPath);
                return;
            }

            {
                ReadOnlySpan<byte> data = Fox.Fs.FileSystem.ReadLooseFile(externalFile);
                UnityEngine.SceneManagement.Scene scene = DataSetFile2.Read(data, loadMode, logger);
                Fox.Fs.FileSystem.TryImportAsset(scene, externalFile, ImportFileMode.Loose);
            }
        }

        private static string NormalizeFoxPath(string foxPath)
        {
            if (string.IsNullOrEmpty(foxPath))
                return null;

            foxPath = foxPath.Replace('\\', '/');

            if (foxPath.Length > 0 && foxPath[0] != '/')
                foxPath = "/" + foxPath;

            if (foxPath.StartsWith("/assets/"))
                foxPath = "/Assets/" + foxPath.Substring("/assets/".Length);

            return foxPath;
        }

        private static List<string> FindTileDirs(string locationRoot, string location, int mapX, int mapY)
        {
            var results = new List<string>();

            string locLower = location.ToLowerInvariant();
            bool isCypr = (locLower == "cypr");

            string xRaw = mapX.ToString();
            string xP2 = mapX.ToString("D2");

            string yRaw = mapY.ToString();
            string yP2 = mapY.ToString("D2");

            string xyRaw = mapX + "_" + mapY;
            string xyP2 = mapX.ToString("D2") + "_" + mapY.ToString("D2");

            string[] blocks = { "block_extraSmall", "block_small" };

            for (int i = 0; i < blocks.Length; i++)
            {
                string blockPath = Path.Combine(locationRoot, blocks[i]);
                if (!Directory.Exists(blockPath))
                    continue;

                TryAddNested(results, blockPath, xRaw, xyRaw);
                TryAddNested(results, blockPath, xRaw, xyP2);
                TryAddNested(results, blockPath, xP2, xyRaw);
                TryAddNested(results, blockPath, xP2, xyP2);

                if (isCypr)
                {
                    TryAddFlatIfHasFox2(results, Path.Combine(blockPath, yP2));
                    TryAddFlatIfHasFox2(results, Path.Combine(blockPath, yRaw));
                }
                else
                {
                    TryAddFlatIfHasFox2(results, Path.Combine(blockPath, xRaw));
                    TryAddFlatIfHasFox2(results, Path.Combine(blockPath, xP2));
                }
            }

            return results;
        }

        private static void TryAddNested(List<string> results, string blockPath, string xFolder, string xyFolder)
        {
            string xPath = Path.Combine(blockPath, xFolder);
            if (!Directory.Exists(xPath))
                return;

            string xyPath = Path.Combine(xPath, xyFolder);
            if (!Directory.Exists(xyPath))
                return;

            if (!results.Contains(xyPath))
                results.Add(xyPath);
        }

        private static void TryAddFlatIfHasFox2(List<string> results, string dir)
        {
            if (!Directory.Exists(dir))
                return;

            bool hasFox2 = false;
            foreach (string _ in Directory.EnumerateFiles(dir, "*.fox2", SearchOption.TopDirectoryOnly))
            {
                hasFox2 = true;
                break;
            }

            if (!hasFox2)
                return;

            if (!results.Contains(dir))
                results.Add(dir);
        }
    }
}