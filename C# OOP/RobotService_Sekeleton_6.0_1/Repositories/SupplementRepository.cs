using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System;
using System.Linq;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private readonly List<ISupplement> supplements;

        public SupplementRepository()
        {
            supplements = new List<ISupplement>();
        }

        public IReadOnlyCollection<ISupplement> Models()
        {
            return supplements.AsReadOnly();
        }

        public void AddNew(ISupplement model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Model cannot be null.");
            }

            supplements.Add(model);
        }

        public bool RemoveByName(string supplementName)
        {
            ISupplement supplement = supplements.FirstOrDefault(s => s.GetType().Name == supplementName);

            if (supplement == null)
            {
                return false;
            }

            supplements.Remove(supplement);
            return true;
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            foreach (ISupplement supplement in supplements)
            {
                if (supplement.InterfaceStandard == interfaceStandard)
                {
                    return supplement;
                }
            }

            return null;
        }
    }
}
