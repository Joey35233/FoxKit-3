using Fox.Core;
using System.Collections.Generic;
using Fox.EdGameCore;
using Fox.EdCore;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Linq;

namespace Tpp.EdGameCore
{
    public class GameObjectEditorWindow : EditorWindow
    {
        private PopupField<string> gameObjectTypeDropdown;
        private PopupField<string> presetPopup;

        private string selectedType = null;
        private string selectedPreset = null;
        private UInt32Field groupIdField;
        private UInt32Field totalCountField;
        private UInt32Field realizedCountField;
        private Toggle createLocator;
        private VisualElement locatorPrefixContainer;
        private List<LocatorPrefixEntry> locatorPrefixEntries = new List<LocatorPrefixEntry>();

        private static readonly List<string> DefaultPresetList = new();

        private class LocatorPrefixEntry
        {
            public VisualElement Container;
            public TextField PrefixField;
            public UInt32Field CountField;
        }

        [MenuItem("Fox/GameObject Creator")]
        public static void ShowWindow()
        {
            var window = GetWindow<GameObjectEditorWindow>();
            window.titleContent = new GUIContent("GameObject Creator");
            window.minSize = new Vector2(350, 400);
        }

        public void CreateGUI()
        {
            List<string> typeList = Fox.EdGameCore.EdGameCoreModule.GameObjectTypeList;
            if (typeList == null || typeList.Count < 1)
            {
                return;
            }

            selectedType = typeList[0];

            gameObjectTypeDropdown = new PopupField<string>("GameObject Type", typeList, 0);
            presetPopup = new PopupField<string>("Preset", DefaultPresetList, 0);
            presetPopup.style.display = DisplayStyle.None;

            groupIdField = new UInt32Field(nameof(Fox.GameCore.GameObject.groupId))
            {
                tooltip =
                    "Group identifier, Unclear what it does.\nAlways 0 in any GameObject."
            };
            totalCountField = new UInt32Field(nameof(Fox.GameCore.GameObject.totalCount))
            {
                tooltip =
                    "Maximum number of instances of this GameObject that can exist"
            };

            totalCountField.RegisterValueChangedCallback<uint>(evt =>
            {
                ValidateTotalLocatorCount();
            });
            realizedCountField = new UInt32Field(nameof(Fox.GameCore.GameObject.realizedCount))
            {
                tooltip =
                    "Maximum number of instances that can be rendered or active at the same time."
            };
            createLocator = new Toggle("Create Locator")
            {
                tooltip =
                    "If enabled, generates a GameObjectLocator for each GameObject.\nThe number of locators will match the Total Count."
            };
            createLocator.style.display = DisplayStyle.None;

            // Container for locator prefix entries
            locatorPrefixContainer = new VisualElement();
            locatorPrefixContainer.style.display = DisplayStyle.None;
            locatorPrefixContainer.style.marginTop = 5;
            locatorPrefixContainer.style.marginBottom = 5;

            var addPrefixButton = new Button(AddLocatorPrefixEntry)
            {
                text = "Add Locator Prefix"
            };
            addPrefixButton.style.display = DisplayStyle.None;

            rootVisualElement.Add(gameObjectTypeDropdown);
            rootVisualElement.Add(presetPopup);

            rootVisualElement.Add(groupIdField);
            rootVisualElement.Add(totalCountField);
            rootVisualElement.Add(realizedCountField);
            rootVisualElement.Add(createLocator);
            rootVisualElement.Add(locatorPrefixContainer);
            rootVisualElement.Add(addPrefixButton);

            SetGameObjectTypeFields();

            gameObjectTypeDropdown.RegisterValueChangedCallback(
                evt =>
                {
                    selectedType = evt.newValue;
                    SetGameObjectTypeFields();
                }
            );

            presetPopup.RegisterValueChangedCallback(
                evt =>
                {
                    selectedPreset = evt.newValue;
                }
            );

            createLocator.RegisterValueChangedCallback(
                evt =>
                {
                    locatorPrefixContainer.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;
                    addPrefixButton.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;

                    if (evt.newValue && locatorPrefixEntries.Count == 0)
                    {
                        AddLocatorPrefixEntry();
                    }
                }
            );

            realizedCountField.RegisterValueChangedCallback<uint>(
                evt =>
                {
                    if (evt.newValue > totalCountField.value)
                    {
                        realizedCountField.SetValueWithoutNotify(totalCountField.value);
                        Debug.LogWarning("Realized count cannot be greater than total count.");
                    }
                }
            );

            var createGameObjectButton = new Button(OnCreateButtonClicked)
            {
                text = "Create GameObject"
            };

            rootVisualElement.Add(createGameObjectButton);
            var resetButton = new Button(SetGameObjectTypeFields) { text = "Reset" };

            rootVisualElement.Add(resetButton);
        }

