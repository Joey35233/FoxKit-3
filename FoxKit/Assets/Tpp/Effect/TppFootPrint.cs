using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;
using System.Collections.Generic;

namespace Tpp.Effect
{
    public partial class TppFootPrint
    {
        // /Assets/tpp/effect/vfx_pic/mark/
        //fx_mrkfot01msk_iy_clp.ftex, fx_mrkfot01n_iy_hnm_clp.ftex
        public enum FootPrintChara : byte
        {
            GZ_SUIT=0,
            BOOT=1,
            FLAT=2,
            VENOM=3,
            RAIDEN=4,
            QUIET=5,
            SOFT=6,
            POLYGON=7,
        }
        public Vector3 DEFAULT_SCALE = new(2.3f, 1.1f, 2.3f);
        public override void Reset()
        {
            base.Reset();
            transform.localScale = DEFAULT_SCALE;
        }
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            /*for (int i = 0; i < matrices.Count; i++)
                matrices[i] = Fox.Math.FoxToUnityMatrix(matrices[i]);*/

            for (int i = 0; i < matrices.Count; i++)
            {
                var fpLoc = new GameObject($"TppFootPrintLocator{i:D4}").AddComponent<TppFootPrintLocator>();
                
                var matrix = Fox.Math.UnityToFoxMatrix(matrices[i]);
                fpLoc.transform.position = matrix.GetPosition();
                fpLoc.transform.rotation = matrix.rotation;
                fpLoc.transform.localScale = gameObject.transform.localScale;

                fpLoc.transform.parent = gameObject.transform;

                fpLoc.footChara = (FootPrintChara)(footChara[i]&7);
                fpLoc.nvg = footChara[i]>>7==1;
                fpLoc.footLR = footLR[i]>0;
                fpLoc.alpha = alpha[i];
                fpLoc.blood = blood[i];
                fpLoc.enable = enable[i];
            }
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            /*List<Matrix4x4> _matrices = new(matrices);
            for (int i = 0; i < _matrices.Count; i++)
                _matrices[i] = Fox.Math.UnityToFoxMatrix(_matrices[i]);
            context.OverrideProperty(nameof(matrices), _matrices);*/

            var fpLocs = this.GetComponentsInChildren<TppFootPrintLocator>();
            int fpLocsCount = fpLocs.Length;
            List<Matrix4x4> _matrices = new(fpLocsCount);
            List<uint> _footChara = new(fpLocsCount);
            List<uint> _footLR = new(fpLocsCount);
            List<float> _alpha = new(fpLocsCount);
            List<bool> _blood = new(fpLocsCount);
            List<bool> _enable = new(fpLocsCount);
            for (int i = 0; i < fpLocsCount; i++)
            {
                TppFootPrintLocator fpLoc = fpLocs[i];
                Matrix4x4 unityMatrix = fpLoc.transform.localToWorldMatrix;
                Matrix4x4 foxMatrix = Fox.Math.UnityToFoxMatrix(unityMatrix);
                _matrices.Insert(i, foxMatrix);
                uint _footCharaLoc = (uint)fpLoc.footChara;
                if (fpLoc.nvg)
                    _footCharaLoc |= 8;
                _footChara.Insert(i, _footCharaLoc);
                _footLR.Insert(i, (uint)(fpLoc.footLR ? 1 : 0) );
                _alpha.Insert(i, fpLoc.alpha);
                _blood.Insert(i, fpLoc.blood);
                _enable.Insert(i, fpLoc.enable);
            }
            context.OverrideProperty(nameof(matrices), _matrices);
            context.OverrideProperty(nameof(footChara), _footChara);
            context.OverrideProperty(nameof(footLR), _footLR);
            context.OverrideProperty(nameof(alpha), _alpha);
            context.OverrideProperty(nameof(blood), _blood);
            context.OverrideProperty(nameof(enable), _enable);
        }
    }
}
