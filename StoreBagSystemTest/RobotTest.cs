using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreBagSystem;

namespace StoreBagSystemTest
{
    [TestClass]
    public class RobotTest
    {
        [TestMethod]
        [ExpectedException(typeof (CabinetException), "No available box exception!")]
        public void ShouldShowErrorMessageWhenNoBoxAvailableInAnyCabinet()
        {
            var cabinet = new Cabinet(1);
            var cabinets = new List<Cabinet> {cabinet};
            cabinet.Store(new Bag());

            var robot = new Robot(cabinets);

            robot.Store(new Bag());
        }

        [TestMethod]
        public void ShouldStoreBagSuccessfullyInFirstAvailableBox()
        {
            var cabinet1 = new Cabinet(1);
            var cabinet2 = new Cabinet(1);
            var cabinets = new List<Cabinet> {cabinet1, cabinet2};

            var robot = new Robot(cabinets);
            var ticket = robot.Store(new Bag());

            Assert.IsNotNull(ticket);
            Assert.AreEqual(0, cabinet1.AvailableBoxes());
        }

        [TestMethod]
        public void ShouldStoreBagInTheSecondAvailableCabinetIfFirstIsFull()
        {
            var cabinet1 = new Cabinet(1);
            cabinet1.Store(new Bag());
            var cabinet2 = new Cabinet(1);
            var cabinets = new List<Cabinet> { cabinet1, cabinet2 };

            var robot = new Robot(cabinets);
            var ticket = robot.Store(new Bag());

            Assert.IsNotNull(ticket);
            Assert.AreEqual(0, cabinet2.AvailableBoxes());
        }

        [TestMethod]
        public void ShouldPickBagSuccessfullyByRobot()
        {
            var cabinet1 = new Cabinet(1);
            cabinet1.Store(new Bag());
            var cabinet2 = new Cabinet(1);
            var cabinets = new List<Cabinet> { cabinet1, cabinet2 };

            var robot = new Robot(cabinets);
            var bag = new Bag();
            var ticket = robot.Store(bag);

            var pickedBag = robot.Pick(ticket);
            Assert.AreSame(bag, pickedBag);
        }
    }
}