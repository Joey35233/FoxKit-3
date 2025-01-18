using System.Collections.Generic;
using Fox.Core;
using UnityEditor;
using UnityEngine;

namespace FoxKit.MenuItems
{    
    public class PruneUnusedEntities
    {
        [MenuItem("FoxKit/Prune Unused DataElements")]
        public static void RemoveUnreferencedDataElements()
        {
            Data[] datas = Object.FindObjectsOfType<Data>();
            foreach (var data in datas)
            {
                HashSet<Entity> referencedEntities = new HashSet<Entity>();
                data.CollectReferencedEntities(referencedEntities);
                
                foreach (DataElement child in data.transform.GetComponentsInChildren<DataElement>())
                {
                    if (!referencedEntities.Contains(child))
                        Object.DestroyImmediate(child.gameObject);
                }
            }
        }
    }
}   