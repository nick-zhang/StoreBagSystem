using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreBagSystem;

namespace StoreBagSystemTest
{
    [TestClass]
    public class CabinetTest
    {
        [TestMethod]
        public void ShouldReturnAvailableBoxNumber()
        {
            var cabinet = new Cabinet(1);
            Assert.AreEqual(1, cabinet.AvailableBoxes());
        }

        [TestMethod]
        public void ShouldTellWhetherCanStoreBag()
        {
            var cabinet = new Cabinet(1);
            var canStore = cabinet.CanStore();
            Assert.IsTrue(canStore);
        }

        [TestMethod]
        public void ShouldReturnCabinetVacancyReate()
        {
            var cabinet = new Cabinet(2);
            cabinet.Store(new Bag());

            Assert.AreEqual(0.5, cabinet.VacancyRate(), 0.001);
        }

        [TestMethod]
        [ExpectedException(typeof(CabinetException), "Excpetion occures for storing a bag.")]
        public void ShouldShowErrorMessageWhenNoBoxAvailableToStoreBag()
        {
            var cabinet = new Cabinet(0);
            cabinet.Store(new Bag());
        }

        [TestMethod]
        public void ShouldStoreBagSuccessfullyWhenThereIsBoxAvailable()
        {
            var cabinet = new Cabinet(1);
            var ticket =cabinet.Store(new Bag());
            Assert.IsNotNull(ticket);
        }

        [TestMethod]
        public void ShouldGetBagSuccessfullyGivenUnusedTicked()
        {
            var cabinet = new Cabinet(1);
            var bag = new Bag();
            var ticket = cabinet.Store(bag);
            var actualBag = cabinet.Pick(ticket);
            Assert.AreSame(bag, actualBag);
        }

        [TestMethod]
        public void ShouldNotGetBagGivenUsedTicked()
        {
            var cabinet = new Cabinet(1);
            var bag = new Bag();
            var ticket = cabinet.Store(bag);
            var actualBag = cabinet.Pick(ticket);
            Assert.AreEqual(bag, actualBag);

            var secondBag = cabinet.Pick(ticket);
            Assert.IsNull(secondBag);
        }

        [TestMethod]
        public void ShouldGetFormattedMessageOfAvaialbeBoxes()
        {
            var cabinet = new Cabinet(2);
            var bag = new Bag();
            cabinet.Store(bag);

            var  message = cabinet.AvailableBoxesMessage();
            Assert.AreEqual(message, string.Format("Cabinet{0}:{1}\n", cabinet.GetHashCode(), cabinet.AvailableBoxes()));
            Console.Out.WriteLine(message);
        }
    }
}
