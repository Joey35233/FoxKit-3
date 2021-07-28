using System;

namespace Fox.Ui
{
    [Serializable]
    public class LangFileEntry
    {
        public uint Key;
        public string LangId;
        public short Color;
        public string Value;
    }
}