namespace StoreBagSystem
{
    public class Manager
    {
        private readonly Cabinet cabinet;

        public Manager(Cabinet cabinet)
        {
            this.cabinet = cabinet;
        }

        public Ticket Store(Bag bag)
        {
            return cabinet.Store(bag);
        }
    }
}