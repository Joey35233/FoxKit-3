using Fox.Core;
using System.Collections.Generic;
using UnityEngine;

namespace Fox.Geox
{
    public partial class GeoxCollisionPrimitive
    {
        public override void Reset()
        {
            base.Reset();
            
            collisionMaterial = "MTR_NONE_A";
            collisionAttributeNames = new List<string>()
            {
                "CHARA",
                "PLAYER",
                "ENEMY",
            };
        }
    }
}
