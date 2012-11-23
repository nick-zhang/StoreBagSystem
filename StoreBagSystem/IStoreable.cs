namespace StoreBagSystem
{
    public interface IStoreable
    {
        Ticket Store(Bag bag);
        Bag Pick(Ticket ticket);
        bool CanStore();
        string AvailableBoxesMessage(string intend);
        string FormattedMessage(MessageFormatter formatter);
    }
}
