namespace Cars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ICar seat = new Seat("Leon", "Gray");
            ICar tesla = new Tesla("Model 3", "Red", 2);

            Console.WriteLine(seat.ToString());
            Console.WriteLine(seat.Start());
            Console.WriteLine(seat.Stop());

            Console.WriteLine(tesla.ToString());
            Console.WriteLine(tesla.Start());
            Console.WriteLine(tesla.Stop());
        }
    }
    public class Tesla : IElectricCar
    {
        public Tesla(string model, string color, int batteryCount)
        {
            Model = model;
            Color = color;
            BatteryCount = batteryCount;
        }
        public int BatteryCount { get ; set; }
        public string Model { get ; set ; }
        public string Color { get ; set ; }

        public override string ToString()
        {
            return $"{Color} Tesla Model {Model} with {BatteryCount} Batteries";
        }
    }
}
