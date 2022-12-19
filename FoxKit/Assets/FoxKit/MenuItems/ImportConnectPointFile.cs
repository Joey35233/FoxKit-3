using UnityEngine;
using UnityEditor;
using Fox.Kernel;
using Fox.Fio;
using Fox.Core;

namespace FoxKit.MenuItems
{
    public static class ImportConnectPointFile
    {
        [MenuItem("FoxKit/Import/ConnectPointFile")]
        private static void OnImportAsset()
        {
            var assetPath = EditorUtility.OpenFilePanel("Import ConnectPointFile", "", "fcnp");
            if (string.IsNullOrEmpty(assetPath))
            {
                return;
            }

            using var reader = new FileStreamReader(System.IO.File.OpenRead(assetPath));
            {
                if (Selection.transforms.Length < 0)
                {
                    return;
                }
                else if (Selection.transforms.Length > 1)
                {
                    Debug.LogWarning($"Multiple objects selected. Applying ConnectionPoints to first: {Selection.transforms[0].name}.");
                }

                UnityEngine.Transform target = Selection.transforms[0];

                FoxDataHeaderContext header = new FoxDataHeaderContext(reader, reader.BaseStream.Position);
                header.Validate(version: 0, flags: 0);

                for (FoxDataNodeContext? node = header.GetFirstNode(); node.HasValue; node = node.Value.GetNextNode())
                {
                    FoxDataNodeContext realNode = node.Value;

                    String name = realNode.GetName(); Debug.Assert(name != (String)null);

                    FoxDataParameterContext? parentParam = realNode.FindParameter(new String("Parent")); Debug.Assert(parentParam.HasValue);
                    String parentName = parentParam.Value.GetString(); Debug.Assert(parentName != (String)null);

                    UnityEngine.Transform parent = target.Find(parentName.CString);
                    if (parent == null)
                    {
                        Debug.LogError($"Could not find parent, {parentName.CString}, of CNP, {name.CString}, in selected object.");
                        continue;
                    }

                    GameObject cnp = new GameObject(name.CString);
                    cnp.AddComponent<ConnectPoint>();

                    // Payload
                    long? dataPosition = realNode.GetDataPosition(); Debug.Assert(dataPosition.HasValue);
                    reader.Seek(dataPosition.Value);

                    UnityEngine.Transform cnpTransform = cnp.transform;
                    cnpTransform.position = reader.ReadPositionHF();
                    cnpTransform.rotation = reader.ReadRotationF();
                    cnpTransform.localScale = reader.ReadScaleHF();

                    cnpTransform.SetParent(parent, worldPositionStays: true);
                }
            }
        }
    }
}
