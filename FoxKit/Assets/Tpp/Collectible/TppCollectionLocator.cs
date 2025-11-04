using UnityEngine;

namespace Tpp.Collectible
{
    [UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppCollection/TppCollectionLocator")]
    public partial class TppCollectionLocator : MonoBehaviour
    {
        [field: SerializeField]
        public TppCollectionLocatorArray.TppCollection_Type type = TppCollectionLocatorArray.TppCollection_Type.TYPE_DIAMOND_SMALL;
    }
}
