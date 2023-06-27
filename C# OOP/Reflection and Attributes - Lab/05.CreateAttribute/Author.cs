namespace _05.CreateAttribute
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AuthorAttribute : Attribute
    {
        public AuthorAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
