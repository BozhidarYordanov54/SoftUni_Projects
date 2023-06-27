

namespace Telephony
{
    public class SmartPhone : ISmartPhone
    {
        public SmartPhone()
        {
            
        }
        public void Browse(string url)
        {
            if (url.Any(char.IsDigit))
            {
                throw new ArgumentException("Invalid url!");
                
            }
            Console.WriteLine($"Browsing: {url}!");
        }

        public void Call(string number)
        {
            if(!number.All(char.IsDigit))
            {
                throw new ArgumentException("Invalid number!");
            }
            Console.WriteLine($"Calling... {number}");
        }
    }

}