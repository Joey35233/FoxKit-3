using Fox;
using Fox.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Tpp.GameCore;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityScene = UnityEngine.SceneManagement.Scene;

namespace FoxEditorTools
{
    public class GameObjectInfo
    {
        public string DefaultName;
        public uint GroupId;
        public uint TotalCount;
        public uint RealizedCount;
        public string ParameterName;

        public GameObjectInfo(string defaultName, uint groupId, uint totalCount, uint realizedCount, string parameterName)
        {
            DefaultName = defaultName;
            GroupId = groupId;
            TotalCount = totalCount;
            RealizedCount = realizedCount;
            ParameterName = parameterName;
        }
    }

    public class EditorWindow_GameObject : EditorWindow
    {
        private string selectedType = "TppBossQuiet2";
        private string selectedSoldierFaction = "Soviet";
        private string inputName;
        private uint inputGroupId = 0;
        private uint inputTotalCount = 1;
        private uint inputRealizedCount = 1;

        private static readonly Dictionary<string, GameObjectInfo> typeData = new()
            {
                //"TppBear",
                //"TppBuddyDog2",
                //"TppBuddyPuppy",
                //"TppBuddyQuiet2",
                { "TppBossQuiet2", new GameObjectInfo("BossQuietGameObject", 0, 1, 1, "TppBossQuiet2Parameter") },//tex: is also sniper parasites
                //"TppCodeTalker2",
                //"TppCommandPost2",
                //"TppCommonWalkerGear2",
                //"TppCorpse",
                //"TppCritterBird",
                //"TppDecoySystem",
                //"TppEagle",
                //"TppEnemyHeli",
                //"TppEspionageRadioSystem",
                //"TppGoat",
                //"TppJackal",
                //"TppMarker2LocatorSystem",
                //"TppNubian",
                //"TppHeli2",
                //"TppHorse2",
                //"TppHostage2",
                //"TppHostageKaz",
                //"TppHostageUnique",
                //"TppHostageUnique2",
                //"TppHuey2",
                //"TppLiquid2",
                //"TppMantis2",
                //"TppOcelot2",
                //"TppOtherHeli2",
                //"TppParasite2",
                //"TppPlacedSystem",
                //"TppPlayer2",
                //"TppPlayerHorseforVr",//tex: prologue volgin escape
                //"TppRat",
                //"TppSahalen2",
                //"TppSecurityCamera2",
                //"TppSkullFace2",
                { "TppSoldier2", new GameObjectInfo("Soldier2GameObject", 0, 160, 12, "TppSoldier2Parameter") },//tex: is also sniper parasites
                //"TppStork",
                //"TppSupplyCboxSystem",
                //"TppSupportAttackSystem",
                //"TppVolgin2",
                //"TppVolgin2forVr",//tex: prologue volgin escape
                //"TppUav",
                //"TppVehicle2",
                //"TppWalkerGear2",
                //"TppWolf",
                //"TppZebra",
        };

        private static readonly Dictionary<string, List<string>> extraOptionsPerType = new()
        {
            { "TppSoldier2", new List<string> { "Soviet", "PF", "XOF", "DD" } }
        };


        private static readonly Dictionary<string, Type> parameterTypes = new()
        {
            { "TppBossQuiet2Parameter", typeof(TppBossQuiet2Parameter) },
            { "TppSoldier2Parameter", typeof(TppSoldier2Parameter) },
        };

        private readonly List<string> soldierFactions = new() {
            "Soviet",
            "PF",
            "XOF",
            "Fatigue - Drab (Male)",
            "Fatigue - Drab (Female)",
            "Fatigue - Tiger (Male)",
            "Fatigue - Tiger (Female)",
            "Sneaking Suit (Male)",
            "Sneaking Suit (Female)",
            "Battle Dress (Male)",
            "Battle Dress (Female)"
        };

        [MenuItem("FoxKit/Editor Tools/GameObject Creator")]
        public static void ShowWindow()
        {
            var window = GetWindow<EditorWindow_GameObject>();
            window.titleContent = new GUIContent("GameObject Creator");
            window.minSize = new Vector2(250, 200);
        }

