

namespace Telephony
{
    public class StationaryPhone : IPhone
    {
        public void Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                throw new ArgumentException("Invalid number!");
            }
            Console.WriteLine($"Dialing... {number}");
        }
    }

}