#define FOX_EDITOR_DEBUG

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using GraphProcessor;
	
namespace FoxKit.Editor.Workflows.Fx
{
	public class FxModuleGraphEditor : BaseGraphWindow
	{
#if FOX_EDITOR_DEBUG
        [MenuItem("FoxKit/Debug/FxModuleGraph")]
        private static void Init()
        {
            ShowEditor();
        }
#endif

        BaseGraph tmpGraph;

		[MenuItem("FoxKit/Debug/FxModuleGraph")]
		public static BaseGraphWindow ShowEditor()
		{
			var graphWindow = CreateWindow<FxModuleGraphEditor>();

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

			if (graphView == null)
				graphView = new BaseGraphView(this);

			rootView.Add(graphView);
		}
	}
}