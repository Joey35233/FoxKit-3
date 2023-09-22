using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.GameKit
{
    public partial class TppCoverPoint : Fox.Tactical.GkTacticalPoint
    {
        public override void InitializeGameObject(GameObject gameObject, TaskLogger logger)
        {
            base.InitializeGameObject(gameObject, logger);
            _ = gameObject.AddComponent<TppCoverPointGizmo>();
        }
    }
}
