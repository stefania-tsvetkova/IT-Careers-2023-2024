namespace Shapes
{
    public class Square : Rectangle
    {
        public Square(double width)
            : base(width, width)
        { }

        public override string Draw()
            => base.Draw() + " that is square";
    }
}
