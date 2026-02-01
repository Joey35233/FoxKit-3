using MoonSharp.Interpreter;
using System.IO;
using UnityEditor;
using UnityEngine;

public class RunScriptMenuItem
{
    [MenuItem("FoxKit/Run Script")]
    private static void Execute()
    {
        string file = Fox.Fs.FileUtils.OpenFilePanel("Run Lua script", "", "lua");
        if (file.Length == 0)
        {
            return;
        }

        _ = UserData.RegisterType<UnityEngine.GameObject>();
        _ = UserData.RegisterType<UnityEngine.Transform>();
        _ = UserData.RegisterType<UnityEngine.Vector3>();
        _ = UserData.RegisterType<UnityEngine.Quaternion>();

        string code = File.ReadAllText(file);

        var script = new Script();
        script.Globals["GameObject"] = typeof(GameObject);
        script.Globals["Vector3"] = typeof(Vector3);
        script.Globals["Quaternion"] = typeof(Quaternion);
        script.Options.DebugPrint = UnityEngine.Debug.Log;

        DynValue res = script.DoString(code);
    }
}
