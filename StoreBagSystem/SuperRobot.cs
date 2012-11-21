using System.Collections.Generic;

namespace StoreBagSystem
{
    public class SuperRobot : AbstractRobot
    {
        public SuperRobot(IList<Cabinet> cabinets, ICabinetSelector selector) : base(cabinets, selector)
        {
        }

        protected override string Name()
        {
            return string.Format("SuperRobot{0}\n", GetHashCode());
        }
    }
}