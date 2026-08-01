using Fox;
using Fox.GameService;

namespace Tpp.GameKit
{
    public class GameKitModule : Module
    {
        public static GameKitModule Instance { get; private set; }

        public GameKitModule() : base("Tpp.GameKit")
        {
            Instance = this;
            AddDependencyModule("Fox.GameService");
        }
        
        public static readonly StringId32Map SwitchRouteConditionIdMap = new StringId32Map();
        public static readonly StringId32Map SyncRouteIdMap = new StringId32Map();

        public override void Init()
        {
            GameServiceModule.RegisterEventInfo("/Assets/tpp/toolbox/Config/Route/EventInfo.csv", "tpp");
            
            // SendMessage
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("SendMessage"), typeof(TppRouteNodeEventSendMessage));
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("PutHostageInVehicle"), typeof(TppRouteNodeEventSendMessage));
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("TakeHostageOutOfVehicle"), typeof(TppRouteNodeEventSendMessage));
            
            // SwitchRoute
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("SwitchRoute"), typeof(TppRouteNodeEventSwitchRoute));
            
            // SyncRoute
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("SyncRoute"), typeof(TppRouteNodeEventSyncRoute));
            
            // Idle actions
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("RelaxedIdleAct"), typeof(TppRouteNodeEventRelaxedIdleAct));
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("CautionIdleAct"), typeof(TppRouteNodeEventCautionIdleAct));
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("ConversationIdle"), typeof(TppRouteNodeEventConversationIdle));

            // Edge events
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("Move"), typeof(TppRouteEdgeEventMove));
            
            // Vehicle
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("VehicleMoveSlow"), typeof(TppRouteEdgeEventVehicleMove));
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("VehicleMoveNormal"), typeof(TppRouteEdgeEventVehicleMove));
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("VehicleMoveFast"), typeof(TppRouteEdgeEventVehicleMove));
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("VehicleBackSlow"), typeof(TppRouteEdgeEventVehicleMove));
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("VehicleBackNormal"), typeof(TppRouteEdgeEventVehicleMove));
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("VehicleBackFast"), typeof(TppRouteEdgeEventVehicleMove));
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("VehicleKmPerHour"), typeof(TppRouteEdgeEventVehicleMove));
            
            // Heli
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("Normal"), typeof(TppRouteEdgeEventHelicopter));
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("PermitGettingOff"), typeof(TppRouteEdgeEventHelicopter));
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("Hovering"), typeof(TppRouteNodeEventHelicopter));
            GameServiceModule.RegisterRouteNodeEventTypeOverride(new StrCode32("DropPoint"), typeof(TppRouteNodeEventHelicopter));
            
            // Volgin ride
            GameServiceModule.RegisterRouteEdgeEventTypeOverride(new StrCode32("chase"), typeof(TppRouteEdgeEventChase));
        }
    }
}
