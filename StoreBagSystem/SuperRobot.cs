using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public class SuperRobot
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
    }
}