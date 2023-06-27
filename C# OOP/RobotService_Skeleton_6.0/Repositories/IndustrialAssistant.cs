namespace RobotService.Repositories
{
    public class IndustrialAssistant : Robot
    {
        private const int InitialBatteryLevel = 40_000;
        private const int ConversionCapacityIndex = 5_000;
        private const int ConstBatteryCapacity = 40_000;

        public IndustrialAssistant(string model)
            : base(model, ConstBatteryCapacity, ConversionCapacityIndex)
        {
            this.BatteryLevel = InitialBatteryLevel;
        }
    }
}
