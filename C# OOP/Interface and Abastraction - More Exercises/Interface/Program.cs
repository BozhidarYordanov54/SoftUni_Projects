
namespace Interface
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IShape circle = new Circle(5);
            Console.WriteLine($"Circle area: {circle.GetArea():f2}");
            Console.WriteLine($"Circle perimeter: {circle.GetPerimeter():f2}");

            IShape rectangle = new Rectangle(3, 4);
            Console.WriteLine($"Rectangle area: {rectangle.GetArea()}");
            Console.WriteLine($"Rectangle perimeter: {rectangle.GetPerimeter()}");
        }
    }
    public class Rectangle : IShape
    {
        public Rectangle(double lenght, double width)
        {
            Lenght = lenght;
            Width = width;
        }

        public double Lenght { get; private set; }
        public double Width { get; private set; }

        public double GetArea()
        {
            return Lenght * Width;
        }

        public double GetPerimeter()
        {
            return 2 * (Lenght + Width);
        }
    }

    public class Circle : IShape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double Radius { get; private set; }
        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
    public interface IShape
    {
        public double GetPerimeter();
        public double GetArea();
    }
}