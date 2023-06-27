using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System;
using System.Linq;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private readonly List<IRobot> robots;

        public RobotRepository()
        {
            robots = new List<IRobot>();
        }

        public IReadOnlyCollection<IRobot> Models()
        {
            return robots.AsReadOnly();
        }

        public void AddNew(IRobot model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model cannot be null.");
            }

            robots.Add(model);
        }

        public bool RemoveByName(string robotName)
        {
            IRobot robot = robots.FirstOrDefault(r => r.Model == robotName);

            if (robot == null)
            {
                return false;
            }

            robots.Remove(robot);
            return true;
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            return robots.FirstOrDefault(r => r.BatteryLevel >= (r.BatteryCapacity * interfaceStandard) / 100);
        }
    }
}
