using Fox.Core;
using System.Collections.Generic;
using Fox.EdGameCore;
using Fox.EdCore;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System;

namespace Tpp.EdGameCore
{
    public class GameObjectEditorWindow : EditorWindow
    {
        // UI Constants
        private const float MIN_WINDOW_WIDTH = 350f;
        private const float MIN_WINDOW_HEIGHT = 400f;
        private const int LISTVIEW_ITEM_HEIGHT = 30;
        private const int MARGIN_MEDIUM = 5;

        private PopupField<string> gameObjectTypeDropdown;
        private PopupField<string> presetPopup;
        private Button createGameObjectButton;

        private string selectedType = null;
        private string selectedPreset = null;
        private UInt32Field groupIdField;
        private UInt32Field totalCountField;
        private UInt32Field realizedCountField;
        private Toggle createLocator;
        private VisualElement locatorContainer;
        private ListView locatorPrefixListView;
        private Label totalLocatorCountLabel;
        private List<LocatorPrefixData> locatorPrefixData = new List<LocatorPrefixData>();

        private static readonly List<string> DefaultPresetList = new();

        [System.Serializable]
        private class LocatorPrefixData
        {
            public string Prefix = "";
            public uint Count = 1;
        }

        [MenuItem("Fox/GameObject Creator")]
        public static void ShowWindow()
        {
            var window = GetWindow<GameObjectEditorWindow>();
            window.titleContent = new GUIContent("GameObject Creator");
            window.minSize = new Vector2(MIN_WINDOW_WIDTH, MIN_WINDOW_HEIGHT);
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
                tooltip = "Group identifier, Unclear what it does.\nAlways 0 in any GameObject."
            };
            totalCountField = new UInt32Field(nameof(Fox.GameCore.GameObject.totalCount))
            {
                tooltip = "Maximum number of instances of this GameObject that can exist"
            };

            totalCountField.RegisterValueChangedCallback<uint>(evt =>
            {
                ValidateTotalLocatorCount();
                UpdateCreateButtonState();
            }); 

            realizedCountField = new UInt32Field(nameof(Fox.GameCore.GameObject.realizedCount))
            {
                tooltip = "Maximum number of instances that can be rendered or active at the same time."
            };

            createLocator = new Toggle("Create Locators")
            {
                tooltip = "If enabled, generates a GameObjectLocator for each GameObject.\nThe number of locators will match the Total Count."
            };
            createLocator.style.display = DisplayStyle.None;

            // Container for the locator section
            locatorContainer = new VisualElement();
            locatorContainer.style.display = DisplayStyle.None;
            locatorContainer.style.marginTop = MARGIN_MEDIUM;
            locatorContainer.style.marginBottom = MARGIN_MEDIUM;

            // Create ListView for locator prefixes
            locatorPrefixListView = new ListView(
                locatorPrefixData,
                LISTVIEW_ITEM_HEIGHT,
                MakeLocatorItem,
                BindLocatorItem
            );
            locatorPrefixListView.reorderable = true;
            locatorPrefixListView.showBorder = true;
            locatorPrefixListView.showAlternatingRowBackgrounds = AlternatingRowBackground.All;
            locatorPrefixListView.style.minHeight = 100;
            locatorPrefixListView.style.maxHeight = 300;
            locatorPrefixListView.selectionType = SelectionType.Single;

            var locatorListHeader = new Label("Locator Prefixes");
            locatorListHeader.style.unityFontStyleAndWeight = FontStyle.Bold;
            locatorListHeader.style.marginBottom = MARGIN_MEDIUM;

            totalLocatorCountLabel = new Label();
            totalLocatorCountLabel.style.marginTop = MARGIN_MEDIUM;
            totalLocatorCountLabel.style.marginBottom = MARGIN_MEDIUM;
            totalLocatorCountLabel.style.unityFontStyleAndWeight = FontStyle.Bold;

            var addPrefixButton = new Button(AddLocatorPrefixEntry)
            {
                text = "Add Locator Prefix"
            };

            var removePrefixButton = new Button(RemoveSelectedLocatorEntry)
            {
                text = "Remove Selected"
            };

            var matchTotalCountButton = new Button(MatchTotalCountToLocators)
            {
                text = "Match Total Count to Locators",
                tooltip = "Sets the Total Count field to match the sum of all locator counts"
            };

