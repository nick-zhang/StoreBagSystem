using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public class Manager
    {
        private readonly IList<IStoreable> storeables;

        public Manager(IList<IStoreable> storeables)
        {
            this.storeables = storeables;
        }

        public Ticket Store(Bag bag)
        {
            var firstOrDefault = storeables.FirstOrDefault(s => s.CanStore());
            return firstOrDefault.Store(bag);  
        }
    }
}