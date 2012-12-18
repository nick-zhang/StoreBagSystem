using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public class MostAvailableSelector : ICabinetSelector
    {
        private readonly IList<Cabinet> cabinets;

        public MostAvailableSelector(IList<Cabinet> cabinets)
        {
            this.cabinets = cabinets;
        }

        public Cabinet SelectCabinet()
        {
            return cabinets.OrderByDescending(cabinet => cabinet.AvailableBoxes()).First();
        }

        public string Name
        {
            get { return "Smart"; }
        }
    }
}
