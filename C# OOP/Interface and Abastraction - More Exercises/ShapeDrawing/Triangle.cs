public class Triangle : IDrawable
{
    private const char symbol = '*';
    public int Size { get; set; }
    public Triangle(int size)
    {
        Size = size;
    }
    public void Draw()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < i + 1; j++)
            {
                Console.Write(symbol);
            }
            Console.WriteLine();
        }
    }
}
