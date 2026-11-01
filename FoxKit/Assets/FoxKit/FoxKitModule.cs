using Fox;
using Fox.Fs;
using Fox.GameService;
using Fox.Geo;

namespace FoxKit
{
    public class FoxKitModule : Module
    {
        public static FoxKitModule Instance { get; private set; }

        public FoxKitModule() : base("FoxKit")
        {
            Instance = this;
            AddDependencyModule("Fox.Fs");
            AddDependencyModule("Fox.GameService");
            AddDependencyModule("Fox.Geo");
        }

        public override void Init()
        {
            RegisterDictionaries();
        }

        private static void RegisterDictionaries()
        {
            GameServiceModule.RouteIdMap.RegisterDictionary("/Assets/tpp/toolbox/Config/Route/route_id_string32");
            GeoModule.RailIdMap.RegisterDictionary("/Assets/tpp/toolbox/Config/Route/route_rail_id_string32");
            
            Tpp.GameKit.GameKitModule.SwitchRouteConditionIdMap.RegisterDictionary("/Assets/tpp/toolbox/Config/Route/route_switch_condition_string32");
            Tpp.GameKit.GameKitModule.SyncRouteIdMap.RegisterDictionary("/Assets/tpp/toolbox/Config/Route/route_sync_id_string32");
            Tpp.GameKit.GameKitModule.IdleActionIdMap.RegisterDictionary("/Assets/tpp/toolbox/Config/Route/route_idle_action_id_string32");
            Tpp.GameKit.GameKitModule.ConversationLabelIdMap.RegisterDictionary("/Assets/tpp/toolbox/Config/Route/route_conversation_label_string32");
            Tpp.GameKit.GameKitModule.GimmickIdMap.RegisterDictionary("/Assets/tpp/toolbox/Config/Route/route_gimmick_id_string32");
            Tpp.GameKit.GameKitModule.MessageIdMap.RegisterDictionary("/Assets/tpp/toolbox/Config/Route/route_message_id_string");
            Tpp.GameKit.GameKitModule.MessageParamMap.RegisterDictionary("/Assets/tpp/toolbox/Config/Route/route_message_param_string32");
            Tpp.GameKit.GameKitModule.CharacterIdMap.RegisterDictionary("/Assets/tpp/toolbox/Config/Route/route_character_id_string");
            Tpp.GameKit.GameKitModule.CharacterId32Map.RegisterDictionary("/Assets/tpp/toolbox/Config/Route/route_character_id_string32");
        }
    }
}
