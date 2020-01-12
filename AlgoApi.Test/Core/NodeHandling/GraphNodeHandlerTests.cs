using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.NodeHandling;
using NUnit.Framework;

namespace AlgoApi.Test.Core.NodeHandling
{
    [TestFixture]
    public class GraphNodeHandlerTests
    {
        [Test]
        public void InitNodes()
        {
            var nodeHandler = new GraphNodeHandler();
            var matrix = Enumerable.Range(0,2).Select( i => new []{i/2, i%2}).ToArray();
            nodeHandler.InitNodes(out var doneNodes, out var nodes, matrix);
            
            

        }
    }
}