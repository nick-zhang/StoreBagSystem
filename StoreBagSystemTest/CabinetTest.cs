using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreBagSystem;

namespace StoreBagSystemTest
{
    [TestClass]
    public class CabinetTest
    {
        [TestMethod]
        [ExpectedException(typeof(CabinetException), "Excpetion occures for storing a bag.")]
        public void ShouldShowErrorMessageWhenNoBoxAvailable()
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
            var actualBag = cabinet.Get(ticket);
            Assert.AreSame(bag, actualBag);
        }

        [TestMethod]
        public void ShouldNotGetBagGivenUsedTicked()
        {
            var cabinet = new Cabinet(1);
            var bag = new Bag();
            var ticket = cabinet.Store(bag);
            var actualBag = cabinet.Get(ticket);
            Assert.AreEqual(bag, actualBag);

            var secondBag = cabinet.Get(ticket);
            Assert.IsNull(secondBag);
        }
    }
}
