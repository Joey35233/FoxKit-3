using Fox;
using UnityEngine;
using UnityEditor;

namespace Fox.EdGameKit
{
    public class TransformEntityEditor : Fox.EdCore.EntityEditor
    {
        protected override bool ShouldOverrideBody() => true;
    }
}