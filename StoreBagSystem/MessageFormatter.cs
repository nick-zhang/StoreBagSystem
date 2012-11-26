using System.Linq;

namespace StoreBagSystem
{
    public class MessageFormatter
    {
        private readonly string intend;

        public MessageFormatter(string intend)
        {
            this.intend = intend;
        }

        public string FormatCabinet(Cabinet cabinet)
        {
            return string.Format("{0}Cabinet{1}:{2}\n", intend, cabinet.GetHashCode(), cabinet.AvailableBoxes());
        }
        
        public string FormatRobot(Robot robot)
        {
            return robot.Cabinets.Aggregate(string.Format("{0}Robot{1}\n", intend, robot.GetHashCode()), 
                (current, cabinet) => string.Concat(current, intend + cabinet.FormattedMessage(new MessageFormatter("  "))));
        }
        
        public string FormatManager(Manager manager)
        {
            return manager.Storeables.Aggregate(string.Format("{0}Manager{1}\n", intend, manager.GetHashCode()), 
                (current, storeable) => string.Concat(current, intend + storeable.FormattedMessage(new MessageFormatter("  "))));
        }
    }
}
