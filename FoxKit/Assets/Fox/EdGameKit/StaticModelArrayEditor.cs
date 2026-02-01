using Fox;
using Fox.EdCore;
using Fox.GameKit;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.EdGameKit
{
    // [CustomEntityField]
    // public class StaticModelArrayField : EntityField<StaticModelArray>
    // {
    //     static StaticModelArrayField()
    //     {
    //         CustomEntityFieldDesc desc = new CustomEntityFieldDesc
    //         {
    //             Constructor = () => new StaticModelArrayField(),
    //         };
    //         
    //         CustomEntityFieldManager.Register(StaticModelArray.ClassInfo, desc);
    //     }
    // }
    
    [CustomEditor(typeof(StaticModelArray))]
    public class StaticModelArrayEditor : EntityEditor
    {
        public override VisualElement CreateInspectorGUI()
        {
            StaticModelArray modelArray = (StaticModelArray)target;
            
            VisualElement container = base.CreateInspectorGUI();

            Button reloadButton = new Button(() => modelArray.ReloadFile())
            {
                text = "Reload Model",
            };
            
            VisualElement lastChild = null;
            foreach (VisualElement child in container.Children())
                lastChild = child;
            lastChild?.Add(reloadButton);

            return container;
        }
    }
}