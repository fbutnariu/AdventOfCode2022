namespace AdventOfCode2022.Day4
{
    internal class Day4
    {
        internal static void Part1()
        {
            int count = 0;
            foreach (string line in File.ReadLines(@"..\..\..\Day4\input.txt"))
            {
                int separator = line.IndexOf(',');
                string first = line.Substring(0, separator);
                string second = line.Substring(separator + 1);

                separator = first.IndexOf('-');
                int firstLow = int.Parse(first.Substring(0, separator));
                int firstUp = int.Parse(first.Substring(separator + 1));

                separator = second.IndexOf('-');
                int secondLow = int.Parse(second.Substring(0, separator));
                int secondUp = int.Parse(second.Substring(separator + 1));

                if ((firstLow <= secondLow && secondUp <= firstUp) || (secondLow <= firstLow && firstUp <= secondUp))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        internal static void Part2()
        {
            int count = 0;
            foreach (string line in File.ReadLines(@"..\..\..\Day4\input.txt"))
            {
                int separator = line.IndexOf(',');
                string first = line.Substring(0, separator);
                string second = line.Substring(separator + 1);

                separator = first.IndexOf('-');
                int firstLow = int.Parse(first.Substring(0, separator));
                int firstUp = int.Parse(first.Substring(separator + 1));

                separator = second.IndexOf('-');
                int secondLow = int.Parse(second.Substring(0, separator));
                int secondUp = int.Parse(second.Substring(separator + 1));

                if (!(firstUp < secondLow || secondUp < firstLow))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
