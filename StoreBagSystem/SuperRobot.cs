using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public class SuperRobot : AbstractRobot
    {
        public SuperRobot(IList<Cabinet> cabinets)
        {
            this.Cabinets = cabinets;
        }

        public override Ticket Store(Bag bag)
        {
            var highestVacancyRateCainet = Cabinets.OrderByDescending(cabinet => cabinet.VacancyRate()).First();
            return highestVacancyRateCainet.Store(bag);
        }
    }
}