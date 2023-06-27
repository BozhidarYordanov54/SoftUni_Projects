using System;
using System.Collections.Generic;
using System.Text;

namespace Dice
{
    internal class Dice
    {
        public int DiceSides { get; set; }

        public int Roll(int diceSides)
        {
            Random randomNum = new Random();

            return randomNum.Next(1, diceSides); 
        }
    }
}
