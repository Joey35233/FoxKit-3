namespace Tpp.GameKit
{
	public partial class TppCombatLocatorData : Fox.Core.TransformData
	{
        public override void Reset()
        {
            base.Reset();
            
            radius = 10;
            lostSearchRadius = 45;
            memberCount = 2;
            memberCountFront = 4;
        }
    }
}