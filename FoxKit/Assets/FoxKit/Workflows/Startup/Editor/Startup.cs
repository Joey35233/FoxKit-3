using UnityEditor;
using UnityEngine;

using FoxKit;

namespace FoxKit.Editor.Startup
{
    [InitializeOnLoad]
    public class Startup
    {
        static Startup()
        {
            var startupState = FoxKit.Config.Internal.FoxKitStartupState.GetInstance();

            if (startupState.ExportConfigPath == null)
            {
                EditorWindow.CreateWindow<Workflows.GetStarted.GetStartedEditorWindow>();
            }
            else
            {

            }
        }
    }
}