using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

using GraphProcessor;

[NodeCustomEditor(typeof(FxColorVectorNode))]
public class FxCompositionVectorNodeView : BaseNodeView
{
	//public override void Enable()
	//{
 //       var compositionVectorNode = nodeTarget as FxCompositionVectorNode;

 //       // Fields
 //       FloatField maskValueField = new FloatField
 //       {
 //           value = compositionVectorNode.MaskValue
 //       };
 //       Toggle secondMaskWField = new Toggle 
 //       { 
 //           value = compositionVectorNode.SecondMaskW 
 //       };
 //       Toggle secondMaskXField = new Toggle
 //       {
 //           value = compositionVectorNode.SecondMaskX
 //       };
 //       Toggle secondMaskYField = new Toggle
 //       {
 //           value = compositionVectorNode.SecondMaskY
 //       };
 //       Toggle secondMaskZField = new Toggle
 //       {
 //           value = compositionVectorNode.SecondMaskZ
 //       };

 //       // Processed callbacks
 //       compositionVectorNode.onProcessed += () => maskValueField.value = compositionVectorNode.MaskValue;
 //       compositionVectorNode.onProcessed += () => secondMaskWField.value = compositionVectorNode.SecondMaskW;
 //       compositionVectorNode.onProcessed += () => secondMaskXField.value = compositionVectorNode.SecondMaskX;
 //       compositionVectorNode.onProcessed += () => secondMaskYField.value = compositionVectorNode.SecondMaskY;
 //       compositionVectorNode.onProcessed += () => secondMaskZField.value = compositionVectorNode.SecondMaskZ;

 //       // Changed value callbacks
 //       maskValueField.RegisterValueChangedCallback((v) =>
 //       {
 //           owner.RegisterCompleteObjectUndo("Updated fxCompositionVectorNodeView property");
 //           maskValueField.value = v.newValue;
 //       });
 //       secondMaskWField.RegisterValueChangedCallback((v) =>
 //       {
 //           owner.RegisterCompleteObjectUndo("Updated fxCompositionVectorNodeView property");
 //           secondMaskWField.value = v.newValue;
 //       });
 //       secondMaskXField.RegisterValueChangedCallback((v) =>
 //       {
 //           owner.RegisterCompleteObjectUndo("Updated fxCompositionVectorNodeView property");
 //           secondMaskXField.value = v.newValue;
 //       });
 //       secondMaskYField.RegisterValueChangedCallback((v) =>
 //       {
 //           owner.RegisterCompleteObjectUndo("Updated fxCompositionVectorNodeView property");
 //           secondMaskYField.value = v.newValue;
 //       });
 //       secondMaskZField.RegisterValueChangedCallback((v) =>
 //       {
 //           owner.RegisterCompleteObjectUndo("Updated fxCompositionVectorNodeView property");
 //           secondMaskZField.value = v.newValue;
 //       });

 //       // Controls
 //       controlsContainer.Add(maskValueField);
 //       controlsContainer.Add(secondMaskWField);
 //       controlsContainer.Add(secondMaskXField);
 //       controlsContainer.Add(secondMaskYField);
 //       controlsContainer.Add(secondMaskZField);
 //   }
}
