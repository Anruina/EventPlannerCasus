namespace Library.Algorithms.PathfindingAlgorihm
{

    public class Node
    {

        public string Name { get; set; }

        public float X { get; set; }
        public float Y { get; set; }

        public List<Node> Neighbours { get; set; }

        public bool HandicappedUsable { get; set; }

        public bool HandicappedOnly { get; set; }

        public Node(string name, float x, float y, bool handicappedUsable = true, bool handicappedOnly = false)
        {

            Name = name;

            X = x;
            Y = y;

            Neighbours = new List<Node>();

            HandicappedUsable = handicappedUsable;
            HandicappedOnly = handicappedOnly;

        }

    }

}
