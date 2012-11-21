using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    class MostAvailableSelector : ICabinetSelector
    {
        private readonly IList<Cabinet> cabinets;

        public MostAvailableSelector(IList<Cabinet> cabinets)
        {
            this.cabinets = cabinets;
        }

        public Cabinet GetAvailableCabinet()
        {
            return cabinets.OrderByDescending(cabinet => cabinet.AvailableBoxes()).First();
        }
    }
}
