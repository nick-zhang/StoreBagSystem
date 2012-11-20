using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public class SuperRobot : AbstractRobot
    {
        public SuperRobot(IList<Cabinet> cabinets) : base(cabinets)
        {
        }

        protected override Cabinet GetAvailableCabinet()
        {
            return Cabinets.OrderByDescending(cabinet => cabinet.VacancyRate()).First();
        }

        protected override string Name()
        {
            return string.Format("SuperRobot{0}\n", GetHashCode());
        }
    }
}