            var buttonContainer = new VisualElement();
            buttonContainer.style.flexDirection = FlexDirection.Row;
            buttonContainer.style.marginTop = MARGIN_MEDIUM;
            buttonContainer.Add(addPrefixButton);
            buttonContainer.Add(removePrefixButton);

            var matchButtonContainer = new VisualElement();
            matchButtonContainer.style.marginTop = MARGIN_MEDIUM;
            matchButtonContainer.Add(matchTotalCountButton);

            locatorContainer.Add(locatorListHeader);
            locatorContainer.Add(locatorPrefixListView);
            locatorContainer.Add(buttonContainer);
            locatorContainer.Add(matchButtonContainer);
            locatorContainer.Add(totalLocatorCountLabel);

            rootVisualElement.Add(gameObjectTypeDropdown);
            rootVisualElement.Add(presetPopup);
            rootVisualElement.Add(groupIdField);
            rootVisualElement.Add(totalCountField);
            rootVisualElement.Add(realizedCountField);
            rootVisualElement.Add(createLocator);
            rootVisualElement.Add(locatorContainer);

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
                    locatorContainer.style.display = evt.newValue ? DisplayStyle.Flex : DisplayStyle.None;

                    if (evt.newValue && locatorPrefixData.Count == 0)
                    {
                        AddLocatorPrefixEntry();
                    }

                    UpdateTotalLocatorCountDisplay();
                    UpdateCreateButtonState();
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

            createGameObjectButton = new Button(OnCreateButtonClicked)
            {
                text = "Create GameObject",
                tooltip = "Creates the GameObject in the current scene.\nWARNING: Will delete existing GameObjects and Locators of the same type in the scene."
            };
            rootVisualElement.Add(createGameObjectButton);

            var resetButton = new Button(SetGameObjectTypeFields) { text = "Reset" };
            rootVisualElement.Add(resetButton);

            UpdateCreateButtonState();
        }

        private VisualElement MakeLocatorItem()
        {
            var container = new VisualElement();
            container.style.flexDirection = FlexDirection.Row;
            container.style.alignItems = Align.Center;
            container.style.paddingLeft = 5;
            container.style.paddingRight = 5;

            var prefixLabel = new Label("Prefix");
            prefixLabel.style.width = 45;
            prefixLabel.style.marginRight = 5;

            var prefixField = new TextField()
            {
                name = "PrefixField",
                tooltip = "Name prefix (e.g., 'sol_citadel')"
            };
            prefixField.style.flexGrow = 1;
            prefixField.style.marginRight = 10;

            var countLabel = new Label("Count");
            countLabel.style.width = 45;
            countLabel.style.marginRight = 5;

            var countField = new UInt32Field()
            {
                name = "CountField",
                tooltip = "Number of locators with this prefix"
            };
            countField.style.width = 60;

            container.Add(prefixLabel);
            container.Add(prefixField);
            container.Add(countLabel);
            container.Add(countField);

            return container;
        }

        private void BindLocatorItem(VisualElement element, int index)
        {
            if (index < 0 || index >= locatorPrefixData.Count)
                return;

            var data = locatorPrefixData[index];
            var prefixField = element.Q<TextField>("PrefixField");
            var countField = element.Q<UInt32Field>("CountField");

            prefixField.SetValueWithoutNotify(data.Prefix);
            countField.SetValueWithoutNotify(data.Count);

            // Unregister old callbacks to avoid duplication
            prefixField.UnregisterCallback<ChangeEvent<string>>(OnPrefixChanged);
            countField.UnregisterCallback<ChangeEvent<uint>>(OnCountChanged);

            // Register new callbacks
            prefixField.RegisterCallback<ChangeEvent<string>>(evt =>
            {
                data.Prefix = evt.newValue;
            });

            countField.RegisterCallback<ChangeEvent<uint>>(evt =>
            {
                data.Count = evt.newValue;
                ValidateTotalLocatorCount();
                UpdateTotalLocatorCountDisplay();
                UpdateCreateButtonState();
            });
        }

        private void OnPrefixChanged(ChangeEvent<string> evt)
        {
            // Placeholder for cleanup
        }

        private void OnCountChanged(ChangeEvent<uint> evt)
        {
            // Placeholder for cleanup
        }

        private void OnDisable()
        {
            // Cleanup: Note that UnregisterValueChangedCallback requires the exact callback reference
            // In this implementation, we use inline lambdas which makes unregistering difficult
            // This is generally okay for EditorWindows as they are long-lived
            // For production code, consider storing callback references if cleanup is critical
        }

