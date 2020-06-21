using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

using GraphProcessor;

[NodeCustomEditor(typeof(FxColorVectorNode))]
public class FxColorVectorNodeView : BaseNodeView
{
	public override void Enable()
	{
		var colorNode = nodeTarget as FxColorVectorNode;

		ColorField colorField = new ColorField
		{
			value = colorNode.color
		};

		colorNode.onProcessed += () => colorField.value = colorNode.color;

		colorField.RegisterValueChangedCallback((v) => {
			owner.RegisterCompleteObjectUndo("Updated fxColorVectorNodeView input");
			colorNode.color = (Color)v.newValue;
		});

		controlsContainer.Add(colorField);
	}
}