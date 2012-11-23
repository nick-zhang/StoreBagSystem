using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public class Manager : IStoreable
    {
        private const string IndentString = "  ";
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

        public string AvailableBoxesMessage(string intend)
        {
            return storeables.Aggregate(Name(intend), (current, storeable) => string.Concat(current, storeable.AvailableBoxesMessage(IndentString+intend)));
        }

        private string Name(string intend)
        {
            return string.Format("{0}Manager{1}\n", intend, GetHashCode());
        }
    }
}