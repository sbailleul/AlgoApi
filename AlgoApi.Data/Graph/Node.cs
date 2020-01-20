namespace AlgoApi.Models.Graph
{
    public class Node
    {
        public Node(int[] position, Node parent, double cost, double heuristic)
        {
            Position = position;
            Parent = parent;
            Cost = cost;
            Heuristic = heuristic;
        }

        public int[] Position { get; set; }
        public Node Parent { get; set; }
        public double Cost { get; set; }

        public double Heuristic { get; set; }
    }
}