using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    class SequentialSelector : ICabinetSelector
    {
        private readonly IList<Cabinet> cabinets;

        public SequentialSelector(IList<Cabinet> cabinets)
        {
            this.cabinets = cabinets;
        }

        public Cabinet GetAvailableCabinet()
        {
            return cabinets.FirstOrDefault(cabinet => cabinet.AvailableBoxes() > 0) ?? cabinets.First();
        }
    }
}
