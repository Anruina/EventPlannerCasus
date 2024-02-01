namespace Library.Algorithms.PathfindingAlgorihm
{

    public static class Pathfinding
    {

        public static List<Node> AStarAlgorithm(Node startNode, Node endNode, bool isHandicapped = false)
        {

            List<Node> openList = new List<Node>();
            HashSet<string> closedList = new HashSet<string>();

            startNode.GCost = 0;
            startNode.HCost = CalculateDistance(startNode, endNode);
            startNode.FCost = startNode.HCost;
            openList.Add(startNode);

            Node? currentNode = null;
            while (openList.Count > 0)
            {

                currentNode = openList.MinBy(node => node.FCost);

                openList.Remove(currentNode);
                closedList.Add(currentNode.Name);

                if (currentNode.Name.Equals(endNode.Name))
                    return ReconstructPath(currentNode);

                foreach (Node neighbor in currentNode.Neighbours)
                {

                    if (!closedList.Contains(neighbor.Name))
                    {

                        Node newNeighbor = new Node(neighbor);

                        newNeighbor.Parent = currentNode;
                        newNeighbor.GCost = currentNode.GCost + CalculateDistance(currentNode, newNeighbor);
                        newNeighbor.HCost = CalculateDistance(newNeighbor, endNode);
                        newNeighbor.FCost = newNeighbor.GCost + newNeighbor.HCost;

                        int otherNodeIndex = openList.FindIndex(n => n.Name.Equals(newNeighbor.Name));
                        if (otherNodeIndex == -1)
                            openList.Add(newNeighbor);
                        else if (openList[otherNodeIndex].FCost > newNeighbor.FCost)
                            openList[otherNodeIndex] = newNeighbor;

                    }

                }

            }

            return new List<Node>();

        }

        private static float CalculateDistance(Node startNode, Node endNode)
        {

            return (float)Math.Abs(startNode.X - endNode.X) + Math.Abs(startNode.Y - endNode.Y);

        }

        private static List<Node> ReconstructPath(Node? endNode)
        {

            List<Node> path = new List<Node>();

            while (endNode != null)
            {

                path.Add(endNode);
                endNode = endNode.Parent;

            }

            path.Reverse();
            return path;

        }

    }

}
