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
            var manager = new Manager(cabinet);

            manager.Store(new Bag());
            
            Assert.AreEqual(9, cabinet.AvailableBoxes());
        }
    }
}