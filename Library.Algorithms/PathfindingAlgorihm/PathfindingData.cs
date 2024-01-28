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
            ComplexPath["B3.225"] = new Node(24, 3.0f, 37.0f, "B3.225");
            ComplexPath["B3.221"] = new Node(25, 8.0f, 37.0f, "B3.223");
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
            ComplexPath["C3.1 Hall"] = new Node(44, 50.0f, 27.5f, "C3.1 Hall");
            ComplexPath["C3.1 Stair"] = new Node(45, 50.0f, 22.5f, "C3.1 Stair");
            ComplexPath["B3.1 Stair"] = new Node(46, 2.8f, 32.0f, "B3.1 Stair");
            ComplexPath["B3.1 Exit"] = new Node(47, 7.0f, 2.0f, "B3.1B Exit");
            ComplexPath["B3.104 Exit"] = new Node(48, 40.3f, 1.5f, "B3.104 Exit");

            // Floor 2
            ComplexPath["B2.315"] = new Node(49, 1.8f, 44.0f, "B2.315");
            ComplexPath["End B2.2"] = new Node(50, 6.6f, 46.3f, "End B2.2");
            ComplexPath["Start B2.2"] = new Node(51, 7.0f, 60.0f, "Start B2.2");
            ComplexPath["B2.317"] = new Node(52, 4.2f, 43.5f, "B2.317");
            ComplexPath["B2.305"] = new Node(53, 3.0f, 59.0f, "B2.305");
            ComplexPath["B2.1"] = new Node(54, 6.8f, 67.5f, "B2.1");
            ComplexPath["End B2.3"] = new Node(55, 21.2f, 66.8f, "End B2.2");
            ComplexPath["Start B2.3"] = new Node(56, 31.6f, 66.8f, "Start B2.2");
            ComplexPath["B2.4"] = new Node(57, 41.3f, 68.0f, "B2.3");
            ComplexPath["B2.207"] = new Node(58, 17.0f, 72.5f, "B2.207");
            ComplexPath["B2.210"] = new Node(59, 14.0f, 63.5f, "B2.210");
            ComplexPath["B2.208"] = new Node(60, 16.8f, 63.5f, "B2.208");
            ComplexPath["B2.205"] = new Node(61, 24.3f, 73.0f, "B2.205");
            ComplexPath["B2.203"] = new Node(62, 34.6f, 73.0f, "B2.203");
            ComplexPath["B2.206"] = new Node(63, 19.3f, 63.5f, "B2.206");
            ComplexPath["B2.204"] = new Node(64, 23.0f, 63.5f, "B2.204");
            ComplexPath["B2.312"] = new Node(65, 9.2f, 45.8f, "B2.312");
            ComplexPath["B2.310"] = new Node(66, 9.2f, 48.8f, "B2.310");
            ComplexPath["B2.308"] = new Node(67, 9.2f, 51.8f, "B2.308");
            ComplexPath["B2.306"] = new Node(68, 9.2f, 54.5f, "B2.306");
            ComplexPath["B2.304"] = new Node(69, 9.2f, 57.0f, "B2.304");
            ComplexPath["B2.302"] = new Node(70, 9.2f, 59.7f, "B2.302");
            ComplexPath["B2.1A"] = new Node(71, 6.0f, 73.0f, "B2.1A");
            ComplexPath["B2.212"] = new Node(72, 5.8f, 78.0f, "B2.212");
            ComplexPath["B2.209"] = new Node(73, 10.0f, 73.0f, "B2.209");
            ComplexPath["B2.203A"] = new Node(74, 39.0f, 77.8f, "B2.203A");
            ComplexPath["B2.201"] = new Node(75, 45.0f, 77.0f, "B2.201");
            ComplexPath["B2.309"] = new Node(76, 3.0f, 54.5f, "B2.309");
            ComplexPath["B2.104"] = new Node(77, 39.3f, 53.0f, "B2.104");
            ComplexPath["B2.313"] = new Node(78, 3.0f, 49.5f, "B2.313");
            ComplexPath["B2.104F"] = new Node(79, 44.8f, 42.3f, "B2.104F");
            ComplexPath["B2.104E"] = new Node(80, 45.8f, 46.1f, "B2.104E");
            ComplexPath["B2.104D"] = new Node(81, 43.2f, 50.5f, "B2.104D");
            ComplexPath["B2.104C"] = new Node(82, 45.8f, 50.6f, "B2.104C");
            ComplexPath["B2.104A"] = new Node(83, 43.0f, 55.5f, "B2.104A");
            ComplexPath["B2.104B"] = new Node(84, 45.8f, 54.5f, "B2.104B");
            ComplexPath["B2.200"] = new Node(85, 36.2f, 62.5f, "B2.200");
            ComplexPath["B2.202"] = new Node(86, 29.7f, 63.5f, "B2.202");
            ComplexPath["B2.300"] = new Node(91, 11.0f, 65.0f, "B2.300");
            ComplexPath["C2.1 Hall"] = new Node(92, 50.0f, 68.5f, "C2.1 Hall");
            ComplexPath["C2.1 Stair"] = new Node(93, 50.0f, 63.5f, "C2.1 Stair");
            ComplexPath["B2.1 Stair"] = new Node(94, 2.7f, 72.5f, "B2.1 Stair");
            ComplexPath["B2.1 Exit"] = new Node(95, 7.0f, 42.5f, "B2.1 Exit");
            ComplexPath["B2.104 Exit"] = new Node(96, 40.3f, 42.5f, "B2.104 Exit");

            // Floor 3
            ComplexPath["B3.309"].Neighbours = new List<Node> { ComplexPath["End B3.1B"] };
            ComplexPath["End B3.1B"].Neighbours = new List<Node> { ComplexPath["B3.309"], ComplexPath["Start B3.1B"], ComplexPath["B3.311"], ComplexPath["B3.310"], ComplexPath["B3.308"], ComplexPath["B3.306"], ComplexPath["B3.1 Exit"] };
            ComplexPath["Start B3.1B"].Neighbours = new List<Node> { ComplexPath["End B3.1B"], ComplexPath["B3.305"], ComplexPath["B3.1"], ComplexPath["B3.304"], ComplexPath["B3.302"], ComplexPath["B3.300"] };
            ComplexPath["B3.311"].Neighbours = new List<Node> { ComplexPath["End B3.1B"] };
            ComplexPath["B3.305"].Neighbours = new List<Node> { ComplexPath["Start B3.1B"] };
            ComplexPath["B3.1"].Neighbours = new List<Node> { ComplexPath["Start B3.1B"], ComplexPath["End B3.2"], ComplexPath["B3.1A"], ComplexPath["B3.1 Stair"] };
            ComplexPath["End B3.2"].Neighbours = new List<Node> { ComplexPath["B3.1"], ComplexPath["Start B3.2"], ComplexPath["B3.217"], ComplexPath["B3.210"], ComplexPath["B3.208"], ComplexPath["B3.215"] };
            ComplexPath["Start B3.2"].Neighbours = new List<Node> { ComplexPath["End B3.2"], ComplexPath["B3.3"], ComplexPath["B3.213"], ComplexPath["B3.206"], ComplexPath["B3.211"], ComplexPath["B3.209"] };
            ComplexPath["B3.3"].Neighbours = new List<Node> { ComplexPath["Start B3.2"], ComplexPath["B3.105"], ComplexPath["B3.103"], ComplexPath["B3.107"], ComplexPath["B3.200"], ComplexPath["B3.104"], ComplexPath["C3.1 Hall"] };
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
            ComplexPath["B2.317"].Neighbours = new List<Node> { ComplexPath["End B2.2"] };
            ComplexPath["End B2.2"].Neighbours = new List<Node> { ComplexPath["B2.315"], ComplexPath["B2.317"], ComplexPath["B2.1 Exit"], ComplexPath["B2.312"], ComplexPath["B2.310"], ComplexPath["B2.313"], ComplexPath["Start B2.2"] };
            ComplexPath["B2.1 Exit"].Neighbours = new List<Node> { ComplexPath["End B2.2"] };
            ComplexPath["B2.312"].Neighbours = new List<Node> { ComplexPath["End B2.2"] };
            ComplexPath["B2.310"].Neighbours = new List<Node> { ComplexPath["End B2.2"] };
            ComplexPath["B2.313"].Neighbours = new List<Node> { ComplexPath["End B2.2"] };
            ComplexPath["Start B2.2"].Neighbours = new List<Node> { ComplexPath["End B2.2"], ComplexPath["B2.309"], ComplexPath["B2.305"], ComplexPath["B2.308"], ComplexPath["B2.306"], ComplexPath["B2.304"], ComplexPath["B2.302"], ComplexPath["B2.1"] };
            ComplexPath["B2.309"].Neighbours = new List<Node> { ComplexPath["Start B2.2"] };
            ComplexPath["B2.305"].Neighbours = new List<Node> { ComplexPath["Start B2.2"] };
            ComplexPath["B2.308"].Neighbours = new List<Node> { ComplexPath["Start B2.2"] };
            ComplexPath["B2.306"].Neighbours = new List<Node> { ComplexPath["Start B2.2"] };
            ComplexPath["B2.304"].Neighbours = new List<Node> { ComplexPath["Start B2.2"] };
            ComplexPath["B2.302"].Neighbours = new List<Node> { ComplexPath["Start B2.2"] };
            ComplexPath["B2.1"].Neighbours = new List<Node> { ComplexPath["Start B2.2"], ComplexPath["End B2.3"], ComplexPath["B2.300"], ComplexPath["B2.209"], ComplexPath["B2.1 Stair"], ComplexPath["B2.1A"] };
            ComplexPath["B2.300"].Neighbours = new List<Node> { ComplexPath["B2.1"] };
            ComplexPath["B2.1 Stair"].Neighbours = new List<Node> { ComplexPath["B2.1"], ComplexPath["B3.1 Stair"] };
            ComplexPath["End B2.3"].Neighbours = new List<Node> { ComplexPath["B2.1"], ComplexPath["Start B2.3"], ComplexPath["B2.207"], ComplexPath["B2.205"], ComplexPath["B2.210"], ComplexPath["B2.208"], ComplexPath["B2.206"], ComplexPath["B2.204"] };
            ComplexPath["B2.1A"].Neighbours = new List<Node> { ComplexPath["B2.1"], ComplexPath["B2.212"], ComplexPath["B2.209"] };
            ComplexPath["B2.209"].Neighbours = new List<Node> { ComplexPath["B2.1"], ComplexPath["B2.1A"], ComplexPath["B2.207"] };
            ComplexPath["B2.207"].Neighbours = new List<Node> { ComplexPath["End B2.3"], ComplexPath["B2.205"] };
            ComplexPath["B2.205"].Neighbours = new List<Node> { ComplexPath["End B2.3"], ComplexPath["B2.207"] };
            ComplexPath["B2.210"].Neighbours = new List<Node> { ComplexPath["End B2.3"] };
            ComplexPath["B2.208"].Neighbours = new List<Node> { ComplexPath["End B2.3"] };
            ComplexPath["B2.206"].Neighbours = new List<Node> { ComplexPath["End B2.3"] };
            ComplexPath["B2.204"].Neighbours = new List<Node> { ComplexPath["End B2.3"] };
            ComplexPath["Start B2.3"].Neighbours = new List<Node> { ComplexPath["End B2.3"], ComplexPath["B2.202"], ComplexPath["B2.200"], ComplexPath["B2.203"] };
            ComplexPath["B2.202"].Neighbours = new List<Node> { ComplexPath["Start B2.3"] };
            ComplexPath["B2.200"].Neighbours = new List<Node> { ComplexPath["Start B2.3"], ComplexPath["B2.4"] };
            ComplexPath["B2.203"].Neighbours = new List<Node> { ComplexPath["Start B2.3"], ComplexPath["B2.203A"], ComplexPath["B2.201"], ComplexPath["B2.4"] };
            ComplexPath["B2.203A"].Neighbours = new List<Node> { ComplexPath["B2.203"] };
            ComplexPath["B2.201"].Neighbours = new List<Node> { ComplexPath["B2.203"], ComplexPath["B2.4"] };
            ComplexPath["B2.4"].Neighbours = new List<Node> { ComplexPath["B2.200"], ComplexPath["B2.201"], ComplexPath["B2.203"], ComplexPath["B2.104"], ComplexPath["C2.1 Hall"] };
            ComplexPath["C2.1 Hall"].Neighbours = new List<Node> { ComplexPath["B2.4"], ComplexPath["C2.1 Stair"] };
            ComplexPath["C2.1 Stair"].Neighbours = new List<Node> { ComplexPath["C2.1 Hall"], ComplexPath["C3.1 Stair"] };
            ComplexPath["B2.104"].Neighbours = new List<Node> { ComplexPath["B2.4"], ComplexPath["B2.104A"], ComplexPath["B2.104B"], ComplexPath["B2.104C"], ComplexPath["B2.104D"], ComplexPath["B2.104E"], ComplexPath["B2.104F"], ComplexPath["B2.104 Exit"] };
            ComplexPath["B2.104F"].Neighbours = new List<Node> { ComplexPath["B2.104"] };
            ComplexPath["B2.104E"].Neighbours = new List<Node> { ComplexPath["B2.104"] };
            ComplexPath["B2.104D"].Neighbours = new List<Node> { ComplexPath["B2.104"] };
            ComplexPath["B2.104C"].Neighbours = new List<Node> { ComplexPath["B2.104"] };
            ComplexPath["B2.104B"].Neighbours = new List<Node> { ComplexPath["B2.104"] };
            ComplexPath["B2.104A"].Neighbours = new List<Node> { ComplexPath["B2.104"] };
            ComplexPath["B2.104 Exit"].Neighbours = new List<Node> { ComplexPath["B2.104"] };

        }

    }

}
