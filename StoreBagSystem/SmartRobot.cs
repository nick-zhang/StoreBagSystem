using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public class SmartRobot : AbstractRobot
    {
        public SmartRobot(IList<Cabinet> cabinets) : base(cabinets)
        {
        }

        public override Ticket Store(Bag bag)
        {
            var cabinetWithMostAvailableBoxes = Cabinets.OrderByDescending(cabinet => cabinet.AvailableBoxes()).First();
            return cabinetWithMostAvailableBoxes.Store(bag);
        }
    }
}