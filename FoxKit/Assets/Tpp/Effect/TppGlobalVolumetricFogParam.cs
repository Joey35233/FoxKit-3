namespace Tpp.Effect
{
    public partial class TppGlobalVolumetricFogParam : Fox.Core.DataElement
    {
        private partial bool enable_Get() => flags == 1;
        private partial void enable_Set(bool value) => flags = value ? 1u : 0u;
    }
}
