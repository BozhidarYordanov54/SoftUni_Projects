namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ");
            string[] urls = Console.ReadLine().Split(" ");

            foreach (string phoneNumber in phoneNumbers) 
            {
                if (phoneNumber.Length == 10)
                {
                    ISmartPhone smartphone = new SmartPhone();
                    smartphone.Call(phoneNumber);
                }
                else if (phoneNumber.Length == 7) 
                { 
                    IPhone stationaryPhone = new StationaryPhone();
                    stationaryPhone.Call(phoneNumber);
                }
            }

            foreach (string url in urls) 
            {
                smartPhone.Browse(url);
            }
        }
    }
}