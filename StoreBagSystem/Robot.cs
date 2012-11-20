using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public class Robot : AbstractRobot
    {
        private const string IndentString = "  ";

        public Robot(IList<Cabinet> cabinets) : base(cabinets)
        {
        }

        protected override Cabinet GetAvailableCabinet()
        {
            return Cabinets.FirstOrDefault(cabinet => cabinet.AvailableBoxes() > 0) ?? Cabinets.First();
        }

        public string AvailableBoxesMessage()
        {
            var message = string.Format("Robot{0}\n", GetHashCode());

            return Cabinets.Aggregate(message, (current, cabinet) => string.Concat(current, IndentString + cabinet.AvailableBoxesMessage()));
        }
    }
}