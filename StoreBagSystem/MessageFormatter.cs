using System.Linq;

namespace StoreBagSystem
{
    public class MessageFormatter
    {
        private const string IntendString = "  ";
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
            return robot.Cabinets.Aggregate(string.Format("{0}{1}Robot{2}\n", intend, robot.GetName(),robot.GetHashCode()), 
                (current, cabinet) => string.Concat(current, intend + cabinet.FormattedMessage(new MessageFormatter(IntendString))));
        }
        
        public string FormatManager(Manager manager)
        {
            return manager.Storeables.Aggregate(string.Format("{0}Manager{1}\n", intend, manager.GetHashCode()), 
                (current, storeable) => string.Concat(current, intend + storeable.FormattedMessage(new MessageFormatter(IntendString))));
        }
    }
}
