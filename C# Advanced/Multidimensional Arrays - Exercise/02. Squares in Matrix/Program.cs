using System;
using System.Linq;

namespace _02._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] matrix = ReadingMatrix();

            int count = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] 
                        && matrix[row, col] == matrix[row + 1, col + 1]
                        && matrix[row, col] == matrix[row + 1, col]) 
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }

        private static string[,] ReadingMatrix()
        {
            int[] matrixSize = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            string[,] matrix = new string[matrixSize[0], matrixSize[1]];

            //Filling the matrix
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] matrixContent = Console.ReadLine()
                .Split(' ');
                
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixContent[col];
                }
            }

            return matrix;
        }
    }
}
