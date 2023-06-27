namespace RobotService.Repositories
{
    public class DomesticAssistant : Robot
    {
        private const int DEFAULT_BATTERY_CAPACITY = 20000;
        private const int DEFAULT_CONVERSION_CAPACITY_INDEX = 2000;

        public DomesticAssistant(string model)
            : base(model, DEFAULT_BATTERY_CAPACITY, DEFAULT_CONVERSION_CAPACITY_INDEX)
        {
        }
    }
}
