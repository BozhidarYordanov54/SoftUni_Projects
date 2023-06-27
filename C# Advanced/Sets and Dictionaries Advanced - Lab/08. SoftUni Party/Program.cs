using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests= new List<string>();
            string command = string.Empty;

            bool end = false;

            while (!end)
            {
                command = Console.ReadLine();
                

                if (command == "PARTY")
                {
                    string guestsComing = string.Empty;
                    while (guestsComing != "END")
                    {
                        guestsComing = Console.ReadLine();

                        if (guestsComing == "END")
                        {
                            end = true;
                            break;
                        }

                        guests.Remove(guestsComing);
                    }
                }
                else
                {
                    guests.Add(command);
                }

                
            }

            Console.WriteLine(guests.Count);

            guests.OrderByDescending(x => x);

            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
