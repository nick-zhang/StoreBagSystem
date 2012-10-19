using StoreBagSystemTest;

namespace StoreBagSystem
{
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