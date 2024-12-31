using Fox;

namespace Fox.Core
{
    public static class TransformUtils
    {
        public static UnityEngine.Transform FindTransformRecursive(UnityEngine.Transform transform, string name)
        {
            foreach (UnityEngine.Transform child in transform)
            {
                if (child.name == name)
                {
                    return child;
                }
                else
                {
                    UnityEngine.Transform childSearch = FindTransformRecursive(child, name);
                    if (childSearch != null)
                        return childSearch;
                }
            }

            return null;
        }
    }
}
