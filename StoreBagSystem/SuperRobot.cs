using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public class SuperRobot : IStoreable
    {
        private readonly IList<Cabinet> cabinets;

        public SuperRobot(IList<Cabinet> cabinets)
        {
            this.cabinets = cabinets;
        }

        public Ticket Store(Bag bag)
        {
            var highestVacancyRateCainet = cabinets.OrderByDescending(cabinet => cabinet.VacancyRate()).First();
            return highestVacancyRateCainet.Store(bag);
        }

        public Bag Pick(Ticket ticket)
        {
            return cabinets.Select(cabinet => cabinet.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }
    }
}