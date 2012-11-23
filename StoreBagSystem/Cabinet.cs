using System.Collections.Generic;

namespace StoreBagSystem
{
    public class Cabinet : IStoreable
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
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            if (NoSuchTick(ticket))
                return null;

            var bag = tickBagMap[ticket];
            tickBagMap.Remove(ticket);
            return bag;
        }

        public int AvailableBoxes()
        {
            return capacity - tickBagMap.Count;
        }

        public double VacancyRate()
        {
            return (double) (AvailableBoxes())/capacity;
        }

        public bool CanStore()
        {
            return AvailableBoxes() > 0;
        }

        private bool NoSuchTick(Ticket ticket)
        {
            return !tickBagMap.ContainsKey(ticket);
        }
        
        public string AvailableBoxesMessage(string intend)
        {
            return string.Format("{0}Cabinet{1}:{2}\n", intend, GetHashCode(), AvailableBoxes());
        }
    }
}