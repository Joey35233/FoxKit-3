using Fox.Fio;
using Fox.Kernel;
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

                String name = realNode.GetName();
                Debug.Assert(name != (String)null);

                FoxDataParameterContext? parentParam = realNode.FindParameter(new String("Parent"));
                Debug.Assert(parentParam.HasValue);
                String parentName = parentParam.Value.GetString();
                Debug.Assert(parentName != (String)null);

                UnityEngine.Transform parent = Fox.Core.TransformUtils.FindTransformRecursive(target, parentName);
                if (parent == null)
                {
                    Debug.LogError($"Could not find parent, {parentName.CString}, of CNP, {name.CString}, in selected object.");
                    continue;
                }

                var cnp = new GameObject(name.CString);
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
    }
}
