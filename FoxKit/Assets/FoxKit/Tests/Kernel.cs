using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;
using Fox;

namespace FoxKit.Tests
{
    public class Kernel
    {
        [Test]
        public void BasicStringTests()
        {
            StrCode hash;
            string hashStr;
                
            // Empty string is valid
            hash = StrCode.Empty;
            Assert.True(hash == 0x0000b8a0bf169f98);
            Assert.True(hash == "");
            hashStr = hash.ToString();
            Assert.True(hashStr == "0x0000b8a0bf169f98");

            hash = new StrCode("teststring");
            Assert.True(hash == 0x00002495e3f32bfb);
            Assert.True(hash == "teststring");
            Assert.True(hash == "0x2495e3f32bfb");
            hashStr = hash.ToString();
            Assert.True(hashStr == "0x00002495e3f32bfb");
            Assert.True(hash == hashStr);
        }
        
        [Test]
        public void BasicPathCodeTests()
        {
            string pathStr; 
            Path path;
            Path pathHash;

            pathStr = "/Assets/tpp/common_source/environ/mother_base/cm_mtbs_fndt002/sourceimages/cm_mtbs_fndt002_c02_bsm.ftex";
            path = new Path(pathStr);
            pathHash = new Path("0x15690228b7b6ce7d");
            Assert.True(path == pathHash);
            Assert.True(path == pathStr);
            Assert.True(path == "0x15690228b7b6ce7d");
            Assert.False(path == "0x25690228b7b6ce72");
            Assert.True(path.Hash == 0x15690228b7b6ce7d);
            
            pathStr = "shaders/dx11/FxShaders_dx11.fsop";
            path = new Path(pathStr);
            pathHash = new Path("0x2cffdf4ce624a964");
            Assert.True(path == pathHash);
            Assert.True(path == pathStr);
            Assert.True(path == "0x2cffdf4ce624a964");
            Assert.False(path == "2cffdf4ce624a964");
            Assert.False(path == "0x3cffdf4ce624a963");
            Assert.False(path == "0x1cffdf4ce624a964");
            Assert.True(path.Hash == 0x2cffdf4ce624a964);

            pathStr = "DATA_IDENTIFIER";
            path = new Path(pathStr);
            pathHash = new Path("0x0007843CE63073DB");
            Assert.True(path == pathHash);
            Assert.True(path == pathStr);
            Assert.True(path == "0x0007843CE63073DB");
            Assert.True(path.Hash == 0x0007843CE63073DB);
            Assert.True(path == "DATA_IDENTIFIER");
            
            Assert.True(new Path("foxfs.dat").Hash == 0xAC8445ADA1C810E4);
            
            Assert.True(new Path("Fox/Scripts/Classes/Entity.lua").Hash == 0x18E5DD353BFA3060);
            
            Assert.True(new PathCode("init.lua") == 0x18E72BE6EC606799);
        }
    }
}