namespace DrawShapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            // first line
            DrawOutherRow();

            // middle lines
            for (int i = 0; i < height - 2; i++)
            {
                DrawMiddleRow();
            }

            // last line
            DrawOutherRow();
        }

        private void DrawOutherRow()
        {
            Console.WriteLine(new string('*', width));
        }

        private void DrawMiddleRow()
        {
            Console.Write("*");
            Console.Write(new string(' ', width - 2));
            Console.WriteLine("*");
        }
    }
}
