using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            Stack<string> changes = new Stack<string>();

            string text = string.Empty;

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ');
                string command = cmdArgs[0];

                switch (command)
                {
                    case "1":
                        changes.Push(text);
                        text += cmdArgs[1];
                        break;
                    case "2":
                        changes.Push(text);
                        int count = int.Parse(cmdArgs[1]) - 1;
                        text = text.Remove(text.Length - count);
                        break;
                    case "3":
                        int index = int.Parse(cmdArgs[1]);
                        Console.WriteLine(text[index]);
                        break;
                    case "4":
                        text = changes.Pop();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
