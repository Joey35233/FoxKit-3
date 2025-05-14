using System.Collections.Generic;
using Fox;
using Fox.Core;
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
                totalCount = 1,
                realizedCount = 1,

                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppBearParameter>();
                    
                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/ber/ber0_main0_def_v00.parts"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/bear/Bear_layers.mtar"));
                    param.mogFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/bear/Bear_layers.mog"));

                    param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/ber/ber0_c00.fv2")));

                    return param;
                },
            });
            
            Fox.EdGameCore.EdGameCoreModule.RegisterGameObjectEditorInfo("TppBuddyDog2", new Fox.EdGameCore.GameObjectEditorInfo
            {
                groupId = 0,
                totalCount = 1,
                realizedCount = 1,
                
                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppBuddyDog2Parameter>();
                    
                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/ddg/ddg0_main0_def_v00.parts"));

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
                
                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppBuddyPuppyParameter>();
                    
                    param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/ddg/ddg0_main0_def_v00.parts"));
                    param.motionGraphFile = FilePtr.Empty;
                    param.mtarFile = FilePtr.Empty;

                    //param.vfxFiles.Insert(null, new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrwepref01_s5MG.vfx"))); Empty

                    param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/ddg/ddg1_v01_c00.fv2")));
                    param.fovaFiles.Add(new FilePtr(new Path("/Assets/tpp/fova/chara/ddg/ddg1_v02_c00.fv2")));

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
                        case "Naked":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_def_v00.parts"));
                            break;
                        case "Naked (Blood)":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_bld_v00.parts"));
                            break;
                        case "Naked (Silver Q)":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_slv_v00.parts"));
                            break;
                        case "Naked (Gold Q)":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_gld_v00.parts"));
                            break;
                        case "Sniper Wolf":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui4_main0_def_v00.parts"));
                            break;
                        case "Gray XOF":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui5_main0_def_v00.parts"));
                            break;
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
                    "Female Skull"
                },
                CreateParameterFunc = (preset) =>
                {
                    var param = new UnityEngine.GameObject().AddComponent<Tpp.GameCore.TppBossQuiet2Parameter>();
                    
                    switch (preset)
                    {
                        case "Quiet":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/qui/qui0_main0_def_v00.parts"));
                            break;
                        case "Female Skull":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/wmu/wmu1_main0_def_v00.parts"));
                            break;
                    }
                    param.motionGraphFile = new FilePtr(new Path("/Assets/tpp/motion/motion_graph/bossquiet2/BossQuiet2_layers.mog"));
                    param.mtarFile = new FilePtr(new Path("/Assets/tpp/motion/mtar/bossquiet2/BossQuiet2_layers.mtar"));
                    param.extensionMtarFile = FilePtr.Empty;

                    param.vfxFiles.Insert("SightLight", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrwepref01_s5MG.vfx")));
                    param.vfxFiles.Insert("EyeFlare", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrlgtquieye_m1.vfx")));
                    param.vfxFiles.Insert("LandingSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuatk01_m1.vfx")));
                    param.vfxFiles.Insert("WarpStart", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuwrp01_s1.vfx")));
                    param.vfxFiles.Insert("SprintSmoke", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquifotsmk02_m1.vfx")));
                    param.vfxFiles.Insert("DrippedBlood", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_blddcl00_s1LG.vfx")));
                    param.vfxFiles.Insert("Recover", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/flare/fx_tpp_flrrbw01_s5.vfx")));
                    param.vfxFiles.Insert("DamageFirefly", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbldwmu01_s1.vfx")));
                    param.vfxFiles.Insert("BloodS", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld01_s1LG.vfx")));
                    param.vfxFiles.Insert("BloodL", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbld03_s1LG.vfx")));
                    param.vfxFiles.Insert("WarpEnd", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrwmuwrp02_s1.vfx")));
                    param.vfxFiles.Insert("Dead", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/blood/fx_tpp_splbldwmu02_s1.vfx")));
                    param.vfxFiles.Insert("BulletLine", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/weapon/fx_tpp_wepbltblr01_s0LG.vfx")));
                    param.vfxFiles.Insert("WeaponGenerate", FilePtr.Empty); // Empty
                    param.vfxFiles.Insert("BloodSplash", FilePtr.Empty); // Empty
                    param.vfxFiles.Insert("JumpStart", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquiwrp01_s1.vfx")));
                    param.vfxFiles.Insert("SprintWater", new FilePtr(new Path("/Assets/tpp/effect/vfx_data/chara/fx_tpp_chrquifotwtr01_m1.vfx")));
                    param.vfxFiles.Insert("MacheteCounterHit", FilePtr.Empty); // Empty

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
                        case "Soviet Prisoner (Male)":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs2_main0_def_v00.parts"));
                            break;
                        case "Soviet Prisoner (Female)":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs3_main0_def_v00.parts"));
                            break;
                        case "Africa Prisoner (Male)":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs5_main0_def_v00.parts"));
                            break;
                        case "Africa Prisoner (Female)":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/prs6_main0_def_v00.parts"));
                            break;
                        case "DD Prisoner":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/prs/pdd5_main0_def_v00.parts"));
                            break;

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
                        case "Soviet":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/svs/svs0_main0_def_v00.parts"));
                            break;
                        case "PF":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/pfs/pfs0_main0_def_v00.parts"));
                            break;
                        case "XOF":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/wss/wss4_main0_def_v00.parts"));
                            break;
                        case "Fatigue - Drab (Male)":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds3_main0_def_v00.parts"));
                            break;
                        case "Fatigue - Drab (Female)":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds8_main0_def_v00.parts"));
                            break;
                        case "Fatigue - Tiger (Male)":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds5_enem0_def_v00.parts"));
                            break;
                        case "Fatigue - Tiger (Female)":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/dds/dds6_enef0_def_v00.parts"));
                            break;
                        case "Sneaking Suit (Male)":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna4_enem0_def_v00.parts"));
                            break;
                        case "Sneaking Suit (Female)":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna4_enef0_def_v00.parts"));
                            break;
                        case "Battle Dress (Male)":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna5_enem0_def_v00.parts"));
                            break;
                        case "Battle Dress (Female)":
                            param.partsFile = new FilePtr(new Path("/Assets/tpp/parts/chara/sna/sna5_enef0_def_v00.parts"));
                            break;
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
