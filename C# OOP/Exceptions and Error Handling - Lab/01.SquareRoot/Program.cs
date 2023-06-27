int num = int.Parse(Console.ReadLine());
try
{
    Console.WriteLine($"{(int)Sqrt(num)}");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Goodbye.");
}

double Sqrt(int num)
{
    if (num < 0)
    {
        throw new ArgumentException("Invalid number.");
    }
    return Math.Sqrt(num);
}