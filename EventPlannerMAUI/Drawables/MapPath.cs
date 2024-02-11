using System.Reflection;
using IImage = Microsoft.Maui.Graphics.IImage;
using Microsoft.Maui.Graphics.Platform;
using Library.Algorithms.PathfindingAlgorihm;
using System.Diagnostics;

namespace EventPlannerMAUI.Drawables
{

    public class MapPath : IDrawable
    {

        public string? StartPos { get; set; }
        public string? EndPos { get; set; }

        public bool IsHandicapped { get; set; }

        public bool Emergency { get; set; }

        private readonly PathfindingData data;

        public MapPath()
        {

            data = new PathfindingData();

            IsHandicapped = false;
            Emergency = false;

        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
                
            // Floor 3 Image
            IImage floor3Image;
            using (Stream? stream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream("EventPlannerMAUI.Resources.Images.floor3.png"))
                floor3Image = PlatformImage.FromStream(stream);

            canvas.DrawImage(floor3Image, 0, 0, floor3Image.Width / 2.05f, floor3Image.Height / 2.05f);

            IImage floor3cImage;
            using (Stream? stream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream("EventPlannerMAUI.Resources.Images.floor3c.png"))
                floor3cImage = PlatformImage.FromStream(stream);

            canvas.DrawImage(floor3cImage, floor3Image.Width / 2.05f, (floor3Image.Height / 4.30f), floor3cImage.Width / 2.30f, floor3cImage.Height / 2.30f);

            // Floor 2 Image
            IImage floor2Image;
            using (Stream? stream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream("EventPlannerMAUI.Resources.Images.floor2.png"))
                floor2Image = PlatformImage.FromStream(stream);

            canvas.DrawImage(floor2Image, 0, floor3Image.Height / 2.10f, floor2Image.Width / 2.45f, floor2Image.Height / 2.45f);

            IImage floor2cImage;
            using (Stream? stream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream("EventPlannerMAUI.Resources.Images.floor2c.png"))
                floor2cImage = PlatformImage.FromStream(stream);

            canvas.DrawImage(floor2cImage, floor3Image.Width / 2.05f, (floor3Image.Height / 2.10f) + (floor2Image.Height / 5.15f), floor2cImage.Width / 2.30f, floor2cImage.Height / 2.30f);

            // Floor 1 Image
            IImage floor1Image;
            using (Stream? stream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream("EventPlannerMAUI.Resources.Images.floor1.png"))
                floor1Image = PlatformImage.FromStream(stream);

            canvas.DrawImage(floor1Image, 0, (floor3Image.Height / 2.10f) * 2.0f, floor2Image.Width / 2.45f, floor2Image.Height / 2.45f);

            IImage floor1cImage;
            using (Stream? stream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream("EventPlannerMAUI.Resources.Images.floor1c.png"))
                floor1cImage = PlatformImage.FromStream(stream);

            canvas.DrawImage(floor1cImage, floor3Image.Width / 2.05f, ((floor3Image.Height / 2.10f) * 2.0f) + (floor1Image.Height / 4.85f), floor1cImage.Width / 2.30f, floor1cImage.Height / 2.30f);
            
            // Floor 0 Image
            IImage floor0Image;
            using (Stream? stream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream("EventPlannerMAUI.Resources.Images.floor0.png"))
                floor0Image = PlatformImage.FromStream(stream);

            canvas.DrawImage(floor0Image, 0, (floor3Image.Height / 2.10f) * 3.0f, floor2Image.Width / 2.45f, floor2Image.Height / 2.45f);

            IImage floor0cImage;
            using (Stream? stream = GetType().GetTypeInfo().Assembly.GetManifestResourceStream("EventPlannerMAUI.Resources.Images.floor0c.png"))
                floor0cImage = PlatformImage.FromStream(stream);

            canvas.DrawImage(floor0cImage, floor3Image.Width / 2.05f, ((floor3Image.Height / 2.10f) * 3.0f) + (floor0Image.Height / 9.75f), floor0cImage.Width / 2.00f, floor0cImage.Height / 2.00f);

            int ScaleFactor = 8;
            if (!Emergency)
            {

                if (StartPos != null && EndPos != null)
                {

                    List<PathFindingNode> FastestPath = Pathfinding.AStarAlgorithm(data.ComplexPath[StartPos], data.ComplexPath[EndPos], IsHandicapped);

                    canvas.FillColor = Colors.Navy;
                    canvas.StrokeColor = Colors.Navy;
                    canvas.StrokeSize = 3;

                    for (int i = 0; i < FastestPath.Count(); i++)
                    {

                        canvas.FillCircle((FastestPath[i].Node.X * ScaleFactor) + 5, (FastestPath[i].Node.Y * ScaleFactor) + 5, 5);

                        if (i > 0)
                            canvas.DrawLine(FastestPath[i].Node.X * ScaleFactor + 5, FastestPath[i].Node.Y * ScaleFactor + 5, FastestPath[i - 1].Node.X * ScaleFactor + 5, FastestPath[i - 1].Node.Y * ScaleFactor + 5);

                    }

                    canvas.FillCircle((FastestPath[0].Node.X * ScaleFactor) + 5, (FastestPath[0].Node.Y * ScaleFactor) + 5, 6);

                    canvas.FillColor = Colors.LightGreen;
                    canvas.FillCircle((FastestPath[0].Node.X * ScaleFactor) + 5, (FastestPath[0].Node.Y * ScaleFactor) + 5, 5);

                }

            }
            else
            {

                if (StartPos != null && StartPos != "Entrance")
                {
                    
                    char currentFloor = StartPos[1];

                    List<PathFindingNode> FastestPath = Pathfinding.AStarAlgorithm(data.ComplexPath[StartPos], data.ComplexPath["B" + currentFloor + ".2 Exit"]);
                    List<PathFindingNode> OtherPath = Pathfinding.AStarAlgorithm(data.ComplexPath[StartPos], data.ComplexPath["B" + currentFloor + ".1 Stair"]);

                    if (FastestPath[FastestPath.Count - 1].GCost > OtherPath[OtherPath.Count - 1].GCost)
                        FastestPath = OtherPath;

                    if (currentFloor == '0')
                        OtherPath = Pathfinding.AStarAlgorithm(data.ComplexPath[StartPos], data.ComplexPath["Entrance"]);
                    else
                        OtherPath = Pathfinding.AStarAlgorithm(data.ComplexPath[StartPos], data.ComplexPath["C" + currentFloor + ".1 Stair"]);

                    if (FastestPath[FastestPath.Count - 1].GCost > OtherPath[OtherPath.Count - 1].GCost)
                        FastestPath = OtherPath;

                    OtherPath = Pathfinding.AStarAlgorithm(data.ComplexPath[StartPos], data.ComplexPath["B" + currentFloor + ".104 Exit"]);
                    if (FastestPath[FastestPath.Count - 1].GCost > OtherPath[OtherPath.Count - 1].GCost)
                        FastestPath = OtherPath;

                    canvas.FillColor = Colors.Navy;
                    canvas.StrokeColor = Colors.Navy;
                    canvas.StrokeSize = 3;

                    for (int i = 0; i < FastestPath.Count(); i++)
                    {

                        canvas.FillCircle((FastestPath[i].Node.X * ScaleFactor) + 5, (FastestPath[i].Node.Y * ScaleFactor) + 5, 5);

                        if (i > 0)
                            canvas.DrawLine(FastestPath[i].Node.X * ScaleFactor + 5, FastestPath[i].Node.Y * ScaleFactor + 5, FastestPath[i - 1].Node.X * ScaleFactor + 5, FastestPath[i - 1].Node.Y * ScaleFactor + 5);

                    }

                    canvas.FillCircle((FastestPath[0].Node.X * ScaleFactor) + 5, (FastestPath[0].Node.Y * ScaleFactor) + 5, 6);

                    canvas.FillColor = Colors.LightGreen;
                    canvas.FillCircle((FastestPath[0].Node.X * ScaleFactor) + 5, (FastestPath[0].Node.Y * ScaleFactor) + 5, 5);
                    
                }

            }

        }

    }

}
