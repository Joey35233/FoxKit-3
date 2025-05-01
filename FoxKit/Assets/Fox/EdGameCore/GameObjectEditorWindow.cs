using Fox.Core;
using Fox.GameCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tpp.GameCore;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Fox.EdGameCore
{
    public class GameObjectEditorWindow : EditorWindow
    {
        private PopupField<string> gameObjectTypeDropdown;
        private PopupField<string> extraOptionPopup;


        private TextField defaultNameField;
        private IntegerField groupIdField;
        private IntegerField totalCountField;
        private IntegerField realizedCountField;

        private string selectedType = "TppBear";
        private string selectedExtraOption;

        [MenuItem("FoxKit/Editor Tools/GameObject Creator")]
        public static void ShowWindow()
        {
            var window = GetWindow<GameObjectEditorWindow>();
            window.titleContent = new GUIContent("GameObject Creator");
            window.minSize = new Vector2(350, 300);
        }

        public void CreateGUI()
        {
            gameObjectTypeDropdown = new PopupField<string>("GameObject Type", EdGameCoreModule.gameObjectTypes, 0);
            extraOptionPopup = new PopupField<string>("Extra Option", new List<string>(), 0);
            extraOptionPopup.style.display = DisplayStyle.None;
            


            defaultNameField = new TextField("GameObject Name");
            groupIdField = new IntegerField("GroupId");
            totalCountField = new IntegerField("Total Count");
            realizedCountField = new IntegerField("Realized Count");

            rootVisualElement.Add(gameObjectTypeDropdown);
            rootVisualElement.Add(extraOptionPopup);
            rootVisualElement.Add(defaultNameField);
            rootVisualElement.Add(groupIdField);
            rootVisualElement.Add(totalCountField);
            rootVisualElement.Add(realizedCountField);

            UpdateFields();

            gameObjectTypeDropdown.RegisterValueChangedCallback(evt =>
            {
                Debug.Log("RegisterValueChangedCallback");
                selectedType = evt.newValue;
                Debug.Log("selectedType value " + selectedType);
                UpdateFields();
            });

            extraOptionPopup.RegisterValueChangedCallback(evt =>
            {
                selectedExtraOption = evt.newValue;
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

            if (selectedType == "TppBuddyQuiet2")
            {
                extraOptionPopup.choices = new List<string> { "Naked", "Naked (Blood)", "Naked (Silver Q)", "Naked (Gold Q)", "Sniper Wolf", "Gray XOF" };
                extraOptionPopup.value = extraOptionPopup.choices[0];

                extraOptionPopup.style.display = DisplayStyle.Flex;
            }
            else if (selectedType == "TppBossQuiet2")
            {
                extraOptionPopup.choices = new List<string> { "Quiet", "Female Skull" };
                extraOptionPopup.value = extraOptionPopup.choices[0];

                extraOptionPopup.style.display = DisplayStyle.Flex;
            }
            else if (selectedType == "TppHostage2")
            {
                extraOptionPopup.choices = new List<string> { "Soviet Prisoner (Male)", "Soviet Prisoner (Female)", "Africa Prisoner (Male)", "Africa Prisoner (Female)", "DD Prisoner" };
                extraOptionPopup.value = extraOptionPopup.choices[0];

                extraOptionPopup.style.display = DisplayStyle.Flex;
            }
            else if(selectedType == "TppSoldier2")
            {
                extraOptionPopup.choices = new List<string>
                {
                    "Soviet", "PF", "XOF",
                    "Fatigue - Drab (Male)", "Fatigue - Drab (Female)",
                    "Fatigue - Tiger (Male)", "Fatigue - Tiger (Female)",
                    "Sneaking Suit (Male)", "Sneaking Suit (Female)",
                    "Battle Dress (Male)", "Battle Dress (Female)"
                };
                extraOptionPopup.value = extraOptionPopup.choices[0];

                extraOptionPopup.style.display = DisplayStyle.Flex;
            }
            else
            {
                extraOptionPopup.style.display = DisplayStyle.None;
            }
        }

        private void OnCreateButtonClicked()
        {
            var info = EdGameCoreModule.GetGameObjectInfoByType(selectedType);
            var scene = SceneManager.GetActiveScene();

            if (!scene.IsValid() || !scene.isLoaded)
            {
                Debug.LogWarning("No active scene!");
                return;
            }

            var existing = UnityEngine.GameObject.FindObjectsOfType<Fox.GameCore.GameObject>(true)
                .FirstOrDefault(x => x.typeName == selectedType && x.gameObject.scene == scene);

            if (existing != null)
            {
                DestroyImmediate(existing.gameObject);
            }

            var obj = new UnityEngine.GameObject(defaultNameField.value);
            SceneManager.MoveGameObjectToScene(obj, scene);

            var foxObject = obj.AddComponent<Fox.GameCore.GameObject>();
            foxObject.typeName = selectedType;
            foxObject.groupId = info.GroupId;
            foxObject.totalCount = info.TotalCount;
            foxObject.realizedCount = info.RealizedCount;

            var parameter = info.CreateAndAssignParameter(foxObject);

            if (parameter is TppBearParameter bearParameter)
            {
                bearParameter.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/ber/ber0_main0_def_v00.parts"));
                bearParameter.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/bear/Bear_layers.mtar"));
                bearParameter.mogFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/bear/Bear_layers.mog"));

                bearParameter.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/ber/ber0_c00.fv2")));

            }
            else if(parameter is TppBuddyDog2Parameter buddyDogParam)
            {
                buddyDogParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/ddg/ddg0_main0_def_v00.parts"));

                buddyDogParam.motionGraphFile = new FilePtr(new Path(""));
                buddyDogParam.mtarFile = new FilePtr(new Path(""));
                buddyDogParam.extensionMtarFile = new FilePtr(new Path(""));
            }
            else if (parameter is TppBuddyPuppyParameter buddyPuppyDogParam)
            {
                buddyPuppyDogParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/ddg/ddg0_main0_def_v00.parts"));
                buddyPuppyDogParam.motionGraphFile = new FilePtr(new Path(""));
                buddyPuppyDogParam.mtarFile = new FilePtr(new Path(""));

                //buddyPuppyDogParam.vfxFiles.Insert(null, new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrwepref01_s5MG.vfx"))); Empty

                buddyPuppyDogParam.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/ddg/ddg1_v01_c00.fv2")));
                buddyPuppyDogParam.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/ddg/ddg1_v02_c00.fv2")));
            }
            else if (parameter is TppBuddyQuiet2Parameter TppBuddyQuiet2Parameter)
            {
                switch (selectedExtraOption)
                {
                    case "Naked":
                        TppBuddyQuiet2Parameter.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_def_v00.parts"));
                        break;
                    case "Naked (Blood)":
                        TppBuddyQuiet2Parameter.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_bld_v00.parts"));
                        break;
                    case "Naked (Silver Q)":
                        TppBuddyQuiet2Parameter.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_slv_v00.parts"));
                        break;
                    case "Naked (Gold Q)":
                        TppBuddyQuiet2Parameter.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_gld_v00.parts"));
                        break;
                    case "Sniper Wolf":
                        TppBuddyQuiet2Parameter.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui4_main0_def_v00.parts"));
                        break;
                    case "Gray XOF":
                        TppBuddyQuiet2Parameter.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui5_main0_def_v00.parts"));
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
            else if (parameter is TppBossQuiet2Parameter bossQuiet2Param)
            {
                switch (selectedExtraOption)
                {
                    case "Quiet":
                        bossQuiet2Param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_def_v00.parts"));
                        break;
                    case "Female Skull":
                        bossQuiet2Param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/wmu/wmu1_main0_def_v00.parts"));
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
            else if (parameter is TppHostage2Parameter hostage2Param)
            {
                switch (selectedExtraOption)
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
            else if (parameter is TppSoldier2Parameter soldierParam)
            {
                switch (selectedExtraOption)
                {
                    case "Soviet":
                        soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/svs/svs0_main0_def_v00.parts"));
                        break;
                    case "PF":
                        soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/pfs/pfs0_main0_def_v00.parts"));
                        break;
                    case "XOF":
                        soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/wss/wss4_main0_def_v00.parts"));
                        break;
                    case "Fatigue - Drab (Male)":
                        soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds3_main0_def_v00.parts"));
                        break;
                    case "Fatigue - Drab (Female)":
                        soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds8_main0_def_v00.parts"));
                        break;
                    case "Fatigue - Tiger (Male)":
                        soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds5_enem0_def_v00.parts"));
                        break;
                    case "Fatigue - Tiger (Female)":
                        soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds6_enef0_def_v00.parts"));
                        break;
                    case "Sneaking Suit (Male)":
                        soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna4_enem0_def_v00.parts"));
                        break;
                    case "Sneaking Suit (Female)":
                        soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna4_enef0_def_v00.parts"));
                        break;
                    case "Battle Dress (Male)":
                        soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna5_enem0_def_v00.parts"));
                        break;
                    case "Battle Dress (Female)":
                        soldierParam.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna5_enef0_def_v00.parts"));
                        break;
                }
                soldierParam.vfxFiles.Insert("Blood0", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld01_s1LG.vfx")));
                soldierParam.vfxFiles.Insert("Blood1", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld03_s1LG.vfx")));
                soldierParam.vfxFiles.Insert("Blood2", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld06_s1.vfx")));
            }

            Selection.activeGameObject = obj;
        }
    }
}