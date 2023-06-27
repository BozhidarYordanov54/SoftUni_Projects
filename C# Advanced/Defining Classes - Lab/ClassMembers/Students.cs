using Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassMembers
{
    internal class Students
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }
        public List<Course> Courses { get; set; }
        
        public void AddCourse(Course course, double grade)
        {
            Courses.Add(course);
        }
        public void Print()
        {
            Console.WriteLine($"{this.FirstName} {this.LastName} at the age of {this.Age} " +
                $"has finished college with grade {this.Grade}");
        }

    }
}
