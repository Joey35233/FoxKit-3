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
                            param.vfxFiles.Insert("WeaponGenerate", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("BloodSplash", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("MacheteCounterHit", new FilePtr(new Path("")));
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
                            param.vfxFiles.Insert("SightLight", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("EyeFlare", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("LandingSmoke", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("WarpStart", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("SprintSmoke", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("Recover", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("DamageFirefly", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("WarpEnd", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("Dead", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("JumpStart", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("SprintWater", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("DrippedBlood", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("BloodS", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("BloodL", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("WeaponGenerate", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("BloodSplash", new FilePtr(new Path("")));
                            param.vfxFiles.Insert("MacheteCounterHit", new FilePtr(new Path("")));
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
                    "mbd0_rvn0_v00", "mbd0_hnb0_v00",
                    "All",
                },

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppBirdParameter2>();

                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/rvn/rvn0_main0_def.parts"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/raven/TppRaven_layers.mtar"));

                    switch(preset)
                    {
                        case "mbd0_rvn0_v00": param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/mbd/mbd0_rvn0_v00.fv2"))); break;
                        case "mbd0_hnb0_v00": param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/mbd/mbd0_hnb0_v00.fv2"))); break;
                        case "All":
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
                    "mbd1_vlt0_v00", "mbd1_vlt1_v00", "mbd1_mte0_v00",
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
        }
    }
}
