using System;
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
            var manager = new Manager(new List<IStoreable> {cabinet});
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
            var cabinets1 = new List<Cabinet> {cabinet};
            var robot = new Robot(cabinets1, new SequentialSelector(cabinets1));
            var manager = new Manager(new List<IStoreable> {robot});

            var storedBag = new Bag();
            var ticket = manager.Store(storedBag);

            Assert.AreEqual(9, cabinet.AvailableBoxes());
            Assert.AreSame(storedBag, manager.Pick(ticket));
        }

        [TestMethod]
        public void ShouldManageMutipleRobots()
        {
            var cabinet1 = new Cabinet(10);
            var cabinets1 = new List<Cabinet> {cabinet1};
            var robot = new Robot(cabinets1, new SequentialSelector(cabinets1));

            var cabinet2 = new Cabinet(5);
            var cabinets2 = new List<Cabinet> {cabinet2};
            var smartRobot = new Robot(cabinets2, new MostAvailableSelector(cabinets2));

            var cabinet3 = new Cabinet(4);
            var cabinets3 = new List<Cabinet> {cabinet3};
            var superRobot = new Robot(cabinets3, new HighestVacancyRateSelector(cabinets3));

            var manager = new Manager(new List<IStoreable> {robot, smartRobot, superRobot});

            manager.Store(new Bag());

            Assert.AreEqual(9, cabinet1.AvailableBoxes());
        }

        [TestMethod]
        public void ShouldManagerManageOtherMangers()
        {
            var cabinet1 = new Cabinet(2);
            var manager1 = new Manager(new List<IStoreable> {cabinet1});

            var manager = new Manager(new List<IStoreable> {manager1});

            var storedBag = new Bag();
            var ticket = manager.Store(storedBag);
            Assert.AreEqual(1, cabinet1.AvailableBoxes());

            var pickedBag = manager.Pick(ticket);
            Assert.AreSame(storedBag, pickedBag);
        }

        [TestMethod]
        public void ShouldGetFormattedAvailbeBoxesMessagesFromAllManagedCabinets()
        {
            var cabinet1 = new Cabinet(10);
            var cabinets1 = new List<Cabinet> {cabinet1};
            var robot = new Robot(cabinets1, new SequentialSelector(cabinets1));

            var manager = new Manager(new List<IStoreable> {robot});
            manager.Store(new Bag());
            var message = manager.AvailableBoxesMessage("");

            Assert.AreEqual(string.Format("Manager{0}\n" +
                                                   "  Robot{1}\n" +
                                                   "    Cabinet{2}:{3}\n",
                                                   manager.GetHashCode(),
                                                   robot.GetHashCode(),
                                                   cabinet1.GetHashCode(), cabinet1.AvailableBoxes()
                                         ), message);
        }
    }
}