﻿namespace Tpp.Effect
{
    public partial class TppGlobalVolumetricFogParam : Fox.Core.DataElement
    {
        private partial bool Get_enable() => flags == 1;
        private partial void Set_enable(bool value) => flags = value ? 1u : 0u;
    }
}
