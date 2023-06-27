using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Repositories
{
    public abstract class Robot : IRobot
    {
        private const string DefaultMessage = "{0} - {1} {2}";

        private string model;
        private int batteryCapacity;
        private int batteryLevel;

        protected Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            this.Model = model;
            this.BatteryCapacity = batteryCapacity;
            this.BatteryLevel = batteryCapacity;
            this.ConvertionCapacityIndex = conversionCapacityIndex;
            this.InterfaceStandards = new List<int>();
        }

        public string Model
        {
            get => this.model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be null or empty.");
                }

                this.model = value;
            }
        }

        public int BatteryCapacity
        {
            get => this.batteryCapacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Battery capacity cannot drop below zero.");
                }

                this.batteryCapacity = value;
            }
        }

        public int BatteryLevel
        {
            get => this.batteryLevel;
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > this.BatteryCapacity)
                {
                    value = this.BatteryCapacity;
                }

                this.batteryLevel = value;
            }
        }

        public int ConvertionCapacityIndex { get; private set; }

        public IReadOnlyCollection<int> InterfaceStandards { get; private set; }

        public void Eating(int minutes)
        {
            int producedEnergy = this.ConvertionCapacityIndex * minutes;
            int currentBatteryLevel = this.BatteryLevel;

            if (currentBatteryLevel + producedEnergy > this.BatteryCapacity)
            {
                this.BatteryLevel = this.BatteryCapacity;
            }
            else
            {
                this.BatteryLevel += producedEnergy;
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (this.BatteryLevel >= consumedEnergy)
            {
                this.BatteryLevel -= consumedEnergy;
                return true;
            }

            return false;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            this.InterfaceStandards = this.InterfaceStandards.Append(supplement.BatteryUsage).ToList();
            this.BatteryCapacity -= supplement.BatteryUsage;
            this.BatteryLevel -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string standardsString = this.InterfaceStandards.Any() ? string.Join(" ", this.InterfaceStandards) : "none";

            sb.AppendLine(string.Format(DefaultMessage, this.GetType().Name, this.Model, ""))
              .AppendLine($"-- Maximum Energy Capacity: {this.BatteryCapacity}")
              .AppendLine($"-- Energy: {this.BatteryLevel}")
              .AppendLine($"-- Modules: {standardsString}");

            return sb.ToString().TrimEnd();
        }
    }
}
