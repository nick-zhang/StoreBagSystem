using System.Collections.Generic;

namespace StoreBagSystem
{
    public class Robot
    {
        private readonly IList<Cabinet> cabinets;

        public Robot(IList<Cabinet> cabinets)
        {
            this.cabinets = cabinets;
        }

        public Ticket Store(Bag bag)
        {
            var availabeCabinet = cabinets.FirstOrDefault(cabinet => cabinet.HasAvailableBox());
            if (availabeCabinet == null)
            {
                throw new CabinetException("No available box.");
            }

            return availabeCabinet.Store(bag);
        }
    }
}