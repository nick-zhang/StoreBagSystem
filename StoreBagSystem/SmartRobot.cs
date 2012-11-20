using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public class SmartRobot : AbstractRobot
    {
        public SmartRobot(IList<Cabinet> cabinets) : base(cabinets)
        {
        }

        protected override Cabinet GetAvailableCabinet()
        {
            return Cabinets.OrderByDescending(cabinet => cabinet.AvailableBoxes()).First();
        }
    }
}