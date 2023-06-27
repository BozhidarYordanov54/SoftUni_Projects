using System;

namespace Dice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dice diceD6 = new Dice();

            diceD6.DiceSides = 6;

            Dice diceD2 = new Dice();

            diceD2.DiceSides = 2;

            Console.WriteLine(diceD6.Roll(diceD6.DiceSides)); 
        }
    }
}
