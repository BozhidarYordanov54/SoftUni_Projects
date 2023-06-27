int[] numbers = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();

int exceptionCount = 0;

while (exceptionCount != 3)
{
    string[] cmdArgs = Console.ReadLine()
        .Split(" ");

    string command = cmdArgs[0];
    try
    {
        switch (command)
        {
            case "Replace":
                Replace(numbers, cmdArgs);
                break;
            case "Print":
                Print(numbers, cmdArgs);
                break;
            case "Show":
                Show(numbers, cmdArgs);
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("The variable is not in the correct format!");
        exceptionCount++;
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("The index does not exist!");
        exceptionCount++;
    }
}

Console.WriteLine(string.Join(", ", numbers));
static void Replace(int[] numbers, string[] cmdArgs)
{
    int index = int.Parse(cmdArgs[1]);
    int element = int.Parse(cmdArgs[2]);

    numbers[index] = element;
}

static void Print(int[] numbers, string[] cmdArgs)
{
    int startIndex = int.Parse(cmdArgs[1]);
    int endIndex = int.Parse(cmdArgs[2]);

    if (startIndex < 0 || endIndex >= numbers.Length || startIndex > endIndex)
    {
        throw new IndexOutOfRangeException();
    }

    for (int i = startIndex; i <= endIndex; i++)
    {
        Console.Write(numbers[i]);
        if (i < endIndex)
        {
            Console.Write(", ");
        }
    }

    Console.WriteLine();
}
static void Show(int[] numbers, string[] cmdArgs)
{
    int index = int.Parse(cmdArgs[1]);

    Console.WriteLine(numbers[index]);
}