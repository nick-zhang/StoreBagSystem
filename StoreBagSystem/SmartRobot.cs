using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public class SmartRobot
    {
        private readonly IList<Cabinet> cabinets;

        public SmartRobot(IList<Cabinet> cabinets)
        {
            this.cabinets = cabinets;
        }

        public Ticket Store(Bag bag)
        {
            var cabinetWithMostAvailableBoxes = cabinets.OrderByDescending(cabinet => cabinet.AvailableBoxes()).First();
            return cabinetWithMostAvailableBoxes.Store(bag);
        }
    }
}