        private void AddLocatorPrefixEntry()
        {
            var newEntry = new LocatorPrefixData();
            locatorPrefixData.Add(newEntry);
            locatorPrefixListView.Rebuild();
            UpdateTotalLocatorCountDisplay();
            UpdateCreateButtonState();
        }

        private void RemoveSelectedLocatorEntry()
        {
            var selectedIndex = locatorPrefixListView.selectedIndex;
            if (selectedIndex >= 0 && selectedIndex < locatorPrefixData.Count)
            {
                locatorPrefixData.RemoveAt(selectedIndex);
                locatorPrefixListView.Rebuild();
                ValidateTotalLocatorCount();
                UpdateTotalLocatorCountDisplay();
                UpdateCreateButtonState();
            }
            else
            {
                Debug.Log("No locator prefix entry selected.");
            }
        }

        private void MatchTotalCountToLocators()
        {
            uint totalLocators = CalculateTotalLocatorCount();
            
            if (totalLocators == 0)
            {
                Debug.LogWarning("No locator prefixes defined. Add some locator prefixes first.");
                return;
            }

            totalCountField.value = totalLocators;
            Debug.Log($"Total Count set to {totalLocators} to match locator count.");
            
            UpdateTotalLocatorCountDisplay();
            UpdateCreateButtonState();
        }

        private void ValidateTotalLocatorCount()
        {
            uint totalLocators = CalculateTotalLocatorCount();

            if (totalLocators > totalCountField.value)
            {
                Debug.LogWarning($"Total locator count ({totalLocators}) exceeds totalCount ({totalCountField.value})! Adjusting totalCount to match total locator count.");
                totalCountField.SetValueWithoutNotify(totalLocators);
            }
        }

        private uint CalculateTotalLocatorCount()
        {
            uint totalLocators = 0;
            foreach (var data in locatorPrefixData)
            {
                totalLocators += data.Count;
            }
            return totalLocators;
        }

        private void UpdateTotalLocatorCountDisplay()
        {
            if (!createLocator.value)
            {
                return;
            }

            uint totalLocators = CalculateTotalLocatorCount();
            uint totalCount = totalCountField.value;

            if (totalLocators == 0)
            {
                totalLocatorCountLabel.text = $"Total Locators: {totalCount} (will use default naming)";
                totalLocatorCountLabel.style.color = Color.gray;
            }
            else if (totalLocators > totalCount)
            {
                totalLocatorCountLabel.text = $"Total Locators: {totalLocators} / {totalCount} (EXCEEDS LIMIT!)";
                totalLocatorCountLabel.style.color = Color.red;
            }
            else if (totalLocators < totalCount)
            {
                totalLocatorCountLabel.text = $"Total Locators: {totalLocators} / {totalCount} (remaining will use default naming)";
                totalLocatorCountLabel.style.color = new Color(1f, 0.65f, 0f); // Orange
            }
            else
            {
                totalLocatorCountLabel.text = $"Total Locators: {totalLocators} / {totalCount}";
                totalLocatorCountLabel.style.color = Color.green;
            }
        }

        private void UpdateCreateButtonState()
        {
            if (createGameObjectButton == null)
                return;

            bool isValid = ValidateBeforeCreation(out string errorMessage);
            createGameObjectButton.SetEnabled(isValid);
            
            if (!isValid && !string.IsNullOrEmpty(errorMessage))
            {
                createGameObjectButton.tooltip = $"Cannot create: {errorMessage}";
            }
            else
            {
                createGameObjectButton.tooltip = "Creates the GameObject in the current scene.\nWARNING: Will delete existing GameObjects and Locators of the same type in the scene.";
            }
        }

