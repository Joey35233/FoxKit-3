namespace Tpp.GameKit
{
	public partial class TppGuardTargetData : Fox.Core.TransformData
	{
        public override void Reset()
        {
            base.Reset();
            
            radius = 15;
            memberCount = 4;
        }
    }
}