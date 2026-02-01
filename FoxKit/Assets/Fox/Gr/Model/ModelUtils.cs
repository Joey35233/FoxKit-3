using UnityEngine;

namespace Fox.Gr
{
    public static class ModelUtils
    {
        public static bool CalculateBounds(Transform transform, ref Bounds bounds)
        {
            bool hasBounds = false;
            
            if (transform.TryGetComponent(out Renderer renderer))
            {
                bounds.Encapsulate(renderer.localBounds);
                hasBounds = true;
            }

            int childCount = transform.childCount;
            for (int i = childCount - 1; i >= 0; i--)
            {
                if (CalculateBounds(transform.GetChild(i), ref bounds))
                    hasBounds = true;
            }

            return hasBounds;
        }
    }
}