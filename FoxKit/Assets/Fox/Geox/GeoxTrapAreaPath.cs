using UnityEngine;

namespace Fox.Geox
{
    public partial class GeoxTrapAreaPath : Fox.Graphx.GraphxPathData
    {
        public override void InitializeGameObject(GameObject gameObject)
        {
            base.InitializeGameObject(gameObject);
            gameObject.AddComponent<GeoxTrapAreaPathGizmo>();
        }
    }
}
