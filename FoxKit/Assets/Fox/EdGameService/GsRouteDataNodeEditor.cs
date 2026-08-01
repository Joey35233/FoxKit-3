using UnityEngine;
using Fox.EdGraphx;
using Fox.GameService;
using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.EdGameService
{
    [CustomEditor(typeof(GsRouteDataNode))]
    public class GsRouteDataNodeEditor : GraphxSpatialGraphDataNodeEditor
    {
        private GsRouteDataNode Target => (GsRouteDataNode)target;

        // private const float DirectionHandleBaseSize = 0.8f;
        private const float DirectionHandleRate = 0.2f;

        protected override void DrawExtraSceneGUI()
        {
            base.DrawExtraSceneGUI();
            
            Vector3 nodePosition = Target.transform.position;

            for (int i = 0; i < Target.events.Count; i++)
            {
                GsRouteDataNodeEvent @event = Target.events[i];
                if (@event == null)
                    continue;
                
                Quaternion dir = @event.dir;

                float handleSize = HandleUtility.GetHandleSize(nodePosition);
                
                float radius = handleSize + DirectionHandleRate * i;
                Vector3 tip = nodePosition + radius * (dir * Vector3.forward);

                Handles.color = Color.cyan;
                Handles.DrawLine(nodePosition, tip);
                Handles.ConeHandleCap(0, tip, dir, 0.15f * handleSize, EventType.Repaint);

                EditorGUI.BeginChangeCheck();
                Quaternion newRot = Handles.Disc(dir, nodePosition, Vector3.up, radius, false, 0f);
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(@event, "Set Node Event Direction");
                    @event.dir = newRot;
                }
            }
        }

        protected override void BuildExtraSections(VisualElement container)
        {
            GsRouteData eventGraph = Target.transform.GetComponentInParent<GsRouteData>();
            if (eventGraph == null || eventGraph.GetNodeEventType() == null)
                return;

            Button addNodeEventButton = new Button();
            addNodeEventButton.text = "Add Node Event";
            addNodeEventButton.clicked += OnAddNodeEventButtonClicked;
            container.Add(addNodeEventButton);

            VisualElement eventTypeSection = new VisualElement();
            container.Add(eventTypeSection);
            int builtCount = -1;
            // int filledCount = Target.GetDirectionCount();

            // container.schedule.Execute(() =>
            // {
            //     if (target == null || eventGraph == null)
            //         return;
            //
            //     int count = Target.GetDirectionCount();
            //
            //     if (count > filledCount && eventGraph.ResolveNodeEvents(Target, filledCount))
            //         serializedObject.Update();
            //     filledCount = count;
            //
            //     if (count != builtCount)
            //     {
            //         BuildEventTypeDropdowns(eventTypeSection, eventGraph);
            //         builtCount = count;
            //     }
            // }).Every(200);
        }

        private void OnAddNodeEventButtonClicked()
        {
            GsRouteData graph = Target.transform.GetComponentInParent<GsRouteData>();
            if (graph == null)
                return;

            int undoGroup = Undo.GetCurrentGroup();
            graph.AddNodeEvent(Target);
            Undo.CollapseUndoOperations(undoGroup);
        }

        private void BuildEventTypeDropdowns(VisualElement section, GsRouteData eventGraph)
        {
            section.Clear();

            for (int i = 0; i < Target.events.Count; i++)
            {
                string currentName = Target.events[i].id;

                int selected = GameServiceModule.RouteNodeEvents.IndexOf(currentName);

                PopupField<string> dropdown = new PopupField<string>($"Event {i} Type", GameServiceModule.RouteNodeEvents, selected);
                dropdown.RegisterValueChangedCallback(evt => eventGraph.SetNodeEventType(Target, i, evt.newValue));
                section.Add(dropdown);
            }
        }
    }
}
