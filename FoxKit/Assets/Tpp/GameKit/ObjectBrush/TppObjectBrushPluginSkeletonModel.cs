using Fox.Core.Utils;
using Fox.Fio;
using UnityEngine;

namespace Tpp.GameKit
{
    public partial class TppObjectBrushPluginSkeletonModel : Fox.GameKit.ObjectBrushPlugin
    {
        public static TppObjectBrushPluginSkeletonModel Deserialize(FileStreamReader reader)
        {
            var plugin = new TppObjectBrushPluginSkeletonModel();

            return plugin;
        }
    }
}
