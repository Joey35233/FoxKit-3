using Fox.Fio;
using System;
using UnityEditor;
using UnityEngine;

namespace Fox.Core
{
    public class ConnectPointFileReader
    {
        public void Read(FileStreamReader reader)
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

            var header = new FoxDataHeaderContext(reader, reader.BaseStream.Position);
            header.Validate(version: 0, flags: 0);

            for (FoxDataNodeContext? node = header.GetFirstNode(); node.HasValue; node = node.Value.GetNextNode())
            {
                FoxDataNodeContext realNode = node.Value;

                string name = realNode.GetName();
                Debug.Assert(name != null);

                FoxDataParameterContext? parentParam = realNode.FindParameter("Parent");
                Debug.Assert(parentParam.HasValue);
                string parentName = parentParam.Value.GetString();
                Debug.Assert(parentName != null);

                UnityEngine.Transform parent = Fox.Core.TransformUtils.FindTransformRecursive(target, parentName);
                if (parent == null)
                {
                    Debug.LogError($"Could not find parent, {parentName}, of CNP, {name}, in selected object.");
                    continue;
                }

                var cnp = new GameObject(name);
                _ = cnp.AddComponent<ConnectPoint>();

                // Payload
                long? dataPosition = realNode.GetDataPosition();
                Debug.Assert(dataPosition.HasValue);
                reader.Seek(dataPosition.Value);

                UnityEngine.Transform cnpTransform = cnp.transform;
                cnpTransform.position = reader.ReadPositionHF();
                cnpTransform.rotation = reader.ReadRotationF();
                cnpTransform.localScale = reader.ReadScaleHF();

                cnpTransform.SetParent(parent, worldPositionStays: false);
            }
        }

        public void ReadUnsafe(ReadOnlySpan<byte> data)
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

                        FoxDataNodeAttribute* parentParam = node->FindAttribute(new String("Parent"));
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
