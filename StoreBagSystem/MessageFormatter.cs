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
    }
}
