namespace AlgoApi.Core.ReferenceHandling
{
    public interface IReferenceHandler
    {
        void SwapRef<T>(ref T ref1, ref T ref2);
    }
}