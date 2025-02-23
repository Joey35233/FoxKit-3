﻿using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using System;
using UnityEngine;

namespace Fox.Tactical
{
    public class TacticalActionFileReader
    {
        private readonly TaskLogger logger = new TaskLogger("ImportNTA");
        private const uint NTA_SIGNATURE = 0x41544E46;
        [Flags]
        private enum Gz_Ground_Attributes : ushort
        {
            Human = 0x1,
            VehicleM = 0x2,
            Vehicle = 0x4,
            HumanHighCost = 0x8,
            HumanSeparate = 0x10,
            HumanCombat = 0x20,
        }
        [Flags]
        private enum Tpp_Ground_Attributes : ushort
        {
            Human = 0x1,
            Vehicle = 0x2,
            Large = 0x4,
            HumanHighCost = 0x8,
            HumanCombat = 0x10,
            Horse = 0x20,
            WalkerGear = 0x40,
            Dog = 0x80,
            Animal = 0x100,
            Event = 0x200,
            Child = 0x400,
        }
        [Flags]
        private enum Tpp_Sky_Attributes : short
        {
            Sky=0x1,
            Divide=0x2,
            Divide2=0x3,
        };
        public void Read(FileStreamReader reader)
        {
            Debug.Assert(reader.ReadUInt32() == NTA_SIGNATURE, "Invalid NTA file.");
            Debug.Assert(reader.ReadUInt16() == 1, "Invalid NTA version.");
            ushort worldCount = reader.ReadUInt16();
            uint worldOffset = reader.ReadUInt32();

            uint seekOffset = worldOffset;

            var emptyHash32 = (StrCode32)StrCode.Empty;

            for (int worldIndex = 0; worldIndex < worldCount; worldIndex++)
            {
                reader.Seek(seekOffset);
                StrCode worldName = reader.ReadStrCode();
                uint actionCount = reader.ReadUInt32();
                uint actionsOffset = reader.ReadUInt32();
                uint actionNameOffset = reader.ReadUInt32();
                uint nextOffset = reader.ReadUInt32();

                reader.Seek(worldOffset + actionsOffset);
                for (int actionIndex = 0; actionIndex < actionCount; actionIndex++)
                {
                    uint rewindPos = (uint)reader.BaseStream.Position;
                    reader.Seek(worldOffset+actionNameOffset+(actionIndex*8));
                    GkTacticalAction tacticalAction = new GameObject(reader.ReadStrCode().ToString()).AddComponent<GkTacticalAction>();
                    tacticalAction.SetTransform(TransformEntity.GetDefault());
                    if(worldName==StrCode.Empty)
                    {
                        tacticalAction.worldName = "";
                    }
                    else
                    {
                        tacticalAction.worldName = worldName.ToString();
                    }
                    tacticalAction.enable = true;
                    tacticalAction.enableInGame = true;
                    reader.Seek(rewindPos);

                    bool bothWays = false;
                    for (int waypointIndex = 0; waypointIndex < 2; waypointIndex++)
                    {
                        tacticalAction.waypoints.Insert(waypointIndex,new GameObject($"GkTacticalActionWaypoint{waypointIndex:0000}").AddComponent<GkTacticalActionWaypoint>());
                        tacticalAction.waypoints[waypointIndex].transform.parent=tacticalAction.gameObject.transform;
                        tacticalAction.waypoints[waypointIndex].position = reader.ReadPositionF();
                        var actionName = reader.ReadStrCode32();
                        if (actionName == emptyHash32 || bothWays==true)
                        {
                            continue;
                        }
                        tacticalAction.edges.Insert(waypointIndex, new GameObject($"GkTacticalActionEdge{waypointIndex:0000}").AddComponent<GkTacticalActionEdge>());
                        tacticalAction.edges[waypointIndex].transform.parent = tacticalAction.gameObject.transform;

                        tacticalAction.edges[waypointIndex].transform.parent = tacticalAction.waypoints[waypointIndex].transform;
                        switch ((uint)actionName.GetHashCode())
                        {
                            case 1277978017: tacticalAction.edges[waypointIndex].actionName = "StepOn"; break;
                            case 1139911476: tacticalAction.edges[waypointIndex].actionName = "StepDown"; break;
                            case 2317903572: tacticalAction.edges[waypointIndex].actionName = "LadderUp"; break;
                            case 3049138984: tacticalAction.edges[waypointIndex].actionName = "LadderDown"; break;
                            case 3451056519:
                                tacticalAction.edges[waypointIndex].actionName = "Door";
                                bothWays = true;
                                break;
                            case 504469101:
                                tacticalAction.edges[waypointIndex].actionName = actionName.ToString();
                                bothWays = true;
                                break;
                            default: tacticalAction.edges[waypointIndex].actionName = actionName.ToString(); break;
                        }
                    }
                    tacticalAction.transform.position = tacticalAction.waypoints[0].position;

                    tacticalAction.waypoints[0].transform.position = tacticalAction.waypoints[0].position;
                    tacticalAction.waypoints[1].transform.position = tacticalAction.waypoints[1].position;

                    tacticalAction.waypoints[0].position = Vector3.zero;
                    tacticalAction.waypoints[1].position = Fox.Math.UnityToFoxVector3(tacticalAction.waypoints[1].transform.localPosition);

                    if (tacticalAction.edges.Count > 1)
                    {
                        tacticalAction.edges[0].actionDirection = GkTacticalActionDirection.TACTICAL_ACTION_ONE_WAY_01;
                        tacticalAction.edges[1].actionDirection = GkTacticalActionDirection.TACTICAL_ACTION_ONE_WAY_10;
                    }
                    else if (tacticalAction.edges.Count==1)
                    {
                        tacticalAction.edges[0].actionDirection = GkTacticalActionDirection.TACTICAL_ACTION_BOTH_WAYS;
                    }

                    var userId = reader.ReadStrCode();
                    if (userId == StrCode.Empty)
                    {
                        tacticalAction.userId = "";
                    }
                    else
                    { 
                        tacticalAction.userId = userId.ToString(); 
                    }

                    tacticalAction.attribute = reader.ReadUInt16();
                    if (tacticalAction.attribute != 0xffff )
                    {
                        var enumType = typeof(Tpp_Ground_Attributes);
                        var emptyWorldName = StrCode.Empty;
                        if (worldName == emptyWorldName)
                        {
                            var attributeFlags = (Tpp_Ground_Attributes)tacticalAction.attribute;
                            foreach (Tpp_Ground_Attributes flag in Enum.GetValues(enumType))
                                if (attributeFlags.HasFlag(flag))
                                    tacticalAction.attributeNames.Add(Enum.GetName(enumType, flag));
                        }
                        else
                        {
                            Debug.LogError($"World name {worldName} is not yet supported");
                        }
                    }
                    reader.Skip(6);
                }

                seekOffset += nextOffset;
            }
        }
    }
}
