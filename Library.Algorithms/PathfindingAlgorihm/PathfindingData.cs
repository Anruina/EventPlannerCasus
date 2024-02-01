using System.Xml.Linq;

namespace Library.Algorithms.PathfindingAlgorihm
{

    public class PathfindingData
    {

        public Dictionary<string, Node> ComplexPath { get; private set; }

        public PathfindingData()
        {

            ComplexPath = new Dictionary<string, Node>();
            OnCreate();

        }

        private void OnCreate()
        {

            // Floor 3
            ComplexPath["B3.309"] = new Node("B3.309", 1.8f, 3.0f);
            ComplexPath["End B3.1B"] = new Node("End B3.1B", 7.0f, 4.3f);
            ComplexPath["Start B3.1B"] = new Node("Start B3.1B", 7.0f, 19.0f);
            ComplexPath["B3.311"] = new Node("B3.311", 4.2f, 2.5f);
            ComplexPath["B3.305"] = new Node("B3.305", 3.0f, 19.0f);
            ComplexPath["B3.1"] = new Node("B3.1", 7.0f, 28.0f);
            ComplexPath["End B3.2"] = new Node("End B3.2", 19.0f, 28.8f);
            ComplexPath["Start B3.2"] = new Node("Start B3.2", 31.6f, 28.8f);
            ComplexPath["B3.3"] = new Node("B3.3", 41.3f, 27.5f);
            ComplexPath["B3.217"] = new Node("B3.217", 15.0f, 32.5f);
            ComplexPath["B3.210"] = new Node("B3.210", 15.0f, 22.5f);
            ComplexPath["B3.208"] = new Node("B3.208", 22.5f, 22.5f);
            ComplexPath["B3.215"] = new Node("B3.215", 21.3f, 32.5f);
            ComplexPath["B3.213"] = new Node("B3.213", 25.6f, 32.5f);
            ComplexPath["B3.206"] = new Node("B3.206", 28.5f, 22.5f);
            ComplexPath["B3.211"] = new Node("B3.211", 29.8f, 32.5f);
            ComplexPath["B3.209"] = new Node("B3.209", 34.0f, 32.5f);
            ComplexPath["B3.310"] = new Node("B3.310", 9.2f, 4.8f);
            ComplexPath["B3.308"] = new Node("B3.308", 9.2f, 7.8f);
            ComplexPath["B3.306"] = new Node("B3.306", 9.2f, 10.8f);
            ComplexPath["B3.304"] = new Node("B3.304", 9.2f, 13.5f);
            ComplexPath["B3.302"] = new Node("B3.302", 9.2f, 16.0f);
            ComplexPath["B3.300"] = new Node("B3.300", 9.2f, 18.7f);
            ComplexPath["B3.1A"] = new Node("B3.1A", 5.0f, 33.0f);
            ComplexPath["B3.225"] = new Node("B3.225", 3.0f, 37.0f);
            ComplexPath["B3.221"] = new Node("B3.223", 8.0f, 37.0f);
            ComplexPath["B3.105"] = new Node("B3.105", 40.5f, 34.0f);
            ComplexPath["B3.103"] = new Node("B3.103", 43.8f, 34.0f);
            ComplexPath["B3.107"] = new Node("B3.107", 42.0f, 37.8f);
            ComplexPath["B3.104"] = new Node("B3.104", 40.3f, 12.5f);
            ComplexPath["B3.114"] = new Node("B3.114", 44.8f, 2.3f);
            ComplexPath["B3.112"] = new Node("B3.112", 45.8f, 4.1f);
            ComplexPath["B3.116"] = new Node("B3.116", 44.2f, 7.1f);
            ComplexPath["B3.115"] = new Node("B3.115", 42.9f, 7.1f);
            ComplexPath["B3.110"] = new Node("B3.110", 45.8f, 11.1f);
            ComplexPath["B3.111"] = new Node("B3.111", 45.8f, 6.2f);
            ComplexPath["B3.122"] = new Node("B3.122", 42.9f, 15.2f);
            ComplexPath["B3.120"] = new Node("B3.120", 44.2f, 15.2f);
            ComplexPath["B3.108"] = new Node("B3.108", 45.8f, 16.1f);
            ComplexPath["B3.106"] = new Node("B3.106", 45.8f, 19.1f);
            ComplexPath["B3.104A"] = new Node("B3.104A", 43.1f, 19.1f);
            ComplexPath["B3.200"] = new Node("B3.200", 35.2f, 22.5f);
            ComplexPath["B3.200B"] = new Node("B3.200B", 32.7f, 21.5f);
            ComplexPath["B3.200A"] = new Node("B3.200A", 32.7f, 23.8f);
            ComplexPath["C3.1 Hall"] = new Node("C3.1 Hall", 50.0f, 27.5f);
            ComplexPath["C3.1 Stair"] = new Node("C3.1 Stair", 50.0f, 22.5f);
            ComplexPath["B3.1 Stair"] = new Node("B3.1 Stair", 2.8f, 32.0f);
            ComplexPath["B3.1 Exit"] = new Node("B3.1B Exit", 7.0f, 2.0f);
            ComplexPath["B3.104 Exit"] = new Node("B3.104 Exit", 40.3f, 1.5f);

            // Floor 2
            ComplexPath["B2.315"] = new Node("B2.315", 1.8f, 44.0f);
            ComplexPath["End B2.2"] = new Node("End B2.2", 6.6f, 46.3f);
            ComplexPath["Start B2.2"] = new Node("Start B2.2", 7.0f, 60.0f);
            ComplexPath["B2.317"] = new Node("B2.317", 4.2f, 43.5f);
            ComplexPath["B2.305"] = new Node("B2.305", 3.0f, 59.0f);
            ComplexPath["B2.1"] = new Node("B2.1", 6.8f, 67.5f);
            ComplexPath["End B2.3"] = new Node("End B2.3", 21.2f, 66.8f);
            ComplexPath["Start B2.3"] = new Node("Start B2.3", 31.6f, 66.8f);
            ComplexPath["B2.4"] = new Node("B2.4", 41.3f, 68.0f);
            ComplexPath["B2.207"] = new Node("B2.207", 17.0f, 72.5f);
            ComplexPath["B2.210"] = new Node("B2.210", 14.0f, 63.5f);
            ComplexPath["B2.208"] = new Node("B2.208", 16.8f, 63.5f);
            ComplexPath["B2.205"] = new Node("B2.205", 24.3f, 73.0f);
            ComplexPath["B2.203"] = new Node("B2.203", 34.6f, 73.0f);
            ComplexPath["B2.206"] = new Node("B2.206", 19.3f, 63.5f);
            ComplexPath["B2.204"] = new Node("B2.204", 23.0f, 63.5f);
            ComplexPath["B2.312"] = new Node("B2.312", 9.2f, 45.8f);
            ComplexPath["B2.310"] = new Node("B2.310", 9.2f, 48.8f);
            ComplexPath["B2.308"] = new Node("B2.308", 9.2f, 51.8f);
            ComplexPath["B2.306"] = new Node("B2.306", 9.2f, 54.5f);
            ComplexPath["B2.304"] = new Node("B2.304", 9.2f, 57.0f);
            ComplexPath["B2.302"] = new Node("B2.302", 9.2f, 59.7f);
            ComplexPath["B2.1A"] = new Node("B2.1A", 6.0f, 73.0f);
            ComplexPath["B2.212"] = new Node("B2.212", 5.8f, 78.0f);
            ComplexPath["B2.209"] = new Node("B2.209", 10.0f, 73.0f);
            ComplexPath["B2.203A"] = new Node("B2.203A", 39.0f, 77.8f);
            ComplexPath["B2.201"] = new Node("B2.201", 45.0f, 77.0f);
            ComplexPath["B2.309"] = new Node("B2.309", 3.0f, 54.5f);
            ComplexPath["B2.104"] = new Node("B2.104", 39.3f, 53.0f);
            ComplexPath["B2.313"] = new Node("B2.313", 3.0f, 49.5f);
            ComplexPath["B2.104F"] = new Node("B2.104F", 44.8f, 42.3f);
            ComplexPath["B2.104E"] = new Node("B2.104E", 45.8f, 46.1f);
            ComplexPath["B2.104D"] = new Node("B2.104D", 43.2f, 50.5f);
            ComplexPath["B2.104C"] = new Node("B2.104C", 45.8f, 50.6f);
            ComplexPath["B2.104A"] = new Node("B2.104A", 43.0f, 55.5f);
            ComplexPath["B2.104B"] = new Node("B2.104B", 45.8f, 54.5f);
            ComplexPath["B2.200"] = new Node("B2.200", 36.2f, 62.5f);
            ComplexPath["B2.202"] = new Node("B2.202", 29.7f, 63.5f);
            ComplexPath["B2.300"] = new Node("B2.300", 11.0f, 65.0f);
            ComplexPath["C2.1 Hall"] = new Node("C2.1 Hall", 50.0f, 68.5f);
            ComplexPath["C2.1 Stair"] = new Node("C2.1 Stair", 50.0f, 63.5f);
            ComplexPath["B2.1 Stair"] = new Node("B2.1 Stair", 2.7f, 72.5f);
            ComplexPath["B2.2 Exit"] = new Node("B2.2 Exit", 7.0f, 42.5f);
            ComplexPath["B2.104 Exit"] = new Node("B2.104 Exit", 40.3f, 42.5f);

            // Floor 1
            ComplexPath["B1.311A"] = new Node("B1.311A", 1.4f, 84.0f);
            ComplexPath["End B1.2"] = new Node("End B1.2", 6.2f, 87.3f);
            ComplexPath["Start B1.2"] = new Node("Start B1.2", 6.4f, 100.0f);
            ComplexPath["B1.311B"] = new Node("B1.311B", 4.0f, 84.0f);
            ComplexPath["B1.311"] = new Node("B1.311", 4.0f, 87.0f);
            ComplexPath["B1.305"] = new Node("B1.305", 2.5f, 98.5f);
            ComplexPath["B1.1"] = new Node("B1.1", 5.8f, 109.2f);
            ComplexPath["End B1.3"] = new Node("End B1.3", 15.8f, 110.0f);
            ComplexPath["Start B1.3"] = new Node("Start B1.3", 26.4f, 110.2f);
            ComplexPath["B1.01"] = new Node("B1.01", 41.0f, 109.0f);
            ComplexPath["B1.217"] = new Node("B1.217", 13.0f, 113.5f);
            ComplexPath["B1.206"] = new Node("B1.206", 13.0f, 103.5f);
            ComplexPath["B1.204"] = new Node("B1.204", 18.5f, 104.0f);
            ComplexPath["B1.213"] = new Node("B1.213", 18.8f, 113.5f);
            ComplexPath["B1.211"] = new Node("B1.211", 23.8f, 113.5f);
            ComplexPath["B1.202"] = new Node("B1.202", 23.5f, 104.0f);
            ComplexPath["B1.200"] = new Node("B1.200", 29.0f, 104.0f);
            ComplexPath["B1.312"] = new Node("B1.312", 8.5f, 86.5f);
            ComplexPath["B1.310"] = new Node("B1.310", 8.5f, 89.8f);
            ComplexPath["B1.308"] = new Node("B1.308", 8.5f, 92.8f);
            ComplexPath["B1.306"] = new Node("B1.306", 8.5f, 95.5f);
            ComplexPath["B1.304"] = new Node("B1.304", 8.5f, 98.0f);
            ComplexPath["B1.302"] = new Node("B1.302", 8.5f, 100.7f);
            ComplexPath["B1.005"] = new Node("B1.005", 4.5f, 118.0f);
            ComplexPath["B1.221"] = new Node("B1.221", 2.8f, 120.5f);
            ComplexPath["B1.223"] = new Node("B1.223", 1.5f, 118.0f);
            ComplexPath["B1.219"] = new Node("B1.219", 8.0f, 118.0f);
            ComplexPath["B1.04"] = new Node("B1.04", 39.0f, 117.8f);
            ComplexPath["B1.03"] = new Node("B1.201", 45.0f, 117.0f);
            ComplexPath["B1.307"] = new Node("B1.307", 2.8f, 93.0f);
            ComplexPath["B1.09"] = new Node("B1.09", 39.3f, 93.0f);
            ComplexPath["B1.309"] = new Node("B1.309", 2.8f, 89.5f);
            ComplexPath["B1.14"] = new Node("B1.14", 45.8f, 90.6f);
            ComplexPath["B1.15"] = new Node("B1.15", 43.2f, 88.5f);
            ComplexPath["B1.17"] = new Node("B1.17", 46.0f, 93.9f);
            ComplexPath["B1.16"] = new Node("B1.16", 46.0f, 92.5f);
            ComplexPath["B1.18"] = new Node("B1.18", 46.0f, 95.2f);
            ComplexPath["B1.19"] = new Node("B1.19", 43.5f, 94.0f);
            ComplexPath["B1.20"] = new Node("B1.20", 45.8f, 98.3f);
            ComplexPath["B1.22"] = new Node("B1.22", 42.8f, 98.9f);
            ComplexPath["B1.300"] = new Node("B1.300", 8.5f, 104.0f);
            ComplexPath["B1.101"] = new Node("B1.101", 34.0f, 103.8f);
            ComplexPath["B1.207A"] = new Node("B1.207A", 35.0f, 113.8f);
            ComplexPath["B1.207B"] = new Node("B1.207B", 32.6f, 113.8f);
            ComplexPath["B1.209A"] = new Node("B1.209A", 30.6f, 113.8f);
            ComplexPath["B1.209B"] = new Node("B1.209B", 27.9f, 113.8f);
            ComplexPath["B1.06"] = new Node("B1.06", 38.5f, 107.0f);
            ComplexPath["B1.02"] = new Node("B1.02", 38.5f, 112.0f);
            ComplexPath["C1.1 Hall"] = new Node("C1.1 Hall", 50.0f, 108.5f);
            ComplexPath["C1.1 Stair"] = new Node("C1.1 Stair", 50.0f, 104.5f);
            ComplexPath["B1.1 Stair"] = new Node("B1.1 Stair", 2.3f, 113.5f);
            ComplexPath["B1.2 Exit"] = new Node("B1.2 Exit", 7.0f, 83.5f);
            ComplexPath["B1.104 Exit"] = new Node("B1.104 Exit", 40.3f, 83.5f);

            // Floor 3
            ComplexPath["B3.309"].Neighbours = new List<Node> { ComplexPath["End B3.1B"] };
            ComplexPath["End B3.1B"].Neighbours = new List<Node> { ComplexPath["B3.309"], ComplexPath["Start B3.1B"], ComplexPath["B3.311"], ComplexPath["B3.310"], ComplexPath["B3.308"], ComplexPath["B3.306"], ComplexPath["B3.1 Exit"] };
            ComplexPath["Start B3.1B"].Neighbours = new List<Node> { ComplexPath["End B3.1B"], ComplexPath["B3.305"], ComplexPath["B3.1"], ComplexPath["B3.304"], ComplexPath["B3.302"], ComplexPath["B3.300"] };
            ComplexPath["B3.311"].Neighbours = new List<Node> { ComplexPath["End B3.1B"] };
            ComplexPath["B3.305"].Neighbours = new List<Node> { ComplexPath["Start B3.1B"] };
            ComplexPath["B3.1"].Neighbours = new List<Node> { ComplexPath["Start B3.1B"], ComplexPath["End B3.2"], ComplexPath["B3.1 Stair"], ComplexPath["B3.1A"] };
            ComplexPath["End B3.2"].Neighbours = new List<Node> { ComplexPath["B3.1"], ComplexPath["Start B3.2"], ComplexPath["B3.217"], ComplexPath["B3.210"], ComplexPath["B3.208"], ComplexPath["B3.215"] };
            ComplexPath["Start B3.2"].Neighbours = new List<Node> { ComplexPath["End B3.2"], ComplexPath["B3.3"], ComplexPath["B3.213"], ComplexPath["B3.206"], ComplexPath["B3.211"], ComplexPath["B3.209"] };
            ComplexPath["B3.3"].Neighbours = new List<Node> { ComplexPath["Start B3.2"], ComplexPath["B3.105"], ComplexPath["B3.103"], ComplexPath["B3.107"], ComplexPath["B3.200"], ComplexPath["B3.104"], ComplexPath["C3.1 Hall"] };
            ComplexPath["B3.217"].Neighbours = new List<Node> { ComplexPath["End B3.2"] };
            ComplexPath["B3.210"].Neighbours = new List<Node> { ComplexPath["End B3.2"] };
            ComplexPath["B3.208"].Neighbours = new List<Node> { ComplexPath["End B3.2"] };
            ComplexPath["B3.215"].Neighbours = new List<Node> { ComplexPath["End B3.2"] };
            ComplexPath["B3.213"].Neighbours = new List<Node> { ComplexPath["Start B3.2"], ComplexPath["B3.211"] };
            ComplexPath["B3.206"].Neighbours = new List<Node> { ComplexPath["Start B3.2"] };
            ComplexPath["B3.211"].Neighbours = new List<Node> { ComplexPath["Start B3.2"], ComplexPath["B3.213"], ComplexPath["B3.209"] };
            ComplexPath["B3.209"].Neighbours = new List<Node> { ComplexPath["Start B3.2"], ComplexPath["B3.211"] };
            ComplexPath["B3.310"].Neighbours = new List<Node> { ComplexPath["End B3.1B"] };
            ComplexPath["B3.308"].Neighbours = new List<Node> { ComplexPath["End B3.1B"] };
            ComplexPath["B3.306"].Neighbours = new List<Node> { ComplexPath["End B3.1B"] };
            ComplexPath["B3.304"].Neighbours = new List<Node> { ComplexPath["Start B3.1B"] };
            ComplexPath["B3.302"].Neighbours = new List<Node> { ComplexPath["Start B3.1B"] };
            ComplexPath["B3.300"].Neighbours = new List<Node> { ComplexPath["Start B3.1B"] };
            ComplexPath["B3.1A"].Neighbours = new List<Node> { ComplexPath["B3.1"], ComplexPath["B3.225"], ComplexPath["B3.221"] };
            ComplexPath["B3.225"].Neighbours = new List<Node> { ComplexPath["B3.1A"] };
            ComplexPath["B3.221"].Neighbours = new List<Node> { ComplexPath["B3.1A"] };
            ComplexPath["B3.105"].Neighbours = new List<Node> { ComplexPath["B3.3"] };
            ComplexPath["B3.103"].Neighbours = new List<Node> { ComplexPath["B3.3"] };
            ComplexPath["B3.107"].Neighbours = new List<Node> { ComplexPath["B3.3"] };
            ComplexPath["B3.104"].Neighbours = new List<Node> { ComplexPath["B3.3"], ComplexPath["B3.114"], ComplexPath["B3.112"], ComplexPath["B3.116"], ComplexPath["B3.115"], ComplexPath["B3.110"], ComplexPath["B3.111"], ComplexPath["B3.122"], ComplexPath["B3.120"], ComplexPath["B3.108"], ComplexPath["B3.106"], ComplexPath["B3.104A"], ComplexPath["B3.104 Exit"] };
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
            ComplexPath["C3.1 Hall"].Neighbours = new List<Node> { ComplexPath["B3.3"], ComplexPath["C3.1 Stair"] };
            ComplexPath["C3.1 Stair"].Neighbours = new List<Node> { ComplexPath["C3.1 Hall"], ComplexPath["C2.1 Stair"] };
            ComplexPath["B3.1 Stair"].Neighbours = new List<Node> { ComplexPath["B3.1"], ComplexPath["B2.1 Stair"] };
            ComplexPath["B3.1 Exit"].Neighbours = new List<Node> { ComplexPath["End B3.1B"] };
            ComplexPath["B3.104 Exit"].Neighbours = new List<Node> { ComplexPath["B3.104"] };

            // Floor 2
            ComplexPath["B2.315"].Neighbours = new List<Node> { ComplexPath["End B2.2"] };
            ComplexPath["End B2.2"].Neighbours = new List<Node> { ComplexPath["B2.315"], ComplexPath["Start B2.2"], ComplexPath["B2.317"], ComplexPath["B2.2 Exit"], ComplexPath["B2.312"], ComplexPath["B2.310"], ComplexPath["B2.308"], ComplexPath["B2.313"], ComplexPath["B2.309"] };
            ComplexPath["Start B2.2"].Neighbours = new List<Node> { ComplexPath["End B2.2"], ComplexPath["B2.309"], ComplexPath["B2.306"], ComplexPath["B2.304"], ComplexPath["B2.302"], ComplexPath["B2.305"], ComplexPath["B2.1"] };
            ComplexPath["B2.317"].Neighbours = new List<Node> { ComplexPath["End B2.2"] };
            ComplexPath["B2.305"].Neighbours = new List<Node> { ComplexPath["Start B2.2"] };
            ComplexPath["B2.1"].Neighbours = new List<Node> { ComplexPath["B2.1 Stair"], ComplexPath["B2.300"], ComplexPath["B2.209"], ComplexPath["B2.1A"], ComplexPath["End B2.3"], ComplexPath["Start B2.2"] };
            ComplexPath["End B2.3"].Neighbours = new List<Node> { ComplexPath["Start B2.3"], ComplexPath["B2.1"], ComplexPath["B2.207"], ComplexPath["B2.210"], ComplexPath["B2.208"], ComplexPath["B2.206"], ComplexPath["B2.204"], ComplexPath["B2.205"] };
            ComplexPath["Start B2.3"].Neighbours = new List<Node> { ComplexPath["End B2.3"], ComplexPath["B2.202"], ComplexPath["B2.203"], ComplexPath["B2.200"], ComplexPath["B2.4"] };
            ComplexPath["B2.4"].Neighbours = new List<Node> { ComplexPath["Start B2.3"], ComplexPath["B2.200"], ComplexPath["B2.203"], ComplexPath["B2.201"], ComplexPath["B2.104"], ComplexPath["C2.1 Hall"] };
            ComplexPath["B2.207"].Neighbours = new List<Node> { ComplexPath["B2.209"], ComplexPath["End B2.3"], ComplexPath["B2.205"] };
            ComplexPath["B2.210"].Neighbours = new List<Node> { ComplexPath["End B2.3"] };
            ComplexPath["B2.208"].Neighbours = new List<Node> { ComplexPath["End B2.3"] };
            ComplexPath["B2.205"].Neighbours = new List<Node> { ComplexPath["End B2.3"], ComplexPath["B2.207"] };
            ComplexPath["B2.203"].Neighbours = new List<Node> { ComplexPath["Start B2.3"], ComplexPath["B2.203A"], ComplexPath["B2.201"], ComplexPath["B2.4"] };
            ComplexPath["B2.206"].Neighbours = new List<Node> { ComplexPath["End B2.3"] };
            ComplexPath["B2.204"].Neighbours = new List<Node> { ComplexPath["End B2.3"] };
            ComplexPath["B2.312"].Neighbours = new List<Node> { ComplexPath["End B2.2"] };
            ComplexPath["B2.310"].Neighbours = new List<Node> { ComplexPath["End B2.2"] };
            ComplexPath["B2.308"].Neighbours = new List<Node> { ComplexPath["End B2.2"] };
            ComplexPath["B2.306"].Neighbours = new List<Node> { ComplexPath["Start B2.2"] };
            ComplexPath["B2.304"].Neighbours = new List<Node> { ComplexPath["Start B2.2"] };
            ComplexPath["B2.302"].Neighbours = new List<Node> { ComplexPath["Start B2.2"] };
            ComplexPath["B2.1A"].Neighbours = new List<Node> { ComplexPath["B2.1"], ComplexPath["B2.212"], ComplexPath["B2.209"] };
            ComplexPath["B2.212"].Neighbours = new List<Node> { ComplexPath["B2.1A"] };
            ComplexPath["B2.209"].Neighbours = new List<Node> { ComplexPath["B2.1A"], ComplexPath["B2.1"], ComplexPath["B2.207"] };
            ComplexPath["B2.203A"].Neighbours = new List<Node> { ComplexPath["B2.203"] };
            ComplexPath["B2.201"].Neighbours = new List<Node> { ComplexPath["B2.203"], ComplexPath["B2.4"] };
            ComplexPath["B2.309"].Neighbours = new List<Node> { ComplexPath["End B2.2"], ComplexPath["Start B2.2"] };
            ComplexPath["B2.104"].Neighbours = new List<Node> { ComplexPath["B2.4"], ComplexPath["B2.104A"], ComplexPath["B2.104B"], ComplexPath["B2.104C"], ComplexPath["B2.104D"], ComplexPath["B2.104E"], ComplexPath["B2.104F"], ComplexPath["B2.104 Exit"] };
            ComplexPath["B2.313"].Neighbours = new List<Node> { ComplexPath["End B2.2"] };
            ComplexPath["B2.104F"].Neighbours = new List<Node> { ComplexPath["B2.104"] };
            ComplexPath["B2.104E"].Neighbours = new List<Node> { ComplexPath["B2.104"] };
            ComplexPath["B2.104D"].Neighbours = new List<Node> { ComplexPath["B2.104"] };
            ComplexPath["B2.104C"].Neighbours = new List<Node> { ComplexPath["B2.104"] };
            ComplexPath["B2.104A"].Neighbours = new List<Node> { ComplexPath["B2.104"] };
            ComplexPath["B2.104B"].Neighbours = new List<Node> { ComplexPath["B2.104"] };
            ComplexPath["B2.200"].Neighbours = new List<Node> { ComplexPath["B2.4"], ComplexPath["Start B2.3"] };
            ComplexPath["B2.202"].Neighbours = new List<Node> { ComplexPath["Start B2.3"] };
            ComplexPath["B2.300"].Neighbours = new List<Node> { ComplexPath["B2.1"] };
            ComplexPath["C2.1 Hall"].Neighbours = new List<Node> { ComplexPath["B2.4"], ComplexPath["C2.1 Stair"] };
            ComplexPath["C2.1 Stair"].Neighbours = new List<Node> { ComplexPath["C2.1 Hall"], ComplexPath["C3.1 Stair"], ComplexPath["C1.1 Stair"] };
            ComplexPath["B2.1 Stair"].Neighbours = new List<Node> { ComplexPath["B2.1"], ComplexPath["B3.1 Stair"], ComplexPath["B1.1 Stair"] };
            ComplexPath["B2.2 Exit"].Neighbours = new List<Node> { ComplexPath["End B2.2"] };
            ComplexPath["B2.104 Exit"].Neighbours = new List<Node> { ComplexPath["B2.104"] };

            // Floor 1
            ComplexPath["B1.311A"].Neighbours = new List<Node> { ComplexPath["B1.311"] };
            ComplexPath["B1.311B"].Neighbours = new List<Node> { ComplexPath["B1.311"] };
            ComplexPath["B1.311"].Neighbours = new List<Node> { ComplexPath["B1.311A"], ComplexPath["B1.311B"], ComplexPath["End B1.2"] };
            ComplexPath["End B1.2"].Neighbours = new List<Node> { ComplexPath["B1.311"], ComplexPath["B1.2 Exit"], ComplexPath["B1.312"], ComplexPath["B1.310"], ComplexPath["B1.309"], ComplexPath["B1.307"], ComplexPath["B1.308"], ComplexPath["Start B1.2"] };
            ComplexPath["B1.2 Exit"].Neighbours = new List<Node> { ComplexPath["End B1.2"] };
            ComplexPath["B1.312"].Neighbours = new List<Node> { ComplexPath["End B1.2"] };
            ComplexPath["B1.309"].Neighbours = new List<Node> { ComplexPath["End B1.2"] };
            ComplexPath["B1.310"].Neighbours = new List<Node> { ComplexPath["End B1.2"] };
            ComplexPath["B1.308"].Neighbours = new List<Node> { ComplexPath["End B1.2"] };
            ComplexPath["B1.307"].Neighbours = new List<Node> { ComplexPath["End B1.2"], ComplexPath["Start B1.2"] };
            ComplexPath["B1.305"].Neighbours = new List<Node> { ComplexPath["Start B1.2"] };
            ComplexPath["B1.306"].Neighbours = new List<Node> { ComplexPath["Start B1.2"] };
            ComplexPath["B1.304"].Neighbours = new List<Node> { ComplexPath["Start B1.2"] };
            ComplexPath["B1.302"].Neighbours = new List<Node> { ComplexPath["Start B1.2"] };
            ComplexPath["Start B1.2"].Neighbours = new List<Node> { ComplexPath["End B1.2"], ComplexPath["B1.305"], ComplexPath["B1.307"], ComplexPath["B1.306"], ComplexPath["B1.302"], ComplexPath["B1.304"], ComplexPath["B1.1"] };
            ComplexPath["B1.1"].Neighbours = new List<Node> { ComplexPath["Start B1.2"], ComplexPath["B1.300"], ComplexPath["B1.1 Stair"], ComplexPath["B1.005"], ComplexPath["B1.219"], ComplexPath["End B1.3"] };
            ComplexPath["B1.300"].Neighbours = new List<Node> { ComplexPath["B1.1"] };
            ComplexPath["B1.219"].Neighbours = new List<Node> { ComplexPath["B1.1"] };
            ComplexPath["B1.005"].Neighbours = new List<Node> { ComplexPath["B1.1"], ComplexPath["B1.223"], ComplexPath["B1.221"] };
            ComplexPath["B1.221"].Neighbours = new List<Node> { ComplexPath["B1.005"] };
            ComplexPath["B1.223"].Neighbours = new List<Node> { ComplexPath["B1.005"] };
            ComplexPath["B1.1 Stair"].Neighbours = new List<Node> { ComplexPath["B1.1"], ComplexPath["B2.1 Stair"] };
            ComplexPath["End B1.3"].Neighbours = new List<Node> { ComplexPath["B1.1"], ComplexPath["Start B1.3"], ComplexPath["B1.206"], ComplexPath["B1.217"], ComplexPath["B1.204"], ComplexPath["B1.213"] };
            ComplexPath["B1.206"].Neighbours = new List<Node> { ComplexPath["End B1.3"] };
            ComplexPath["B1.217"].Neighbours = new List<Node> { ComplexPath["End B1.3"] };
            ComplexPath["B1.213"].Neighbours = new List<Node> { ComplexPath["End B1.3"] };
            ComplexPath["B1.204"].Neighbours = new List<Node> { ComplexPath["End B1.3"] };
            ComplexPath["Start B1.3"].Neighbours = new List<Node> { ComplexPath["End B1.3"], ComplexPath["B1.202"], ComplexPath["B1.200"], ComplexPath["B1.211"], ComplexPath["B1.209B"], ComplexPath["B1.209A"], ComplexPath["B1.207B"], ComplexPath["B1.207A"], ComplexPath["B1.01"] };
            ComplexPath["B1.202"].Neighbours = new List<Node> { ComplexPath["Start B1.3"] };
            ComplexPath["B1.200"].Neighbours = new List<Node> { ComplexPath["Start B1.3"], ComplexPath["B1.101"] };
            ComplexPath["B1.101"].Neighbours = new List<Node> { ComplexPath["B1.200"] };
            ComplexPath["B1.211"].Neighbours = new List<Node> { ComplexPath["Start B1.3"] };
            ComplexPath["B1.209B"].Neighbours = new List<Node> { ComplexPath["Start B1.3"], ComplexPath["B1.209A"] };
            ComplexPath["B1.209A"].Neighbours = new List<Node> { ComplexPath["Start B1.3"], ComplexPath["B1.209B"] };
            ComplexPath["B1.207B"].Neighbours = new List<Node> { ComplexPath["Start B1.3"], ComplexPath["B1.207A"] };
            ComplexPath["B1.207A"].Neighbours = new List<Node> { ComplexPath["Start B1.3"], ComplexPath["B1.207B"] };
            ComplexPath["B1.01"].Neighbours = new List<Node> { ComplexPath["Start B1.3"], ComplexPath["B1.06"], ComplexPath["B1.02"], ComplexPath["B1.03"], ComplexPath["C1.1 Hall"], ComplexPath["B1.09"] };
            ComplexPath["B1.06"].Neighbours = new List<Node> { ComplexPath["B1.01"] };
            ComplexPath["B1.02"].Neighbours = new List<Node> { ComplexPath["B1.01"] };
            ComplexPath["B1.03"].Neighbours = new List<Node> { ComplexPath["B1.01"], ComplexPath["B1.04"] };
            ComplexPath["B1.04"].Neighbours = new List<Node> { ComplexPath["B1.03"] };
            ComplexPath["C1.1 Hall"].Neighbours = new List<Node> { ComplexPath["B1.01"], ComplexPath["C1.1 Stair"] };
            ComplexPath["C1.1 Stair"].Neighbours = new List<Node> { ComplexPath["C1.1 Hall"], ComplexPath["C2.1 Stair"] };
            ComplexPath["B1.09"].Neighbours = new List<Node> { ComplexPath["B1.01"], ComplexPath["B1.15"], ComplexPath["B1.14"], ComplexPath["B1.16"], ComplexPath["B1.17"], ComplexPath["B1.18"], ComplexPath["B1.19"], ComplexPath["B1.20"], ComplexPath["B1.22"], ComplexPath["B1.104 Exit"] };
            ComplexPath["B1.15"].Neighbours = new List<Node> { ComplexPath["B1.09"] };
            ComplexPath["B1.14"].Neighbours = new List<Node> { ComplexPath["B1.09"] };
            ComplexPath["B1.16"].Neighbours = new List<Node> { ComplexPath["B1.09"] };
            ComplexPath["B1.17"].Neighbours = new List<Node> { ComplexPath["B1.09"] };
            ComplexPath["B1.18"].Neighbours = new List<Node> { ComplexPath["B1.09"] };
            ComplexPath["B1.19"].Neighbours = new List<Node> { ComplexPath["B1.09"] };
            ComplexPath["B1.20"].Neighbours = new List<Node> { ComplexPath["B1.09"] };
            ComplexPath["B1.22"].Neighbours = new List<Node> { ComplexPath["B1.09"] };
            ComplexPath["B1.104 Exit"].Neighbours = new List<Node> { ComplexPath["B1.09"] };

        }

    }

}
