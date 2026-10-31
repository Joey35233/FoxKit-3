namespace Tpp.GameKit
{
	public partial class TppGuardTargetData : Fox.Core.TransformData
	{
        public float Radius => radius;

        public override void Reset()
        {
            base.Reset();
            
            radius = 15;
            memberCount = 4;
        }
    }
}