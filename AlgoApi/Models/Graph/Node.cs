using System.Collections.Generic;

namespace AlgoApi.Models
{
    public class Node
    {
        public List<int> Position { get; set; }
        public Node Parent { get; set; }
        public double Cost { get; set; }
        
        public double Heuristic { get; set; }

        public Node(List<int> position, Node parent, double cost, double heuristic)
        {
            Position = position;
            Parent = parent;
            Cost = cost;
            Heuristic = heuristic;
        }
    }
}