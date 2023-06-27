namespace Cars
{
    public class Seat : ICar
    {
        public Seat(string make, string color)
        {
            Model = make;
            Color = color;
        }
        public string Model { get ; set ; }
        public string Color { get ; set ; }

        public override string ToString()
        {
            return $"{Color} Seat {Model}";
        }
    }
}
