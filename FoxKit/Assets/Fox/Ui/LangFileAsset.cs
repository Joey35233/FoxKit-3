using System.Collections.Generic;
using UnityEngine;

namespace Fox.Ui
{
    public class LangFileAsset : ScriptableObject
    {
        public List<LangFileEntry> Entries = new();
    }
}