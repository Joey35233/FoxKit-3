namespace Fox
{
    using Fox.Core;
    using UnityEngine;
    
    public class InspectorTestComponent3 : MonoBehaviour
    {
        [SerializeReference]
        public Fox.Geox.GeoxCollisionFreeShape Entity = new Fox.Geox.GeoxCollisionFreeShape();
    }
}