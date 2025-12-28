using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fox.Anim
{
    public partial class MtarFile
    {
        private static Dictionary<StrCode32, string> StringDictionary = null;
        private static StrCode[] HashList = null;

        private static bool TryResolveHash(StrCode32 hash32, out StrCode search)
        {
            search = StrCode.Empty;
            foreach (var hash in HashList)
            {
                if ((StrCode32)hash == hash32)
                {
                    search = hash;
                    return true;
                }
            }

            return false;
        }
        
        public static unsafe AnimationClip[] Convert(ReadOnlySpan<byte> file)
        {
            if (StringDictionary == null)
            {
                string[] lines = System.IO.File.ReadAllLines("Assets/GameTest/RigTesting/fmdl_dictionary.txt");
                StringDictionary = new Dictionary<StrCode32, string>();
                foreach (var line in lines)
                    StringDictionary.Add(new StrCode32(line), line);
                StringDictionary.Add(new StrCode32("NONE->GLOBAL"), "NONE->GLOBAL");
            }

            if (HashList == null)
            {
                string[] lines = System.IO.File.ReadAllLines("Assets/GameTest/RigTesting/fmdl_hashes.txt");
                HashList = new StrCode[lines.Length + 1];
                for (uint i = 0; i < lines.Length; i++)
                    HashList[i] = HashingBitConverter.ToStrCode(ulong.Parse(lines[i]));
                HashList[lines.Length] = StrCode.Empty;
            }
            
            AnimationClip[] clips = null;
            fixed (byte* fileData = file)
            {
                MtarHeader* mtarHeader = (MtarHeader*)fileData;

                if (mtarHeader->Flags.HasFlag(MtarHeader.MtarFlags.New))
                {
                    clips = new AnimationClip[mtarHeader->FileCount];
                    MtarTableList2* tableList = (MtarTableList2*)(mtarHeader + 1);
                    for (uint i = 0; i < mtarHeader->FileCount; i++)
                    {
                        MtarTableList2* tableEntry = tableList + i;
                        
                        AnimationClip clip = clips[i] = new AnimationClip { name = tableEntry->Path.ToString() };
                        
                        MtarMiniDataNode* nodes = (MtarMiniDataNode*)((byte*)mtarHeader + mtarHeader->CommonInfoOffset);
                        
                        MtarMiniDataNode* skelListNode = nodes->Find(HashingBitConverter.ToStrCode32(999978884));
                        ReadOnlySpan<MotionPointList2> motionPoints = new ReadOnlySpan<MotionPointList2>();
                        if (skelListNode != null)
                        {
                            uint* listData = (uint*)(skelListNode + 1);
                            uint count = *listData;
                            MotionPointList2* list = (MotionPointList2*)(listData + 1);

                            motionPoints = new ReadOnlySpan<MotionPointList2>(list, (int)count);
                        }

                        if (tableEntry->TracksOffset != 0)
                        {
                            byte* tracks = (byte*)mtarHeader + tableEntry->TracksOffset;

                            MtarMiniDataNode* commonTrackHeaderNode = nodes->Find(HashingBitConverter.ToStrCode32(1337830127));
                            TrackHeader* commonTrackHeader = (TrackHeader*)(commonTrackHeaderNode + 1);
                            TrackMiniHeader* miniTrackHeader = (TrackMiniHeader*)tracks;

                            TrackControl.PopulateClip(clip, commonTrackHeader, miniTrackHeader);

                            if (tableEntry->MotionPointTracksOffset != 0)
                            {
                                TrackHeader* motionPointTrackHeader = (TrackHeader*)(tracks + tableEntry->MotionPointTracksOffset);
                            
                                TrackControl.PopulateClip(clip, motionPointTrackHeader, motionPoints);
                            }
                        }
                    }
                }
            }

            return clips;
        }
    }
}