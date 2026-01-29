using System.IO;
using Fox;
using Fox.Fio;
using Fox.GameKit;
using UnityEngine;

namespace Tpp.GameKit
{
    public sealed class LocatorFileWriter
    {
        private readonly FileStreamReader writer;
        private const double Margin = 0.00001;
        private const uint PaddingA = 0x7372644D;
        private const uint PaddingB = 0x6E766548;
        public static void Write(string locaterFilePath, GameObject locator, string dataSetPathString, bool useIds)
        {
            var transform = locator.transform;

            LocatorBinaryArrayFile.LocatorBinaryFlags flags = 0;
            
            if (useIds)
                flags |= LocatorBinaryArrayFile.LocatorBinaryFlags.UseIds;

            using var writer = new BinaryWriter(new FileStream(locaterFilePath, FileMode.Create));
            
            writer.Write(transform.childCount);
            
            //decide 
            if (flags.HasFlag(LocatorBinaryArrayFile.LocatorBinaryFlags.UseIds))
            {
                for (var i = 0; i < transform.childCount; i++)
                {
                    var child = transform.GetChild(i);

                    //decide scale
                
                    var absX = Mathf.Abs(child.transform.localScale.x - 1);
                    var absY = Mathf.Abs(child.transform.localScale.y - 1);
                    var absZ= Mathf.Abs(child.transform.localScale.z - 1);
                
                    if (absX>Margin||absY>Margin||absZ>Margin)
                    {
                        flags |= LocatorBinaryArrayFile.LocatorBinaryFlags.UseScale;
                        break;
                    }
                }
            }
            
            //write flags
            
            writer.Write((uint)flags);

            writer.Seek(0x10, SeekOrigin.Begin);
                
            //write transforms
            for (var i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);

                writer.Write(Fox.Math.UnityToFoxVector3(child.transform.position));
                writer.Seek(-sizeof(float), SeekOrigin.Current);
                writer.Write(PaddingA);
                writer.Write(Fox.Math.UnityToFoxQuaternion(child.transform.rotation));
                
                if (flags.HasFlag(LocatorBinaryArrayFile.LocatorBinaryFlags.UseScale))
                {
                    writer.Write(child.transform.localScale);
                    writer.Seek(-sizeof(float), SeekOrigin.Current);
                    writer.Write(PaddingB);
                }
            };
            
            //write footer names and paths
            if (flags.HasFlag(LocatorBinaryArrayFile.LocatorBinaryFlags.UseIds))
            {
                for (var i = 0; i < transform.childCount; i++)
                {
                    StrCode32 locatorNameHash = new StrCode32(transform.GetChild(i).name);
                    writer.WriteStrCode32(locatorNameHash);
                    StrCode32 dataSetPathHash = (StrCode32)(new PathCode(dataSetPathString));
                    writer.WriteStrCode32(dataSetPathHash);
                }
            }
        }
    }
}