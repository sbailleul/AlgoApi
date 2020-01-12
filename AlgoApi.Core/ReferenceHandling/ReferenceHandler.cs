namespace AlgoApi.Core.ReferenceHandling
{
    public class ReferenceHandler : IReferenceHandler
    {
        public void SwapRef<T>(ref T ref1, ref T ref2)
        {
            var tmpRef = ref1;
            ref1 = ref2;
            ref2 = tmpRef;
            ;
        }
    }
}