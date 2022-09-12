using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using FoxKit.Gr.Terrain;

namespace Fox.Gr.Terrain.Editor
{
    [CustomEditor(typeof(TerrainFileAsset))]
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