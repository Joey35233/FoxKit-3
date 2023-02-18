using UnityEngine;
using String = Fox.Kernel.String;

namespace Fox.Core
{
    public partial class Data : Fox.Core.Entity
    {
        protected partial String Get_referencePath() => throw new System.NotImplementedException();

        public override void InitializeGameObject(GameObject gameObject)
        {
            if (name != (String)null)
                gameObject.name = name.CString;
            base.InitializeGameObject(gameObject);
        }
    }
}