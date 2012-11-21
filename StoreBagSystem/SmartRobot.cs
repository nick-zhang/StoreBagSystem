using System.Collections.Generic;

namespace StoreBagSystem
{
    public class SmartRobot : AbstractRobot
    {
        public SmartRobot(IList<Cabinet> cabinets, ICabinetSelector selector) : base(cabinets ,selector)
        {
        }
    }
}