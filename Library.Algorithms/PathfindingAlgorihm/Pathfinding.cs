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

            Node? currentNode = openList[0];
            while (openList.Count > 0)
            {

                int nodeIndex = 0;
                for (int i = 0; i < openList.Count(); i++)
                    if (openList[nodeIndex].FCost > openList[i].FCost)
                        nodeIndex = i;

                currentNode = openList[nodeIndex];

                openList.RemoveAt(nodeIndex);
                closedList.Add(currentNode.Name);

                if (currentNode.Name == endNode.Name)
                    return ReconstructPath(currentNode);

                foreach (Node neighbor in currentNode.Neighbours)
                {

                    if (!closedList.Contains(neighbor.Name))
                    {

                        Node newNeighbor = new Node(neighbor);

                        newNeighbor.Parent = currentNode;
                        newNeighbor.GCost = currentNode.GCost + CalculateDistance(newNeighbor, currentNode);
                        newNeighbor.HCost = CalculateDistance(newNeighbor, endNode);
                        newNeighbor.FCost = newNeighbor.HCost + newNeighbor.GCost;

                        int otherNodeIndex = openList.FindIndex(n => n.Name == newNeighbor.Name);
                        if (otherNodeIndex > -1)
                        {

                            if (openList[otherNodeIndex].FCost > newNeighbor.FCost)
                                openList[otherNodeIndex] = newNeighbor;

                        }
                        else
                            openList.Add(newNeighbor);

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

            return path;

        }

    }

}
