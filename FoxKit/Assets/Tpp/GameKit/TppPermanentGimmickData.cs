using UnityEngine;

namespace Tpp.GameKit
{
    public partial class TppPermanentGimmickData : Fox.Core.Data
    {
        public override void InitializeGameObject(GameObject gameObject)
        {
            base.InitializeGameObject(gameObject);

            string partsPath = "/Assets/Game" + partsFile.path.CString;
            string locatorPath = "/Assets/Game" + locaterFile.path.CString;

        }
    }
}
