using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rowsAndCols, rowsAndCols];

            for (int rows = 0; rows < rowsAndCols; rows++)
            {
                string input = Console.ReadLine();
                char[] rowData= input.ToCharArray();

                for (int cols = 0; cols < rowsAndCols; cols++)
                {
                    matrix[rows, cols] = rowData[cols];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool isFound = false;

            for (int rows = 0; rows < rowsAndCols; rows++)
            {
                for (int cols = 0; cols < rowsAndCols; cols++)
                {
                    if (matrix[rows,cols] == symbol)
                    {
                        Console.WriteLine($"({rows}, {cols})");
                        isFound = true;
                    }
                }

                if (isFound)
                {
                    return;
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
