using System.Collections.Generic;

namespace StoreBagSystem
{
    public class SmartRobot : AbstractRobot
    {
        public SmartRobot(IList<Cabinet> cabinets, ICabinetSelector selector) : base(cabinets ,selector)
        {
        }

        protected override string Name()
        {
            return string.Format("SmartRobot{0}\n", GetHashCode());
        }
    }
}