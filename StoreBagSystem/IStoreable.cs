namespace StoreBagSystem
{
    public interface IStoreable
    {
        Ticket Store(Bag bag);
        Bag Pick(Ticket ticket);
        bool CanStore();
        string ReportEmptyBox(MessageFormatter formatter);
    }
}
