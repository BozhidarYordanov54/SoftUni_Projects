using System.Drawing;

IDrawable rectangle = new Rectangle(10, 4);
IDrawable triangle = new Triangle(5);

rectangle.Draw();
Console.WriteLine();
triangle.Draw();

public class Circle : IDrawable
{
    double 
    public void Draw()
    {
        throw new NotImplementedException();
    }
}