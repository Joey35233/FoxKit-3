using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Fox.Core.Utils;
using Fox.Fs;
using Fox.Core;
using Fox.Fio;

namespace FoxKit.Windows
{
    public class MapLoader : EditorWindow
    {
        private static readonly Dictionary<string, MapBounds> MapBoundsByLocation =
            new Dictionary<string, MapBounds>()
            {
                { "AFGH", new MapBounds(101, 101, 164, 164) },
                { "CYPR", new MapBounds(1,   1,   1,   9)   },
                { "MAFR", new MapBounds(101, 101, 164, 164) },
                { "MBQF", new MapBounds(101, 101, 102, 102) },
            };

        private static readonly List<string> LocationList =
            new List<string>() { "AFGH", "CYPR", "MAFR", "MBQF" };

        private const int CellW = 14;
        private const int CellH = 14;

        private Label selectedLabel;
        private Label hoverLabel;
        private VisualElement gridHost;

        private readonly HashSet<string> loadedFox2ExternalPaths =
            new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        [MenuItem("FoxKit/Import/Map Loader")]
        public static void Open()
        {
            MapLoader wnd = GetWindow<MapLoader>();
            wnd.titleContent = new GUIContent("Map Loader");
            wnd.minSize = new Vector2(700, 520);
        }

        public void CreateGUI()
        {
            VisualElement root = rootVisualElement;

            root.style.paddingLeft = 6;
            root.style.paddingRight = 6;
            root.style.paddingTop = 6;
            root.style.paddingBottom = 6;

            VisualElement header = BuildHeaderUI(root);

            BuildScrollAndGridHost(root);

            PopupField<string> locationPopup = header.Q<PopupField<string>>("locationPopup");
            RebuildGrid(locationPopup.value);

            locationPopup.RegisterValueChangedCallback(OnLocationChanged);
        }

        private VisualElement BuildHeaderUI(VisualElement root)
        {
            VisualElement header = new VisualElement();
            header.style.flexDirection = FlexDirection.Row;
            header.style.alignItems = Align.Center;
            header.style.marginBottom = 6;

            header.Add(new Label("Location:"));

            PopupField<string> locationPopup = new PopupField<string>(LocationList, 0);
            locationPopup.name = "locationPopup";
            locationPopup.style.minWidth = 120;
            header.Add(locationPopup);

            selectedLabel = new Label("Selected: none");
            selectedLabel.style.unityFontStyleAndWeight = FontStyle.Bold;
            selectedLabel.style.marginLeft = 12;
            header.Add(selectedLabel);

            hoverLabel = new Label("Hover: none");
            hoverLabel.style.marginLeft = 14;
            header.Add(hoverLabel);

            root.Add(header);
            return header;
        }

        private void BuildScrollAndGridHost(VisualElement root)
        {
            ScrollView scroll = new ScrollView(ScrollViewMode.VerticalAndHorizontal);
            scroll.style.flexGrow = 1;
            root.Add(scroll);

            gridHost = new VisualElement();
            scroll.Add(gridHost);
        }

        private void OnLocationChanged(ChangeEvent<string> evt)
        {
            RebuildGrid(evt.newValue);
        }

        private void RebuildGrid(string location)
        {
            MapBounds bounds;
            if (!MapBoundsByLocation.TryGetValue(location, out bounds))
            {
                bounds = new MapBounds(101, 101, 164, 164);
            }

            selectedLabel.text = "Selected: none";
            hoverLabel.text = "Hover: none";

            gridHost.Clear();

            GridWithHover grid = new GridWithHover(bounds, CellW, CellH);

            grid.OnSelectionChanged += (mapX, mapY, index0) =>
            {
                selectedLabel.text =
                    "Selected: X=" + mapX + ", Y=" + mapY +
                    " | Index0=" + index0 +
                    " | Index1=" + (index0 + 1);

                ImportFox2ForTile(location, mapX, mapY);
            };

            grid.OnHoverChanged += (mapX, mapY, index0) =>
            {
                if (index0 < 0)
                {
                    hoverLabel.text = "Hover: none";
                }
                else
                {
                    hoverLabel.text =
                        "Hover: X=" + mapX + ", Y=" + mapY +
                        " | Index0=" + index0 +
                        " | Index1=" + (index0 + 1);
                }
            };

            gridHost.Add(grid);
        }

        private struct MapBounds
        {
            public int StartX;
            public int StartY;
            public int EndX;
            public int EndY;

            public MapBounds(int startX, int startY, int endX, int endY)
            {
                StartX = startX;
                StartY = startY;
                EndX = endX;
                EndY = endY;
            }

            public int Cols
            {
                get { return (EndX - StartX) + 1; }
            }

            public int Rows
            {
                get { return (EndY - StartY) + 1; }
            }
        }

        private sealed class GridWithHover : VisualElement
        {
            public event Action<int, int, int> OnSelectionChanged;
            public event Action<int, int, int> OnHoverChanged;

