using System;
using System.Xml.Serialization;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IDrawable circle = new Circle(3);
            IDrawable rectangle = new Rectangle(4, 5);

            List<IDrawable> shapes = new List<IDrawable>();
            shapes.Add(circle);
            shapes.Add(rectangle);

            foreach (IDrawable shape in shapes)
            {
                shape.Draw();
            }
            
        }
    }
}