        private bool ValidateBeforeCreation(out string errorMessage)
        {
            errorMessage = string.Empty;

            var scene = SceneManager.GetActiveScene();
            if (!scene.IsValid() || !scene.isLoaded)
            {
                errorMessage = "No active scene";
                return false;
            }

            if (createLocator.value)
            {
                uint totalLocators = CalculateTotalLocatorCount();
                if (totalLocators > totalCountField.value)
                {
                    errorMessage = "Total locator count exceeds totalCount";
                    return false;
                }
            }

            return true;
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
            if (presets != null && presets.Count > 0)
            {
                presetPopup.choices = presets;
                presetPopup.value = presets[0];
                selectedPreset = presets[0];
                presetPopup.style.display = DisplayStyle.Flex;
            }
            else
            {
                presetPopup.style.display = DisplayStyle.None;
                selectedPreset = null;
            }

            if (!info.canCreateLocator)
            {
                createLocator.style.display = DisplayStyle.None;
                locatorContainer.style.display = DisplayStyle.None;
            }
            else
            {
                createLocator.style.display = DisplayStyle.Flex;
                locatorContainer.style.display = createLocator.value ? DisplayStyle.Flex : DisplayStyle.None;
            }

            // Clear locator entries on reset
            locatorPrefixData.Clear();

            // Check if locators already exist in the scene and populate the list
            PopulateExistingLocators();

            locatorPrefixListView.Rebuild();

            UpdateTotalLocatorCountDisplay();
            UpdateCreateButtonState();
        }

        private void PopulateExistingLocators()
        {
            var scene = SceneManager.GetActiveScene();
            if (!scene.IsValid() || !scene.isLoaded)
            {
                return;
            }

            var existingLocators = FindObjectsByType<Fox.GameCore.GameObjectLocator>(
                FindObjectsInactive.Include, 
                FindObjectsSortMode.None
            );

            // Filter locators that match the current type and are in the active scene
            var matchingLocators = new List<Fox.GameCore.GameObjectLocator>();
            foreach (var locator in existingLocators)
            {
                if (locator.typeName == selectedType && locator.gameObject.scene == scene)
                {
                    matchingLocators.Add(locator);
                }
            }

            if (matchingLocators.Count == 0)
            {
                return;
            }

            // Group locators by prefix pattern
            Dictionary<string, uint> prefixCounts = new Dictionary<string, uint>();

            foreach (var locator in matchingLocators)
            {
                string locatorName = locator.name;
                
                // Try to extract prefix (everything before the last underscore followed by digits)
                string prefix = ExtractPrefix(locatorName);
                
                if (!string.IsNullOrEmpty(prefix))
                {
                    if (prefixCounts.ContainsKey(prefix))
                    {
                        prefixCounts[prefix]++;
                    }
                    else
                    {
                        prefixCounts[prefix] = 1;
                    }
                }
            }

            // Populate the locator prefix data from discovered prefixes
            foreach (var kvp in prefixCounts)
            {
                locatorPrefixData.Add(new LocatorPrefixData
                {
                    Prefix = kvp.Key,
                    Count = kvp.Value
                });
            }

            // If we found locators, automatically enable the create locator toggle
            if (locatorPrefixData.Count > 0)
            {
                createLocator.SetValueWithoutNotify(true);
                locatorContainer.style.display = DisplayStyle.Flex;
                Debug.Log($"Found {matchingLocators.Count} existing locators with {locatorPrefixData.Count} unique prefix(es).");
            }
        }

        private string ExtractPrefix(string locatorName)
        {
            // Pattern 1: prefix_0001 format (standard pattern)
            int lastUnderscore = locatorName.LastIndexOf('_');
            if (lastUnderscore > 0 && lastUnderscore < locatorName.Length - 1)
            {
                string afterUnderscore = locatorName.Substring(lastUnderscore + 1);
                
                // Check if everything after the underscore is digits
                bool allDigits = true;
                foreach (char c in afterUnderscore)
                {
                    if (!char.IsDigit(c))
                    {
                        allDigits = false;
                        break;
                    }
                }

                if (allDigits)
                {
                    return locatorName.Substring(0, lastUnderscore);
                }
            }

            // Pattern 2: If no standard pattern found, return the whole name as prefix
            // This handles cases like "sol_citadel" without numeric suffix
            return locatorName;
        }

        private void OnCreateButtonClicked()
        {
            if (!ValidateBeforeCreation(out string errorMessage))
            {
                Debug.LogError($"Cannot create GameObject: {errorMessage}");
                EditorUtility.DisplayDialog("Creation Failed", errorMessage, "OK");
                return;
            }

            var scene = SceneManager.GetActiveScene();

            bool hasInfo = Fox.EdGameCore.EdGameCoreModule.TryGetEditorInfoForGameObjectType(
                selectedType,
                out GameObjectEditorInfo info
            );
            if (!hasInfo)
            {
                Debug.LogError($"Failed to get editor info for type: {selectedType}");
                return;
            }

            try
            {
                Fox.GameCore.GameObject gameObject = CreateOrUpdateGameObject(scene, info);
                
                if (createLocator.value)
                {
                    CreateLocators(scene, info);
                }

                Debug.Log($"Successfully created GameObject: {gameObject.name}");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error creating GameObject: {ex.Message}\n{ex.StackTrace}");
                EditorUtility.DisplayDialog("Creation Error", $"An error occurred:\n{ex.Message}", "OK");
            }
        }

