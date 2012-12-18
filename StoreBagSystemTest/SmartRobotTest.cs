using System;
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
            var cabinets = new List<Cabinet> {cabinet1, cabinet2};
            var smartRobot = new Robot(cabinets, new MostAvailableSelector(cabinets));
            smartRobot.Store(new Bag());
            Assert.AreEqual(1, cabinet1.AvailableBoxes());
            Assert.AreEqual(1, cabinet2.AvailableBoxes());
        }

        [TestMethod]
        public void ShouldStoreBagIntoTheFirstCabinetWhenMoreThanTwoCabinetsHaveTheSameAvailableBoxes()
        {
            var cabinet1 = new Cabinet(1);
            var cabinet2 = new Cabinet(1);
            var cabinets = new List<Cabinet> {cabinet1, cabinet2};

            var smartRobot = new Robot(cabinets, new MostAvailableSelector(cabinets));
            smartRobot.Store(new Bag());
            Assert.AreEqual(0, cabinet1.AvailableBoxes());
            Assert.AreEqual(1, cabinet2.AvailableBoxes());
        }

        [TestMethod]
        [ExpectedException(typeof (CabinetException), "No available box exception!")]
        public void ShouldThrowExceptionWhenNoAvailableBox()
        {
            var cabinet1 = new Cabinet(0);
            var cabinet2 = new Cabinet(0);
            var cabinets = new List<Cabinet> {cabinet1, cabinet2};
            var smartRobot = new Robot(cabinets, new MostAvailableSelector(cabinets));
            smartRobot.Store(new Bag());
        }

        [TestMethod]
        public void ShouldPickBagSuccessfullyBySmartRobot()
        {
            var cabinet1 = new Cabinet(1);
            var cabinet2 = new Cabinet(2);
            var cabinets = new List<Cabinet> { cabinet1, cabinet2 };
            var smartRobot = new Robot(cabinets, new MostAvailableSelector(cabinets));
            var bag = new Bag();
            var ticket = smartRobot.Store(bag);

            var pickedBag = smartRobot.Pick(ticket);
            Assert.AreSame(bag, pickedBag);
        }

        [TestMethod]
        public void ShouldGetFormattedAvailbeBoxesMessagesForAllCabinets()
        {
            var cabinet1 = new Cabinet(1);
            cabinet1.Store(new Bag());
            var cabinet2 = new Cabinet(1);
            var cabinets = new List<Cabinet> { cabinet1, cabinet2 };

            var robot = new Robot(cabinets, new MostAvailableSelector(cabinets));
            robot.Store(new Bag());
            var message = robot.FormattedMessage(new MessageFormatter(""));
            Console.Out.WriteLine(message);
            Assert.AreEqual(string.Format("SmartRobot{0}\n  Cabinet{1}:{2}\n  Cabinet{3}:{4}\n",
                                                   robot.GetHashCode(),
                                                   cabinet1.GetHashCode(), cabinet1.AvailableBoxes(),
                                                   cabinet2.GetHashCode(), cabinet2.AvailableBoxes()
                                         ), message);
        }
    }
}
