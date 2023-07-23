using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Fox.Gr.Editor
{
    [CustomEditor(typeof(TerrainMapAsset))]
    public class TerrainFileAssetEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            // var field = new InspectorElement(serializedObject);

            //return field;

            VisualElement wrapper = new();

            SerializedProperty child = serializedObject.GetIterator();
            if (child.NextVisible(true))
            {
                do
                {
                    if (child.name != "m_Script")
                        wrapper.Add(new PropertyField(child));
                } while (child.NextVisible(false));
            }

            return wrapper;
        }
    }
}