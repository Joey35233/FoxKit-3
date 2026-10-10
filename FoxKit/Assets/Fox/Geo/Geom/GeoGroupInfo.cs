using UnityEngine;
using UnityEngine.Serialization;

namespace Fox.Geo
{
    [AddComponentMenu("Geo/GeoGroupInfo"), RequireComponent(typeof(BoxCollider))]
    public class GeoGroupInfo : MonoBehaviour
    {
        public Vector3 CellSize;
	
        public uint CellCountX;
        public uint CellCountY;
        public uint CellCountZ;
        
        void OnDrawGizmosSelected()
        {
            Gizmos.matrix = transform.localToWorldMatrix;
            
            BoxCollider boxCollider = GetComponent<BoxCollider>();
            Vector3 extents = boxCollider.size * 0.5f;
            Vector3 corner = boxCollider.center - extents;

            // Draw grid cells
            if (CellCountX > 0 && CellCountY > 0 && CellCountZ > 0)
            {
                Gizmos.color = Color.yellow;

                for (uint x = 0; x < CellCountX; x++)
                {
                    for (uint y = 0; y < CellCountY; y++)
                    {
                        for (uint z = 0; z < CellCountZ; z++)
                        {
                            Vector3 cellPos = corner +  new Vector3(x * CellSize.x, y * CellSize.y, z * CellSize.z);

                            Gizmos.DrawWireCube(cellPos + CellSize * 0.5f, CellSize);
                        }
                    }
                }
            }
        }
    }
}