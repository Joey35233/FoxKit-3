using Fox;
using Fox.Core;
using Fox.EdCore;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using Transform = Fox.Core.Transform;

namespace Fox.EdCore
{
    [CustomEntityInspector2(true, true, BuildBodyOverrideBehavior.SpecificClassOverride, false)]
    public class TransformDataInspector : EntityInspector2<TransformData>
    {
        private TransformDataInspector(TransformData target) : base(target) {}

        public override void BuildHeader(VisualElement header)
        {
            header.Add(new HelpBox("One of transform, shearTransform, pivotTransform must be set and a direct child of this TransformData.", HelpBoxMessageType.Warning));
        }
        
        public override void BuildBody(VisualElement body)
        {
            EntityPtrField<TransformEntity> transformField = new EntityPtrField<TransformEntity>("transform");
            transformField.bindingPath = IFoxField.GetBindingPathForPropertyName(transformField.label);
            body.Add(transformField);
            
            EntityPtrField<ShearTransformEntity> shearTransformField = new EntityPtrField<ShearTransformEntity>("shearTransform");
            shearTransformField.bindingPath = IFoxField.GetBindingPathForPropertyName(shearTransformField.label);
            body.Add(shearTransformField);
            
            EntityPtrField<PivotTransformEntity> pivotTransformField = new EntityPtrField<PivotTransformEntity>("pivotTransform");
            pivotTransformField.bindingPath = IFoxField.GetBindingPathForPropertyName(pivotTransformField.label);
            body.Add(pivotTransformField);
            
            EnumFlagsField flagsField = new EnumFlagsField("flags");
            flagsField.bindingPath = IFoxField.GetBindingPathForPropertyName(flagsField.label);
            body.Add(flagsField);
            
            // Transform preview
            var transformPreviewLabel = new Label
            {
                text = "<b>Transform</b>",
                style =
                {
                    fontSize = 12
                }
            };
            body.Add(transformPreviewLabel);
            
            HelpBox flagsInfoBox = new HelpBox($"If INHERIT_TRANSFORM is set, the output transform will be relative to that of this object's parent.", HelpBoxMessageType.Info);
            body.Add(flagsInfoBox);
            
            IMGUIContainer positionDisplayContainer = new IMGUIContainer(OnPositionDisplayGUI);
            body.Add(positionDisplayContainer);
        }

        private static GUIContent PositionLabel = EditorGUIUtility.TrTextContent("Position");
        private static GUIContent RotationLabel = EditorGUIUtility.TrTextContent("Rotation");
        private static GUIContent ScaleLabel = EditorGUIUtility.TrTextContent("Scale");
        private static GUILayoutOption LabelWidth = GUILayout.Width(70);
        
        private void OnPositionDisplayGUI()
        {
            UnityEngine.Transform transform = Target.transform;
            
            Vector3 position;
            Vector3 rotation;
            Vector3 scale;
            if (Target.inheritTransform)
            {
                position = transform.position;
                rotation = transform.rotation.eulerAngles;
                scale = transform.lossyScale;
            }
            else
            {
                position = transform.localPosition;
                rotation = transform.localRotation.eulerAngles;
                scale = transform.localScale;
            }
            
            EditorGUI.BeginDisabledGroup(true);
            
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(PositionLabel, LabelWidth);
            EditorGUILayout.Vector3Field(GUIContent.none, position);
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(RotationLabel, LabelWidth);
            EditorGUILayout.Vector3Field(GUIContent.none, rotation);
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(ScaleLabel, LabelWidth);
            EditorGUILayout.Vector3Field(GUIContent.none, scale);
            EditorGUILayout.EndHorizontal();
            
            EditorGUI.EndDisabledGroup();
        }
    }

    public class TransformDataField : BaseEntityField<TransformData>
    {
        
    }
}