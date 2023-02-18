using UnityEngine;

namespace Tpp.GameKit
{
    public partial class TppCoverPoint : Fox.Tactical.GkTacticalPoint
    {
        public override void InitializeGameObject(GameObject gameObject)
        {
            base.InitializeGameObject(gameObject);
            _ = gameObject.AddComponent<TppCoverPointGizmo>();
        }
    }
}
