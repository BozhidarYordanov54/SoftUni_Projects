public class Rectangle : IDrawable
{
    private char symbol = '*';
    private int lenght;
    private int height;
    public Rectangle(int lenght, int height)
    {
        Width = lenght;
        Height = height;
    }
    public int Height
    { 
        get { return height; } 
        set { height = value; }
    }

    public int Width
    {
        get { return lenght; }
        set { lenght = value; }
    }

    public void Draw()
    {
        for (int j = 0; j < 0 + this.Height; j++)
        {
            for (int i = 0; i < 0 + this.Width; i++)
            {
                Console.Write(this.symbol);
            }
            Console.WriteLine();
        }
    }
}
