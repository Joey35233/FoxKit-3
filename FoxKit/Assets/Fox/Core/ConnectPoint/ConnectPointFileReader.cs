using Fox.Fio;
using System;
using UnityEditor;
using UnityEngine;

namespace Fox.Core
{
    public class ConnectPointFileReader
    {
        public void Read(ReadOnlySpan<byte> data)
        {
            if (Selection.transforms.Length < 1)
            {
                return;
            }
            else if (Selection.transforms.Length > 1)
            {
                Debug.LogWarning($"Multiple objects selected. Applying ConnectionPoints to first: {Selection.transforms[0].name}.");
            }

            UnityEngine.Transform target = Selection.transforms[0];

            unsafe
            {
                fixed (byte* dataPtr = data)
                {
                    var header = (FoxDataHeader*)dataPtr;
                    Debug.Assert(header->Version == 0);
                    Debug.Assert(header->Flags == 0);

                    for (FoxDataNode* node = header->GetNodes(); node != null; node = node->GetNext())
                    {
                        String name = node->Name.ReadStringFromRelativeOffset();
                        if (name is null)
                        {
                            Debug.LogError($"Node name null.");
                            return;
                        }

                        FoxDataParameter* parentParam = node->FindParameter(new String("Parent"));
                        if (parentParam is null)
                        {
                            Debug.LogError($"Node does not have parent.");
                            return;
                        }

                        FoxDataString* parentStringPtr = parentParam->GetStringValue();
                        String parentName = parentStringPtr->ReadStringFromRelativeOffset();
                        if (parentName is null)
                        {
                            Debug.LogError($"Parent name null.");
                            return;
                        }

                        UnityEngine.Transform parent = Fox.Core.TransformUtils.FindTransformRecursive(target, parentName);
                        if (parent is null)
                        {
                            Debug.LogError($"Could not find Parent: {parentName} of CNP: {name} in selected object.");
                            return;
                        }

                        byte* payload = node->GetData();
                        if (payload is null)
                        {
                            Debug.LogError($"{name} has no transform.");
                            return;
                        }

                        var cnp = new GameObject(name);
                        _ = cnp.AddComponent<ConnectPoint>();

                        UnityEngine.Transform cnpTransform = cnp.transform;
                        cnpTransform.position = Fox.Math.UnityToFoxVector3(*(Vector3*)payload); payload += 16;
                        cnpTransform.rotation = Fox.Math.UnityToFoxQuaternion(*(Quaternion*)payload); payload += 16;
                        cnpTransform.localScale = *(Vector3*)payload; payload += 16;

                        cnpTransform.SetParent(parent, worldPositionStays: false);
                    }
                }
            }
        }
    }
}
