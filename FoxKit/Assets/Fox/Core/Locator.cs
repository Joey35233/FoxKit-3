namespace Fox.Core
{
    public partial class Locator : TransformData
    {
        public float Size { get => size; set => size = value; }

        public override void Reset()
        {
            base.Reset();
            size = 1;
        }
    }
}