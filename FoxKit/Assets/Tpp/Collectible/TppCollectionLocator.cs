using UnityEngine;

namespace Tpp.Collectible
{
    [UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppCollection/TppCollectionLocator")]
    public partial class TppCollectionLocator : MonoBehaviour
    {
        [field: UnityEngine.SerializeField]
        public TppCollectionLocatorArray.TppCollection_Type type;
    }
}
