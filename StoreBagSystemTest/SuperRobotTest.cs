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
            var superRobot = new Robot(cabinets, new HighestVacancyRateSelector(cabinets));
            superRobot.Store(new Bag());

            Assert.AreEqual(0, cabinet1.AvailableBoxes());
            Assert.AreEqual(2, cabinet2.AvailableBoxes());
        }

        [TestMethod]
        public void ShouldPickBagSuccessfullyBySuperRobot()
        {
            var cabinet1 = new Cabinet(1);
            var cabinet2 = new Cabinet(2);
            var cabinets = new List<Cabinet> { cabinet1, cabinet2 };
            var superRobot = new Robot(cabinets, new HighestVacancyRateSelector(cabinets));
            var bag = new Bag();
            var ticket = superRobot.Store(bag);

            var pickedBag = superRobot.Pick(ticket);
            Assert.AreSame(bag, pickedBag);
        }

        [TestMethod]
        public void ShouldGetFormattedAvailbeBoxesMessagesForAllCabinets()
        {
            var cabinet1 = new Cabinet(1);
            cabinet1.Store(new Bag());
            var cabinet2 = new Cabinet(1);
            var cabinets = new List<Cabinet> { cabinet1, cabinet2 };

            var robot = new Robot(cabinets, new HighestVacancyRateSelector(cabinets));
            robot.Store(new Bag());
            var message = robot.ReportEmptyBox(new EmptyBoxReporter());
            
            Assert.AreEqual(message, string.Format("SuperRobot{0}\n  Cabinet{1}:{2}\n  Cabinet{3}:{4}\n",
                                                   robot.GetHashCode(),
                                                   cabinet1.GetHashCode(), cabinet1.AvailableBoxes(),
                                                   cabinet2.GetHashCode(), cabinet2.AvailableBoxes()
                                         ));
        }
    }
}