        private void AddLocatorPrefixEntry()
        {
            var entry = new LocatorPrefixEntry();

            var entryContainer = new VisualElement();
            entryContainer.style.flexDirection = FlexDirection.Row;
            entryContainer.style.marginBottom = 2;
            entryContainer.style.alignItems = Align.Center;

            var prefixLabel = new Label("Prefix");
            prefixLabel.style.width = 45;
            prefixLabel.style.marginRight = 5;

            var prefixField = new TextField()
            {
                tooltip = "Name prefix (e.g., 'sol_citadel')"
            };
            prefixField.style.flexGrow = 1;
            prefixField.style.marginRight = 10;

            var countLabel = new Label("Count");
            countLabel.style.width = 45;
            countLabel.style.marginRight = 5;

            var countField = new UInt32Field()
            {
                value = 1,
                tooltip = "Number of locators with this prefix"
            };
            countField.style.width = 60;
            countField.style.marginRight = 5;

            countField.RegisterValueChangedCallback<uint>(evt =>
            {
                ValidateTotalLocatorCount();
            });

            var removeButton = new Button(() => RemoveLocatorPrefixEntry(entry))
            {
                text = "X"
            };
            removeButton.style.width = 25;

            entryContainer.Add(prefixLabel);
            entryContainer.Add(prefixField);
            entryContainer.Add(countLabel);
            entryContainer.Add(countField);
            entryContainer.Add(removeButton);

            entry.Container = entryContainer;
            entry.PrefixField = prefixField;
            entry.CountField = countField;

            locatorPrefixEntries.Add(entry);
            locatorPrefixContainer.Add(entryContainer);
        }

        private void RemoveLocatorPrefixEntry(LocatorPrefixEntry entry)
        {
            locatorPrefixEntries.Remove(entry);
            locatorPrefixContainer.Remove(entry.Container);
            ValidateTotalLocatorCount();
        }

        private void ValidateTotalLocatorCount()
        {
            uint totalLocators = (uint)locatorPrefixEntries.Sum(e => (int)e.CountField.value);

            if (totalLocators > totalCountField.value)
            {
                Debug.LogWarning($"Total locator count ({totalLocators}) exceeds totalCount ({totalCountField.value})!");
            }
        }

