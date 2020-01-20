using System.Linq;
using AlgoApi.Core.NodeHandling;
using NUnit.Framework;

namespace AlgoApi.Test.Core.NodeHandling
{
    [TestFixture]
    public class GridNodeHandlerTests
    {
        [Test]
        public void InitNodesTests()
        {
            var nodeHandler = new GridNodeHandler();
            var matrix = new[]
            {
                new[] {0, 0},
                new[] {1, 0},
            };
            nodeHandler.InitNodes(out var doneNodes, out var nodes, matrix);
            
            Assert.IsEmpty(doneNodes);
            Assert.AreEqual(1, nodes.Count);
            Assert.IsTrue(nodes[0].Position.SequenceEqual(matrix[1]));
            
        }
    }
}