using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

    public class Bag
    {
    }

    public class CabinetException : ApplicationException
    {
        public CabinetException(string noBoxAvailable) : base(noBoxAvailable)
        {
            
        }
    }

    public class Cabinet
    {
        public Cabinet(int i)
        {
        }

        public void Store(Bag bag)
        {
            throw new CabinetException("No Box Available");
        }
    }
}
