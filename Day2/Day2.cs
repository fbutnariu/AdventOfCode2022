namespace AdventOfCode2022.Day2
{
    internal class Day2
    {
        internal static void Part1()
        {
            IDictionary<char, int> oy = new Dictionary<char, int>
            {
                { 'A', 1 },
                { 'B', 2 },
                { 'C', 3 },
                { 'X', 1 },
                { 'Y', 2 },
                { 'Z', 3 }
            };
            IDictionary<string, int> wl = new Dictionary<string, int>
            {
                { "31", 6 },
                { "23", 6 },
                { "12", 6 },
                { "13", 0 },
                { "32", 0 },
                { "21", 0 },
                { "11", 3 },
                { "22", 3 },
                { "33", 3 }
            };
            int total = 0;
            foreach (string line in File.ReadLines(@"..\..\..\Day2\input.txt"))
            {
                int o = oy[line[0]];
                int y = oy[line[2]];
                total += wl[o + "" + y] + y;
            }
            Console.WriteLine(total);
        }

        internal static void Part2()
        {
            IDictionary<int, int> d = new Dictionary<int, int>
            {
                { 1, 1 },
                { 2, 2 },
                { 3, 3 },
            };
            IDictionary<int, int> l = new Dictionary<int, int>
            {
                { 1, 3 },
                { 3, 2 },
                { 2, 1 },
            };
            IDictionary<int, int> w = new Dictionary<int, int>
            {
                { 3, 1 },
                { 2, 3 },
                { 1, 2 },
            };
            IDictionary<char, IDictionary<int, int>> y = new Dictionary<char, IDictionary<int, int>>
            {
                { 'X', l },
                { 'Y', d },
                { 'Z', w }
            };
            IDictionary<char, int> yp = new Dictionary<char, int>
            {
                { 'X', 0 },
                { 'Y', 3 },
                { 'Z', 6 }
            };
            IDictionary<char, int> o = new Dictionary<char, int>
            {
                { 'A', 1 },
                { 'B', 2 },
                { 'C', 3 }
            };
            int total = 0;
            foreach (string line in File.ReadLines(@"..\..\..\Day2\input.txt"))
            {
                var di = y[line[2]];
                total += di[o[line[0]]] + yp[line[2]];
            }
            Console.WriteLine(total);
        }
    }
}
