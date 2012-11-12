using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreBagSystem;

namespace StoreBagSystemTest
{
    [TestClass]
    public class SmartRobotTest
    {
        [TestMethod]
        public void ShouldStoreBagIntoTheCabinetHasMostAvailableBoxes()
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
}
