using UnityEditor;
using MoonSharp.Interpreter;
using System.IO;
using UnityEngine;

public class RunScriptMenuItem
{
    [MenuItem("FoxKit/Run Script")]
    static void Execute()
    {
		var file = EditorUtility.OpenFilePanel("Run Lua script", "", "lua");
		if (file.Length == 0)
		{
			return;
		}

		UserData.RegisterType<UnityEngine.GameObject>();
		UserData.RegisterType<UnityEngine.Transform>();
		UserData.RegisterType<UnityEngine.Vector3>();
		UserData.RegisterType<UnityEngine.Quaternion>();

		var code = File.ReadAllText(file);

		var script = new Script();
		script.Globals["GameObject"] = typeof(GameObject);
		script.Globals["Vector3"] = typeof(Vector3);
		script.Globals["Quaternion"] = typeof(Quaternion);
		script.Options.DebugPrint = UnityEngine.Debug.Log;
				
		DynValue res = script.DoString(code);
	}
}
