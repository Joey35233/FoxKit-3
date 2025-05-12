using Fox;
using Fox.Core;
using System.Collections.Generic;
using Fox.EdGameCore;
using Fox.EdCore;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Tpp.EdGameCore
{
    public class GameObjectEditorWindow : EditorWindow
    {
        private PopupField<string> gameObjectTypeDropdown;
        private PopupField<string> presetPopup;

        private TextField defaultNameField;
        // private Int32Field groupIdField;
        // private Int32Field totalCountField;
        // private Int32Field realizedCountField;

        private string selectedType = "TppBear";
        private string selectedPreset = null;

        private static readonly List<string> DefaultPresetList = new();

        [MenuItem("Fox/GameObject Creator")]
        public static void ShowWindow()
        {
            var window = GetWindow<GameObjectEditorWindow>();
            window.titleContent = new GUIContent("GameObject Creator");
            window.minSize = new Vector2(350, 300);
        }

        public void CreateGUI()
        {
            gameObjectTypeDropdown = new PopupField<string>("GameObject Type", Fox.EdGameCore.EdGameCoreModule.GameObjectTypeList, 0);
            presetPopup = new PopupField<string>("Preset", DefaultPresetList, 0);
            presetPopup.style.display = DisplayStyle.None;

            defaultNameField = new TextField("GameObject Name");
            // groupIdField = new Int32Field("GroupId");
            // totalCountField = new Int32Field("Total Count");
            // realizedCountField = new Int32Field("Realized Count");

            rootVisualElement.Add(gameObjectTypeDropdown);
            rootVisualElement.Add(presetPopup);
            rootVisualElement.Add(defaultNameField);
            // rootVisualElement.Add(groupIdField);
            // rootVisualElement.Add(totalCountField);
            // rootVisualElement.Add(realizedCountField);

            UpdateFields();

            gameObjectTypeDropdown.RegisterValueChangedCallback(evt =>
            {
                selectedType = evt.newValue;
                UpdateFields();
            });

            presetPopup.RegisterValueChangedCallback(evt =>
            {
                selectedPreset = evt.newValue;
            });

            var createGameObjectButton = new Button(OnCreateButtonClicked)
            {
                text = "Create GameObject"
            };

            rootVisualElement.Add(createGameObjectButton);
        }

        private void UpdateFields()
        {
            bool hasInfo = Fox.EdGameCore.EdGameCoreModule.TryGetEditorInfoForGameObjectType(selectedType, out GameObjectEditorInfo info);
            if (!hasInfo)
                return;
            
            defaultNameField.value = info.DefaultName;
            // groupIdField.value = (int)info.GroupId;
            // totalCountField.value = (int)info.TotalCount;
            // realizedCountField.value = (int)info.RealizedCount;

            List<string> presets = info.Presets;
            if (presets != null)
            {
                presetPopup.choices = presets;
                presetPopup.value = presets[0];
                presetPopup.style.display = DisplayStyle.Flex;
            }
            else
            {
                presetPopup.style.display = DisplayStyle.None;
            }
        }

        private void OnCreateButtonClicked()
        {
            var scene = SceneManager.GetActiveScene();

            if (!scene.IsValid() || !scene.isLoaded)
            {
                Debug.LogWarning("No active scene!");
                return;
            }
            
            bool hasInfo = Fox.EdGameCore.EdGameCoreModule.TryGetEditorInfoForGameObjectType(selectedType, out GameObjectEditorInfo info);
            if (!hasInfo)
                return;

            // Create new Fox GameObject
            List<Fox.GameCore.GameObject> gameObjects = new List<Fox.GameCore.GameObject>();
            Fox.GameCore.GameObject[] existingGameObjects = FindObjectsOfType<Fox.GameCore.GameObject>(true);

            Fox.GameCore.GameObject targetGameObject = null;
            foreach (var gameObject in existingGameObjects)
                if (gameObject.typeName == selectedType && gameObject.gameObject.scene == scene)
                    targetGameObject = gameObject;

            if (targetGameObject == null)
            {
                targetGameObject = new UnityEngine.GameObject(defaultNameField.value).AddComponent<Fox.GameCore.GameObject>();
                //SceneManager.MoveGameObjectToScene(obj, scene);
            }
            
            // Reset children
            while (targetGameObject.transform.childCount > 0)
                DestroyImmediate(targetGameObject.transform.GetChild(0).gameObject);
            
            // Initialize
            targetGameObject.typeName = selectedType;
            // targetGameObject.groupId = info.GroupId;
            // targetGameObject.totalCount = info.TotalCount;
            // targetGameObject.realizedCount = info.RealizedCount;

            DataElement parameterBase = info.CreateParameterFunc(selectedPreset);
            parameterBase.name = "Parameters";
            targetGameObject.parameters = parameterBase;
            parameterBase.SetOwner(targetGameObject);

            Selection.activeGameObject = targetGameObject.gameObject;
        }
    }
}