using Fox.GameService;
using System;
using System.Collections.Generic;
using Fox.EdCore;
using Fox.EdGraphx;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.EdGameService
{
    [CustomEditor(typeof(GsRouteData))]
    public class GsRouteDataEditor : GraphxSpatialGraphDataEditor
    {
        private new GsRouteData Target => (GsRouteData)base.Target;

        // protected override void BuildExtraSections(VisualElement container)
        // {
        //     VisualElement edgeTemplate = new VisualElement();
        //     VisualElement nodeTemplate = new VisualElement();
        //
        //     AddEventDropdown(container, "DefaultEdgeEvent", GameServiceModule.RouteEdgeEvents, "Default Edge Event", () =>
        //     {
        //         Route.SyncEventTemplates();
        //         RebuildTemplateSection(edgeTemplate, Route.GetEdgeEventTemplate());
        //     });
        //     container.Add(edgeTemplate);
        //
        //     AddEventDropdown(container, "DefaultNodeEvent", GameServiceModule.RouteNodeEvents, "Default Node Event", () =>
        //     {
        //         Route.SyncEventTemplates();
        //         RebuildTemplateSection(nodeTemplate, Route.GetNodeEventTemplate());
        //     });
        //     container.Add(nodeTemplate);
        //
        //     container.schedule.Execute(() =>
        //     {
        //         if (target == null)
        //             return;
        //
        //         Route.SyncEventTemplates();
        //         RebuildTemplateSection(edgeTemplate, Route.GetEdgeEventTemplate());
        //         RebuildTemplateSection(nodeTemplate, Route.GetNodeEventTemplate());
        //     });
        // }
        //
        // private void AddEventDropdown(VisualElement container, string propertyName, List<string> eventList, string label, Action onChanged)
        // {
        //     SerializedProperty prop = serializedObject.FindProperty(propertyName);
        //     if (prop == null)
        //         return;
        //
        //     int selectedIndex = eventList.IndexOf(prop.stringValue);
        //
        //     PopupField<string> popup = new PopupField<string>(label, eventList, selectedIndex);
        //     popup.RegisterValueChangedCallback(evt =>
        //     {
        //         SerializedProperty liveProp = serializedObject.FindProperty(propertyName);
        //         if (liveProp == null)
        //             return;
        //         
        //         liveProp.stringValue = evt.newValue;
        //
        //         serializedObject.ApplyModifiedProperties();
        //         onChanged?.Invoke();
        //     });
        //     container.Add(popup);
        // }

        // private void RebuildTemplateSection(VisualElement section, UnityEngine.Object template)
        // {
        //     section.Clear();
        //     if (template == null)
        //         return;
        //
        //     section.Add(new InspectorElement(template));
        // }
    }
}
