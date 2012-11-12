using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreBagSystem;

namespace StoreBagSystemTest
{
    [TestClass]
    public class SmartRobotTest
    {
        [TestMethod]
        public void ShouldStoreTheBagIntoTheCabitNetHasMaxAvailableBox()
        {
            var cabinet1 = new Cabinet(1);
            var cabinet2 = new Cabinet(2);
            var cabinets = new List<Cabinet> { cabinet1, cabinet2 };

            var smartRobot = new SmartRobot(cabinets);
            smartRobot.Store(new Bag());
            Assert.AreEqual(1, cabinet1.AvailableBoxes());
            Assert.AreEqual(1, cabinet2.AvailableBoxes());
        }
    }

    public class SmartRobot
    {
        private readonly IList<Cabinet> cabinets;

        public SmartRobot(IList<Cabinet> cabinets)
        {
            this.cabinets = cabinets;
        }

        public Ticket Store(Bag bag)
        {
            var cabinetWithMostAvailableBoxes = cabinets.OrderBy(cabinet => cabinet.AvailableBoxes()).Last();
            return cabinetWithMostAvailableBoxes.Store(bag);
        }
    }
}
