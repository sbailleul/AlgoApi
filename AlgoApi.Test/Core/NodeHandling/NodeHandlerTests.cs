using System.Collections.Generic;
using System.Linq;
using AlgoApi.Core.NodeHandling;
using AlgoApi.Models.Graph;
using NUnit.Framework;

namespace AlgoApi.Test.Core.NodeHandling
{
    [TestFixture]
    public class NodeHandlerTests
    {
        [Test]
        public void GetMinimalCostNodeTests()
        {
            var nodeHandler = new GraphNodeHandler();
            var nodes = new List<Node>
            {
                new Node(null, null, 3, 1),
                new Node(null, null, 4, 1),
                new Node(null, null, 1, 1),
            };
            var doneNodes = new List<Node>();
            
            Assert.AreEqual(nodes[2],nodeHandler.GetMinimalCostNode(nodes, doneNodes));
        }
        
        [Test]
        public void GetShortestPathTests()
        {
            var nodeHandler = new GraphNodeHandler();
            var positions = new List<int[]> {new[] {1, 1}, new[] {1, 2}, new[] {1, 3}};
            var nodes = new List<Node>
            {
                new Node(positions[2], null, 3, 1),
                new Node(positions[1], null, 4, 1),
                new Node(positions[0], null, 1, 1),
            };
            nodes[1].Parent = nodes[0];
            nodes[2].Parent = nodes[1];
            var shortestPath = nodeHandler.GetShortestPath(nodes, nodes[0].Position, nodes[2].Position);
            Assert.IsTrue(positions.SequenceEqual(shortestPath));
        }
        
        [Test]
        public void SetStartNodeTest()
        {
            var nodeHandler = new GraphNodeHandler();
            var positions = new List<int[]> {new[] {1, 1}, new[] {1, 2}, new[] {1, 3}};
            var nodes = new List<Node>
            {
                new Node(positions[2], null, 3, 1),
                new Node(positions[1], null, 4, 1),
                new Node(positions[0], null, 1, 1),
            };
            nodeHandler.SetStartNode(nodes, positions[0]);
            Assert.AreEqual(0,nodes[2].Cost);
        }
    }
}