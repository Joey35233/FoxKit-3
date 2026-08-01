namespace Fox.Geo
{
	public partial class GeoTrap : Fox.Core.TransformData
	{
        public override void Reset()
        {
            base.Reset();
            
            enable = true;
        }
    }
}