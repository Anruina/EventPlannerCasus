namespace Library.Algorithms.PathfindingAlgorihm
{

    public class Node
    {

        public string Name { get; set; }

        public float X { get; set; }
        public float Y { get; set; }

        public Node? Parent { get; set; }

        public float TotalCost { get; set; }

        public List<Node> Neighbours { get; set; }

        public Node(string name, float x, float y)
        {

            Name = name;

            X = x;
            Y = y;

            Neighbours = new List<Node>();
            Parent = null;

            TotalCost = 0;

        }

        public Node(Node otherNode)
        {

            Name = otherNode.Name;

            X = otherNode.X;
            Y = otherNode.Y;

            Neighbours = otherNode.Neighbours;
            Parent = otherNode.Parent;

            TotalCost = 0;

        }

    }

}
