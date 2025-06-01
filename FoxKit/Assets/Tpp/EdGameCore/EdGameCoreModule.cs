using Fox;
using Fox.Core;
using System.Collections.Generic;
using UnityEditor;

namespace Tpp.EdGameCore
{
    [InitializeOnLoad]
    public class EdGameCoreModule
    {
        static EdGameCoreModule()
        {
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppBear", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 2,
                realizedCount = 2,

                Presets = new List<string>
                {
                    "Brown Bear",
                    "White Bear",
                    "All",
                },

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppBearParameter>();
                    
                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/ber/ber0_main0_def_v00.parts"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/bear/Bear_layers.mtar"));
                    param.mogFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/bear/Bear_layers.mog"));
                    switch (preset)
                    {
                        case "Brown Bear": param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/ber/ber0_c00.fv2"))); break;
                        case "White Bear": param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/ber/ber0_c01.fv2"))); break;
                        case "All":
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/ber/ber0_c00.fv2")));
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/ber/ber0_c01.fv2")));
                            break;
                    }

                    return param;
                },
            });
            
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppBuddyDog2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,

                Presets = new List<string>
                {
                    "buddy_dog2_00",
                    "buddy_dog2_01",
                    "buddy_dog2_02",
                    "buddy_dog2_03",
                    "buddy_dog2_04",
                },

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppBuddyDog2Parameter>();
                    
                    
                    switch (preset)
                    {
                        case "buddy_dog2_00": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/ddg/ddg0_main0_def_v00.parts")); break;
                        case "buddy_dog2_01": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/ddg/ddg0_main4_def_v00.parts")); break;
                        case "buddy_dog2_02": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/ddg/ddg0_main1_def_v00.parts")); break;
                        case "buddy_dog2_03": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/ddg/ddg0_main3_def_v00.parts")); break;
                        case "buddy_dog2_04": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/ddg/ddg0_main2_def_v00.parts")); break;
                    }

                    param.motionGraphFile = FilePtr.Empty;
                    param.mtarFile = FilePtr.Empty;
                    param.extensionMtarFile = FilePtr.Empty;

                    return param;
                },
            });
            
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppBuddyPuppy", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,

                Presets = new List<string>
                {
                    "ddg1_v00_c00_low",
                    "ddg1_v01_c00_low",
                    "All"
                },

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppBuddyPuppyParameter>();
                    
                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/ddg/ddg0_main0_def_v00.parts"));
                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/buddypuppy/BuddyPuppy_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/buddypuppy/BuddyPuppy_layers.mtar"));
                    //param.vfxFiles.Insert(null, new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrwepref01_s5MG.vfx"))); Empty
                    switch(preset)
                    {
                        case "ddg1_v00_c00_low": param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/ddg/ddg1_v01_c00.fv2"))); break;
                        case "ddg1_v01_c00_low": param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/ddg/ddg1_v02_c00.fv2"))); break;
                        case "All": 
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/ddg/ddg1_v01_c00.fv2")));
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/ddg/ddg1_v02_c00.fv2")));
                            break;
                    }

                   
                    

                    return param;
                },
            });
            
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppBuddyQuiet2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,
                
                Presets = new List<string>
                {
                    "Naked", 
                    "Naked (Blood)", 
                    "Naked (Silver Q)", 
                    "Naked (Gold Q)", 
                    "Sniper Wolf", 
                    "Gray XOF"
                },
                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppBuddyQuiet2Parameter>();
                        
                    switch (preset)
                    {
                        case "Naked": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_def_v00.parts"));break;
                        case "Naked (Blood)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_bld_v00.parts"));break;
                        case "Naked (Silver Q)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_slv_v00.parts"));break;
                        case "Naked (Gold Q)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_gld_v00.parts"));break;
                        case "Sniper Wolf": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui4_main0_def_v00.parts"));break;
                        case "Gray XOF": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui5_main0_def_v00.parts"));break;
                    }
                    param.vfxFiles.Insert("Blood0", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld01_s1LG.vfx")));
                    param.vfxFiles.Insert("Blood1", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld03_s1LG.vfx")));
                    param.vfxFiles.Insert("Blood2", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld06_s1.vfx")));
                    param.vfxFiles.Insert("SightLight", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrwepref01_s5MG.vfx")));
                    param.vfxFiles.Insert("EyeFlare", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrlgtquieye_m1.vfx")));
                    param.vfxFiles.Insert("Warp", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuwrp01_s1.vfx")));
                    param.vfxFiles.Insert("LandingSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquignddwn01_m1.vfx")));
                    param.vfxFiles.Insert("SprintSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquifotsmk02_m1.vfx")));
                    param.vfxFiles.Insert("SlidingSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquifotsmk03_s1.vfx")));
                    param.vfxFiles.Insert("HaloSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquidnwgnd01_m2.vfx")));
                    param.vfxFiles.Insert("WaterPillar", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquifotwtr01_m1.vfx")));
                    param.vfxFiles.Insert("DamageFirefly", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbldwmu01_s1.vfx")));
                    param.vfxFiles.Insert("Dead", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbldwmu02_s1.vfx")));

                    return param;
                },
            });
            
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppBossQuiet2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,
                
                Presets = new List<string> 
                { 
                    "Quiet",
                    "Female Skull",
                    "Light Quiet",
                },
                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppBossQuiet2Parameter>();
                    
                    param.vfxFiles.Insert("SightLight", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrwepref01_s5MG.vfx")));
                    param.vfxFiles.Insert("EyeFlare", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrlgtquieye_m1.vfx")));
                    param.vfxFiles.Insert("LandingSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuatk01_m1.vfx")));
                    param.vfxFiles.Insert("WarpStart", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuwrp01_s1.vfx")));
                    param.vfxFiles.Insert("SprintSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquifotsmk02_m1.vfx")));
                    param.vfxFiles.Insert("Recover", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrrbw01_s5.vfx")));
                    param.vfxFiles.Insert("DamageFirefly", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbldwmu01_s1.vfx")));
                    param.vfxFiles.Insert("WarpEnd", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuwrp02_s1.vfx")));
                    param.vfxFiles.Insert("Dead", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbldwmu02_s1.vfx")));
                    param.vfxFiles.Insert("BulletLine", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/weapon/fx_tpp_wepbltblr01_s0LG.vfx")));
                    param.vfxFiles.Insert("JumpStart", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquiwrp01_s1.vfx")));
                    param.vfxFiles.Insert("SprintWater", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquifotwtr01_m1.vfx")));
                  




                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/bossquiet2/BossQuiet2_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/bossquiet2/BossQuiet2_layers.mtar"));
                    param.extensionMtarFile = FilePtr.Empty;


                    switch (preset)
                    {
                        case "Quiet":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_def_v00.parts"));
                            param.vfxFiles.Insert("DrippedBlood", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_blddcl00_s1LG.vfx")));
                            param.vfxFiles.Insert("BloodS", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld01_s1LG.vfx")));
                            param.vfxFiles.Insert("BloodL", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld03_s1LG.vfx")));
                            param.vfxFiles.Insert("WeaponGenerate", FilePtr.Empty);
                            param.vfxFiles.Insert("BloodSplash", FilePtr.Empty);
                            param.vfxFiles.Insert("MacheteCounterHit", FilePtr.Empty);
                            break;
                        case "Female Skull":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/wmu/wmu1_main0_def_v00.parts"));
                            param.vfxFiles.Insert("DrippedBlood", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_blddclwmu02_s1.vfx")));
                            param.vfxFiles.Insert("BloodS", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbldwmu01_s1.vfx")));
                            param.vfxFiles.Insert("BloodL", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbldwmu04_s2.vfx")));
                            param.vfxFiles.Insert("WeaponGenerate", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuwep01_s1.vfx")));
                            param.vfxFiles.Insert("BloodSplash", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_blddclwmu01_s1.vfx")));
                            param.vfxFiles.Insert("MacheteCounterHit", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuatk06_s2.vfx")));
                            break;
                        case "Light Quiet":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_def_v00.parts"));
                            param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/bossquiet2/LightQuiet_layers.mog"));
                            param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/bossquiet2/LightQuiet_layers.mtar"));
                            param.vfxFiles.Clear();
                            param.vfxFiles.Insert("BulletLine", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/weapon/fx_tpp_wepbltblr01_s0LG.vfx")));
                            param.vfxFiles.Insert("SightLight", FilePtr.Empty);
                            param.vfxFiles.Insert("EyeFlare", FilePtr.Empty);
                            param.vfxFiles.Insert("LandingSmoke", FilePtr.Empty);
                            param.vfxFiles.Insert("WarpStart", FilePtr.Empty);
                            param.vfxFiles.Insert("SprintSmoke", FilePtr.Empty);
                            param.vfxFiles.Insert("Recover", FilePtr.Empty);
                            param.vfxFiles.Insert("DamageFirefly", FilePtr.Empty);
                            param.vfxFiles.Insert("WarpEnd", FilePtr.Empty);
                            param.vfxFiles.Insert("Dead", FilePtr.Empty);
                            param.vfxFiles.Insert("JumpStart", FilePtr.Empty);
                            param.vfxFiles.Insert("SprintWater", FilePtr.Empty);
                            param.vfxFiles.Insert("DrippedBlood", FilePtr.Empty);
                            param.vfxFiles.Insert("BloodS", FilePtr.Empty);
                            param.vfxFiles.Insert("BloodL", FilePtr.Empty);
                            param.vfxFiles.Insert("WeaponGenerate", FilePtr.Empty);
                            param.vfxFiles.Insert("BloodSplash", FilePtr.Empty);
                            param.vfxFiles.Insert("MacheteCounterHit", FilePtr.Empty);
                            break;
                    }

                    return param;
                },
            });

            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppCodeTalker2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,
                        
                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppHostage2Parameter>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/cdt/cdt0_main0_def_v00.parts"));
                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/hostage2/Hostage2_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/hostage2/Hostage2_layers_no_stand.mtar"));
                    param.extensionMtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/codetalker2/CodeTalker2_layers.mtar"));

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppCorpse", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 6,
                realizedCount = 6,
                Presets = new List<string>
                {
                    "Soviet", "PF", "XOF",
                    "Fatigue - Drab (Male)",
                    "Fatigue - Drab (Female)",
                    "Fatigue - Tiger (Male)",
                    "Fatigue - Tiger (Female)",
                    "Sneaking Suit (Male)",
                    "Sneaking Suit (Female)",
                    "Battle Dress (Male)",
                    "Battle Dress (Female)"
                },

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppCorpseParameter>();

                    switch (preset)
                    {
                        case "Soviet":param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/svs/svs0_main0_def_v00.parts"));break;
                        case "PF":param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/pfs/pfs0_main0_def_v00.parts"));break;
                        case "XOF":param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/wss/wss4_main0_def_v00.parts"));break;
                        case "Fatigue - Drab (Male)":param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds3_main0_def_v00.parts"));break;
                        case "Fatigue - Drab (Female)":param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds8_main0_def_v00.parts"));break;
                        case "Fatigue - Tiger (Male)":param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds5_enem0_def_v00.parts"));break;
                        case "Fatigue - Tiger (Female)":param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds6_enef0_def_v00.parts"));break;
                        case "Sneaking Suit (Male)":param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna4_enem0_def_v00.parts"));break;
                        case "Sneaking Suit (Female)":param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna4_enef0_def_v00.parts"));break;
                        case "Battle Dress (Male)":param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna5_enem0_def_v00.parts"));break;
                        case "Battle Dress (Female)":param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna5_enef0_def_v00.parts"));break;
                    }

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppCritterBird", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 10,
                realizedCount = 4,

                Presets = new List<string>
                {
                    "Raven", "mbd0_rvn0_v00", "mbd0_hnb0_v00",
                    "All",
                },

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppBirdParameter2>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/rvn/rvn0_main0_def.parts"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/raven/TppRaven_layers.mtar"));

                    switch(preset)
                    {
                        case "Raven":param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/rvn/rvn0_main0_def.parts"));break;
                        case "Hornbill":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/mbd/mbd0_main0_def.parts"));
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/mbd/mbd0_hnb0_v00.fv2"))); 
                            break;
                        case "All":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/mbd/mbd0_main0_def.parts"));
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/mbd/mbd0_rvn0_v00.fv2")));
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/mbd/mbd0_hnb0_v00.fv2")));
                            break;
                    }

                    param.vfxFiles.Insert("Dead", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbrdwng01_s1.vfx")));

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppEagle", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 6,
                realizedCount = 6,

                Presets = new List<string>
                {
                    "Vulture, variant 0", "Vulture, variant 1", "mbd1_mte0_v00",
                    "All",
                },

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppBirdParameter2>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/mbd/mbd1_main0_def_v00.parts"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/eagle/Eagle_layers.mtar"));

                    switch (preset)
                    {
                        case "mbd1_vlt0_v00": param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/mbd/mbd1_vlt0_v00.fv2"))); break;
                        case "mbd1_vlt1_v00": param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/mbd/mbd1_vlt1_v00.fv2"))); break;
                        case "mbd1_mte0_v00": param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/mbd/mbd1_mte0_v00.fv2"))); break;
                        case "All":
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/mbd/mbd1_vlt0_v00.fv2")));
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/mbd/mbd1_vlt1_v00.fv2")));
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/mbd/mbd1_mte0_v00.fv2")));
                            break;
                    }

                    param.vfxFiles.Insert("Dead", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbrdwng01_s1.vfx")));

                    return param;
                },
            });

            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppEnemyHeli", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,

                
                Presets = new List<string>
                {
                    "Internal",
                    "without internal"
                },
                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppHeli2Parameter>();

                    param.partsFiles.Insert("Main", new FilePtr(new Path("/Assets/tpp/parts/mecha/sbh/sbh0_main0_ene_v00.parts")));
                    param.partsFiles.Insert("Rocket", new FilePtr(new Path("/Assets/tpp/parts/mecha/uth/uth0_ammo1_def.parts")));

                    switch (preset)
                    {
                        case "Internal":
                            param.fmdlFiles.Insert("Internal", new FilePtr(new Path("/Assets/tpp/mecha/sbh/Scenes/sbh0_intr0_ene.fmdl")));
                            break;
                        case "without internal":
                            break;
                    }

                    param.fcnpFiles.Insert("Main", new FilePtr(new Path("/Assets/tpp/mecha/sbh/Scenes/sbh0_main0_ene.fcnp")));

                    param.vfxFiles.Insert("Downwash", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchuthdnwblr04_s5MG.vfx")));
                    param.vfxFiles.Insert("Explosion", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/explosion/fx_tpp_expmch03_m2.vfx")));
                    param.vfxFiles.Insert("DownwashWater", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchuthdnwblr01d_s5MG.vfx")));
                    param.vfxFiles.Insert("SearchLight", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrmchsrclgt01_m5MG.vfx")));
                    param.vfxFiles.Insert("LauncherMuzzleFlash", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/muzzle/fx_tpp_mzfrpg01_s0MG.vfx")));
                    param.vfxFiles.Insert("LauncherBackFire", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/muzzle/fx_tpp_mzfbkfrpg01_s0MG.vfx")));
                    param.vfxFiles.Insert("LensFlare", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrmchsrclgt01flr_m5.vfx")));

                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/heli/east/TppHeliEast_layers.mtar"));

                    

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppEspionageRadioSystem", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 50,
                realizedCount = 0,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.Radio.TppEspionageRadioSystemParameter>();
                   
                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppGoat", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 12,
                realizedCount = 6,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppAnimalParameter>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/kkl/kkl0_main0_def_v00.parts"));
                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/goat/Goat_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/goat/Goat_layers.mtar"));

                    param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/kkl/kkl_v00.fv2")));

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppHeli2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppHeli2Parameter>();

                    param.partsFiles.Insert("Main", new FilePtr(new Path("/Assets/tpp/parts/mecha/uth/uth0_main0_def.parts")));
                    param.partsFiles.Insert("Missile", new FilePtr(new Path("/Assets/tpp/parts/mecha/uth/uth0_ammo0_def.parts")));
                    param.partsFiles.Insert("Rocket", new FilePtr(new Path("/Assets/tpp/parts/mecha/uth/uth0_ammo1_def.parts")));

                    param.fmdlFiles.Insert("PilotL", new FilePtr(new Path("/Assets/tpp/chara/dds/Scenes/dds9_main0_v00_sta.fmdl")));
                    param.fmdlFiles.Insert("PilotR", new FilePtr(new Path("/Assets/tpp/chara/dds/Scenes/dds9_main0_v00_sta.fmdl")));
                    param.fmdlFiles.Insert("GunArmL", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_arms0_def.fmdl")));
                    param.fmdlFiles.Insert("GunArmR", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_arms1_def.fmdl")));
                    param.fmdlFiles.Insert("GunL", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_mgun0_def.fmdl")));
                    param.fmdlFiles.Insert("GunR", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_mgun0_def.fmdl")));
                    param.fmdlFiles.Insert("Shield", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_shld0_def.fmdl")));
                    param.fmdlFiles.Insert("ExtraWeapon", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_wepn0_def.fmdl")));
                    param.fmdlFiles.Insert("MissileLauncherLL", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_miss0_def.fmdl")));
                    param.fmdlFiles.Insert("MissileLauncherLR", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_miss0_def.fmdl")));
                    param.fmdlFiles.Insert("MissileLauncherRL", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_miss0_def.fmdl")));
                    param.fmdlFiles.Insert("MissileLauncherRR", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_miss0_def.fmdl")));
                    param.fmdlFiles.Insert("RocketLauncherLL", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_rckt0_def.fmdl")));
                    param.fmdlFiles.Insert("RocketLauncherLR", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_rckt0_def.fmdl")));
                    param.fmdlFiles.Insert("RocketLauncherRL", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_rckt0_def.fmdl")));
                    param.fmdlFiles.Insert("RocketLauncherRR", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_rckt0_def.fmdl")));
                    param.fmdlFiles.Insert("Logo", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_logo1_def.fmdl")));
                    param.fmdlFiles.Insert("Glass0", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_glas0_def.fmdl")));
                    param.fmdlFiles.Insert("Glass1", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_glas1_def.fmdl")));
                    param.fmdlFiles.Insert("Glass2", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_glas2_def.fmdl")));
                    param.fmdlFiles.Insert("Glass3", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_glas3_def.fmdl")));
                    param.fmdlFiles.Insert("Glass4", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_glas4_def.fmdl")));
                    param.fmdlFiles.Insert("Glass5", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_glas5_def.fmdl")));

                    param.fcnpFiles.Insert("Main", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_main0_def.fcnp")));
                    param.fcnpFiles.Insert("GunArmL", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_arms0_def.fcnp")));
                    param.fcnpFiles.Insert("GunArmR", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_arms1_def.fcnp")));
                    param.fcnpFiles.Insert("ExtraWeapon", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_wepn0_def.fcnp")));
                    param.fcnpFiles.Insert("Gun", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_mgun0_def.fcnp")));
                    param.fcnpFiles.Insert("MissileLauncher", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_miss0_def.fcnp")));
                    param.fcnpFiles.Insert("RocketLauncher", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_rckt0_def.fcnp")));

                    param.gsklFiles.Insert("GunArmL", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_arms0_def.gskl")));
                    param.gsklFiles.Insert("GunArmR", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_arms1_def.gskl")));
                    param.gsklFiles.Insert("GunL", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_mgun0_def.gskl")));
                    param.gsklFiles.Insert("GunR", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_mgun0_def.gskl")));
                    param.gsklFiles.Insert("ExtraWeapon", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_wepn0_def.gskl")));
                    param.gsklFiles.Insert("MissileLauncherLL", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_miss0_def.gskl")));
                    param.gsklFiles.Insert("MissileLauncherLR", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_miss0_def.gskl")));
                    param.gsklFiles.Insert("MissileLauncherRL", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_miss0_def.gskl")));
                    param.gsklFiles.Insert("MissileLauncherRR", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_miss0_def.gskl")));
                    param.gsklFiles.Insert("RocketLauncherLL", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_rckt0_def.gskl")));
                    param.gsklFiles.Insert("RocketLauncherLR", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_rckt0_def.gskl")));
                    param.gsklFiles.Insert("RocketLauncherRL", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_rckt0_def.gskl")));
                    param.gsklFiles.Insert("RocketLauncherRR", new FilePtr(new Path("/Assets/tpp/mecha/uth/Scenes/uth0_rckt0_def.gskl")));

                    param.vfxFiles.Insert("Downwash", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchuthdnwblr04_s5MG.vfx")));
                    param.vfxFiles.Insert("Explosion", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/explosion/fx_tpp_expmch03_m2.vfx")));
                    param.vfxFiles.Insert("MuzzleFlash", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/muzzle/fx_tpp_mzfgg01_s0FG.vfx")));
                    param.vfxFiles.Insert("DownwashWater", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchuthdnwblr01d_s5MG.vfx")));
                    param.vfxFiles.Insert("LauncherMuzzleFlash", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/muzzle/fx_tpp_mzfrpg01_s0MG.vfx")));
                    param.vfxFiles.Insert("LauncherBackFire", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/muzzle/fx_tpp_mzfbkfrpg01_s0MG.vfx")));
                    param.vfxFiles.Insert("Flare", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/smoke/fx_tpp_smkflr01_m1.vfx")));
                    param.vfxFiles.Insert("SearchLight", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrmchsrclgt01_m5MG.vfx")));
                    param.vfxFiles.Insert("BarrelHeat", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchuthblh00_s3.vfx")));
                    param.vfxFiles.Insert("BarrelHeatSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchnadblhsmk00_s1.vfx")));
                    param.vfxFiles.Insert("LensFlare", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrmchsrclgt01flr_m5.vfx")));

                    param.fovaFiles.Insert("Default", new FilePtr(new Path("/Assets/tpp/fova/mecha/uth/uth_v02_fv2.fv2")));

                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/heli/west/TppHeliWest_layers.mtar"));



                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppHorse2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,

                Presets = new List<string>
                {
                    "buddy_horse2_00",
                    "buddy_horse2_02_0",
                    "buddy_horse2_02_1",
                    "buddy_horse2_02_2",
                    "buddy_horse2_03",
                    "buddy_horse2_04",
                    "buddy_horse2_05",
                },

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppHorse2Parameter>();
                    switch (preset)
                    {
                        case "buddy_horse2_00": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/hrs/hrs0_main0_def_v00.parts")); break;
                        case "buddy_horse2_02_0": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/hrs/hrs2_main0_def_v00.parts")); break;
                        case "buddy_horse2_02_1": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/hrs/hrs2_main1_def_v00.parts")); break;
                        case "buddy_horse2_02_2": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/hrs/hrs2_main2_def_v00.parts")); break;
                        case "buddy_horse2_03": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/hrs/hrs3_main0_def_v00.parts")); break;
                        case "buddy_horse2_04": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/hrs/hrs4_main0_def_v00.parts")); break;
                        case "buddy_horse2_05": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/hrs/hrs5_main1_def_v00.parts")); break;

                    }
                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppHostage2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 4,
                realizedCount = 4,


                Presets = new List<string>
                {
                    "Soviet Prisoner (Male)",
                    "Soviet Prisoner (Female)",
                    "Africa Prisoner (Male)",
                    "Africa Prisoner (Female)",
                    "DD Prisoner"
                },
                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppHostage2Parameter>();

                    switch (preset)
                    {
                        case "Soviet Prisoner (Male)":param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs2_main0_def_v00.parts"));break;
                        case "Soviet Prisoner (Female)":param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs3_main0_def_v00.parts"));break;
                        case "Africa Prisoner (Male)":param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs5_main0_def_v00.parts"));break;
                        case "Africa Prisoner (Female)":param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs6_main0_def_v00.parts"));break;
                        case "DD Prisoner":param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/pdd5_main0_def_v00.parts"));break;

                    }
                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/hostage2/Hostage2_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/hostage2/Hostage2_layers.mtar"));
                    param.extensionMtarFile = FilePtr.Empty; // Empty as per XML

                    param.vfxFiles.Insert("Blood0", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld01_s1LG.vfx")));
                    param.vfxFiles.Insert("Blood1", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld03_s1LG.vfx")));
                    param.vfxFiles.Insert("Blood2", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld06_s1.vfx")));

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppHostageKaz", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppHostage2Parameter>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/kaz/kaz2_main0_def_v00.parts"));
                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/hostage2/Hostage2_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/hostage2/Hostage2_layers_no_stand.mtar"));
                    param.extensionMtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/hostagekaz/HostageKaz_layers.mtar"));

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppHostageUnique", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 4,
                realizedCount = 4,


                Presets = new List<string>
                {
                    "Soviet Prisoner (Male)",
                    "Soviet Prisoner (Female)",
                    "Africa Prisoner (Male)",
                    "Africa Prisoner (Female)",
                    "DD Prisoner"
                },
                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppHostage2Parameter>();

                    switch (preset)
                    {
                        case "Soviet Prisoner (Male)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs2_main0_def_v00.parts")); break;
                        case "Soviet Prisoner (Female)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs3_main0_def_v00.parts")); break;
                        case "Africa Prisoner (Male)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs5_main0_def_v00.parts")); break;
                        case "Africa Prisoner (Female)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs6_main0_def_v00.parts")); break;
                        case "DD Prisoner": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/pdd5_main0_def_v00.parts")); break;

                    }
                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/hostage2/Hostage2_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/hostage2/Hostage2_layers.mtar"));
                    param.extensionMtarFile = FilePtr.Empty; // Empty as per XML

                    param.vfxFiles.Insert("Blood0", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld01_s1LG.vfx")));
                    param.vfxFiles.Insert("Blood1", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld03_s1LG.vfx")));
                    param.vfxFiles.Insert("Blood2", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld06_s1.vfx")));

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppHostageUnique2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 4,
                realizedCount = 4,


                Presets = new List<string>
                {
                    "Soviet Prisoner (Male)",
                    "Soviet Prisoner (Female)",
                    "Africa Prisoner (Male)",
                    "Africa Prisoner (Female)",
                    "DD Prisoner"
                },
                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppHostage2Parameter>();

                    switch (preset)
                    {
                        case "Soviet Prisoner (Male)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs2_main0_def_v00.parts")); break;
                        case "Soviet Prisoner (Female)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs3_main0_def_v00.parts")); break;
                        case "Africa Prisoner (Male)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs5_main0_def_v00.parts")); break;
                        case "Africa Prisoner (Female)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs6_main0_def_v00.parts")); break;
                        case "DD Prisoner": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/pdd5_main0_def_v00.parts")); break;

                    }
                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/hostage2/Hostage2_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/hostage2/Hostage2_layers.mtar"));
                    param.extensionMtarFile = FilePtr.Empty; // Empty as per XML

                    param.vfxFiles.Insert("Blood0", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld01_s1LG.vfx")));
                    param.vfxFiles.Insert("Blood1", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld03_s1LG.vfx")));
                    param.vfxFiles.Insert("Blood2", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld06_s1.vfx")));

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppHuey2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,


                
                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppHostage2Parameter>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/hyu/hyu0_main0_def_v00.parts"));
                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/hostage2/Hostage2_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/hostage2/Hostage2_layers_no_stand.mtar"));
                    param.extensionMtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/huey2/Huey2_layers.mtar"));

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppJackal", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 2,
                realizedCount = 2,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppWolfParameter>();

                    param.partsFile = new FilePtr(new Path("Assets/tpp/parts/chara/jcl/jcl0_main0_def_v00.parts"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/wolf/Wolf_layers.mtar"));
                    param.mogFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/wolf/Wolf_layers.mog"));
                    param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/jcl/jcl0_v00_c00.fv2")));

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppLiquid2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppLiquid2Parameter>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/lqd/lqd0_main0_def_v00.parts"));
                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/liquid2/Liquid2_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/liquid2/Liquid2_layers.mtar"));

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppMantis2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppHostage2Parameter>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/mnt/mnt0_main0_def_v00.parts"));
                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/mantis2/Mantis2_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/mantis2/Mantis2_layers.mtar"));

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppMarker2LocatorSystem", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 60,
                realizedCount = 0,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.MarkerLocator.TppMarker2LocatorSystemParameter>();

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppNubian", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 12,
                realizedCount = 6,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppAnimalParameter>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/nbn/nbn0_main0_def_v00.parts"));
                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/goat/Goat_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/goat/Goat_layers.mtar"));
                    param.partsFile = new FilePtr(new Path("/Assets/tpp/fova/chara/nbn/nbn_v00.fv2"));

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppOcelot2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,

                Presets = new List<string>
                {
                    "Ocelot",
                    "Ocelot Ride"
                },



                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppHostage2Parameter>();

                    switch(preset)
                    {
                        case "Ocelot": 
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/oce/oce0_main0_def_v00.parts"));
                            param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/ocelot2/Ocelot2_layers.mtar"));
                            break;
                        case "Ocelot Ride":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/oce/oce1_main0_def_v00.parts"));
                            param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/ocelot2/Ocelot2_layers_ride.mtar"));
                            break;
                    }

                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/ocelot2/Ocelot2_layers.mog"));



                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppOtherHeli2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 5,
                realizedCount = 5,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppHeli2Parameter>();

                    param.partsFiles.Insert("Main", new FilePtr(new Path("/Assets/tpp/parts/mecha/sbh/sbh0_main0_ene_v00.parts")));
                    param.partsFiles.Insert("Rocket", new FilePtr(new Path("/Assets/tpp/parts/mecha/uth/uth0_ammo1_def.parts")));

                    param.fcnpFiles.Insert("Main", new FilePtr(new Path("/Assets/tpp/mecha/sbh/Scenes/sbh0_main0_ene.fcnp")));

                    param.vfxFiles.Insert("Downwash", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchuthdnwblr04_s5MG.vfx")));
                    param.vfxFiles.Insert("Explosion", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/explosion/fx_tpp_expmch03_m2.vfx")));
                    param.vfxFiles.Insert("DownwashWater", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchuthdnwblr01d_s5MG.vfx")));
                    param.vfxFiles.Insert("SearchLight", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrmchsrclgt01_m5MG.vfx")));
                    param.vfxFiles.Insert("LauncherMuzzleFlash", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/muzzle/fx_tpp_mzfrpg01_s0MG.vfx")));
                    param.vfxFiles.Insert("LauncherBackFire", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/muzzle/fx_tpp_mzfbkfrpg01_s0MG.vfx")));

                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/heli/east/TppHeliEast_layers.mtar"));



                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppParasite2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 4,
                realizedCount = 4,

                Presets = new List<string>
                {

                    "Parasite Fog",
                    "Parasite Metal",
                },

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppParasite2Parameter>();

                    switch (preset)
                    {
                        case "Parasite Fog":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/wmu/wmu0_main0_def_v00.parts"));
                            param.partsFiles.Insert("Main", new FilePtr(new Path("/Assets/tpp/parts/chara/wmu/wmu0_main0_def_v00.parts")));


                            break;
                        case "Parasite Metal":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/wmu/wmu3_main0_def_v00.partss"));
                            param.partsFiles.Insert("Main", new FilePtr(new Path("/Assets/tpp/parts/chara/wmu/wmu3_main0_def_v00.parts")));

                            param.vfxFiles.Insert("FovaHard", new FilePtr(new Path("/Assets/tpp/fova/chara/wmu/wmu3_v00.fv2")));
                            param.vfxFiles.Insert("FovaNormal", new FilePtr(new Path("/Assets/tpp/fova/chara/wmu/wmu3_v01.fv2")));
                            break;
                    }

                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/parasite/Parasite2_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/parasite/Parasite2_layers.mtar"));

                    param.partsFiles.Insert("AssaultRifle", new FilePtr(new Path("/Assets/tpp/parts/weapon/assemble/asr/ar02_main0_aw0_v00.parts")));
                    param.partsFiles.Insert("SubmachineGun", new FilePtr(new Path("/Assets/tpp/parts/weapon/assemble/smg/sm02_main1_aw0_v00.parts")));
                    param.partsFiles.Insert("Shotgun", new FilePtr(new Path("/Assets/tpp/parts/weapon/assemble/shg/sg03_main1_aw0_v00.parts")));



                    param.vfxFiles.Insert("Blood", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbldwmu01_s1.vfx")));
                    param.vfxFiles.Insert("LandingSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuatk01_m1.vfx")));
                    param.vfxFiles.Insert("SprintSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrmntfotsmk01_s3.vfx")));
                    param.vfxFiles.Insert("WarpStart", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuwrp01_s1.vfx")));
                    param.vfxFiles.Insert("WarpEnd", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuwrp02_s1.vfx")));
                    param.vfxFiles.Insert("BloodBig", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbldwmu04_s2.vfx")));
                    param.vfxFiles.Insert("DEBUG0", new FilePtr(new Path("/Assets/tpp/parts/weapon/assemble/asr/ar02_main0_aw0_v00.parts")));
                    param.vfxFiles.Insert("DEBUG1", new FilePtr(new Path("/Assets/tpp/parts/weapon/bld/bl03_main0_def.parts")));
                    param.vfxFiles.Insert("WallTrail", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuatk04_m1.vfx")));
                    param.vfxFiles.Insert("WallBreak", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuatk05_m1.vfx")));
                    param.vfxFiles.Insert("GeomRock0", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock0_sta.geom")));
                    param.vfxFiles.Insert("GeomRock1", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock1_sta.geom")));
                    param.vfxFiles.Insert("GeomRock2", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock2_sta.geom")));
                    param.vfxFiles.Insert("GeomRock3", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock3_sta.geom")));
                    param.vfxFiles.Insert("GeomRock4", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock4_sta.geom")));
                    param.vfxFiles.Insert("GeomRock5", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock5_sta.geom")));
                    param.vfxFiles.Insert("GeomRock6", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock6_sta.geom")));
                    param.vfxFiles.Insert("GeomRock7", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock7_sta.geom")));
                    param.vfxFiles.Insert("GeomRock8", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock8_sta.geom")));
                    param.vfxFiles.Insert("GeomRock9", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock9_sta.geom")));
                    param.vfxFiles.Insert("WallRicochet", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/ricochet/fx_tpp_rctwmuroc01M_s1.vfx")));
                    param.vfxFiles.Insert("WallGenerate", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmurocspn01_s3.vfx")));
                    param.vfxFiles.Insert("WallRaise", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmurocsmk01_s3.vfx")));
                    param.vfxFiles.Insert("WeaponGenerate", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuwep01_s1.vfx")));
                    param.vfxFiles.Insert("BloodPool", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_blddclwmu02_s1.vfx")));
                    param.vfxFiles.Insert("BloodSplash", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_blddclwmu01_s1.vfx")));
                    param.vfxFiles.Insert("BodySmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/weapon/fx_tpp_wepsmkbmb05_s5.vfx")));
                    param.vfxFiles.Insert("MacheteCounterHit", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuatk06_s2.vfx")));
                    param.vfxFiles.Insert("WallExplosion", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/weapon/fx_tpp_wepgreexp01_s2LG.vfx")));
                    param.vfxFiles.Insert("WallGenerateTrail", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuatk04_m1.vfx")));

                    param.fmdlFiles.Insert("Rock0", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock0_sta.fmdl")));
                    param.fmdlFiles.Insert("Rock1", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock1_sta.fmdl")));
                    param.fmdlFiles.Insert("Rock2", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock2_sta.fmdl")));
                    param.fmdlFiles.Insert("Rock3", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock3_sta.fmdl")));
                    param.fmdlFiles.Insert("Rock4", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock4_sta.fmdl")));
                    param.fmdlFiles.Insert("Rock5", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock5_sta.fmdl")));
                    param.fmdlFiles.Insert("Rock6", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock6_sta.fmdl")));
                    param.fmdlFiles.Insert("Rock7", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock7_sta.fmdl")));
                    param.fmdlFiles.Insert("Rock8", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock8_sta.fmdl")));
                    param.fmdlFiles.Insert("Rock9", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock9_sta.fmdl")));


                    param.geomFiles.Insert("Rock0", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock0_sta.geom")));
                    param.geomFiles.Insert("Rock1", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock1_sta.geom")));
                    param.geomFiles.Insert("Rock2", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock2_sta.geom")));
                    param.geomFiles.Insert("Rock3", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock3_sta.geom")));
                    param.geomFiles.Insert("Rock4", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock4_sta.geom")));
                    param.geomFiles.Insert("Rock5", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock5_sta.geom")));
                    param.geomFiles.Insert("Rock6", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock6_sta.geom")));
                    param.geomFiles.Insert("Rock7", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock7_sta.geom")));
                    param.geomFiles.Insert("Rock8", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock8_sta.geom")));
                    param.geomFiles.Insert("Rock9", new FilePtr(new Path("/Assets/tpp/chara/wmu/Scenes/wmue_rock9_sta.geom")));







                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppPlayer2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,


                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppPlayer2Parameter>();

                    param.vfxFiles.Insert("Blood", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld01_s1LG.vfx")));

                    param.lifeMax = 6000;
                    param.lifeRecoveryPerSecond = 1000;
                    param.respawnTime = 10;
                    param.clipCount = 30;
                    param.fireInterval = 0.1001f;
                    param.lifeRecoveryCooldownTimer = 2;

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppPlayerHorse2forVr", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppHorse2forVrParameter>();


                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/hrs/hrs0_main0_def_v00.parts"));
                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/volginRide2/TppHorse2forVr_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/volginRide2/TppHorse2forVr_layers.mtar"));

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppRat", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 6,
                realizedCount = 6,

                Presets = new List<string>
                {

                    "Rat",
                    "Hedgehog, variant 0",
                    "Hedgehog, variant 1",
                    "Apeke",
                    "All"
                },

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppRat2Parameter>();


                    
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/rat/TppRat_layers.mtar"));

                    switch(preset)
                    {
                        case "Rat": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/rat/rat2_main0_def_v00.parts"));break;
                        case "Hedgehog, variant 0": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/hgh/hgh0_main0_def_v00.parts")); break;
                        case "Hedgehog, variant 1": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/hgh/hgh1_main0_def_v00.parts")); break;
                        case "Apeke": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/apk/apk0_main0_def_v00.parts")); break;
                        case "All":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/san/san0_main0_def_v00.parts"));
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/san/san0_rat2_v00_c00.fv2")));
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/san/san0_hgh1_v00_c00.fv2")));
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/san/san0_hgh0_v00_c00.fv2")));
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/san/san0_apk0_v00_c00.fv2")));
                            break;
                    }

                    


                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppSahalen2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,

                Presets = new List<string>
                {
                    "Sahelan HellBound",
                    "Sahelan Battle",
                },

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppSahelan2Parameter>();


                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/mecha/mgs/mgs0_main0_def.parts"));
                    param.vfxFiles.Insert("SwordStick", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchmgsatk02_s5.vfx")));
                    param.vfxFiles.Insert("SwordSwing", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchmgsatk01_s5.vfx")));
                    param.vfxFiles.Insert("BlastMissile", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/weapon/fx_tpp_wepexprpg01_s2LG.vfx")));
                    param.vfxFiles.Insert("DamageSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchmgsdmgsmk01_s5.vfx")));
                    param.vfxFiles.Insert("BrokenSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/smoke/fx_tpp_smkmchbrk02_m2LG.vfx")));
                    param.vfxFiles.Insert("BreakExplosion", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/explosion/fx_tpp_expmch02_m1LG.vfx")));
                    param.vfxFiles.Insert("FireFlame", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchatkfir01_m2.vfx")));
                    param.vfxFiles.Insert("SwordPreEffect", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchmgsatk03_s5.vfx")));
                    param.vfxFiles.Insert("MissileMuzzle", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchmgsmslmzf01_s1.vfx")));
                    param.vfxFiles.Insert("TestRailGunReady", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchmgmstncrg01_s3.vfx")));
                    param.vfxFiles.Insert("MantisEffect", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chamntsmk01_s0LD.vfx")));
                    param.vfxFiles.Insert("SwordSwingNew", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchmgsatk01c_s5.vfx")));
                    param.vfxFiles.Insert("RailGunFire", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/weapon/fx_tpp_wepbltrgn01_m1.vfx")));
                    param.vfxFiles.Insert("Search", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchmgssrc01_m5.vfx")));
                    param.vfxFiles.Insert("DeadExplosion", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/explosion/fx_tpp_expmch03_m2.vfx")));


                    switch (preset)
                    {
                        case "Sahelan HellBound":
                            param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/sahelan2/TppSahelan2for1st_layers.mog"));
                            param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/sahelan2/TppSahelan2for1st_layers.mtar"));
                            param.vfxFiles.Insert("PileBunkerStick", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchmgsatk01s_s5.vfx")));
                            param.vfxFiles.Insert("DeadFloorSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchmgsfotsmk03b_m2.vfx")));
                            param.vfxFiles.Insert("BlastSearchMissile", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/explosion/fx_tpp_expgrnd01_s2LG.vfx")));

                            break;
                        case "Sahelan Battle":
                            param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/sahelan2/TppSahelan2_layers.mog"));
                            param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/sahelan2/TppSahelan2_layers.mtar"));
                            param.vfxFiles.Insert("ActiveBlade", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchmgswep03_m2.vfx")));
                            param.vfxFiles.Insert("BladeHit", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/mecha/fx_tpp_mchmgswep06_m2.vfx")));
                            param.vfxFiles.Insert("GroundFire", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/fire/fx_tpp_firvol04b_s1.vfx")));
                            param.vfxFiles.Insert("MantisEffectSlow", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrmntrip02_s5.vfx")));
                            param.vfxFiles.Insert("MushiarashiSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/dust/fx_tpp_dstsndstmviw01s_m1.vfx")));

                            break;
                    }

                    


                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppSecurityCamera2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 15,
                realizedCount = 6,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppSecurityCamera2Parameter>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/mecha/ctv/ctv0_main0_def_v00.parts"));
                    
                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppSkullFace2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppHostage2Parameter>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/wsp/wsp0_main0_def_v00.parts"));
                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/skullface2/Skullface2_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/skullface2/SkullFace2_layers.mtar"));
                    param.extensionMtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/skullface2/SkullFace2_10150.mtar")); //10150: No idea 

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppSoldier2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 160,
                realizedCount = 12,
                
                Presets = new List<string>
                {
                    "Soviet", "PF", "XOF",
                    "Fatigue - Drab (Male)", 
                    "Fatigue - Drab (Female)",
                    "Fatigue - Tiger (Male)", 
                    "Fatigue - Tiger (Female)",
                    "Sneaking Suit (Male)", 
                    "Sneaking Suit (Female)",
                    "Battle Dress (Male)", 
                    "Battle Dress (Female)"
                },
                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppSoldier2Parameter>();

                    switch (preset)
                    {
                        case "Soviet": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/svs/svs0_main0_def_v00.parts")); break;
                        case "PF": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/pfs/pfs0_main0_def_v00.parts")); break;
                        case "XOF": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/wss/wss4_main0_def_v00.parts")); break;
                        case "Fatigue - Drab (Male)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds3_main0_def_v00.parts")); break;
                        case "Fatigue - Drab (Female)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds8_main0_def_v00.parts")); break;
                        case "Fatigue - Tiger (Male)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds5_enem0_def_v00.parts")); break;
                        case "Fatigue - Tiger (Female)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds6_enef0_def_v00.parts")); break;
                        case "Sneaking Suit (Male)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna4_enem0_def_v00.parts")); break;
                        case "Sneaking Suit (Female)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna4_enef0_def_v00.parts")); break;
                        case "Battle Dress (Male)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna5_enem0_def_v00.parts")); break;
                        case "Battle Dress (Female)": param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna5_enef0_def_v00.parts")); break;
                    }
                    param.vfxFiles.Insert("Blood0", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld01_s1LG.vfx")));
                    param.vfxFiles.Insert("Blood1", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld03_s1LG.vfx")));
                    param.vfxFiles.Insert("Blood2", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld06_s1.vfx")));

                    return param;
                },

            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppStork", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 6,
                realizedCount = 6,

                Presets = new List<string>
                {
                    "Stork, variant 1", "Stork, variant 2", "Stork, variant 3",
                    "All",
                },
                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppBirdParameter2>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/stk/stk0_main0_def_v00.parts"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/stork/Stork_layers.mtar"));

                    switch (preset)
                    {
                        case "Stork, variant 1": param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/stk/stk0_c00.fv2"))); break;
                        case "Stork, variant 2": param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/stk/stk0_c01.fv2"))); break;
                        case "Stork, variant 3": param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/stk/stk0_c02.fv2"))); break;
                        case "All":
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/stk/stk0_c00.fv2")));
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/stk/stk0_c01.fv2")));
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/stk/stk0_c02.fv2")));

                            break;
                    }

                    param.vfxFiles.Insert("Wing", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbrdwng01_s1.vfx")));

                    return param;
                },

            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppVolgin2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppVolgin2Parameter>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/vol/vol0_main0_def_v00.parts"));
                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/volgin2/Volgin2_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/volgin2/Volgin2_layers.mtar"));

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppVolgin2forVr", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppVolgin2forVrParameter>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/vol/vol0_main0_def_v00.parts"));
                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/volginRide/VolginRide_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/volginRide/VolginRide_layers.mtar"));

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppUav", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppUavParameter>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/mecha/uav/uav0_main0_def_v00.parts"));

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppVehicle2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 15,
                realizedCount = 4,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppVehicle2Parameter>();

                    param.SetMaxBodyTypeCount((byte)3);

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppCommonWalkerGear2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 15,
                realizedCount = 4,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppWalkerGear2Parameter>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/mecha/mgm/mgm1_main0_def.parts"));
                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/walkergear2/walkergear2_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/walkergear2/walkergear2_layers.mtar"));
                    param.extensionMtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/walkergear2/walkergear2_attc_layers.mtar"));

                    param.vfxFiles.Insert("TestKey0", FilePtr.Empty);

                    param.extraPartsFiles.Insert("TestKey0", new FilePtr(new Path("/Assets/tpp/parts/mecha/mgm/mgm0_attc0_def.parts")));
                    param.extraPartsFiles.Insert("TestKey1", new FilePtr(new Path("/Assets/tpp/parts/mecha/mgm/mgm0_mgun0_def.parts")));
                    param.extraPartsFiles.Insert("TestKey2", new FilePtr(new Path("/Assets/tpp/parts/mecha/mgm/mgm0_towm0_def_v00.parts")));
                    param.extraPartsFiles.Insert("TestKey3", new FilePtr(new Path("/Assets/tpp/parts/mecha/mgm/mgm0_ammo0_def_v00.parts")));
                    param.extraPartsFiles.Insert("TestKey4", new FilePtr(new Path("/Assets/tpp/parts/mecha/mgm/mgm0_main0_def.parts")));
                    param.extraPartsFiles.Insert("TestKey5", new FilePtr(new Path("/Assets/tpp/parts/mecha/mgm/mgm1_shed0_def.parts")));
                    param.extraPartsFiles.Insert("TestKey6", FilePtr.Empty);



                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppWolf", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 6,
                realizedCount = 6,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppWolfParameter>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/wlf/wlf0_main0_def_v00.parts"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/wolf/Wolf_layers.mtar"));
                    param.mogFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/wolf/Wolf_layers.mog"));

                    return param;
                },
            });
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppZebra", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 12,
                realizedCount = 6,

                Presets = new List<string>
                {
                    "Donkey", "Okapi", "Zebra",
                    "All",
                },

                CreateParameterFunc = (preset) =>
                {


                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppAnimalParameter>();
                    switch (preset)
                    {
                        case "Donkey":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dnk/dnk0_main0_def_v00.parts"));
                            break;
                        case "Okapi":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/okp/okp0_main0_def_v00.parts"));
                            break;
                        case "Zebra":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/zbr/zbr0_main0_def_v00.parts"));
                            break;
                        case "All":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/equ/equ0_main0_def_v00.parts"));
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/equ/equ0_dnk0_v00.fv2")));
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/equ/equ0_okp0_v00.fv2")));
                            param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/equ/equ0_zbr0_v00.fv2")));
                            break;
                    }

                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/zebra/TppZebra_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("Assets/tpp/motion/mtar/zebra/Zebra_layers.mtar"));

                    return param;
                },
            });
        }
    }
}
