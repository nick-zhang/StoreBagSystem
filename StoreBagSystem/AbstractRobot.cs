using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public abstract class AbstractRobot : IStoreable
    {
        protected IList<Cabinet> Cabinets;

        public abstract Ticket Store(Bag bag);

        public Bag Pick(Ticket ticket)
        {
            return Cabinets.Select(cabinet => cabinet.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }
    }
}