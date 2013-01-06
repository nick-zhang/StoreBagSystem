using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public sealed class Robot : IStoreable
    {
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

        public string GetName()
        {
            return selector.GetName();
        }

        public Ticket Store(Bag bag)
        {
            var cabinet = selector.SelectCabinet();
            return cabinet.Store(bag);
        }

        public Bag Pick(Ticket ticket)
        {
            return Cabinets.Select(cabinet => cabinet.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }

        public bool CanStore()
        {
            return Cabinets.Any(cabinet => cabinet.CanStore());
        }

        public string ReportEmptyBox(EmptyBoxReporter formatter)
        {
            return formatter.Report(this);
        }
    }
}