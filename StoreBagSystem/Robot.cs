using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public sealed class Robot : IStoreable
    {
        private const string IndentString = "  ";
        private readonly IList<Cabinet> cabinets;
        private readonly ICabinetSelector selector;

        public Robot(IList<Cabinet> cabinets, ICabinetSelector selector)
        {
            this.cabinets = cabinets;
            this.selector = selector;
        }

        public Ticket Store(Bag bag)
        {
            var availableBox = selector.GetAvailableCabinet();
            return availableBox.Store(bag);
        }

        public Bag Pick(Ticket ticket)
        {
            return cabinets.Select(cabinet => cabinet.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }

        public bool CanStore()
        {
            return cabinets.Any(cabinet => cabinet.CanStore());
        }

        public string AvailableBoxesMessage(string intend)
        {
            return cabinets.Aggregate(Name(intend), (current, cabinet) => string.Concat(current, cabinet.AvailableBoxesMessage(IndentString + intend)));
        }

        private string Name(string intend)
        {
            return string.Format("{0}{1}Robot{2}\n", intend, selector.Name(), GetHashCode());
        }
    }
}