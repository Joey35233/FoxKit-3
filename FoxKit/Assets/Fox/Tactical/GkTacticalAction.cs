using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Tactical
{
    [System.Serializable]
    public partial class GkTacticalAction : Fox.Core.TransformData
    {
        public override void InitializeGameObject(GameObject gameObject, TaskLogger logger)
        {
            base.InitializeGameObject(gameObject, logger);
            _ = gameObject.AddComponent<GkTacticalActionGizmo>();
        }
    }
}