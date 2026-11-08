using UnityEngine;

namespace Tpp.Effect
{
    public partial class TppWaterBounding
    {
        private static Color Water = new Color(0,0,1,0.5f);
        private static Color WaterSwamp = new Color(0, 0.75f, 0.5f, 0.5f);
        private static Color WaterSound = new Color(0.5f, 0.5f, 1, 0.5f);
        private void DrawGizmos(bool isSelected)
        {
            //plane
            Color waterColor = Water;
            switch (type)
            {
                case TppWaterBoundingType.TYPE_WATER:
                    waterColor = Water;
                    break;
                case TppWaterBoundingType.TYPE_MAFR_SWAMP:
                    waterColor = WaterSwamp;
                    break;
                case TppWaterBoundingType.TYPE_SOUND_ONLY:
                    waterColor = WaterSound;
                    break;
            }

            Gizmos.color = isSelected? waterColor * 0.5f : waterColor * 0.25f;
            Matrix4x4 matrix = this.transform.localToWorldMatrix;

            if (!enableRotate)
                matrix.SetTRS(this.transform.position, Quaternion.identity, this.transform.lossyScale);

            Gizmos.matrix = matrix;
            Gizmos.DrawCube(Vector3.zero,Vector3.one);
            
            //bounds
            Gizmos.color = isSelected ? Color.white : Color.white * 0.5f;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }
        private void OnDrawGizmos()
        {
            DrawGizmos(false);
        }
        private void OnDrawGizmosSelected()
        {
            DrawGizmos(true);
        }
    }
}
