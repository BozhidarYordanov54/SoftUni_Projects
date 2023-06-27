using System;
using Create_Custom_Data_Structures;

namespace Create_Custom_Data_Structures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList customList = new CustomList();
            customList.Add(5);
            customList.Add(6);
            customList.Add(7);
            customList.Add(8);
            customList.Add(9);

            customList.RemoveAt(5);

            customList.InsertAt(1, 5);

            customList.Contains(5);

            customList.Swap(1, 3);

            for (int i = 0; i < customList.Count; i++)
            {
                Console.WriteLine(customList[i]);
            }
        }
    }
}
