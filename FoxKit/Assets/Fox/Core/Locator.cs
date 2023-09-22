using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Core
{
    [System.Serializable]
    public partial class Locator : TransformData
    {
        public override void InitializeGameObject(GameObject gameObject, TaskLogger logger)
        {
            gameObject.AddComponent<BoxGizmo>().Color = new Color(0.819607843f, 0.768627451f, 0.623529412f);
            base.InitializeGameObject(gameObject, logger);
        }
    }
}