using Classes;
using System;
using System.Collections.Generic;

namespace Classes___Mid
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Student gosho = new Student()
            {
                FirstName = "Gosho",
                LastName = "Ivanov",
                Age = 20,
                Grade = 2,
                Courses = new List<Course>()
            };

            gosho.Courses.Add(new Course()
            {
                Name = "C# Advanced",
                StartDate = DateTime.Now.AddDays(60),
                EndDate = DateTime.Now.AddDays(120),
                Lecturer = "Victor Dakov",

            });

            gosho.Courses.Add(new Course
            {
                Name = "C# OOP",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(60),
                Lecturer = "Victor Dakov",
            });

            PrintStudent(gosho);

            List<Student> students = new List<Student>();

            students.Add(new Student()
            {
                FirstName = "Goshko"
            });

            students.Add(new Student()
            {
                FirstName = "Dimitichko"
            });

            students.Add(new Student()
            {
                FirstName = "Niki"
            });

            foreach (var item in students)
            {
                Console.WriteLine(item.FirstName);
            }
        }
        static void PrintStudent(Student student)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName} at the age of {student.Age} " +
                $"has finished college with grade {student.Grade}");

            Console.WriteLine();

            if (student.Courses.Count > 0)
            {
                foreach (var course in student.Courses)
                {
                    Console.WriteLine($"{student.FirstName} is studying: {course.Name} starting " +
                    $"{course.StartDate:Y} ending {course.EndDate:Y} with lecturer {course.Lecturer}");
                }
            }
        }
    }
}
