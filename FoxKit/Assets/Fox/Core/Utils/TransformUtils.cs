using Fox.Kernel;
using UnityEngine;

namespace Fox.Core
{
    public static class TransformUtils
    {
        public static UnityEngine.Transform FindTransformRecursive(UnityEngine.Transform transform, String name)
        {
            foreach (UnityEngine.Transform child in transform)
            {
                if (child.name == name.CString)
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
