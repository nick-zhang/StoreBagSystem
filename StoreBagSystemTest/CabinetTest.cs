using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreBagSystem;

namespace StoreBagSystemTest
{
    [TestClass]
    public class CabinetTest
    {
        [TestMethod]
        [ExpectedException(typeof(CabinetException), "There is excpetion for storing a bag.")]
        public void ShouldShowErrorMessageWhenNoBoxAvailable()
        {
            var cabinet = new Cabinet(0);
            cabinet.Store(new Bag());
        }
    }
}
