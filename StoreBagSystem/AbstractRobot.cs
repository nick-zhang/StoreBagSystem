using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public class AbstractRobot : IStoreable
    {
        private const string IndentString = "  ";
        protected readonly IList<Cabinet> Cabinets;
        private readonly ICabinetSelector selector;

        protected AbstractRobot(IList<Cabinet> cabinets, ICabinetSelector selector)
        {
            Cabinets = cabinets;
            this.selector = selector;
        }

        public virtual Ticket Store(Bag bag)
        {
            var availableBox = selector.GetAvailableCabinet();
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

        public string AvailableBoxesMessage()
        {
            return Cabinets.Aggregate(Name(), (current, cabinet) => string.Concat(current, IndentString + cabinet.AvailableBoxesMessage()));
        }

        protected virtual  string Name()
        {
            return string.Empty;
        }
    }
}