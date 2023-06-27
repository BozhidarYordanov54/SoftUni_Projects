using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            int[] rowAndColumn = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int rows = rowAndColumn[0];
            int columns = rowAndColumn[1];

            int[,] matrix = new int[rows, columns];

            int[] matrixSumCols = new int[columns];

            //Filling matrix
            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            //Summing columns
            for (int col = 0; col < columns; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    sum += matrix[row, col];
                }
                matrixSumCols[col] = sum;
                sum = 0;
            }

            foreach (int colSum in matrixSumCols)
            {
                Console.WriteLine(colSum);
            }
        }
    }
}
