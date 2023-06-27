using RobotService.Models.Contracts;
using RobotService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core.Contracts
{
    public class Controller : IController
    {
        private readonly RobotRepository robots;
        private readonly SupplementRepository supplements;

        public Controller()
        {
            this.robots = new RobotRepository();
            this.supplements = new SupplementRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            if (typeName != "DomesticAssistant" && typeName != "IndustrialAssistant")
            {
                return $"Robot type {typeName} cannot be created.";
            }

            IRobot robot;
            if (typeName == "DomesticAssistant")
            {
                robot = new DomesticAssistant(model);
            }
            else
            {
                robot = new IndustrialAssistant(model);
            }

            robots.AddNew(robot);
            return $"{typeName} {model} is created and added to the RobotRepository.";
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != "SpecializedArm" && typeName != "LaserRadar")
            {
                return $"{typeName} is not compatible with our robots.";
            }

            ISupplement supplement;
            if (typeName == "SpecializedArm")
            {
                supplement = new SpecializedArm();
            }
            else
            {
                supplement = new LaserRadar();
            }

            supplements.AddNew(supplement);
            return $"{typeName} is created and added to the SupplementRepository.";
        }

        public string PerformService(string serviceName, int interfaceStandard, int totalPowerNeeded)
        {
            return robots.ToString();
        }
        public string Report()
        {
            return null;
        }

        public string RobotRecovery(string model, int minutes)
        {
            throw new NotImplementedException();
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            return null;
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}

