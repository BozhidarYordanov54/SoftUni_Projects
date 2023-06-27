using P03.Detail_Printer;
using System;

namespace P03.DetailPrinter
{
    public abstract class Employee : IPrintable
    {
        public string Name { get; set; }

        public virtual void Print()
        {
            Console.WriteLine(Name);
        }
    }
}
