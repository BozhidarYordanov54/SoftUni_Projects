using System;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[matrixSize[0], matrixSize[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] matrixData = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = matrixData[col];
                }
            }

            string cmdArgs = string.Empty;
            while ((cmdArgs = Console.ReadLine()) != "END")
            {
                string[] tokens = cmdArgs.Split(" ");
                string command = tokens[0];
                int rowSelect = int.Parse(tokens[1]);
                int colSelect = int.Parse(tokens[2]);
                int rowSwap = int.Parse(tokens[3]);
                int colSwap = int.Parse(tokens[4]);

                if (tokens.Length < 4) 
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
    }
}
