using Fox.GameService;
using UnityEditor;

namespace Tpp.GameKit
{
    [InitializeOnLoad]
    public static class GameKitModule
    {
        static GameKitModule()
        {
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteUnknown1245047319NodeEvent.Id, TppRouteUnknown1245047319NodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteUnknown1875147223NodeEvent.Id, TppRouteUnknown1875147223NodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRoutePermitToGetOffNodeEvent.Id, TppRoutePermitToGetOffNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteUnknown2358641809NodeEvent.Id, TppRouteUnknown2358641809NodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteVehicleAntiPlayerFireNodeEvent.Id, TppRouteVehicleAntiPlayerFireNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteUnknown2795470991NodeEvent.Id, TppRouteUnknown2795470991NodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteUnknown3589755714NodeEvent.Id, TppRouteUnknown3589755714NodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteUnknown3696614179NodeEvent.Id, TppRouteUnknown3696614179NodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteUnknown3969758229NodeEvent.Id, TppRouteUnknown3969758229NodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteUnknown4257632892NodeEvent.Id, TppRouteUnknown4257632892NodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionNodeEvent.Id, TppRouteCautionNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionIdleActNodeEvent.Id, TppRouteCautionIdleActNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionSquatFireNodeEvent.Id, TppRouteCautionSquatFireNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionSquatIdleNodeEvent.Id, TppRouteCautionSquatIdleNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionSquatIdleAimNodeEvent.Id, TppRouteCautionSquatIdleAimNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionStandFireNodeEvent.Id, TppRouteCautionStandFireNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionStandIdleNodeEvent.Id, TppRouteCautionStandIdleNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionStandIdleAimNodeEvent.Id, TppRouteCautionStandIdleAimNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionStandIdleAimCarryingNodeEvent.Id, TppRouteCautionStandIdleAimCarryingNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionStandIdleReadyNodeEvent.Id, TppRouteCautionStandIdleReadyNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionStandIdleSearchNodeEvent.Id, TppRouteCautionStandIdleSearchNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCloseDoorNodeEvent.Id, TppRouteCloseDoorNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteConversationIdleNodeEvent.Id, TppRouteConversationIdleNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCurtainInNodeEvent.Id, TppRouteCurtainInNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCurtainOutNodeEvent.Id, TppRouteCurtainOutNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteDemoNodeEvent.Id, TppRouteDemoNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteDropPointNodeEvent.Id, TppRouteDropPointNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteFireNodeEvent.Id, TppRouteFireNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteHeliIdleNodeEvent.Id, TppRouteHeliIdleNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteHoveringNodeEvent.Id, TppRouteHoveringNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteKillNodeEvent.Id, TppRouteKillNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteOnBaseRouteNodeEvent.Id, TppRouteOnBaseRouteNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteOnTheHillNodeEvent.Id, TppRouteOnTheHillNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteOpenDoorNodeEvent.Id, TppRouteOpenDoorNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRoutePileBunkerNodeEvent.Id, TppRoutePileBunkerNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRoutePickUpHoneyBeeNodeEvent.Id, TppRoutePickUpHoneyBeeNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRoutePutDownHoneyBeeNodeEvent.Id, TppRoutePutDownHoneyBeeNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRoutePutHostageInVehicleNodeEvent.Id, TppRoutePutHostageInVehicleNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteRecoveryNodeEvent.Id, TppRouteRecoveryNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteRelaxedIdleActNodeEvent.Id, TppRouteRelaxedIdleActNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteRelaxedStandIdleNodeEvent.Id, TppRouteRelaxedStandIdleNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteRideVehicleNodeEvent.Id, TppRouteRideVehicleNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteSaluteNodeEvent.Id, TppRouteSaluteNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteSaluteGreetingNodeEvent.Id, TppRouteSaluteGreetingNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteSearchMissileNodeEvent.Id, TppRouteSearchMissileNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteSendMessageNodeEvent.Id, TppRouteSendMessageNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteSetTargetSpeedNodeEvent.Id, TppRouteSetTargetSpeedNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteSitInChairNodeEvent.Id, TppRouteSitInChairNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteSnipeNodeEvent.Id, TppRouteSnipeNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteStandIdleNodeEvent.Id, TppRouteStandIdleNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteStandSearchNodeEvent.Id, TppRouteStandSearchNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteSupineSnipeNodeEvent.Id, TppRouteSupineSnipeNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteSwitchRouteNodeEvent.Id, TppRouteSwitchRouteNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteSyncRouteNodeEvent.Id, TppRouteSyncRouteNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteTakeHostageOutOfVehicleNodeEvent.Id, TppRouteTakeHostageOutOfVehicleNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteUseFlashLightNodeEvent.Id, TppRouteUseFlashLightNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteUseSearchLightNodeEvent.Id, TppRouteUseSearchLightNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteVanishNodeEvent.Id, TppRouteVanishNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteVehicleFireNodeEvent.Id, TppRouteVehicleFireNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteVehicleGetInNodeEvent.Id, TppRouteVehicleGetInNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteVehicleGetOffNodeEvent.Id, TppRouteVehicleGetOffNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteVehicleGetOutNodeEvent.Id, TppRouteVehicleGetOutNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteVehicleIdleNodeEvent.Id, TppRouteVehicleIdleNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteWaitNodeEvent.Id, TppRouteWaitNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteWaitIdleNodeEvent.Id, TppRouteWaitIdleNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteWalkerGearCautionIdleNodeEvent.Id, TppRouteWalkerGearCautionIdleNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteWalkerGearRelaxedIdleNodeEvent.Id, TppRouteWalkerGearRelaxedIdleNodeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteUnknown41204288EdgeEvent.Id, TppRouteUnknown41204288EdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteAllEdgeEvent.Id, TppRouteAllEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCarryHoneyBeeEdgeEvent.Id, TppRouteCarryHoneyBeeEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionDashEdgeEvent.Id, TppRouteCautionDashEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionRunEdgeEvent.Id, TppRouteCautionRunEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionRunAimEdgeEvent.Id, TppRouteCautionRunAimEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionStandWalkReadyEdgeEvent.Id, TppRouteCautionStandWalkReadyEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionWalkEdgeEvent.Id, TppRouteCautionWalkEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionWalkAimEdgeEvent.Id, TppRouteCautionWalkAimEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionWalkAimFrontEdgeEvent.Id, TppRouteCautionWalkAimFrontEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionWalkFireEdgeEvent.Id, TppRouteCautionWalkFireEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteCautionWalkSearchEdgeEvent.Id, TppRouteCautionWalkSearchEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteDashEdgeEvent.Id, TppRouteDashEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteForwardChangeSpeedEdgeEvent.Id, TppRouteForwardChangeSpeedEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteJumpOnlyEdgeEvent.Id, TppRouteJumpOnlyEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteJumpWalkEdgeEvent.Id, TppRouteJumpWalkEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteMoveEdgeEvent.Id, TppRouteMoveEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteMoveFastEdgeEvent.Id, TppRouteMoveFastEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteMoveVeryFastEdgeEvent.Id, TppRouteMoveVeryFastEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteMoveNormalEdgeEvent.Id, TppRouteMoveNormalEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteMoveSlowEdgeEvent.Id, TppRouteMoveSlowEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteNoneEdgeEvent.Id, TppRouteNoneEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteNormalEdgeEvent.Id, TppRouteNormalEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRoutePermitGettingOffEdgeEvent.Id, TppRoutePermitGettingOffEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteRelaxedRunEdgeEvent.Id, TppRouteRelaxedRunEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteRelaxedStandWalkEdgeEvent.Id, TppRouteRelaxedStandWalkEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteRelaxedStandWalkActEdgeEvent.Id, TppRouteRelaxedStandWalkActEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteRelaxedWalkEdgeEvent.Id, TppRouteRelaxedWalkEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteRelaxedWalkActEdgeEvent.Id, TppRouteRelaxedWalkActEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteRouteMoveEdgeEvent.Id, TppRouteRouteMoveEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteRouteMoveFreeEdgeEvent.Id, TppRouteRouteMoveFreeEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteRunOnlyEdgeEvent.Id, TppRouteRunOnlyEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteRunWalkEdgeEvent.Id, TppRouteRunWalkEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteStairsDownEdgeEvent.Id, TppRouteStairsDownEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteVehicleBackFastEdgeEvent.Id, TppRouteVehicleBackFastEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteVehicleBackNormalEdgeEvent.Id, TppRouteVehicleBackNormalEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteVehicleBackSlowEdgeEvent.Id, TppRouteVehicleBackSlowEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteVehicleMoveFastEdgeEvent.Id, TppRouteVehicleMoveFastEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteVehicleMoveNormalEdgeEvent.Id, TppRouteVehicleMoveNormalEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteVehicleMoveSlowEdgeEvent.Id, TppRouteVehicleMoveSlowEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteWalkEdgeEvent.Id, TppRouteWalkEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteWalkOnlyEdgeEvent.Id, TppRouteWalkOnlyEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteWalkerGearCautionDashEdgeEvent.Id, TppRouteWalkerGearCautionDashEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteWalkerGearCautionRunEdgeEvent.Id, TppRouteWalkerGearCautionRunEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteWalkerGearCautionWalkEdgeEvent.Id, TppRouteWalkerGearCautionWalkEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteWalkerGearRelaxedRunEdgeEvent.Id, TppRouteWalkerGearRelaxedRunEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteWalkerGearRelaxedWalkEdgeEvent.Id, TppRouteWalkerGearRelaxedWalkEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteEMPTY_STRINGEdgeEvent.Id, TppRouteEMPTY_STRINGEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRoutechaseEdgeEvent.Id, TppRoutechaseEdgeEvent.Deserialize);
            GameServiceModule.RegisterRouteDataEventDeserializationCallback(TppRouteLOWERCASE_moveEdgeEvent.Id, TppRouteLOWERCASE_moveEdgeEvent.Deserialize);
        }
    }
}
