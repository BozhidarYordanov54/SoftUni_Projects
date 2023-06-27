using P03.DetailPrinter;
using System;
using System.Collections.Generic;

public class Manager : Employee
{
    public IList<string> Documents { get; set; }

    public override void Print()
    {
        Console.WriteLine(Name);
        Console.WriteLine(string.Join(Environment.NewLine, Documents));
    }
}