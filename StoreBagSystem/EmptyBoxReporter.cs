using System.Linq;

namespace StoreBagSystem
{
    public class EmptyBoxReporter
    {
        private const string INTEND_STRING = "  ";
        private string intend = string.Empty;

        public string Report(Cabinet cabinet)
        {
            return string.Format("{0}Cabinet{1}:{2}\n", intend, cabinet.GetHashCode(), cabinet.AvailableBoxes());
        }
        
        public string Report(Robot robot)
        {
            var reportEmptyBox = string.Format("{0}{1}Robot{2}\n", intend, robot.GetName(), robot.GetHashCode());
            AddIntend();
            reportEmptyBox = robot.Cabinets.Aggregate(reportEmptyBox, (current, cabinet) => current + cabinet.ReportEmptyBox(this));
            RevertIntend();
            return reportEmptyBox;
        }
        
        public string Report(Manager manager)
        {
            var reportEmptyBox = string.Format("{0}Manager{1}\n", intend, manager.GetHashCode());
            AddIntend();
            reportEmptyBox = manager.Storeables.Aggregate(reportEmptyBox, (current, storeable) => current + storeable.ReportEmptyBox(this));
            RevertIntend();
            return reportEmptyBox;
        }

        private void AddIntend()
        {
            intend += INTEND_STRING;
        }

        private void RevertIntend()
        {
            intend = intend.Remove(intend.Length - 2, 2);
        }
    }
}
