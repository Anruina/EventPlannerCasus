namespace Library.Algorithms.PathfindingAlgorihm
{

    public class Node
    {

        public float X { get; set; }
        public float Y { get; set; }
        public string Name { get; set; }

        public Node? Parent { get; set; }

        public float GCost { get; set; }
        public float FCost { get; set; }
        public float HCost { get; set; }

        public List<Node> Neighbours { get; set; }

        public Node(float x, float y, string name)
        {

            X = x;
            Y = y;

            Name = name;

            Neighbours = new List<Node>();
            Parent = null;

            GCost = 0;
            FCost = 0;
            HCost = 0;

        }

        public Node(Node otherNode)
        {

            X = otherNode.X;
            Y = otherNode.Y;

            Name = otherNode.Name;

            Neighbours = otherNode.Neighbours;
            Parent = otherNode.Parent;

        }

    }

}
