using UnityEngine;
using static Tpp.Effect.TppFootPrint;

namespace Tpp.Effect
{
    [UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppEffect/TppFootPrintLocator")]
    public class TppFootPrintLocator : MonoBehaviour
    {
        [field: SerializeField]
        public FootPrintChara footChara = FootPrintChara.BOOT;
        [field: SerializeField]
        public bool nvg = true;
        [field: SerializeField]
        public bool footLR = false;
        [field: SerializeField]
        public float alpha = 1.0f;
        [field: SerializeField]
        public bool blood = false;
        [field: SerializeField]
        public bool enable = true;
        public void OnDrawGizmos()
        {
            Gizmos.matrix = transform.localToWorldMatrix;

            Gizmos.DrawCube(Vector3.forward*0.05f, new Vector3(0.1f, 0, 0.2f));
        }
        public void Reset()
        {
            transform.localScale = new Vector3(2.3f,1.1f,2.3f);
        }
    }
}
