using System;
using System.Linq;

namespace _05._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = ReadMatrixWithCommas();

            int maxSum = 0;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    int currentSum = 0;

                    if (row >= matrix.GetLength(0) - 1 || col >= matrix.GetLength(1) - 1)
                    {
                        continue;
                    }
                    currentSum += matrix[row, col];
                    currentSum += matrix[row + 1, col];
                    currentSum += matrix[row, col + 1];
                    currentSum += matrix[row + 1, col + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]}");
            Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]}");

            Console.WriteLine(maxSum);
        }

        public static int[,] ReadMatrixWithCommas()
        {
            int[] rowsAndColumns = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

            int rows = rowsAndColumns[0];
            int columns = rowsAndColumns[1];

            int[,] matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = rowData[col];

                }
            }

            return matrix;
        }
    }
}
