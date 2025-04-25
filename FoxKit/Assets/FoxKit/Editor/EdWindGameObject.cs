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
        private string selectedType = "TppSoldier2";
        private string selectedFaction = "Soviet";
        private string inputName;
        private uint inputGroupId = 0;
        private uint inputTotalCount = 160;
        private uint inputRealizedCount = 12;

        private static readonly Dictionary<string, GameObjectInfo> typeData = new()
            { 
                { "TppBear", new GameObjectInfo("BearGameObject", 0, 1, 1, "TppBearParameter") },
                { "TppBuddyDog2", new GameObjectInfo("BuddyDogGameObject", 0, 1, 1, "TppBuddyDog2Parameter") },
                { "TppBuddyPuppy", new GameObjectInfo("BuddyPuppy", 0, 1, 1, "TppBuddyPuppyParameter") },
                { "TppBuddyQuiet2", new GameObjectInfo("BuddyQuietGameObject", 0, 1, 1, "TppBuddyQuiet2Parameter") },
                { "TppBossQuiet2", new GameObjectInfo("BossQuietGameObject", 0, 1, 1, "TppBossQuiet2Parameter") },//tex: is also sniper parasites
                //{ "TppCodeTalker2", new GameObjectInfo("GameObjectTppCodeTalker2", 0, 1, 1, "TppHostage2Parameter") },
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
                { "TppHostage2", new GameObjectInfo("Hostage2GameObject2", 0, 14, 5, "TppHostage2Parameter") },
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

        private static readonly Dictionary<string, Type> parameterTypes = new()
        { 
            { "TppBearParameter", typeof(TppBearParameter) },
            { "TppBuddyDog2Parameter", typeof(TppBuddyDog2Parameter) },
            { "TppBuddyPuppyParameter", typeof(TppBuddyPuppyParameter) },
            { "TppBuddyQuiet2Parameter", typeof(TppBuddyQuiet2Parameter) },
            { "TppBossQuiet2Parameter", typeof(TppBossQuiet2Parameter) },
            { "TppHostage2Parameter", typeof(TppHostage2Parameter) },
            { "TppSoldier2Parameter", typeof(TppSoldier2Parameter) },
        };

        // new: faction options per type
        private static readonly Dictionary<string, List<string>> factionOptions = new()
        {
            { "TppBuddyQuiet2", new List<string> { "Naked", "Naked (Blood)", "Naked (Silver Q)", "Naked (Gold Q)", "Sniper Wolf", "Gray XOF" } },
            { "TppBossQuiet2", new List<string> { "Quiet", "Female Skull" } },
            { "TppHostage2", new List<string> { "Soviet Prisoner (Male)", "Soviet Prisoner (Female)", "Africa Prisoner (Male)", "Africa Prisoner (Female)", "DD Prisoner" } },
            { "TppSoldier2", new List<string> {
                "Soviet", "PF", "XOF",
                "Fatigue - Drab (Male)", "Fatigue - Drab (Female)",
                "Fatigue - Tiger (Male)", "Fatigue - Tiger (Female)",
                "Sneaking Suit (Male)", "Sneaking Suit (Female)",
                "Battle Dress (Male)", "Battle Dress (Female)"
            }}
        };

        [MenuItem("FoxKit/Editor Tools/GameObject Creator")]
        public static void ShowWindow()
        {
            var window = GetWindow<EditorWindow_GameObject>();
            window.titleContent = new GUIContent("GameObject Creator");
            window.minSize = new Vector2(350, 250);
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
            var factionPopup = new PopupField<string>("Faction", new List<string>(), 0);
            factionPopup.style.display = DisplayStyle.None;

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

                if (factionOptions.TryGetValue(selectedType, out var factions))
                {
                    factionPopup.choices = factions;
                    factionPopup.value = factions[0];
                    selectedFaction = factions[0];

                    if (!rootVisualElement.Contains(factionPopup))
                        rootVisualElement.Insert(2, factionPopup);

                    factionPopup.style.display = DisplayStyle.Flex;
                }
                else
                {
                    factionPopup.style.display = DisplayStyle.None;
                }
            }

            popup.RegisterValueChangedCallback(evt =>
            {
                selectedType = evt.newValue;
                UpdateFields();
            });

            factionPopup.RegisterValueChangedCallback(evt =>
            {
                selectedFaction = evt.newValue;
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
            if (typeName == "TppBear" && param is TppBearParameter bearParameter)
            {
                bearParameter.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/ber/ber0_main0_def_v00.parts"));
                bearParameter.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/bear/Bear_layers.mtar"));
                bearParameter.mogFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/bear/Bear_layers.mog"));

                bearParameter.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/ber/ber0_c00.fv2")));
            }
            else if (typeName == "TppBuddyDog2" && param is TppBuddyDog2Parameter buddyDogParam)
            {
                buddyDogParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/ddg/ddg0_main0_def_v00.parts"));

                buddyDogParam.motionGraphFile = new FilePtr(new Path(""));
                buddyDogParam.mtarFile = new FilePtr(new Path(""));
                buddyDogParam.extensionMtarFile = new FilePtr(new Path(""));
            }
            else if (typeName == "TppBuddyPuppy" && param is TppBuddyPuppyParameter buddyPuppyDogParam)
            {
                buddyPuppyDogParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/ddg/ddg0_main0_def_v00.parts"));
                buddyPuppyDogParam.motionGraphFile = new FilePtr(new Path(""));
                buddyPuppyDogParam.mtarFile = new FilePtr(new Path(""));

                //buddyPuppyDogParam.vfxFiles.Insert(null, new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrwepref01_s5MG.vfx"))); Empty

                buddyPuppyDogParam.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/ddg/ddg1_v01_c00.fv2")));
                buddyPuppyDogParam.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/ddg/ddg1_v02_c00.fv2")));
            }
            else if (typeName == "TppBuddyQuiet2" && param is TppBuddyQuiet2Parameter TppBuddyQuiet2Parameter)
            {
                switch (selectedFaction)
                {
                    case "Naked":TppBuddyQuiet2Parameter.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_def_v00.parts"));
                        break;
                    case "Naked (Blood)":TppBuddyQuiet2Parameter.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_bld_v00.parts"));
                        break;
                    case "Naked (Silver Q)":TppBuddyQuiet2Parameter.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_slv_v00.parts"));
                        break;
                    case "Naked (Gold Q)":TppBuddyQuiet2Parameter.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_gld_v00.parts"));
                        break;
                    case "Sniper Wolf":TppBuddyQuiet2Parameter.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui4_main0_def_v00.parts"));
                        break;
                    case "Gray XOF":TppBuddyQuiet2Parameter.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui5_main0_def_v00.parts"));
                        break;
                }
                TppBuddyQuiet2Parameter.vfxFiles.Insert("Blood0", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld01_s1LG.vfx")));
                TppBuddyQuiet2Parameter.vfxFiles.Insert("Blood1", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld03_s1LG.vfx")));
                TppBuddyQuiet2Parameter.vfxFiles.Insert("Blood2", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld06_s1.vfx")));
                TppBuddyQuiet2Parameter.vfxFiles.Insert("SightLight", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrwepref01_s5MG.vfx")));
                TppBuddyQuiet2Parameter.vfxFiles.Insert("EyeFlare", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrlgtquieye_m1.vfx")));
                TppBuddyQuiet2Parameter.vfxFiles.Insert("Warp", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuwrp01_s1.vfx")));
                TppBuddyQuiet2Parameter.vfxFiles.Insert("LandingSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquignddwn01_m1.vfx")));
                TppBuddyQuiet2Parameter.vfxFiles.Insert("SprintSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquifotsmk02_m1.vfx")));
                TppBuddyQuiet2Parameter.vfxFiles.Insert("SlidingSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquifotsmk03_s1.vfx")));
                TppBuddyQuiet2Parameter.vfxFiles.Insert("HaloSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquidnwgnd01_m2.vfx")));
                TppBuddyQuiet2Parameter.vfxFiles.Insert("WaterPillar", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquifotwtr01_m1.vfx")));
                TppBuddyQuiet2Parameter.vfxFiles.Insert("DamageFirefly", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbldwmu01_s1.vfx")));
                TppBuddyQuiet2Parameter.vfxFiles.Insert("Dead", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbldwmu02_s1.vfx")));

            }
            else if (typeName == "TppBossQuiet2" && param is TppBossQuiet2Parameter bossQuiet2Param)
            {
                switch (selectedFaction)
                {
                    case "Quiet":bossQuiet2Param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_def_v00.parts"));
                        break;
                    case "Female Skull":bossQuiet2Param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/wmu/wmu1_main0_def_v00.parts"));
                        break;
                }
                bossQuiet2Param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/bossquiet2/BossQuiet2_layers.mog"));
                bossQuiet2Param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/bossquiet2/BossQuiet2_layers.mtar"));
                bossQuiet2Param.extensionMtarFile = new FilePtr(new Path("")); // It's empty

                bossQuiet2Param.vfxFiles.Insert("SightLight", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrwepref01_s5MG.vfx")));
                bossQuiet2Param.vfxFiles.Insert("EyeFlare", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrlgtquieye_m1.vfx")));
                bossQuiet2Param.vfxFiles.Insert("LandingSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuatk01_m1.vfx")));
                bossQuiet2Param.vfxFiles.Insert("WarpStart", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuwrp01_s1.vfx")));
                bossQuiet2Param.vfxFiles.Insert("SprintSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquifotsmk02_m1.vfx")));
                bossQuiet2Param.vfxFiles.Insert("DrippedBlood", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_blddcl00_s1LG.vfx")));
                bossQuiet2Param.vfxFiles.Insert("Recover", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrrbw01_s5.vfx")));
                bossQuiet2Param.vfxFiles.Insert("DamageFirefly", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbldwmu01_s1.vfx")));
                bossQuiet2Param.vfxFiles.Insert("BloodS", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld01_s1LG.vfx")));
                bossQuiet2Param.vfxFiles.Insert("BloodL", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld03_s1LG.vfx")));
                bossQuiet2Param.vfxFiles.Insert("WarpEnd", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuwrp02_s1.vfx")));
                bossQuiet2Param.vfxFiles.Insert("Dead", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbldwmu02_s1.vfx")));
                bossQuiet2Param.vfxFiles.Insert("BulletLine", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/weapon/fx_tpp_wepbltblr01_s0LG.vfx")));
                bossQuiet2Param.vfxFiles.Insert("WeaponGenerate", new FilePtr(new Path(""))); // Empty
                bossQuiet2Param.vfxFiles.Insert("BloodSplash", new FilePtr(new Path(""))); // Empty
                bossQuiet2Param.vfxFiles.Insert("JumpStart", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquiwrp01_s1.vfx")));
                bossQuiet2Param.vfxFiles.Insert("SprintWater", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquifotwtr01_m1.vfx")));
                bossQuiet2Param.vfxFiles.Insert("MacheteCounterHit", new FilePtr(new Path(""))); // Empty
            }
            else if (typeName == "TppHostage2" && param is TppHostage2Parameter hostage2Param)
            {
                switch (selectedFaction)
                {
                    case "Soviet Prisoner (Male)":
                        hostage2Param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs2_main0_def_v00.parts"));
                        break;
                    case "Soviet Prisoner (Female)":
                        hostage2Param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs3_main0_def_v00.parts"));
                        break;
                    case "Africa Prisoner (Male)":
                        hostage2Param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs5_main0_def_v00.parts"));
                        break;
                    case "Africa Prisoner (Female)":
                        hostage2Param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs6_main0_def_v00.parts"));
                        break;
                    case "DD Prisoner":
                        hostage2Param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/pdd5_main0_def_v00.parts"));
                        break;
                    
                }
                hostage2Param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/hostage2/Hostage2_layers.mog"));
                hostage2Param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/hostage2/Hostage2_layers.mtar"));
                hostage2Param.extensionMtarFile = new FilePtr(new Path("")); // Empty as per XML

                hostage2Param.vfxFiles.Insert("Blood0", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld01_s1LG.vfx")));
                hostage2Param.vfxFiles.Insert("Blood1", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld03_s1LG.vfx")));
                hostage2Param.vfxFiles.Insert("Blood2", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld06_s1.vfx")));
            }
            else if (typeName == "TppSoldier2" && param is TppSoldier2Parameter soldierParam)
            {
                switch (selectedFaction)
                {
                    case "Soviet":soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/svs/svs0_main0_def_v00.parts"));
                        break;
                    case "PF":soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/pfs/pfs0_main0_def_v00.parts"));
                        break;
                    case "XOF":soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/wss/wss4_main0_def_v00.parts"));
                        break;
                    case "Fatigue - Drab (Male)":soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds3_main0_def_v00.parts"));
                        break;
                    case "Fatigue - Drab (Female)":soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds8_main0_def_v00.parts"));
                        break;
                    case "Fatigue - Tiger (Male)":soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds5_enem0_def_v00.parts"));
                        break;
                    case "Fatigue - Tiger (Female)":soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds6_enef0_def_v00.parts"));
                        break;
                    case "Sneaking Suit (Male)":soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna4_enem0_def_v00.parts"));
                        break;
                    case "Sneaking Suit (Female)":soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna4_enef0_def_v00.parts"));
                        break;
                    case "Battle Dress (Male)":soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna5_enem0_def_v00.parts"));
                        break;
                    case "Battle Dress (Female)":soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna5_enef0_def_v00.parts"));
                        break;
                }
                soldierParam.vfxFiles.Insert("Blood0", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld01_s1LG.vfx")));
                soldierParam.vfxFiles.Insert("Blood1", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld03_s1LG.vfx")));
                soldierParam.vfxFiles.Insert("Blood2", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld06_s1.vfx")));
            }
        }
    }
}