        public void CreateGUI()
        {
            var label = new Label("   Select GameObject Type:");
            rootVisualElement.Add(label);

            var typeList = typeData.Keys.ToList();
            var popup = new PopupField<string>("GameObject Type", typeList, selectedType);
            var nameField = new TextField("GameObject Name");
            var totalCountField = new IntegerField("Total Count");
            var realizedCountField = new IntegerField("Realized Count");
            var factionPopup = new PopupField<string>("Soldier Faction", soldierFactions, selectedSoldierFaction);
            factionPopup.style.display = selectedType == "TppSoldier2" ? DisplayStyle.Flex : DisplayStyle.None;

            rootVisualElement.Add(popup);
            rootVisualElement.Add(nameField);
            rootVisualElement.Add(totalCountField);
            rootVisualElement.Add(realizedCountField);

            void UpdateFields()
            {
                var info = typeData[selectedType];
                inputName = info.DefaultName;
                inputGroupId = info.GroupId;
                inputTotalCount = info.TotalCount;
                inputRealizedCount = info.RealizedCount;

                nameField.value = inputName;
                totalCountField.value = (int)inputTotalCount;
                realizedCountField.value = (int)inputRealizedCount;

                if (selectedType == "TppSoldier2")
                {
                    if (!rootVisualElement.Contains(factionPopup))
                    {
                        rootVisualElement.Insert(2, factionPopup); // insert before createButton
                    }
                    factionPopup.style.display = DisplayStyle.Flex;
                }
                else
                {
                    if (rootVisualElement.Contains(factionPopup))
                    {
                        factionPopup.style.display = DisplayStyle.None;
                    }
                }
            }


            popup.RegisterValueChangedCallback(evt =>
            {
                selectedType = evt.newValue;
                UpdateFields();
            });

            factionPopup.RegisterValueChangedCallback(evt =>
            {
                selectedSoldierFaction = evt.newValue;
            });

            UpdateFields();

            var createButton = new Button(() =>
            {
                inputName = nameField.value;
                inputTotalCount = (uint)totalCountField.value;
                inputRealizedCount = (uint)realizedCountField.value;

                CreateGameObject(selectedType, inputName, inputGroupId, inputTotalCount, inputRealizedCount);
            })
            {
                text = "Create GameObject"
            };

            rootVisualElement.Add(createButton);
        }

        private static DataElement CreateAndAttachParameter(GameObject parent, string name, Type paramType)
        {
            var paramGO = new GameObject(name);
            paramGO.transform.SetParent(parent.transform);
            return (DataElement)paramGO.AddComponent(paramType);
        }

        private static void AssignParameter(GameObject obj, DataElement param)
        {
            if (obj == null || param == null) return;
            obj.GetComponent<Fox.GameCore.GameObject>().parameters = param;
            Selection.activeGameObject = obj;
        }

        private void CreateGameObject(string typeName, string name, uint groupId, uint totalCount, uint realizedCount)
        {
            var scene = SceneManager.GetActiveScene();
            if (!scene.IsValid() || !scene.isLoaded)
            {
                Debug.LogWarning("No active scene!");
                return;
            }

            var existing = GameObject.FindObjectsOfType<Fox.GameCore.GameObject>(true)
                            .FirstOrDefault(x => x.typeName == typeName && x.gameObject.scene == scene);
            if (existing != null)
            {
                DestroyImmediate(existing.gameObject);
            }

            var obj = new GameObject(name);
            SceneManager.MoveGameObjectToScene(obj, scene);

            var foxObj = obj.AddComponent<Fox.GameCore.GameObject>();
            foxObj.typeName = typeName;
            foxObj.groupId = groupId;
            foxObj.totalCount = totalCount;
            foxObj.realizedCount = realizedCount;

            if (typeData.TryGetValue(typeName, out var info) && parameterTypes.TryGetValue(info.ParameterName, out var paramType))
            {
                var param = CreateAndAttachParameter(obj, info.ParameterName, paramType);
                ConfigureParameter(typeName, param);
                AssignParameter(obj, param);
            }
            else
            {
                Debug.LogWarning($"No parameter found or registered for: {typeName}");
            }

            Selection.activeGameObject = obj;
        }

        private void ConfigureParameter(string typeName, DataElement param)
        {
            if (typeName == "TppSoldier2" && param is TppSoldier2Parameter soldier)
            {
                switch (selectedSoldierFaction)
                {
                    case "Soviet":
                        soldier.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/svs/svs0_main0_def_v00.parts"));
                        break;
                    case "PF":
                        soldier.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/pfs/pfs0_main0_def_v00.parts"));
                        break;
                    case "XOF":
                        soldier.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/wss/wss4_main0_def_v00.parts"));
                        break;
                    case "Fatigue - Drab (Male)":
                        soldier.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds3_main0_def_v00.parts"));
                        break;
                    case "Fatigue - Drab (Female)":
                        soldier.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds8_main0_def_v00.parts"));
                        break;
                    case "Fatigue - Tiger (Male)":
                        soldier.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds5_enem0_def_v00.parts"));
                        break;
                    case "Fatigue - Tiger (Female)":
                        soldier.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds6_enef0_def_v00.parts"));
                        break;
                    case "Sneaking Suit (Male)":
                        soldier.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna4_enem0_def_v00.parts"));
                        break;
                    case "Sneaking Suit (Female)":
                        soldier.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna4_enef0_def_v00.parts"));
                        break;
                    case "Battle Dress (Male)":
                        soldier.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna5_enem0_def_v00.parts"));
                        break;
                    case "Battle Dress (Female)":
                        soldier.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna5_enef0_def_v00.parts"));
                        break;
                }

                soldier.vfxFiles.Insert("Blood0", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld01_s1LG.vfx")));
                soldier.vfxFiles.Insert("Blood1", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld03_s1LG.vfx")));
                soldier.vfxFiles.Insert("Blood2", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld06_s1.vfx")));
            }
        }
    }
}