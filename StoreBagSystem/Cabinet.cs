using System.Collections.Generic;
using StoreBagSystemTest;

namespace StoreBagSystem
{
    public class Cabinet
    {
        private readonly int capacity;
        private readonly Dictionary<Ticket, Bag> tickBagMap;

        public Cabinet(int capacity)
        {
            this.capacity = capacity;
            tickBagMap = new Dictionary<Ticket, Bag>();
        }

        public Ticket Store(Bag bag)
        {
            if (tickBagMap.Keys.Count >= capacity)
                throw new CabinetException("No Box Available");

            var ticket = new Ticket();
            tickBagMap.Add(ticket, bag);
            return  ticket;
        }

        public Bag Get(Ticket ticket)
        {
            return tickBagMap[ticket];
        }
    }
}