namespace Fox
{
    using Fox.Core;
    using UnityEngine;
    
    public class InspectorTestComponent3 : MonoBehaviour
    {
        [SerializeReference]
        public Tpp.Sound.TppAmbientParameter Entity = new Tpp.Sound.TppAmbientParameter();
    }
}