using GenericArrayCreator;
using System;

namespace _02._Array_Creator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] peshos = ArrayCreator.Create(5, "Pesho");

            Console.WriteLine(string.Join(" ", peshos));

            int[] numbers = ArrayCreator.Create(10, 1);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
