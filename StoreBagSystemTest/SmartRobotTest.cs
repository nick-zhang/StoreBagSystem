using System.Collections.Generic;
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
            Assert.IsTrue(cabinet1.HasAvailableBox());
        }
    }

    public class SmartRobot
    {
        public SmartRobot(IList<Cabinet> cabinets)
        {
            throw new System.NotImplementedException();
        }
    }
}
