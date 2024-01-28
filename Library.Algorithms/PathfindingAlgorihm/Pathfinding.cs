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

                int nodeIndex = 0;
                for (int i = 0; i < openList.Count(); i++)
                    if (openList[nodeIndex].FCost > openList[i].FCost)
                        nodeIndex = i;

                currentNode = openList[nodeIndex];

                openList.RemoveAt(nodeIndex);
                closedList.Add(currentNode);

                if (currentNode.Id == endNode.Id)
                    return ReconstructPath(closedList[closedList.Count - 1]);

                foreach (Node neighbor in currentNode.Neighbours)
                {

                    Node newNeighbor = new Node(neighbor);

                    newNeighbor.Parent = currentNode;
                    newNeighbor.GCost = currentNode.GCost + CalculateDistance(newNeighbor, currentNode);
                    newNeighbor.HCost = CalculateDistance(newNeighbor, endNode);
                    newNeighbor.FCost = newNeighbor.HCost + newNeighbor.GCost;

                    int otherNodeIndex = openList.FindIndex(n => n.Id == newNeighbor.Id);
                    if (otherNodeIndex > -1)
                    {

                        if (openList[otherNodeIndex].FCost > newNeighbor.FCost)
                            openList[otherNodeIndex] = newNeighbor;

                    }
                    else if (closedList.FindIndex(n => n.Id == newNeighbor.Id) == -1)
                        openList.Add(newNeighbor);

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
