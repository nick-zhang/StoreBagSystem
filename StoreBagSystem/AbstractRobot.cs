using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public abstract class AbstractRobot : IStoreable
    {
        protected readonly IList<Cabinet> Cabinets;

        protected AbstractRobot(IList<Cabinet> cabinets)
        {
            Cabinets = cabinets;
        }

        public virtual Ticket Store(Bag bag)
        {
            var availableBox = GetAvailableCabinet();
            return availableBox.Store(bag);
        }

        public Bag Pick(Ticket ticket)
        {
            return Cabinets.Select(cabinet => cabinet.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }

        public bool CanStore()
        {
            return Cabinets.Any(cabinet => cabinet.CanStore());
        }

        protected abstract Cabinet GetAvailableCabinet();
    }
}