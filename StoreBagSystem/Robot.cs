using System.Collections.Generic;

namespace StoreBagSystem
{
    public class Robot : AbstractRobot
    {
        public Robot(IList<Cabinet> cabinets, ICabinetSelector selector) : base(cabinets, selector)
        {
        }

        protected override string Name()
        {
            return string.Format("Robot{0}\n", GetHashCode());
        }
    }
}