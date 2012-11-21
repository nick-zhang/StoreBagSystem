using System.Collections.Generic;
using System.Linq;

namespace StoreBagSystem
{
    public class AbstractRobot : IStoreable
    {
        private const string IndentString = "  ";
        private readonly IList<Cabinet> cabinets;
        private readonly ICabinetSelector selector;

        protected AbstractRobot(IList<Cabinet> cabinets, ICabinetSelector selector)
        {
            this.cabinets = cabinets;
            this.selector = selector;
        }

        public virtual Ticket Store(Bag bag)
        {
            var availableBox = selector.GetAvailableCabinet();
            return availableBox.Store(bag);
        }

        public Bag Pick(Ticket ticket)
        {
            return cabinets.Select(cabinet => cabinet.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }

        public bool CanStore()
        {
            return cabinets.Any(cabinet => cabinet.CanStore());
        }

        public string AvailableBoxesMessage()
        {
            return cabinets.Aggregate(RobotName(), (current, cabinet) => string.Concat(current, IndentString + cabinet.AvailableBoxesMessage()));
        }

        private string RobotName()
        {
            return selector.Name()+"Robot"+GetHashCode()+"\n";
        }
    }
}