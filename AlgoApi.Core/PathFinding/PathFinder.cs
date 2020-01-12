using AlgoApi.Core.NodeHandling;

namespace AlgoApi.Core.PathFinding
{
    public abstract class PathFinder
    {
        protected abstract INodeHandler NodeHandler { get; set; }

    }
}