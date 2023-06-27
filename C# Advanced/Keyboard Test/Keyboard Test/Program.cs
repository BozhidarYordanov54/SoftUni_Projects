using System;

namespace Keyboard_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int randomNumber = random.Next(0, 99);

            int numberInput = int.Parse(Console.ReadLine());

            while (numberInput != randomNumber)
            {
                if (numberInput > randomNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (numberInput < randomNumber)
                {
                    Console.WriteLine("Higher");
                }

                numberInput = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("you won! congrats");
        }
    }
}
