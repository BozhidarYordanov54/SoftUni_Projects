using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            students = students.OrderBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                string studentName = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new List<decimal>());
                }

                students[studentName].Add(grade);
            }

            foreach (var studentGrade in students)
            {
                Console.WriteLine($"{studentGrade.Key} -> {string.Join(" ", studentGrade.Value.Select(x => $"{x:f2}").ToList())} (avg: {studentGrade.Value.Average():f2})");
            }
        }
    }
}
