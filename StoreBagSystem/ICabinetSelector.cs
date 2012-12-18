namespace StoreBagSystem
{
    public interface ICabinetSelector
    {
        Cabinet SelectCabinet();
        string Name { get;}
    }
}