using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }
        public List<Course> Courses { get; set; }
    }
}
