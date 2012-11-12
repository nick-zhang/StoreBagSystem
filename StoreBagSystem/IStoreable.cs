namespace StoreBagSystem
{
    public interface IStoreable
    {
        Ticket Store(Bag bag);
        Bag Pick(Ticket ticket);
    }
}