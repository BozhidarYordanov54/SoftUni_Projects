﻿

namespace Stealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();
            Console.WriteLine(spy.RevealPrivateMethods("Stealer.Hacker"));
        }
    }
}