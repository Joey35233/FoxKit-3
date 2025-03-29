using UnityEngine;
using static Fox.Geo.GeoGeom;

namespace Fox.Geo
{
    [UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("Geo/CollisionTags")]
    public class CollisionTags : MonoBehaviour
    {
        [field: SerializeField]
        public GeoCollisionTags tags;
    }
}
