using System.Globalization;
using System.IO;
using Fox;
using Fox.Fio;
using UnityEngine;

namespace Tpp.GameKit
{
    public sealed class LocatorFileWriter
    {
        private readonly FileStreamReader writer;
        private const double Margin = 0.00001;
        private const short WidePaddingA = 0x109;
        private const short WidePaddingB = 0x2015;
        public static void Write(string locaterFilePath, GameObject locator, string dataSetPathString, bool isPowerCutArea)
        {
            var transform = locator.transform;
            
            var isScale = false;

            using var writer = new BinaryWriter(new FileStream(locaterFilePath, FileMode.Create));
            
            writer.Write(transform.childCount);
            
            //decide 
            if (!isPowerCutArea)
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
                        isScale = true;
                        break;
                    }
                }
            }
    
            //write scale
            if (!isScale)
            {
                if (isPowerCutArea)
                    writer.Write((int)LocatorBinaryType.PowerCutArea);
            }
            else
            {
                writer.Write((int)LocatorBinaryType.Scaled);
            }

            writer.Seek(0x10, SeekOrigin.Begin);
                
            //write transforms
            for (var i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);

                writer.Write(Fox.Math.UnityToFoxVector3(child.transform.position));
                writer.Write(Fox.Math.UnityToFoxQuaternion(child.transform.rotation));
                
                if (isScale)
                {
                    
                    writer.Write(child.transform.localScale);
                    writer.Seek(-sizeof(float), SeekOrigin.Current);
                    writer.Write(WidePaddingA);
                    writer.Write(WidePaddingB);
                }
            };
            
            //write footer names and paths
            if (!isPowerCutArea)
            {
                for (var i = 0; i < transform.childCount; i++)
                {
                    var locatorNameString = transform.GetChild(i).name;
                    var locatorNameHash = int.TryParse(locatorNameString, NumberStyles.HexNumber, null, out var outHash) ? outHash : new StrCode32(locatorNameString).GetHashCode();
                    writer.Write(locatorNameHash);
                    var dataSetPathHash = new PathCode(dataSetPathString).GetHashCode();
                    writer.Write(dataSetPathHash);
                }
            }
        }
    }
}