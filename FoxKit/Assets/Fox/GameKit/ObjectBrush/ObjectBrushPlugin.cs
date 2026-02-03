using Fox.Core;
using PlasticGui;
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
        protected void UpdateBase()
        {
            if (transform.parent == null)
                return;

            bool isParentObr = transform.parent.TryGetComponent(out ObjectBrush objectBrush);

            bool isParentObrb = transform.parent.TryGetComponent(out ObjectBrushBlock objectBrushBlock);
            
            if (isParentObrb)
            {
                if (!FoxGameKitModule.ObjectBrushRegistry.TryGetValue(objectBrushBlock.objectBrushName, out objectBrush))
                {
                    return;
                }
            }
            
            if (!transform.hasChanged)
                return;

            var position = transform.localPosition;
            
            (uint NumBlocksH, uint NumBlocksW) = objectBrush.GetNumBlocks();

            if (isParentObr)
            {
                
                float maxX = NumBlocksH/2*128;
                float maxZ = NumBlocksW/2*128;
                
                if (position.x < -maxX)
                    position.x = -maxX;
                if (position.x > maxX)
                    position.x = maxX;
            
                if (position.z < -maxZ)
                    position.z = -maxZ;
                if (position.z > maxZ)
                    position.z = maxZ;
            }
            else if (isParentObrb)
            {
                uint blockId = objectBrushBlock.blockId;
                ushort blockX = (ushort)(blockId % NumBlocksH);
                ushort blockZ = (ushort)(blockId / NumBlocksW);
                
                float blockCenterX = 128 * (blockX + 0.5f - (0.5f * NumBlocksH));
                float blockCenterZ = 128 * (blockZ + 0.5f - (0.5f * NumBlocksW));
                
                float minX = blockCenterX - 64;
                float maxX = blockCenterX + 64;
                float minZ = blockCenterZ - 64;
                float maxZ = blockCenterZ + 64;
                
                if (position.x > -minX)
                    position.x = -minX;
                if (position.x < -maxX)
                    position.x = -maxX;
            
                if (position.z < minZ)
                    position.z = minZ;
                if (position.z > maxZ)
                    position.z = maxZ;
            }

            if (position != transform.localPosition)
            {
                Debug.Log($"Moving {name} inside bounds, {transform.localPosition} to {position}");
                transform.localPosition = position;
            }
        }
    }
}