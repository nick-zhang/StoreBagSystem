using System.Linq;

namespace StoreBagSystem
{
    public class MessageFormatter
    {
        public string FormatCabinet(Cabinet cabinet)
        {
            const string intend = "";
            return string.Format("{0}Cabinet{1}:{2}\n", intend, cabinet.GetHashCode(), cabinet.AvailableBoxes());
        }
        
        public string FormatRobot(Robot robot)
        {
            const string intend = "";
            return robot.Cabinets.Aggregate(string.Format("{0}Robot{1}\n", intend, robot.GetHashCode()), 
                (current, cabinet) => string.Concat(current, "  "+FormatCabinet(cabinet)));
        }
        
        public string FormatManager(Manager manager)
        {
            const string intend = "";

            return manager.Storeables.Aggregate(string.Format("{0}Manager{1}\n", intend, manager.GetHashCode()), 
                (current, storeable) => string.Concat(current, storeable.FormattedMessage(this)));
        }
    }
}
