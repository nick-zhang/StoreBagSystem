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

        public IEnumerable<Cabinet> Cabinets
        {
            get { return cabinets; }
        }

        public Ticket Store(Bag bag)
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

        public string AvailableBoxesMessage(string intend)
        {
            return Cabinets.Aggregate(Name(intend), (current, cabinet) => string.Concat(current, cabinet.AvailableBoxesMessage(IndentString + intend)));
        }

        public string FormattedMessage(MessageFormatter formatter)
        {
            return formatter.FormatRobot(this);
        }

        private string Name(string intend)
        {
            return string.Format("{0}Robot{1}\n", intend, GetHashCode());
        }
    }
}