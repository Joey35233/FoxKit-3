using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;
using System.Collections.Generic;

namespace Fox.Geox
{
    public partial class GeoxCollisionPyraidFreeShape
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            for (int i = 0; i < points.Length; i++)
                points[i] = Fox.Math.FoxToUnityVector3(points[i]);
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            Vector3[] _points = points;
            for (int i = 0; i < _points.Length; i++)
                _points[i] = Fox.Math.UnityToFoxVector3(_points[i]);

            context.OverrideProperty(nameof(points), _points);
        }

        public override void Reset()
        {
            base.Reset();

            points[0] = new Vector3(0.5f, -0.5f, -0.5f);
            points[1] = new Vector3(0.5f, -0.5f, 0.5f);
            points[2] = new Vector3(-0.5f, -0.5f, 0.5f);
            points[3] = new Vector3(-0.5f, -0.5f, -0.5f);
            points[4] = new Vector3(0, 0.5f, 0);
            
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
