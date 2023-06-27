using System;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Course csharpAdvanced = new Course();
            {
                csharpAdvanced.Name = "C# Advanced";
                csharpAdvanced.StartDate = DateTime.Now;
                csharpAdvanced.EndDate = DateTime.Now.AddDays(60);
                csharpAdvanced.Lecturer = "Victor Dakov";
            }

            Student student = new Student();
            {
                student.FirstName = "Petar";
                student.LastName = "Petrov";
                student.Age = 18;
                student.Grade = 5.5;
                student.Course = csharpAdvanced;
            }

            PrintStudent(student);
        }

        static void PrintStudent(Student student)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName} at the age of {student.Age} " +
                $"has finished college with grade {student.Grade}");

            Console.WriteLine();

            if (student.Course != null)
            {
                Console.WriteLine($"{student.FirstName} is studying: {student.Course.Name} starting " +
                    $"{student.Course.StartDate:Y} ending {student.Course.EndDate:Y} with lecturer {student.Course.Lecturer}");
            }
        }
    }
}
