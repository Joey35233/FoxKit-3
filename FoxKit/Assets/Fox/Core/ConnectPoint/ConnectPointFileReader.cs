using Fox.Core;
using Fox.Fio;
using System.IO;
using UnityEngine;
using System.Collections.Generic;
using Fox.Kernel;
using UnityEditor;

namespace Fox.Core
{
    public class ConnectPointFileReader
    {
        public ConnectPoint[] Read(FileStreamReader reader)
        {
            List<ConnectPoint> cnps = new List<ConnectPoint>();

            string FoxDataStringRead(FileStreamReader reader)
            {
                long pos = reader.BaseStream.Position;
                StrCode32 Hash = reader.ReadStrCode32();
                int OffsetToString = reader.ReadInt32();
                reader.Seek(pos + OffsetToString);
                string str = reader.ReadNullTerminatedString();
                reader.Seek(pos + 0x8);
                return str;
            };

            //HEADER
            reader.Seek(0x4);
            int nodesOffset = reader.ReadInt32();

            //NODES
            int nextNodeOffset = nodesOffset;
            while (nextNodeOffset>0)
            {
                reader.Seek(nextNodeOffset);
                long nodeStartPos = reader.BaseStream.Position;

                GameObject cnpGo = new GameObject();
                ConnectPoint cnp = cnpGo.AddComponent<ConnectPoint>();

                cnpGo.name = FoxDataStringRead(reader);

                long pos = reader.BaseStream.Position += 0x4;
                int offsetToPayload = reader.ReadInt32();

                reader.Seek(pos + 0x14);
                nextNodeOffset = reader.ReadInt32();
                if (nextNodeOffset>0)
                    nextNodeOffset = (int)(nodeStartPos + nextNodeOffset);
                Debug.Log($"{nodeStartPos}+{nextNodeOffset}={nodeStartPos + nextNodeOffset}");
                int parametersOffset = reader.ReadInt32();

                //payload
                reader.Seek(nodeStartPos + offsetToPayload);
                Transform transform = new Transform();
                transform.translation = reader.ReadPositionF(); reader.BaseStream.Position += 0x4;
                transform.rotation_quat = reader.ReadRotationF();
                transform.scale = reader.ReadVector3(); reader.BaseStream.Position += 0x4;

                string parentNameToSeek=string.Empty;
                //parameters
                while (parametersOffset > 0)
                {
                    reader.Seek(nodeStartPos + parametersOffset);
                    ushort paramType = reader.ReadUInt16();
                    parametersOffset = reader.ReadInt16();
                    if (paramType==1)
                    {
                        string paramName = FoxDataStringRead(reader);
                        parentNameToSeek = FoxDataStringRead(reader);
                    };
                };

                if (parentNameToSeek != null)
                {
                    Debug.Assert(parentNameToSeek != string.Empty, $"Parent name somehow empty");
                }

                GameObject parent = null;

                if (Selection.gameObjects.Length>0)
                {
                    foreach (GameObject selectedGo in Selection.gameObjects)
                    {
                        if (selectedGo.transform.Find(parentNameToSeek))
                        {
                            parent = selectedGo.transform.Find(parentNameToSeek).gameObject;
                            if (parent != null)
                            {
                                break;
                            }
                        }
                    }
                }

                if (parent == null)
                {
                    parent = GameObject.Find(parentNameToSeek);
                }

                if (parent==null)
                {
                    parent = new GameObject(parentNameToSeek);
                }

                cnpGo.transform.SetParent(parent.transform);

                cnpGo.transform.localPosition = transform.translation;
                cnpGo.transform.localRotation = transform.rotation_quat;
                cnpGo.transform.localScale = transform.scale;

                cnps.Add(cnp);
            }

            return cnps.ToArray();
        }
    }
}
