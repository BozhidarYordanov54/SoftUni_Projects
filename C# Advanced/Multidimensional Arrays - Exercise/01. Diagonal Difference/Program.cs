using System;
using System.Globalization;
using System.Linq;

namespace _01._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            int[,] matrix = new int[sizeOfMatrix, sizeOfMatrix];

            //Filling the matrix
            for (int row = 0; row < sizeOfMatrix; row++)
            {
                int[] matrixFill = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < sizeOfMatrix; col++)
                {
                    matrix[row, col] = matrixFill[col];
                }
            }

            int sumPrimaryDiagonal = SumPrimaryDiagonal(matrix);

            int sumSecondaryDiagonal = SumSecondaryDiagonal(matrix);

            Console.WriteLine(Math.Abs(sumPrimaryDiagonal - sumSecondaryDiagonal));
        }

        private static int SumPrimaryDiagonal(int[,] matrix)
        {
            int sumPrimaryDiagonal = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        sumPrimaryDiagonal += matrix[row, col];
                    }
                }
            }

            return sumPrimaryDiagonal;
        }

        private static int SumSecondaryDiagonal(int[,] matrix)
        {
            int sumSecondaryDiagonal = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if ((row + col) == (matrix.GetLength(0) - 1))
                    {
                        sumSecondaryDiagonal += matrix[row, col];
                    }
                }
            }

            return sumSecondaryDiagonal;
        }
    }
}