        private void SetGameObjectTypeFields()
        {
            bool hasInfo = Fox.EdGameCore.EdGameCoreModule.TryGetEditorInfoForGameObjectType(
                selectedType,
                out GameObjectEditorInfo info
            );
            if (!hasInfo)
            {
                return;
            }

            groupIdField.value = info.groupId;
            totalCountField.value = info.totalCount;
            realizedCountField.value = info.realizedCount;

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

            if (!info.canCreateLocator)
            {
                createLocator.style.display = DisplayStyle.None;
                locatorPrefixContainer.style.display = DisplayStyle.None;
            }
            else
            {
                createLocator.style.display = DisplayStyle.Flex;
                locatorPrefixContainer.style.display = createLocator.value ? DisplayStyle.Flex : DisplayStyle.None;
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

            bool hasInfo = Fox.EdGameCore.EdGameCoreModule.TryGetEditorInfoForGameObjectType(
                selectedType,
                out GameObjectEditorInfo info
            );
            if (!hasInfo)
                return;

            // Create/setup new Fox GameObject
            Fox.GameCore.GameObject[] existingGameObjects =
                FindObjectsByType<Fox.GameCore.GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            Fox.GameCore.GameObject gameObject = null;
            foreach (var existingObject in existingGameObjects)
                if (
                    existingObject.typeName == selectedType
                    && existingObject.gameObject.scene == scene
                )
                    gameObject = existingObject;

            if (gameObject == null)
            {
                gameObject = new UnityEngine.GameObject().AddComponent<Fox.GameCore.GameObject>();
            }
            else
            {
                // Reset children
                while (gameObject.transform.childCount > 0)
                    DestroyImmediate(gameObject.transform.GetChild(0).gameObject);
            }

            // Initialize
            gameObject.name = $"{selectedType}GameObject";
            gameObject.typeName = selectedType;
            gameObject.groupId = groupIdField.value;
            gameObject.totalCount = totalCountField.value;
            gameObject.realizedCount = realizedCountField.value;

            DataElement parameterBase = info.CreateParameterFunc(selectedPreset);
            parameterBase.name = "Parameters";
            gameObject.parameters = parameterBase;
            parameterBase.SetOwner(gameObject);

            Selection.activeGameObject = gameObject.gameObject;

            // Create/setup new Fox GameObjectLocator
            if (createLocator.value)
            {
                // Find all existing locators of this type in the scene
                var existingGameObjectLocators = FindObjectsByType<Fox.GameCore.GameObjectLocator>(FindObjectsInactive.Include, FindObjectsSortMode.None);

                List<Fox.GameCore.GameObjectLocator> locatorsToCleanup = new List<Fox.GameCore.GameObjectLocator>();
                foreach (var existingLocator in existingGameObjectLocators)
                {
                    if (existingLocator.typeName == selectedType && existingLocator.gameObject.scene == scene)
                    {
                        locatorsToCleanup.Add(existingLocator);
                    }
                }

                // Clean up old locators
                foreach (var oldLocator in locatorsToCleanup)
                {
                    DestroyImmediate(oldLocator.gameObject);
                }

                // Calculate total locators needed and validate
                uint totalLocatorsToCreate = (uint)locatorPrefixEntries.Sum(e => (int)e.CountField.value);

                if (totalLocatorsToCreate > totalCountField.value)
                {
                    Debug.LogError($"Cannot create locators: Total count ({totalLocatorsToCreate}) exceeds totalCount ({totalCountField.value}). Aborting locator creation.");
                    return;
                }

                // Create new locators based on prefix entries
                int globalIndex = 0;
                foreach (var entry in locatorPrefixEntries)
                {
                    string prefix = entry.PrefixField.value?.Trim();
                    uint count = entry.CountField.value;

                    if (string.IsNullOrEmpty(prefix))
                    {
                        Debug.LogWarning("Skipping entry with empty prefix.");
                        continue;
                    }

                    for (int i = 0; i < count && globalIndex < totalCountField.value; i++, globalIndex++)
                    {
                        Fox.GameCore.GameObjectLocator gameObjectLocator = new UnityEngine.GameObject().AddComponent<Fox.GameCore.GameObjectLocator>();
                        gameObjectLocator.name = $"{prefix}_{i:D4}";

                        TransformEntity transformBase = new UnityEngine.GameObject().AddComponent<Fox.Core.TransformEntity>();
                        transformBase.name = "TransformEntity";
                        transformBase.SetOwner(gameObjectLocator);

                        gameObjectLocator.SetProperty("transform", new Fox.Core.Value(transformBase));

                        gameObjectLocator.typeName = selectedType;
                        gameObjectLocator.groupId = groupIdField.value;
                        gameObjectLocator.parameters = info.CreateLocatorParameterFunc(selectedPreset);
                        gameObjectLocator.parameters.name = "Parameters";
                        gameObjectLocator.parameters.SetOwner(gameObjectLocator);
                    }
                }

                // If no prefix entries exist, fall back to default naming
                if (locatorPrefixEntries.Count == 0)
                {
                    for (int i = 0; i < totalCountField.value; i++)
                    {
                        Fox.GameCore.GameObjectLocator gameObjectLocator = new UnityEngine.GameObject().AddComponent<Fox.GameCore.GameObjectLocator>();
                        gameObjectLocator.name = $"{selectedType}_GameObjectLocator_{i}";

                        TransformEntity transformBase = new UnityEngine.GameObject().AddComponent<Fox.Core.TransformEntity>();
                        transformBase.name = "TransformEntity";
                        transformBase.SetOwner(gameObjectLocator);

                        gameObjectLocator.SetProperty("transform", new Fox.Core.Value(transformBase));

                        gameObjectLocator.typeName = selectedType;
                        gameObjectLocator.groupId = groupIdField.value;
                        gameObjectLocator.parameters = info.CreateLocatorParameterFunc(selectedPreset);
                        gameObjectLocator.parameters.name = "Parameters";
                        gameObjectLocator.parameters.SetOwner(gameObjectLocator);
                    }
                }
            }
        }
    }
}