namespace RobotService
{
    using RobotService.Core;
    using RobotService.Core.Contracts;
    using RobotService.Models.Contracts;
    using RobotService.Repositories;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
