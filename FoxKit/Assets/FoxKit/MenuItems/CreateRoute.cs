using System.Collections.Generic;
using Fox.Core;
using Fox.GameService;
using UnityEditor;
using UnityEngine;

namespace FoxKit.MenuItems
{
    public static class CreateRoute
    {
        [MenuItem("FoxKit/Create/Route")]
        private static void Create()
        {
            int undoGroup = Undo.GetCurrentGroup();
            Undo.SetCurrentGroupName("Create Route");

            GameObject go = new GameObject(GenerateUniqueRouteName());
            Undo.RegisterCreatedObjectUndo(go, "Create Route");

            GsRouteData route = go.AddComponent<GsRouteData>();
            route.SetTransform(TransformEntity.GetDefault());

            Undo.CollapseUndoOperations(undoGroup);

            Selection.activeGameObject = go;
        }

        private static string GenerateUniqueRouteName()
        {
            HashSet<string> used = new();
            foreach (GsRouteData route in UnityEngine.Object.FindObjectsByType<GsRouteData>(FindObjectsInactive.Include, FindObjectsSortMode.None))
                used.Add(route.name);

            int index = 0;
            string name = $"rt_newRoute_{index:D4}";
            while (used.Contains(name))
            {
                index++;
                name = $"rt_newRoute_{index:D4}";
            }

            return name;
        }
    }
}
