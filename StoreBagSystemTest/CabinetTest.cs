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
    }
}
