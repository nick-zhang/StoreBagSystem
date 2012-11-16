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

        public Ticket Store(Bag bag)
        {
            var firstCanStore = storeables.FirstOrDefault(s => s.CanStore());
            if (firstCanStore ==null)
                throw  new CabinetException("No Box Available.");
                
            return firstCanStore.Store(bag);  
        }

        public Bag Pick(Ticket ticket)
        {
            return storeables.Select(s => s.Pick(ticket)).FirstOrDefault(b => b != null);
        }

        public bool CanStore()
        {
            return storeables.Any(s => s.CanStore());
        }
    }
}