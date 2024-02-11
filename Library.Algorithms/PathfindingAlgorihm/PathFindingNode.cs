namespace Library.Algorithms.PathfindingAlgorihm
{

    public class PathFindingNode : IComparable<PathFindingNode>
    {

        public PathFindingNode? Parent { get; set; }
        public Node Node { get; set; }

        public float GCost { get; set; }
        public float FCost { get; set; }

        public PathFindingNode(PathFindingNode? parent, Node node, float gCost, float fCost)
        {

            Parent = parent;
            Node = node;
            GCost = gCost;
            FCost = fCost;  

        }

        public int CompareTo(PathFindingNode? other) { return 0 - FCost.CompareTo(other.FCost); }

    }

}
