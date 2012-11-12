using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public class Robot : AbstractRobot
    {
        public Robot(IList<Cabinet> cabinets)
        {
            Cabinets = cabinets;
        }

        public override Ticket Store(Bag bag)
        {
            var availabeCabinet = Cabinets.FirstOrDefault(cabinet => cabinet.AvailableBoxes() > 0);
            if (availabeCabinet == null)
            {
                throw new CabinetException("No available box.");
            }

            return availabeCabinet.Store(bag);
        }
    }
}