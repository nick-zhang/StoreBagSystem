using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreBagSystem;

namespace StoreBagSystemTest
{
    [TestClass]
    public class CabinetTest
    {
        [TestMethod]
        public void ShouldReturnTrueWhenHasAvailableBox()
        {
            var cabinet = new Cabinet(1);
            Assert.IsTrue(cabinet.HasAvailableBox());
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
    }
}
