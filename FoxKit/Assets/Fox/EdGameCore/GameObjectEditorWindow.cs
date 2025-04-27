using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.EdGameCore
{
    public class GameObjectEditorWindow : EditorWindow
    {
        private PopupField<string> gameObjectTypeDropdown;
        private TextField defaultNameField;
        private IntegerField groupIdField;
        private IntegerField totalCountField;
        private IntegerField realizedCountField;

        private string selectedType = "TppBear";
       
        [MenuItem("FoxKit/Editor Tools/GameObject Creator")]
        public static void ShowWindow()
        {
            var window = GetWindow<GameObjectEditorWindow>();
            window.titleContent = new GUIContent("GameObject Creator");
            window.minSize = new Vector2(350, 300);
        }

        public void CreateGUI()
        {
            // Create the dropdown
            gameObjectTypeDropdown = new PopupField<string>("GameObject Type", EdGameCoreModule.gameObjectTypes, 0);
            rootVisualElement.Add(gameObjectTypeDropdown);

            // Create the fields
            defaultNameField = new TextField("GameObject Name");
            groupIdField = new IntegerField("GroupId");
            totalCountField = new IntegerField("Total Count");
            realizedCountField = new IntegerField("Realized Count");

            rootVisualElement.Add(defaultNameField);
            rootVisualElement.Add(groupIdField);
            rootVisualElement.Add(totalCountField); 
            rootVisualElement.Add(realizedCountField);

            

            UpdateFields();

            // When selection changes
            gameObjectTypeDropdown.RegisterValueChangedCallback(evt =>
            {
                var selectedType = evt.newValue;
                UpdateFields();
            });


            var createGameObjectButton = new Button(() => OnCreateButtonClicked())
            {
                text = "Create GameObject"
            };

            rootVisualElement.Add(createGameObjectButton);
        }

        private void UpdateFields()
        {
            var info = EdGameCoreModule.GetGameObjectInfoByType(selectedType);

            defaultNameField.value = info.DefaultName;
            groupIdField.value = (int)info.GroupId;
            totalCountField.value = (int)info.TotalCount;
            realizedCountField.value = (int)info.RealizedCount;
        }

        private void OnCreateButtonClicked()
        {
            
        }


    }
}
