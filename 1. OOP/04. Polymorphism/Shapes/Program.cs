using Shapes;

Circle circle = new Circle(2);
Circle circle1 = new Circle(5);

Rectangle rectangle = new Rectangle(2, 3);
Rectangle rectangle1 = new Rectangle(10, 15);

Square square = new Square(5);

List<Shape> shapes = new List<Shape>();
shapes.Add(circle);
shapes.Add(circle1);
shapes.Add(rectangle);
shapes.Add(rectangle1);
shapes.Add(square);

foreach (Shape shape in shapes)
{
    Console.WriteLine(shape.Draw());
    Console.WriteLine(shape.CalculatePerimeter());
    Console.WriteLine(shape.CalculateArea());
    Console.WriteLine();
}