using UnityEngine;

namespace Tpp.GameCore
{
    [UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppGameCore/TppCollectionLocator")]
    public partial class TppCollectionLocator : MonoBehaviour
    {
        [field: SerializeField]
        public TppCollectionLocatorArray.TppCollection_Type type = TppCollectionLocatorArray.TppCollection_Type.TYPE_DIAMOND_SMALL;
    }
}
