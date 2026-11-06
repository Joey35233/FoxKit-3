using System;
using Fox.Core;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.EdCore.Testing
{
	[CustomEditor(typeof(TestClass))]
	public class TestClassEditor : UnityEditor.Editor
	{
		private new TestClass target => base.target as TestClass;
        
		public override VisualElement CreateInspectorGUI()
		{
			VisualElement container = new VisualElement();
			
			StringField stringField = new StringField();
			stringField.bindingPath = "testString";
			container.Add(stringField);
			
			TestClassField refField = new TestClassField();
			refField.bindingPath = "testRef";
			refField.BindProperty(serializedObject.FindProperty("testRef"));
			container.Add(refField);

			return container;
		}
	}
}