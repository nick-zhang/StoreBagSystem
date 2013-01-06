using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public class Manager : IStoreable
    {
        private readonly IList<IStoreable> storeables;

        public Manager(IList<IStoreable> storeables)
        {
            this.storeables = storeables;
        }

        public IEnumerable<IStoreable> Storeables
        {
            get { return storeables; }
        }

        public Ticket Store(Bag bag)
        {
            var firstCanStore = Storeables.FirstOrDefault(s => s.CanStore());
            if (firstCanStore ==null)
                throw  new CabinetException("No Box Available.");
                
            return firstCanStore.Store(bag);  
        }

        public Bag Pick(Ticket ticket)
        {
            return Storeables.Select(s => s.Pick(ticket)).FirstOrDefault(b => b != null);
        }

        public bool CanStore()
        {
            return Storeables.Any(s => s.CanStore());
        }

        public string ReportEmptyBox(EmptyBoxReporter formatter)
        {
            return formatter.Report(this);
        }
    }
}