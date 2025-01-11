using Fox.Core.Utils;
using Fox.Fio;
using UnityEngine;

namespace Fox.Tactical
{
    public class TacticalActionFileReader
    {
        private readonly TaskLogger logger = new TaskLogger("ImportNTA");
        private const uint NTA_SIGNATURE = 0x41544E46;
        public void Read(FileStreamReader reader)
        {
            Debug.Assert(reader.ReadUInt32() == NTA_SIGNATURE, "Invalid NTA file.");
            Debug.Assert(reader.ReadUInt16() == 1, "Invalid NTA version.");
            ushort worldCount = reader.ReadUInt16();
            uint worldOffset = reader.ReadUInt32();

            reader.Seek(worldOffset);
            for (int worldIndex = 0; worldIndex < worldCount; worldIndex++)
            {
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
                    tacticalAction.worldName = worldName.ToString();
                    reader.Seek(rewindPos);

                    for (int waypointIndex = 0; waypointIndex < 2; waypointIndex++)
                    {
                        tacticalAction.waypoints.Insert(waypointIndex,new GameObject($"GkTacticalActionWaypoint{waypointIndex:0000}").AddComponent<GkTacticalActionWaypoint>());
                        tacticalAction.waypoints[waypointIndex].transform.parent=tacticalAction.gameObject.transform;
                        tacticalAction.waypoints[waypointIndex].position = reader.ReadPositionF();
                        tacticalAction.edges.Insert(waypointIndex,new GameObject($"GkTacticalActionEdge{waypointIndex:0000}").AddComponent<GkTacticalActionEdge>());
                        tacticalAction.edges[waypointIndex].transform.parent = tacticalAction.gameObject.transform;
                        tacticalAction.edges[waypointIndex].actionName = reader.ReadStrCode32().ToString();
                        tacticalAction.edges[waypointIndex].actionDirection = GkTacticalActionDirection.TACTICAL_ACTION_BOTH_WAYS;
                    }
                    tacticalAction.transform.position = tacticalAction.waypoints[0].position;
                    tacticalAction.waypoints[0].transform.position = tacticalAction.waypoints[0].position;
                    tacticalAction.waypoints[1].transform.position = tacticalAction.waypoints[1].position;
                    tacticalAction.waypoints[0].position = Vector3.zero;
                    tacticalAction.waypoints[1].position = Fox.Math.UnityToFoxVector3(tacticalAction.waypoints[1].transform.localPosition);

                    tacticalAction.userId = reader.ReadStrCode().ToString();

                    tacticalAction.attribute = reader.ReadUInt16();
                    reader.Skip(6);
                }

                reader.Seek(nextOffset);
            }
        }
    }
}
