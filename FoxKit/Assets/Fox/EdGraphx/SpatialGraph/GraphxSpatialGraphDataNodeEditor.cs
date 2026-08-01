using Fox.EdCore;
using Fox.Graphx;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdGraphx
{
    [CustomEditor(typeof(GraphxSpatialGraphDataNode), editorForChildClasses: true)]
    public class GraphxSpatialGraphDataNodeEditor : EntityEditor
    {
        private GraphxSpatialGraphDataNode Target => (GraphxSpatialGraphDataNode)target;
        private GraphxSpatialGraphData Graph => target.transform.parent.GetComponent<GraphxSpatialGraphData>();

        protected bool HasFrameBounds() => Graph != null;

        protected Bounds OnGetFrameBounds() => new Bounds(Target.transform.position, new Vector3(1, 1, 1));

        // private void OnEnable()
        // {
        //     Tools.hidden = true;
        // }

        // private void OnDisable()
        // {
        //     Tools.hidden = false;
        // }

        // protected virtual void OnSceneGUI()
        // {
        //     if (Graph == null)
        //         return;
            
        //     DrawExtraSceneGUI();
        // }

        protected virtual void DrawExtraSceneGUI()
        {
            
        }

        // public override VisualElement CreateInspectorGUI()
        // {
        //     VisualElement container = new VisualElement();

        //     Button addNodeButton = new Button();
        //     addNodeButton.text = "Add Node";
        //     addNodeButton.clicked += OnAddNodeButtonClicked;
        //     container.Add(addNodeButton);

        //     Button deleteNodeButton = new Button();
        //     deleteNodeButton.text = "Delete Node";
        //     deleteNodeButton.clicked += OnDeleteNodeButtonClicked;
        //     container.Add(deleteNodeButton);

        //     Button nextNodeButton = new Button();
        //     nextNodeButton.text = "Next Node";
        //     nextNodeButton.clicked += OnNextNodeButtonClicked;
        //     container.Add(nextNodeButton);

        //     Button previousNodeButton = new Button();
        //     previousNodeButton.text = "Previous Node";
        //     previousNodeButton.clicked += OnPreviousNodeButtonClicked;
        //     container.Add(previousNodeButton);

        //     Button graphButton = new Button();
        //     graphButton.text = "Select Graph";
        //     graphButton.clicked += OnGraphButtonClicked;
        //     container.Add(graphButton);

        //     BuildExtraSections(container);

        //     GraphxSpatialGraphDataField field = new GraphxSpatialGraphDataField();
        //     field.Build(this.serializedObject);
        //     container.Add(field);

        //     return container;
        // }

        protected virtual void BuildExtraSections(VisualElement container) { }

        // private void OnAddNodeButtonClicked()
        // {
        //     if (Graph == null)
        //     {
        //         Debug.LogError($"Parent GameObject is not a ${nameof(GraphxSpatialGraphData)}.");
        //         return;
        //     }

        //     var index = Graph.IndexOf(Target);
        //     if (index == -1)
        //     {
        //         Debug.LogError($"Node is not assigned to parent's {nameof(GraphxSpatialGraphData.nodes)} property.");
        //         return;
        //     }

        //     // Create node at current position
        //     var newNode = Graph.AddNodeAfter(Target);
        //     newNode.transform.position = Target.transform.position;
        //     Selection.activeGameObject = newNode.gameObject;
        // }

        // private void OnDeleteNodeButtonClicked()
        // {
        //     if (Graph == null)
        //     {
        //         Debug.LogError($"Parent GameObject is not a {nameof(GraphxSpatialGraphData)}.");
        //         return;
        //     }

        //     var index = Graph.IndexOf(Target);
        //     if (index == -1)
        //     {
        //         Debug.LogError($"Node is not assigned to parent's {nameof(GraphxSpatialGraphData.nodes)} property.");
        //         return;
        //     }

        //     GameObject selectAfter = Graph.gameObject;
        //     if (Graph.nodes.Count > 1)
        //     {
        //         int neighbourIndex;
        //         if (index > 0)
        //             neighbourIndex = index - 1;
        //         else
        //             neighbourIndex = 1;
        //         selectAfter = Graph.GetGraphNode(neighbourIndex).gameObject;
        //     }

        //     Graph.RemoveNode(Target);
        //     Selection.activeGameObject = selectAfter;
        // }

        // private void OnNextNodeButtonClicked()
        // {
        //     if (Graph == null)
        //     {
        //         Debug.LogError($"Parent GameObject is not a {nameof(GraphxSpatialGraphData)}.");
        //         return;
        //     }

        //     var index = Graph.IndexOf(Target);
        //     if (index == -1)
        //     {
        //         Debug.LogError($"Node is not assigned to parent's {nameof(GraphxSpatialGraphData.nodes)} property.");
        //         return;
        //     }

        //     var nextIndex = index + 1;
        //     if (nextIndex >= Graph.nodes.Count)
        //     {
        //         nextIndex = 0;
        //     }

        //     var nextNode = Graph.GetGraphNode(nextIndex);
        //     if (nextNode == null)
        //     {
        //         Debug.LogError($"Next graph node is null. Did you delete a node without removing it from parent's {nameof(GraphxSpatialGraphData.nodes)} property?");
        //     }

        //     Selection.activeGameObject = nextNode.gameObject;
        // }

        // private void OnPreviousNodeButtonClicked()
        // {
        //     if (Graph == null)
        //     {
        //         Debug.LogError($"Parent GameObject is not a ${nameof(GraphxSpatialGraphData)}.");
        //         return;
        //     }

        //     var index = Graph.IndexOf(Target);
        //     if (index == -1)
        //     {
        //         Debug.LogError($"Node is not assigned to parent's {nameof(GraphxSpatialGraphData.nodes)} property.");
        //         return;
        //     }

        //     var nextIndex = index - 1;
        //     if (nextIndex < 0)
        //     {
        //         nextIndex = Graph.nodes.Count - 1;
        //     }

        //     var nextNode = Graph.GetGraphNode(nextIndex);
        //     if (nextNode == null)
        //     {
        //         Debug.LogError($"Previous graph node is null. Did you delete a node without removing it from parent's {nameof(GraphxSpatialGraphData.nodes)} property?");
        //     }

        //     Selection.activeGameObject = nextNode.gameObject;
        // }

        // private void OnGraphButtonClicked()
        // {
        //     if (Graph == null)
        //     {
        //         Debug.LogError($"Parent GameObject is not a ${nameof(GraphxSpatialGraphData)}.");
        //         return;
        //     }

        //     Selection.activeGameObject = Graph.gameObject;
        // }
    }
}
