using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using System;
using System.Collections.Generic;
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

        private static string GetActionName(StrCode32 actionName) => (uint)actionName.GetHashCode() switch
        {
            1277978017 => "StepOn",
            1139911476 => "StepDown",
            2317903572 => "LadderUp",
            3049138984 => "LadderDown",
            3451056519 => "Door",
            504469101 => "StepFence",
            504835594 => "SubstanceVowelCourseStepFence",
            3205930904 => "",
            _ => actionName.ToString(),
        };
        private static GkTacticalActionDirection GetDirection(string actionName) => actionName switch
        {
            "StepOn" or 
            "LadderUp" => GkTacticalActionDirection.TACTICAL_ACTION_ONE_WAY_01,
            "StepDown" or 
            "LadderDown" => GkTacticalActionDirection.TACTICAL_ACTION_ONE_WAY_10,
            "Door" or 
            "StepFence" or 
            "SubstanceVowelCourseStepFence" or 
            _ => GkTacticalActionDirection.TACTICAL_ACTION_BOTH_WAYS,
        };
        private static (uint, List<string>) GetAttribute(string actionName) => actionName switch
        {
            "LadderUp" or
            "LadderDown" or
            "StepOn" or
            "StepDown" => (1, new List<string>{ "Human" }),

            "StepFence" or
            "SubstanceVowelCourseStepFence" => (16, new List<string> { "HumanCombat" }),
            
            "Door" or _ => (1153, new List<string> { "Human", "Dog", "Child" }),
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

                    var tacticalActionName = reader.ReadStrCode();
                    GkTacticalAction tacticalAction = new GameObject(tacticalActionName.ToString()).AddComponent<GkTacticalAction>();
                    tacticalAction.SetTransform(TransformEntity.GetDefault());

                    if(worldName==StrCode.Empty)
                        tacticalAction.worldName = "";
                    else
                        tacticalAction.worldName = worldName.ToString();

                    tacticalAction.enable = true;
                    tacticalAction.enableInGame = true;

                    reader.Seek(rewindPos);

                    bool oneEdge = false;
                    for (int waypointIndex = 0; waypointIndex < 2; waypointIndex++)
                    {
                        //Waypoint
                        tacticalAction.waypoints.Insert(waypointIndex,new GameObject($"GkTacticalActionWaypoint{waypointIndex:0000}").AddComponent<GkTacticalActionWaypoint>());
                        tacticalAction.waypoints[waypointIndex].SetOwner(tacticalAction);
                        tacticalAction.waypoints[waypointIndex].position = reader.ReadPositionF();


                        //Edge
                        var actionName = reader.ReadStrCode32();
                        var actionNameStr = GetActionName(actionName);
                        if (/*actionName == emptyHash32 || */oneEdge==true)
                            //edges with an empty string shouldn't exist according to Joey
                            //and tactical actions with the direction BOTH_WAYS should have only one edge
                            continue;

                        tacticalAction.edges.Insert(waypointIndex, new GameObject($"GkTacticalActionEdge{waypointIndex:0000}|{actionNameStr}").AddComponent<GkTacticalActionEdge>());
                        tacticalAction.edges[waypointIndex].SetOwner(tacticalAction);

                        tacticalAction.edges[waypointIndex].actionName = actionNameStr;

                        var actionDirection = GetDirection(actionNameStr);
                        tacticalAction.edges[waypointIndex].actionDirection = actionDirection;

                        //ensure only one edge is in the action if BOTH_WAYS
                        oneEdge = actionDirection == GkTacticalActionDirection.TACTICAL_ACTION_BOTH_WAYS;
                    }

                    //set to comfortable local positions from globals
                    tacticalAction.transform.position = tacticalAction.waypoints[1].position - ((tacticalAction.waypoints[1].position - tacticalAction.waypoints[0].position)/2);

                    tacticalAction.waypoints[0].position -= tacticalAction.transform.position;
                    tacticalAction.waypoints[1].position -= tacticalAction.transform.position;

                    tacticalAction.waypoints[0].transform.localPosition = tacticalAction.waypoints[0].position;
                    tacticalAction.waypoints[1].transform.localPosition = tacticalAction.waypoints[1].position;

                    tacticalAction.waypoints[0].position = Math.FoxToUnityVector3(tacticalAction.waypoints[0].position);
                    tacticalAction.waypoints[1].position = Math.FoxToUnityVector3(tacticalAction.waypoints[1].position);


                    if (tacticalAction.edges[0].actionName == "LadderDown" || tacticalAction.edges[0].actionName == "StepDown")
                    {
                        tacticalAction.waypoints.Reverse();
                        tacticalAction.edges.Reverse();
                    }

                    //userId refers to related gameobject or gimmick
                    var userId = reader.ReadStrCode();
                    if (userId == StrCode.Empty)
                        tacticalAction.userId = "";
                    else
                        tacticalAction.userId = userId.ToString();

                    //nav attributes
                    tacticalAction.attribute = reader.ReadUInt16();
                    var enumType = typeof(Tpp_Ground_Attributes);
                    if (tacticalAction.attribute != 0xffff )
                    {
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
                    else
                    {
                        foreach (GkTacticalActionEdge edge in tacticalAction.edges)
                        {
                            (var attribute, var attributeNames) = GetAttribute(edge.actionName);
                            tacticalAction.attribute = attribute;
                            tacticalAction.attributeNames.AddRange(attributeNames);
                            break;
                        }
                    }
                    reader.Skip(6);
                }

                seekOffset += nextOffset;
            }
        }
    }
}
