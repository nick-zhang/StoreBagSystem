using System.Collections.Generic;
using StoreBagSystemTest;

namespace StoreBagSystem
{
    public class Cabinet
    {
        private readonly int capacity;
        private readonly Dictionary<Ticket, Bag> dictionary;

        public Cabinet(int capacity)
        {
            this.capacity = capacity;
            dictionary = new Dictionary<Ticket, Bag>();
        }

        public Ticket Store(Bag bag)
        {
            if (dictionary.Keys.Count >= capacity)
                throw new CabinetException("No Box Available");

            var ticket = new Ticket();
            dictionary.Add(ticket, bag);
            return  ticket;
        }
    }
}