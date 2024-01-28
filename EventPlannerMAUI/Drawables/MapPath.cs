using System.Reflection;
using IImage = Microsoft.Maui.Graphics.IImage;
using Microsoft.Maui.Graphics.Platform;
using Library.Algorithms.PathfindingAlgorihm;

namespace EventPlannerMAUI.Drawables
{

    public class MapPath : IDrawable
    {

        public string? StartPos { get; set; }
        public string? EndPos { get; set; }

        public bool Emergency { get; set; }

        public MapPath()
        {

            StartPos = "B3.217";
            EndPos = "B3.209";

            Emergency = false;

        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {

            PathfindingData data = new PathfindingData();
            
            // Floor 3 Image
            IImage floor3Image;
            using (Stream? stream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream("EventPlannerMAUI.Resources.Images.floor3.png"))
                floor3Image = PlatformImage.FromStream(stream);

            canvas.DrawImage(floor3Image, 0, 0, floor3Image.Width / 2.05f, floor3Image.Height / 2.05f);

            // Floor 2 Image
            IImage floor2Image;
            using (Stream? stream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream("EventPlannerMAUI.Resources.Images.floor2.png"))
                floor2Image = PlatformImage.FromStream(stream);

            canvas.DrawImage(floor2Image, 0, floor3Image.Height / 2.10f, floor2Image.Width / 2.45f, floor2Image.Height / 2.45f);

            int ScaleFactor = 8;

            if (!Emergency)
            {

                if (StartPos != null && EndPos != null)
                {

                    List<Node> FastestPath = Pathfinding.AStarAlgorithm(data.ComplexPath[StartPos], data.ComplexPath[EndPos]);

                    canvas.FillColor = Colors.Navy;
                    canvas.StrokeColor = Colors.Navy;
                    canvas.StrokeSize = 3;

                    for (int i = 0; i < FastestPath.Count(); i++)
                    {

                        canvas.FillCircle((FastestPath[i].X * ScaleFactor) + 5, (FastestPath[i].Y * ScaleFactor) + 5, 5);

                        if (i > 0)
                            canvas.DrawLine(FastestPath[i].X * ScaleFactor + 5, FastestPath[i].Y * ScaleFactor + 5, FastestPath[i - 1].X * ScaleFactor + 5, FastestPath[i - 1].Y * ScaleFactor + 5);

                    }

                    canvas.FillCircle((FastestPath[0].X * ScaleFactor) + 5, (FastestPath[0].Y * ScaleFactor) + 5, 6);

                    canvas.FillColor = Colors.LightGreen;
                    canvas.FillCircle((FastestPath[0].X * ScaleFactor) + 5, (FastestPath[0].Y * ScaleFactor) + 5, 5);

                }

            }
            else
            {

                if (StartPos != null)
                {

                    char currentFloor = StartPos[1];

                    List<Node> FastestPath = Pathfinding.AStarAlgorithm(data.ComplexPath[StartPos], data.ComplexPath["C" + currentFloor + ".1 Stair"]);
                    List<Node> OtherPath = Pathfinding.AStarAlgorithm(data.ComplexPath[StartPos], data.ComplexPath["B" + currentFloor + ".1 Stair"]);

                    if (FastestPath[0].GCost > OtherPath[0].GCost)
                        FastestPath = OtherPath;

                    OtherPath = Pathfinding.AStarAlgorithm(data.ComplexPath[StartPos], data.ComplexPath["B" + currentFloor + ".1 Exit"]);
                    if (FastestPath[0].GCost > OtherPath[0].GCost)
                        FastestPath = OtherPath;

                    OtherPath = Pathfinding.AStarAlgorithm(data.ComplexPath[StartPos], data.ComplexPath["B" + currentFloor + ".104 Exit"]);
                    if (FastestPath[0].GCost > OtherPath[0].GCost)
                        FastestPath = OtherPath;

                    canvas.FillColor = Colors.Navy;
                    canvas.StrokeColor = Colors.Navy;
                    canvas.StrokeSize = 3;

                    for (int i = 0; i < FastestPath.Count(); i++)
                    {

                        canvas.FillCircle((FastestPath[i].X * ScaleFactor) + 5, (FastestPath[i].Y * ScaleFactor) + 5, 5);

                        if (i > 0)
                            canvas.DrawLine(FastestPath[i].X * ScaleFactor + 5, FastestPath[i].Y * ScaleFactor + 5, FastestPath[i - 1].X * ScaleFactor + 5, FastestPath[i - 1].Y * ScaleFactor + 5);

                    }

                    canvas.FillCircle((FastestPath[0].X * ScaleFactor) + 5, (FastestPath[0].Y * ScaleFactor) + 5, 6);

                    canvas.FillColor = Colors.LightGreen;
                    canvas.FillCircle((FastestPath[0].X * ScaleFactor) + 5, (FastestPath[0].Y * ScaleFactor) + 5, 5);

                }

            }

        }

    }

}
