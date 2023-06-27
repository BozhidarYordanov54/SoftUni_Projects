using System;

namespace _07._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long triangleSize = long.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[triangleSize][];

            for (int i = 0; i < triangleSize; i++)
            {
                pascalTriangle[i] = new long[triangleSize + 1];

                for (int j = 0; j < i + 1; j++)
                {
                    if (j > 0 && j < pascalTriangle[i].Length - 1)
                    {
                        pascalTriangle[i][j] = pascalTriangle[i - 1][j - 1] + pascalTriangle[i - 1][j];
                    }
                    else
                    {
                        pascalTriangle[i][j] = 1;
                    }
                }
            }

            for (int i = 0; i < triangleSize; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    if (pascalTriangle[i][j] != 0)
                    {
                        Console.Write($"{pascalTriangle[i][j]} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
