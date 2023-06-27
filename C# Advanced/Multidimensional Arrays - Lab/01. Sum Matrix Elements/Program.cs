using System;
using System.Linq;

namespace _01._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            int[] rowsAndCols = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            
            int rows = rowsAndCols[0];
            int columns = rowsAndCols[1];

            int[ , ] matrix = new int[rows, columns];

            int[] matrixData = new int[3];
            matrixData[0] = rows;
            matrixData[1] = columns;
            matrixData[2] = sum;
            

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = rowData[col];
                    sum += rowData[col];
                }
            }

            matrixData[2] = sum;

            foreach (var item in matrixData)
            {
                Console.WriteLine(item);
            }
        }
    }
}
