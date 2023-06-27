int start = 1;
int end = 100;

int[] numArr = new int[10];

for (int i = 0; i < 10; i++)
{
	try
	{

		numArr[i] = ReadNumber(start, end);
		start = numArr.First();
	}
	catch (ArgumentException ex)
	{
        Console.WriteLine(ex.Message);
		i--;
    }
}
Console.WriteLine(string.Join(", ", numArr));
static int ReadNumber(int start, int end)
{
	int number;
    if (!int.TryParse(Console.ReadLine(), out number))
    {
        throw new ArgumentException("Invalid Number!");
    }

	if (number <= start || number >= end)
	{
		throw new ArgumentException($"Your number is not in range {start} - 100!");

    }

	return number;
}