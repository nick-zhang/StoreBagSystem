using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreBagSystem;

namespace StoreBagSystemTest
{
    [TestClass]
    public class SuperRobotTest
    {
        [TestMethod]
        public void ShouldStoreBagToCabinetWithHighestVacancyRate()
        {
            var cabinet1 = new Cabinet(2);
            cabinet1.Store(new Bag());

            var cabinet2 = new Cabinet(5);
            cabinet2.Store(new Bag());
            cabinet2.Store(new Bag());
            cabinet2.Store(new Bag());

            var cabinets = new List<Cabinet> { cabinet1, cabinet2 };
            var superRobot = new SuperRobot(cabinets);
            superRobot.Store(new Bag());

            Assert.AreEqual(0, cabinet1.AvailableBoxes());
            Assert.AreEqual(2, cabinet2.AvailableBoxes());
        }
    }
}
