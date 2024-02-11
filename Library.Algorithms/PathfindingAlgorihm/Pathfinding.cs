namespace Library.Algorithms.PathfindingAlgorihm
{

    public static class Pathfinding
    {

        public static List<PathFindingNode> AStarAlgorithm(Node startNode, Node endNode, bool isHandicapped = false)
        {

            PriorityQueue<PathFindingNode, float> openList = new PriorityQueue<PathFindingNode, float>();
            HashSet<string> closedList = new HashSet<string>();

            PathFindingNode currentNode = new PathFindingNode(null, startNode, 0, CalculateDistance(startNode, endNode));
            openList.Enqueue(currentNode, currentNode.FCost);

            while (openList.Count != 0)
            {

                currentNode = openList.Dequeue();
                closedList.Add(currentNode.Node.Name);

                if (currentNode.Node.Name.Equals(endNode.Name))
                    return ReconstructPath(currentNode);

                foreach (Node neighbor in currentNode.Node.Neighbours)
                {

                    if ((neighbor.HandicappedUsable || !isHandicapped) && (!neighbor.HandicappedOnly || isHandicapped) && !closedList.Contains(neighbor.Name))
                    {

                        float GCost = currentNode.GCost + CalculateDistance(currentNode.Node, neighbor);
                        float FCost = GCost + CalculateDistance(neighbor, endNode);

                        openList.Enqueue(new PathFindingNode(currentNode, neighbor, GCost, FCost), FCost);

                    }

                }

            }

            return new List<PathFindingNode>();

        }

        private static float CalculateDistance(Node startNode, Node endNode) { return (float)Math.Abs(startNode.X - endNode.X) + Math.Abs(startNode.Y - endNode.Y); }

        private static List<PathFindingNode> ReconstructPath(PathFindingNode? endNode)
        {

            List<PathFindingNode> path = new List<PathFindingNode>();

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
