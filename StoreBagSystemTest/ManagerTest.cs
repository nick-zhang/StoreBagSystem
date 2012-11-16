using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreBagSystem;

namespace StoreBagSystemTest
{
    [TestClass]
    public class ManagerTest
    {
        [TestMethod]
        public void ShouldStoreBagWithDirectlyByCabinet()
        {
            var cabinet = new Cabinet(10);
            var manager = new Manager(new List<IStoreable>{cabinet});

            var storedBag = new Bag();
            var ticket = manager.Store(storedBag);

            Assert.AreEqual(9, cabinet.AvailableBoxes());

            var pickedBag = manager.Pick(ticket);
            Assert.AreSame(storedBag, pickedBag);

        }

        [TestMethod]
        public void ShouldStoreBagByAnyRobot()
        {
            var cabinet = new Cabinet(10);
            var robot = new Robot(new List<Cabinet> {cabinet});
            var manager = new Manager(new List<IStoreable>{robot});

            var storedBag = new Bag();
            var ticket = manager.Store(storedBag);

            Assert.AreEqual(9, cabinet.AvailableBoxes());
            Assert.AreSame(storedBag, manager.Pick(ticket));
        }

        [TestMethod]
        public void ShouldManageMutipleRobots()
        {
            var cabinet1 = new Cabinet(10);
            var robot = new Robot(new List<Cabinet> {cabinet1});

            var cabinet2 = new Cabinet(5);
            var smartRobot = new SmartRobot(new List<Cabinet> {cabinet2});

            var cabinet3 = new Cabinet(4);
            var superRobot = new SuperRobot(new List<Cabinet> {cabinet3});

            var manager = new Manager(new List<IStoreable> {robot, smartRobot, superRobot});

            manager.Store(new Bag());
           
            Assert.AreEqual(9, cabinet1.AvailableBoxes());
        }
    }
}