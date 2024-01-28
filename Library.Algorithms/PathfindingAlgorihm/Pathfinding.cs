namespace Library.Algorithms.PathfindingAlgorihm
{

    public static class Pathfinding
    {

        public static List<Node> AStarAlgorithm(Node startNode, Node endNode, bool isHandicapped = false)
        {

            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();

            startNode.GCost = 0;
            startNode.HCost = CalculateDistance(startNode, endNode);
            startNode.FCost = startNode.HCost;

            openList.Add(startNode);

            Node? currentNode = openList[0];
            while (openList.Count > 0)
            {

                currentNode = openList.MinBy(node => node.FCost);

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                if (currentNode.Name == endNode.Name)
                    return ReconstructPath(currentNode);

                foreach (Node neighbor in currentNode.Neighbours)
                {

                    if (closedList.FindIndex(n => n.Name == neighbor.Name) == -1)
                    {

                        Node newNeighbor = new Node(neighbor);

                        newNeighbor.Parent = currentNode;
                        newNeighbor.GCost = currentNode.GCost + CalculateDistance(newNeighbor, currentNode);
                        newNeighbor.HCost = CalculateDistance(newNeighbor, endNode);
                        newNeighbor.FCost = newNeighbor.HCost + newNeighbor.GCost;

                        int otherNodeIndex = openList.FindIndex(n => n.Name == newNeighbor.Name);
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

            return (float)Math.Sqrt((startNode.X - endNode.X) * (startNode.X - endNode.X) + (startNode.Y - endNode.Y) * (startNode.Y - endNode.Y));

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
