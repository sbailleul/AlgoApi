using System.Linq;
using AlgoApi.Core.CostCalculating;
using AlgoApi.Core.HeuristicHandling;
using AlgoApi.Core.MatrixGenerating;
using AlgoApi.Core.MatrixHandling;
using AlgoApi.Core.NodeHandling;
using AlgoApi.Core.PathFinding;
using NUnit.Framework;

namespace AlgoApi.Test.Core.PathFinding
{
    [TestFixture]
    public class PathFinderTests
    {
        [Test]
        public void AStarPerpendicularTests()
        {
            var matrix = new[]
            {
                new[] {1, 0, 0, 1},
                new[] {1, 0, 0, 1},
                new[] {1, 1, 1, 1}
            };
            var expectedShortestPath = new[]
            {
                new[] {2, 3}, new[] {2, 2}, new[] {2, 1}, new[] {2, 0}, new[] {1, 0}, new[] {0, 0},
            };
            var pathfinder = new AStar(new GridNodeHandler(), new GridCostCalculator(new Matrix4DGenerator(), new ManhattanGridDistance()));
            var shortestPtah = pathfinder.FindShortestPath(matrix, new[] {0, 0}, new[] {2, 3});
            for (var i = 0; i < shortestPtah.Count; i++)
            {
                Assert.IsTrue(shortestPtah[i].SequenceEqual(expectedShortestPath[i]));
            }
        }
        
        [Test]
        public void AStarDiagonalTests()
        {
            var matrix = new[]
            {
                new[] {1, 0, 0, 1},
                new[] {1, 1, 1, 1},
                new[] {1, 1, 1, 1}
            };
            var expectedShortestPath = new[]
            {
                new[] {2, 3}, new[] {2, 2}, new[] {1,1}, new[] {0, 0},
            };
            var pathfinder = new AStar(new GridNodeHandler(), new GridCostCalculator(new Matrix8DGenerator(), new ChebyshevDistance()));
            var shortestPtah = pathfinder.FindShortestPath(matrix, new[] {0, 0}, new[] {2, 3});
            for (var i = 0; i < shortestPtah.Count; i++)
            {
                Assert.IsTrue(shortestPtah[i].SequenceEqual(expectedShortestPath[i]));
            }
        }
        
        [Test]
        public void DjikstraGraphTest()
        {
            var matrix = new[]
            {
                new[] {0, 4, 0, 0, 0, 0, 0, 8, 0}, new[] {4, 0, 8, 0, 0, 0, 0, 11, 0},
                new[] {0, 8, 0, 7, 0, 4, 0, 0, 2}, new[] {0, 0, 7, 0, 9, 14, 0, 0, 0},
                new[] {0, 0, 0, 9, 0, 10, 0, 0, 0}, new[] {0, 0, 4, 14, 10, 0, 2, 0, 0},
                new[] {0, 0, 0, 0, 0, 2, 0, 1, 6}, new[] {8, 11, 0, 0, 0, 0, 1, 0, 7},
                new[] {0, 0, 2, 0, 0, 0, 6, 7, 0}
            };
            
            var expectedShortestPath = new[]
            {
                new []{4},new []{5},new []{6},new []{7},new []{0}
            };
            
            var pathfinder = new Dijkstra(new GraphNodeHandler(), new GraphCostCalculator());
            var shortestPtah = pathfinder.FindShortestPath(matrix,new [] {0}, new[] {4});
            for (var i = 0; i < shortestPtah.Count; i++)
            {
                Assert.IsTrue(shortestPtah[i].SequenceEqual(expectedShortestPath[i]));
            }
        }
    }
}