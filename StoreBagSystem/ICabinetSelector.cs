namespace StoreBagSystem
{
    public interface ICabinetSelector
    {
        Cabinet SelectCabinet();
        string GetName();
    }
}