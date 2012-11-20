using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public class Robot : AbstractRobot
    {
        public Robot(IList<Cabinet> cabinets) : base(cabinets)
        {
        }

        protected override Cabinet GetAvailableCabinet()
        {
            return Cabinets.FirstOrDefault(cabinet => cabinet.AvailableBoxes() > 0) ?? Cabinets.First();
        }

        protected override string Name()
        {
            return string.Format("Robot{0}\n", GetHashCode());
        }
    }
}