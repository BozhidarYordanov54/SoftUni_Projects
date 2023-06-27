using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string parantheses = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (var paranthese in parantheses)
            {
                switch (paranthese)
                {
                    case '{':
                    case '(':
                    case '[':
                        stack.Push(paranthese);
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Pop() != '{')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != '[')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;

                    default:
                        break;
                }
            }

            if (stack.Count > 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
