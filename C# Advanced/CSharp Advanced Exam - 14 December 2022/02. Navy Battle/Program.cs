using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Navy_Battle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());
            char[,] battleField = new char[sizeOfField, sizeOfField];

            int x = 0, y = 0;

            for (int i = 0; i < sizeOfField; i++)
            {
                string map = Console.ReadLine();   
                for (int j = 0; j < sizeOfField; j++)
                {
                    battleField[i, j] = map[j];

                    if (battleField[i, j] == 'S')
                    {
                        x = i;
                        y = j;
                    }
                }
            }
            int[,] subCoordtines = new int[x, y];
            battleField[x, y] = '-';

            //Game logic
            int lives = 3;
            int commandos = 3;

            bool isAlive = true;

            while (commandos != 0)
            {
                string direction = Console.ReadLine();

                switch (direction)
                {
                    case "right":
                        y++;
                        break;
                    case "left":
                        y--;
                        break;
                    case "up":
                        x--;
                        break;
                    case "down":
                        x++;
                        break;
                }

                if (battleField[x, y] == '*')
                {
                    lives--;
                    battleField[x, y] = '-';

                    if (lives == 0)
                    {
                        isAlive = false;
                        break;
                    }
                }

                if (battleField[x, y] == 'C')
                {
                    commandos--;
                    battleField[x, y] = '-';
                }
            }

            if (isAlive)
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
            }
            else
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{x}, {y}]!");
            }

            battleField[x, y] = 'S';
            for (int i = 0; i < sizeOfField; i++)
            {
                for (int j = 0; j < sizeOfField; j++)
                {
                    Console.Write(battleField[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
