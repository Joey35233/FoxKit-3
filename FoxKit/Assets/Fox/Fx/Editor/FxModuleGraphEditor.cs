using GraphProcessor;
using UnityEditor;
using UnityEngine;

namespace FoxKit.Fx.Editor
{
    public class FxModuleGraphEditor : BaseGraphWindow
    {
        private BaseGraph tmpGraph;

        [MenuItem("FoxKit/Debug/FxModuleGraph")]
        public static BaseGraphWindow ShowEditor()
        {
            FxModuleGraphEditor graphWindow = CreateWindow<FxModuleGraphEditor>();

            // When the graph is opened from the window, we don't save the graph to disk
            graphWindow.tmpGraph = ScriptableObject.CreateInstance<BaseGraph>();
            graphWindow.tmpGraph.hideFlags = HideFlags.HideAndDontSave;
            graphWindow.InitializeGraph(graphWindow.tmpGraph);

            graphWindow.Show();

            return graphWindow;
        }

        protected override void OnDestroy() => DestroyImmediate(tmpGraph);

        protected override void InitializeWindow(BaseGraph graph)
        {
            titleContent = new GUIContent("Default Graph");

            graphView ??= new BaseGraphView(this);

            rootView.Add(graphView);
        }
    }
}