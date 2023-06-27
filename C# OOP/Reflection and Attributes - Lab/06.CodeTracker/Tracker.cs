using _05.CreateAttribute;
using AuthorProblem;
using System.Reflection;

namespace _06.CodeTracker
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
                {
                    Attribute[] attributes = (Attribute[])method.GetCustomAttributes(typeof(AuthorAttribute), false);

                    foreach (AuthorAttribute author in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {author.Name}");
                    }
                }
            }
        }
    }
}
