namespace AdventOfCode2022.Day6
{
    internal class Day6
    {
        internal static void Part1()
        {
            foreach (string line in File.ReadLines(@"..\..\..\Day6\input.txt"))
            {
                string marker = line[0].ToString();
                int i = 1;
                while (i < line.Length && marker.Length < 4)
                {
                    int j = marker.IndexOf(line[i]);
                    if (j != -1)
                    {
                        marker = marker.Substring(j + 1);
                    }
                    marker += line[i];
                    i++;
                }
                Console.WriteLine(i);
            }
        }

        internal static void Part2()
        {
            foreach (string line in File.ReadLines(@"..\..\..\Day6\input.txt"))
            {
                string marker = line[0].ToString();
                int i = 1;
                while (i < line.Length && marker.Length < 14)
                {
                    int j = marker.IndexOf(line[i]);
                    if (j != -1)
                    {
                        marker = marker.Substring(j + 1);
                    }
                    marker += line[i];
                    i++;
                }
                Console.WriteLine(i);
            }
        }
    }
}
