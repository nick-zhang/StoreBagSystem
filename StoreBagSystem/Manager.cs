using System.Collections.Generic;

namespace StoreBagSystem
{
    public class Manager
    {
        private readonly IStoreable storeable;

        public Manager(IStoreable storeable)
        {
            this.storeable = storeable;
        }

        public Ticket Store(Bag bag)
        {
            return storeable.Store(bag);  
        }
    }
}