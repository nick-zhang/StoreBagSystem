using System.Collections.Generic;

namespace StoreBagSystem
{
    public class Robot : AbstractRobot
    {
        public Robot(IList<Cabinet> cabinets, ICabinetSelector selector) : base(cabinets, selector)
        {
        }
    }
}