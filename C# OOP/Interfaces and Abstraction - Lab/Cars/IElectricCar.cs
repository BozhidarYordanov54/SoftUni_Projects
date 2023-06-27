namespace Cars
{
    public interface IElectricCar : ICar
    {
        int BatteryCount { get; set; }
    }
}