            private MapBounds bounds;
            private int rows;
            private int cols;
            private int cellW;
            private int cellH;

            private int selectedRow = -1;
            private int selectedCol = -1;

            private int hoverRow = -1;
            private int hoverCol = -1;

            private static readonly Color GridBg = new Color(0f, 0f, 0f, 0.08f);
            private static readonly Color Line = new Color(0f, 0f, 0f, 0.25f);

            private static readonly Color SelFill = new Color(0.25f, 0.6f, 1f, 0.45f);
            private static readonly Color SelBorder = new Color(0.25f, 0.6f, 1f, 0.95f);
            private static readonly Color HoverBorder = new Color(1f, 1f, 1f, 0.55f);

            public GridWithHover(MapBounds bounds, int cellW, int cellH)
            {
                this.bounds = bounds;

                rows = Mathf.Max(1, bounds.Rows);
                cols = Mathf.Max(1, bounds.Cols);

                this.cellW = Mathf.Max(2, cellW);
                this.cellH = Mathf.Max(2, cellH);

                style.width = cols * this.cellW + 1;
                style.height = rows * this.cellH + 1;

                pickingMode = PickingMode.Position;

                generateVisualContent += OnDraw;

                RegisterCallback<MouseDownEvent>(OnMouseDown);
                RegisterCallback<MouseMoveEvent>(OnMouseMove);
                RegisterCallback<MouseLeaveEvent>(OnMouseLeave);
            }

            private void OnMouseLeave(MouseLeaveEvent e)
            {
                if (hoverRow != -1 || hoverCol != -1)
                {
                    hoverRow = -1;
                    hoverCol = -1;

                    if (OnHoverChanged != null)
                        OnHoverChanged(0, 0, -1);

                    MarkDirtyRepaint();
                }
            }

            private void OnMouseMove(MouseMoveEvent e)
            {
                int r, c;
                if (!TryPickCell(e.mousePosition, out r, out c))
                {
                    if (hoverRow != -1 || hoverCol != -1)
                    {
                        hoverRow = -1;
                        hoverCol = -1;

                        if (OnHoverChanged != null)
                            OnHoverChanged(0, 0, -1);

                        MarkDirtyRepaint();
                    }
                    return;
                }

                if (hoverRow == r && hoverCol == c)
                    return;

                hoverRow = r;
                hoverCol = c;

                int mapX = bounds.StartX + c;
                int mapY = bounds.StartY + r;
                int index0 = (r * cols) + c;

                if (OnHoverChanged != null)
                    OnHoverChanged(mapX, mapY, index0);

                MarkDirtyRepaint();
            }

            private void OnMouseDown(MouseDownEvent e)
            {
                if (e.button != 0)
                    return;

                int r, c;
                if (!TryPickCell(e.mousePosition, out r, out c))
                    return;

                if (selectedRow == r && selectedCol == c)
                    return;

                selectedRow = r;
                selectedCol = c;

                int mapX = bounds.StartX + c;
                int mapY = bounds.StartY + r;
                int index0 = (r * cols) + c;

                if (OnSelectionChanged != null)
                    OnSelectionChanged(mapX, mapY, index0);

                MarkDirtyRepaint();
                e.StopPropagation();
            }

            private bool TryPickCell(Vector2 mouseWorld, out int r, out int c)
            {
                r = -1;
                c = -1;

                Vector2 local = mouseWorld - new Vector2(worldBound.xMin, worldBound.yMin);

                c = Mathf.FloorToInt(local.x / cellW);
                r = Mathf.FloorToInt(local.y / cellH);

                // Out of bounds?
                if (r < 0 || r >= rows || c < 0 || c >= cols)
                    return false;

                return true;
            }

            private static void PathRect(Painter2D p, Rect r)
            {
                p.BeginPath();
                p.MoveTo(new Vector2(r.xMin, r.yMin));
                p.LineTo(new Vector2(r.xMax, r.yMin));
                p.LineTo(new Vector2(r.xMax, r.yMax));
                p.LineTo(new Vector2(r.xMin, r.yMax));
                p.LineTo(new Vector2(r.xMin, r.yMin));
            }

