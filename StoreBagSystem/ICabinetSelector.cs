namespace StoreBagSystem
{
    public interface ICabinetSelector
    {
        Cabinet GetAvailableCabinet();
        string Name();
    }
}