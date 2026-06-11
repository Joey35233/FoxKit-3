using Fox.Core;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    public partial class ObjectBrushPlugin
    {
        protected GameObject ModelInstance;

        private void ClearObjects()
        {
            for (int i = this.transform.childCount - 1; i >= 0; i--)
            {
                var child = this.transform.GetChild(i);
                if (child.GetComponent<Entity>())
                    continue;
                DestroyImmediate(child.gameObject);
            }
        }

        protected void OnEnableBase()
        {
            if (ModelInstance != null)
            {
                Debug.LogError("ModelInstance survived.");
                
                DestroyImmediate(ModelInstance);
            }
            
            ClearObjects();
        }

        protected void OnDisableBase()
        {
            DestroyImmediate(ModelInstance);
            
            ClearObjects();
        }
    }
}