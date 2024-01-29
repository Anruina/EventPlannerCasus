namespace Library.Algorithms.PathfindingAlgorihm
{

    public static class Pathfinding
    {

        public static List<Node> AStarAlgorithm(Node startNode, Node endNode, bool isHandicapped = false)
        {

            List<Node> openList = new List<Node>();
            HashSet<string> closedList = new HashSet<string>();

            startNode.TotalCost = 0;
            openList.Add(startNode);

            Node? currentNode = null;
            while (openList.Count > 0)
            {

                currentNode = openList.MinBy(node => node.TotalCost);

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
                        newNeighbor.TotalCost = currentNode.TotalCost + CalculateDistance(currentNode, newNeighbor);

                        int otherNodeIndex = openList.FindIndex(n => n.Name.Equals(newNeighbor.Name));
                        if (otherNodeIndex == -1)
                            openList.Add(newNeighbor);
                        else if (openList[otherNodeIndex].TotalCost > newNeighbor.TotalCost)
                            openList[otherNodeIndex] = newNeighbor;

                    }

                }

            }

            return new List<Node>();

        }

        private static float CalculateDistance(Node startNode, Node endNode)
        {

            return (float)Math.Abs(startNode.X - endNode.X) + Math.Abs(startNode.Y - endNode.Y);
            //return (float)Math.Sqrt((startNode.X - endNode.X) * (startNode.X - endNode.X) + (startNode.Y - endNode.Y) * (startNode.Y - endNode.Y));

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
