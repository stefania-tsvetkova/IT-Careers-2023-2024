namespace DrawShapes
{
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            for (int x = 0; x < 2 * radius + 1; x++)
            {
                for (int y = 0; y < 2 * radius + 1; y++)
                {
                    Console.Write(IsPointOnCirclePerimeter(x, y) ? '*' : ' ');
                }

                Console.WriteLine();
            }
        }

        private bool IsPointOnCirclePerimeter(int x, int y)
        {
            int width = (x - radius) * (x - radius);
            int heigth = (y - radius) * (y - radius);
            double r = Math.Sqrt(width + heigth);

            return Math.Abs(r - radius) < 0.5;
        }
    }
}
