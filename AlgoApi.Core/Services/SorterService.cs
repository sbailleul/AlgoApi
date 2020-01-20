using AlgoApi.Core.Sorting;

namespace AlgoApi.Core.PathFinding
{
    public class SorterService<TSorter,TSortType> where TSorter:Sorter<TSortType>
    {
        private readonly Sorter<TSortType> _sorter;
        
        public SorterService(TSorter sorter)
        {
            _sorter = sorter;
        }

        public TSortType[][] SortMatrix(TSortType[][] matrix)
        {
            return _sorter.SortMatrix(matrix);
        }
    }
}