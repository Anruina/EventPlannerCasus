using System.Reflection;
using IImage = Microsoft.Maui.Graphics.IImage;
using Microsoft.Maui.Graphics.Platform;

namespace EventPlannerMAUI.Drawables
{

    public class Node
    {

        public int Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public string Name { get; set; }

        public Node? Parent { get; set; }

        public float GCost { get; set; }
        public float FCost { get; set; }
        public float HCost { get; set; }

        public List<Node> Neighbours { get; set; }

        public Node(int id, float x, float y, string name)
        {

            Id = id;
            X = x;
            Y = y;

            Name = name;

            Neighbours = new List<Node>();
            Parent = null;

        }

        public float CalculateDistance(Node other)
        {

            return (float)Math.Sqrt((X - other.X) * (X - other.X) + (Y - other.Y) * (Y - other.Y));

        }

        public int CompareTo(Node other)
        {

            return FCost.CompareTo(other.FCost);

        }

    }

    public class MapPath : IDrawable
    {

        public string? StartPos { get; set; }
        public string? EndPos { get; set; }

        public MapPath()
        {

            StartPos = "B3.217";
            EndPos = "B3.209";

        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {

            Dictionary<string, Node> ComplexPath = new Dictionary<string, Node>();

            ComplexPath["B3.309"] = new Node(0, 1.8f, 3.0f, "B3.309");
            ComplexPath["End B3.1B"] = new Node(1, 7.0f, 4.3f, "End B3.1B");
            ComplexPath["Start B3.1B"] = new Node(2, 7.0f, 19.0f, "Start B3.1B");
            ComplexPath["B3.311"] = new Node(3, 4.2f, 2.5f, "B3.311");
            ComplexPath["B3.305"] = new Node(4, 3.0f, 19.0f, "B3.305");
            ComplexPath["B3.1"] = new Node(5, 7.0f, 28.0f, "B3.1");
            ComplexPath["End B3.2"] = new Node(6, 19.0f, 28.8f, "End B3.2");
            ComplexPath["Start B3.2"] = new Node(7, 31.6f, 28.8f, "Start B3.2");
            ComplexPath["B3.3"] = new Node(8, 41.3f, 27.5f, "B3.3");
            ComplexPath["B3.217"] = new Node(9, 15.0f, 32.5f, "B3.217");
            ComplexPath["B3.210"] = new Node(10, 15.0f, 22.5f, "B3.210");
            ComplexPath["B3.208"] = new Node(11, 22.5f, 22.5f, "B3.208");
            ComplexPath["B3.215"] = new Node(12, 21.3f, 32.5f, "B3.215");
            ComplexPath["B3.213"] = new Node(13, 25.6f, 32.5f, "B3.213");
            ComplexPath["B3.206"] = new Node(14, 28.5f, 22.5f, "B3.206");
            ComplexPath["B3.211"] = new Node(15, 29.8f, 32.5f, "B3.211");
            ComplexPath["B3.209"] = new Node(16, 34.0f, 32.5f, "B3.209");
            ComplexPath["B3.310"] = new Node(17, 9.2f, 4.8f, "B3.310");
            ComplexPath["B3.308"] = new Node(18, 9.2f, 7.8f, "B3.308");
            ComplexPath["B3.306"] = new Node(19, 9.2f, 10.8f, "B3.306");
            ComplexPath["B3.304"] = new Node(20, 9.2f, 13.5f, "B3.304");
            ComplexPath["B3.302"] = new Node(21, 9.2f, 16.0f, "B3.302");
            ComplexPath["B3.300"] = new Node(22, 9.2f, 18.7f, "B3.300");
            ComplexPath["B3.1A"] = new Node(23, 5.0f, 33.0f, "B3.1A");
            ComplexPath["B3.255"] = new Node(24, 3.0f, 37.0f, "B3.255");
            ComplexPath["B3.223"] = new Node(25, 8.0f, 37.0f, "B3.223");
            ComplexPath["B3.105"] = new Node(26, 40.5f, 34.0f, "B3.105");
            ComplexPath["B3.103"] = new Node(27, 43.8f, 34.0f, "B3.103");
            ComplexPath["B3.107"] = new Node(28, 42.0f, 37.8f, "B3.107");
            ComplexPath["B3.104"] = new Node(29, 40.3f, 12.5f, "B3.104");
            ComplexPath["B3.114"] = new Node(30, 44.8f, 2.3f, "B3.114");
            ComplexPath["B3.112"] = new Node(31, 45.8f, 4.1f, "B3.112");
            ComplexPath["B3.116"] = new Node(32, 44.2f, 7.1f, "B3.116");
            ComplexPath["B3.115"] = new Node(33, 42.9f, 7.1f, "B3.115");
            ComplexPath["B3.110"] = new Node(34, 45.8f, 11.1f, "B3.110");
            ComplexPath["B3.111"] = new Node(35, 45.8f, 6.2f, "B3.111");
            ComplexPath["B3.122"] = new Node(36, 42.9f, 15.2f, "B3.122");
            ComplexPath["B3.120"] = new Node(37, 44.2f, 15.2f, "B3.120");
            ComplexPath["B3.108"] = new Node(38, 45.8f, 16.1f, "B3.108");
            ComplexPath["B3.106"] = new Node(39, 45.8f, 19.1f, "B3.106");
            ComplexPath["B3.104A"] = new Node(40, 43.1f, 19.1f, "B3.104A");
            ComplexPath["B3.200"] = new Node(41, 35.2f, 22.5f, "B3.200");
            ComplexPath["B3.200B"] = new Node(42, 32.7f, 21.5f, "B3.200B");
            ComplexPath["B3.200A"] = new Node(43, 32.7f, 23.8f, "B3.200A");
            // Linker Trap 
            // Rechter Trap
            // Linker GevaarUitgang
            // Rechter GevaarUitgang

            ComplexPath["B3.309"].Neighbours = new List<Node> { ComplexPath["End B3.1B"] };
            ComplexPath["End B3.1B"].Neighbours = new List<Node> { ComplexPath["B3.309"], ComplexPath["Start B3.1B"], ComplexPath["B3.311"], ComplexPath["B3.310"], ComplexPath["B3.308"], ComplexPath["B3.306"] };
            ComplexPath["Start B3.1B"].Neighbours = new List<Node> { ComplexPath["End B3.1B"], ComplexPath["Start B3.1B"], ComplexPath["B3.305"], ComplexPath["B3.1"], ComplexPath["B3.304"], ComplexPath["B3.302"], ComplexPath["B3.300"] };
            ComplexPath["B3.311"].Neighbours = new List<Node> { ComplexPath["End B3.1B"] };
            ComplexPath["B3.305"].Neighbours = new List<Node> { ComplexPath["Start B3.1B"] };
            ComplexPath["B3.1"].Neighbours = new List<Node> { ComplexPath["Start B3.1B"], ComplexPath["End B3.2"], ComplexPath["B3.1A"] };
            ComplexPath["End B3.2"].Neighbours = new List<Node> { ComplexPath["B3.1"], ComplexPath["Start B3.2"], ComplexPath["B3.217"], ComplexPath["B3.210"], ComplexPath["B3.208"], ComplexPath["B3.215"] };
            ComplexPath["Start B3.2"].Neighbours = new List<Node> { ComplexPath["End B3.2"], ComplexPath["B3.3"], ComplexPath["B3.213"], ComplexPath["B3.206"], ComplexPath["B3.211"], ComplexPath["B3.209"] };
            ComplexPath["B3.3"].Neighbours = new List<Node> { ComplexPath["Start B3.2"], ComplexPath["B3.105"], ComplexPath["B3.103"], ComplexPath["B3.107"], ComplexPath["B3.200"], ComplexPath["B3.104"] };
            ComplexPath["B3.217"].Neighbours = new List<Node> { ComplexPath["End B3.2"] };
            ComplexPath["B3.210"].Neighbours = new List<Node> { ComplexPath["End B3.2"] };
            ComplexPath["B3.208"].Neighbours = new List<Node> { ComplexPath["End B3.2"] };
            ComplexPath["B3.215"].Neighbours = new List<Node> { ComplexPath["End B3.2"] };
            ComplexPath["B3.213"].Neighbours = new List<Node> { ComplexPath["Start B3.2"] };
            ComplexPath["B3.206"].Neighbours = new List<Node> { ComplexPath["Start B3.2"] };
            ComplexPath["B3.211"].Neighbours = new List<Node> { ComplexPath["Start B3.2"] };
            ComplexPath["B3.209"].Neighbours = new List<Node> { ComplexPath["Start B3.2"] };
            ComplexPath["B3.310"].Neighbours = new List<Node> { ComplexPath["End B3.1B"] };
            ComplexPath["B3.308"].Neighbours = new List<Node> { ComplexPath["End B3.1B"] };
            ComplexPath["B3.306"].Neighbours = new List<Node> { ComplexPath["End B3.1B"] };
            ComplexPath["B3.304"].Neighbours = new List<Node> { ComplexPath["Start B3.1B"] };
            ComplexPath["B3.302"].Neighbours = new List<Node> { ComplexPath["Start B3.1B"] };
            ComplexPath["B3.300"].Neighbours = new List<Node> { ComplexPath["Start B3.1B"] };
            ComplexPath["B3.1A"].Neighbours = new List<Node> { ComplexPath["B3.1"], ComplexPath["B3.255"], ComplexPath["B3.223"] };
            ComplexPath["B3.255"].Neighbours = new List<Node> { ComplexPath["B3.1A"] };
            ComplexPath["B3.223"].Neighbours = new List<Node> { ComplexPath["B3.1A"] };
            ComplexPath["B3.105"].Neighbours = new List<Node> { ComplexPath["B3.3"] };
            ComplexPath["B3.103"].Neighbours = new List<Node> { ComplexPath["B3.3"] };
            ComplexPath["B3.107"].Neighbours = new List<Node> { ComplexPath["B3.3"] };
            ComplexPath["B3.104"].Neighbours = new List<Node> { ComplexPath["B3.3"], ComplexPath["B3.114"], ComplexPath["B3.112"], ComplexPath["B3.116"], ComplexPath["B3.115"], ComplexPath["B3.110"], ComplexPath["B3.111"], ComplexPath["B3.122"], ComplexPath["B3.120"], ComplexPath["B3.108"], ComplexPath["B3.106"], ComplexPath["B3.104A"] };
            ComplexPath["B3.114"].Neighbours = new List<Node> { ComplexPath["B3.104"] };
            ComplexPath["B3.112"].Neighbours = new List<Node> { ComplexPath["B3.104"] };
            ComplexPath["B3.116"].Neighbours = new List<Node> { ComplexPath["B3.104"] };
            ComplexPath["B3.115"].Neighbours = new List<Node> { ComplexPath["B3.104"] };
            ComplexPath["B3.110"].Neighbours = new List<Node> { ComplexPath["B3.104"] };
            ComplexPath["B3.111"].Neighbours = new List<Node> { ComplexPath["B3.104"] };
            ComplexPath["B3.122"].Neighbours = new List<Node> { ComplexPath["B3.104"] };
            ComplexPath["B3.120"].Neighbours = new List<Node> { ComplexPath["B3.104"] };
            ComplexPath["B3.108"].Neighbours = new List<Node> { ComplexPath["B3.104"] };
            ComplexPath["B3.106"].Neighbours = new List<Node> { ComplexPath["B3.104"] };
            ComplexPath["B3.104A"].Neighbours = new List<Node> { ComplexPath["B3.104"] };
            ComplexPath["B3.200"].Neighbours = new List<Node> { ComplexPath["B3.3"], ComplexPath["B3.200B"], ComplexPath["B3.200A"] };
            ComplexPath["B3.200B"].Neighbours = new List<Node> { ComplexPath["B3.200"] };
            ComplexPath["B3.200A"].Neighbours = new List<Node> { ComplexPath["B3.200"] };

            IImage image;
            using (Stream? stream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream("EventPlannerMAUI.Resources.Images.floor3.png"))
                image = PlatformImage.FromStream(stream);

            canvas.DrawImage(image, 0, 0, image.Width / 1.8f, image.Height / 1.8f);

            canvas.FillColor = Colors.Red;
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 3;

            int ScaleFactor = 8;
            if (StartPos != null && EndPos != null)
            {

                List<Node> FastestPath = AStarAlgorithm(ComplexPath[StartPos], ComplexPath[EndPos]);

                canvas.FillColor = Colors.Green;
                canvas.StrokeColor = Colors.Green;

                for (int i = 0; i < FastestPath.Count(); i++)
                {

                    canvas.FillCircle((FastestPath[i].X * ScaleFactor) + 5, (FastestPath[i].Y * ScaleFactor) + 5, 5);

                    if (i > 0)
                        canvas.DrawLine(FastestPath[i].X * ScaleFactor + 5, FastestPath[i].Y * ScaleFactor + 5, FastestPath[i - 1].X * ScaleFactor + 5, FastestPath[i - 1].Y * ScaleFactor + 5);

                }

            }

        }

        public List<Node> AStarAlgorithm(Node startNode, Node endNode)
        {

            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();

            startNode.GCost = 0;
            startNode.HCost = startNode.CalculateDistance(endNode);
            startNode.FCost = startNode.HCost;

            openList.Add(startNode);

            Node? currentNode = null;
            while (openList.Count > 0)
            {

                openList.Sort((node1, node2) => node1.FCost.CompareTo(node2.FCost));
                currentNode = openList[0];

                openList.RemoveAt(0);
                closedList.Add(currentNode);

                if (currentNode.Id == endNode.Id)
                {

                    List<Node> path = new List<Node>();

                    currentNode = closedList[closedList.Count - 1];
                    while (currentNode != null)
                    {

                        path.Add(currentNode);
                        currentNode = currentNode.Parent;

                    }

                    return path;

                }

                foreach (Node neighbor in currentNode.Neighbours)
                {

                    Node newNeighbor = new Node(neighbor.Id, neighbor.X, neighbor.Y, neighbor.Name);
                    newNeighbor.Neighbours = neighbor.Neighbours;

                    newNeighbor.Parent = currentNode;
                    newNeighbor.GCost = currentNode.GCost + neighbor.CalculateDistance(currentNode);
                    newNeighbor.HCost = newNeighbor.CalculateDistance(endNode);
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

    }

}
