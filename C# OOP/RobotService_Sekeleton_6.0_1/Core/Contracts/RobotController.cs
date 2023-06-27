using RobotService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core.Contracts
{
    public class RobotController
    {
        private readonly RobotRepository robotRepository;

        public RobotController()
        {
            this.robotRepository = new RobotRepository();
        }
    }
}
