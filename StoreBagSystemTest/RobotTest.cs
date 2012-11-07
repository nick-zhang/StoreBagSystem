using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreBagSystem;

namespace StoreBagSystemTest
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        [ExpectedException(typeof(CabinetException), "No available box exception!")]
        public void ShouldShowErrorMessageWhenNoBoxAvailableInAnyCabinet()
        {
            var cabinet = new Cabinet(1);
            var cabinets = new List<Cabinet> {cabinet};
            cabinet.Store(new Bag());

            var robot = new Robot(cabinets);
            
            robot.Store(new Bag());
        }
    }

    public class Robot
    {
        public Robot(IList<Cabinet> cabinets)
        {
        }

        public void Store(Bag bag)
        {
            throw new CabinetException("No Box Available.");
        }
    }
}
