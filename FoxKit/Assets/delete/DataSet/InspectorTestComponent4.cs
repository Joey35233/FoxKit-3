namespace Fox
{
    using Fox.Core;
    using UnityEngine;
    
    public class InspectorTestComponent4 : MonoBehaviour
    {
        [SerializeReference]
        public Tpp.GameKit.TppPermanentGimmickData Entity = new Tpp.GameKit.TppPermanentGimmickData();
    }
}