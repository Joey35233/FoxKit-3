using Fox;
using UnityEngine;

namespace Fox.Core
{
    [System.Serializable]
    public partial class Locator : TransformData
    {
        public override void InitializeGameObject(GameObject gameObject)
        {
            base.InitializeGameObject(gameObject);
            gameObject.AddComponent<LocatorGizmo>();
        }
    }
}