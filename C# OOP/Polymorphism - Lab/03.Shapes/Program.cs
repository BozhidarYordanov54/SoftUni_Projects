namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            shapes.Add(new Rectangle(10, 20));
            shapes.Add(new Circle(30));

            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.CalculatePerimeter());
                Console.WriteLine(shape.CalculateArea());
                Console.WriteLine(shape.Draw());

            }
        }
    }
}