            private void OnDraw(MeshGenerationContext ctx)
            {
                Painter2D p = ctx.painter2D;

                float gridW = cols * cellW;
                float gridH = rows * cellH;

                p.fillColor = GridBg;
                PathRect(p, new Rect(0, 0, gridW, gridH));
                p.Fill();

                if (hoverRow >= 0 && hoverCol >= 0)
                {
                    float x = hoverCol * cellW;
                    float y = hoverRow * cellH;

                    p.strokeColor = HoverBorder;
                    p.lineWidth = 1f;
                    PathRect(p, new Rect(x, y, cellW, cellH));
                    p.Stroke();
                }

                if (selectedRow >= 0 && selectedCol >= 0)
                {
                    float x = selectedCol * cellW;
                    float y = selectedRow * cellH;

                    p.fillColor = SelFill;
                    PathRect(p, new Rect(x, y, cellW, cellH));
                    p.Fill();

                    p.strokeColor = SelBorder;
                    p.lineWidth = 2f;
                    PathRect(p, new Rect(x, y, cellW, cellH));
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
            string externalRoot = FoxKit.SettingsManager.ExternalBasePath;
            if (!IsExternalRootValid(externalRoot))
            {
                Debug.LogError("[MapLoader] ExternalBasePath is not set or invalid. Open FoxKit settings and set it.");
                FoxKit.SettingsManager.ShowSettingsWindow();
                return;
            }

            string locationRoot = GetLocationRoot(externalRoot, location);
            if (!Directory.Exists(locationRoot))
            {
                Debug.LogWarning("[MapLoader] Location folder not found: " + locationRoot);
                return;
            }

            List<string> tileDirs = FindTileDirs(locationRoot, location, mapX, mapY);
            if (tileDirs.Count == 0)
            {
                Debug.LogWarning("[MapLoader] Tile folder not found for " + location +
                                 " X=" + mapX + " Y=" + mapY +
                                 " in block_small/block_extraSmall.");
                return;
            }

            List<string> fox2Files = CollectFox2Files(tileDirs);
            if (fox2Files.Count == 0)
            {
                Debug.LogWarning("[MapLoader] No .fox2 files found for " + location +
                                 " X=" + mapX + " Y=" + mapY + ".");
                return;
            }

            ImportFox2FilesWithProgress(location, mapX, mapY, fox2Files);
        }

        private bool IsExternalRootValid(string externalRoot)
        {
            if (string.IsNullOrEmpty(externalRoot))
                return false;

            if (!Directory.Exists(externalRoot))
                return false;

            return true;
        }

        private string GetLocationRoot(string externalRoot, string location)
        {
            string locLower = location.ToLowerInvariant();
            return Path.Combine(externalRoot, "Assets", "tpp", "level", "location", locLower);
        }

        private List<string> CollectFox2Files(List<string> tileDirs)
        {
            HashSet<string> fox2Set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < tileDirs.Count; i++)
            {
                string dir = tileDirs[i];

                foreach (string f in Directory.EnumerateFiles(dir, "*.fox2", SearchOption.AllDirectories))
                {
                    fox2Set.Add(f);
                }
            }

            List<string> list = new List<string>(fox2Set);
            list.Sort(StringComparer.OrdinalIgnoreCase);

            return list;
        }

        private void ImportFox2FilesWithProgress(string location, int mapX, int mapY, List<string> fox2Files)
        {
            TaskLogger logger = new TaskLogger("Import Tile FOX2 [" + location + "] " + mapX + "_" + mapY);
            int success = 0;
            int fail = 0;

            try
            {
                int total = fox2Files.Count;
                int processed = 0;

                for (int i = 0; i < total; i++)
                {
                    string externalFile = fox2Files[i];

                    if (loadedFox2ExternalPaths.Contains(externalFile))
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

                        loadedFox2ExternalPaths.Add(externalFile);
                        success++;
                    }
                    catch (Exception ex)
                    {
                        fail++;
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
                      ". Imported=" + success + ", Failed=" + fail);
        }

        private static void ImportOneFox2(string externalFile, TaskLogger logger, bool keepScenesOpen)
        {
            string foxPath = Fox.Fs.FileSystem.GetFoxPathFromExternalPath(externalFile);
            foxPath = NormalizeFoxPath(foxPath);

            DataSetFile2.SceneLoadMode loadMode = keepScenesOpen
                ? DataSetFile2.SceneLoadMode.Additive
                : DataSetFile2.SceneLoadMode.Auto;

            if (!string.IsNullOrEmpty(foxPath) && foxPath.StartsWith("/Assets/"))
            {
                ReadOnlySpan<byte> fileData = Fox.Fs.FileSystem.ReadExternalFile(foxPath);
                UnityEngine.SceneManagement.Scene scene = DataSetFile2.Read(fileData, loadMode, logger);

                Fox.Fs.FileSystem.TryImportAsset(scene, foxPath);
                return;
            }

            {
                ReadOnlySpan<byte> fileData = Fox.Fs.FileSystem.ReadLooseFile(externalFile);
                UnityEngine.SceneManagement.Scene scene = DataSetFile2.Read(fileData, loadMode, logger);

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
            List<string> results = new List<string>();

            string locLower = location.ToLowerInvariant();
            bool isCypr = (locLower == "cypr");

            string xRaw = mapX.ToString();
            string xP2 = mapX.ToString("D2");

            string yRaw = mapY.ToString();
            string yP2 = mapY.ToString("D2");

            string xyRaw = mapX + "_" + mapY;
            string xyP2 = mapX.ToString("D2") + "_" + mapY.ToString("D2");

            string[] blockFolders = new string[] { "block_extraSmall", "block_small" };

            for (int i = 0; i < blockFolders.Length; i++)
            {
                string blockPath = Path.Combine(locationRoot, blockFolders[i]);
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