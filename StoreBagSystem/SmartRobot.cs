using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public class SmartRobot : IStoreable
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

        public Bag Pick(Ticket ticket)
        {
            return cabinets.Select(cabinet => cabinet.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }
    }
}