        private Fox.GameCore.GameObject CreateOrUpdateGameObject(UnityEngine.SceneManagement.Scene scene, GameObjectEditorInfo info)
        {
            Fox.GameCore.GameObject[] existingGameObjects =
                FindObjectsByType<Fox.GameCore.GameObject>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            Fox.GameCore.GameObject gameObject = null;
            foreach (var existingObject in existingGameObjects)
            {
                if (existingObject.typeName == selectedType && existingObject.gameObject.scene == scene)
                {
                    gameObject = existingObject;
                    break;
                }
            }

            if (gameObject == null)
            {
                var newGameObject = new UnityEngine.GameObject();
                Undo.RegisterCreatedObjectUndo(newGameObject, "Create GameObject");
                gameObject = newGameObject.AddComponent<Fox.GameCore.GameObject>();
            }
            else
            {
                Undo.RecordObject(gameObject, "Update GameObject");
                while (gameObject.transform.childCount > 0)
                {
                    var child = gameObject.transform.GetChild(0).gameObject;
                    Undo.DestroyObjectImmediate(child);
                }
            }

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

            return gameObject;
        }

        private void CreateLocators(UnityEngine.SceneManagement.Scene scene, GameObjectEditorInfo info)
        {
            CleanupExistingLocators(scene);

            uint totalLocatorsToCreate = CalculateTotalLocatorCount();

            if (totalLocatorsToCreate > totalCountField.value)
            {
                Debug.LogError($"Cannot create locators: Total count ({totalLocatorsToCreate}) exceeds totalCount ({totalCountField.value}). Aborting locator creation.");
                return;
            }

            int globalIndex = 0;

            if (locatorPrefixData.Count > 0)
            {
                foreach (var data in locatorPrefixData)
                {
                    string prefix = data.Prefix?.Trim();
                    uint count = data.Count;

                    if (string.IsNullOrEmpty(prefix))
                    {
                        Debug.LogWarning("Skipping entry with empty prefix.");
                        continue;
                    }

                    for (int i = 0; i < count && globalIndex < totalCountField.value; i++, globalIndex++)
                    {
                        CreateSingleLocator(info, $"{prefix}_{i:D4}");
                    }
                }
            }

            // Create remaining locators with default naming if needed
            while (globalIndex < totalCountField.value)
            {
                CreateSingleLocator(info, $"{selectedType}_GameObjectLocator_{globalIndex}");
                globalIndex++;
            }
        }

        private void CleanupExistingLocators(UnityEngine.SceneManagement.Scene scene)
        {
            var existingGameObjectLocators = FindObjectsByType<Fox.GameCore.GameObjectLocator>(
                FindObjectsInactive.Include, 
                FindObjectsSortMode.None
            );

            List<Fox.GameCore.GameObjectLocator> locatorsToCleanup = new List<Fox.GameCore.GameObjectLocator>();
            foreach (var existingLocator in existingGameObjectLocators)
            {
                if (existingLocator.typeName == selectedType && existingLocator.gameObject.scene == scene)
                {
                    locatorsToCleanup.Add(existingLocator);
                }
            }

            foreach (var oldLocator in locatorsToCleanup)
            {
                Undo.DestroyObjectImmediate(oldLocator.gameObject);
            }
        }

        private void CreateSingleLocator(GameObjectEditorInfo info, string locatorName)
        {
            var locatorGameObject = new UnityEngine.GameObject();
            Undo.RegisterCreatedObjectUndo(locatorGameObject, "Create GameObjectLocator");
            
            Fox.GameCore.GameObjectLocator gameObjectLocator = locatorGameObject.AddComponent<Fox.GameCore.GameObjectLocator>();
            gameObjectLocator.name = locatorName;

            var transformGameObject = new UnityEngine.GameObject();
            Undo.RegisterCreatedObjectUndo(transformGameObject, "Create TransformEntity");
            
            TransformEntity transformBase = transformGameObject.AddComponent<Fox.Core.TransformEntity>();
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