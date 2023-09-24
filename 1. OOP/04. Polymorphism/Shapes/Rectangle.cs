namespace Shapes
{
    public class Rectangle : Shape
    {
        private double width;

        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public sealed override double CalculateArea()
            => width * height;

        public sealed override double CalculatePerimeter()
            => 2 * (width + height);

        public override string Draw()
            => base.Draw() + "rectangle";
    }
}
