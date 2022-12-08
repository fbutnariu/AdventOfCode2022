namespace AdventOfCode2022.Day5
{
    internal class Day5
    {
        internal static void Part1()
        {
            var lines = File.ReadLines(@"..\..\..\Day5\input.txt");
            int i = 0;
            string line = lines.ElementAt(i);
            while (!string.IsNullOrWhiteSpace(line))
            {
                line = lines.ElementAt(++i);
            }



            IDictionary<int, string> stacks = new Dictionary<int, string>();
            line = lines.ElementAt(i - 1);
            int k = 1;
            int position = line.IndexOf(k.ToString());

            while (position > -1)
            {
                string stack = "";
                for (int j = i - 2; 0 <= j; j--)
                {
                    line = lines.ElementAt(j);
                    if (line[position] != ' ')
                    {
                        stack += line[position];
                    }
                    else
                    {
                        break;
                    }
                }

                stacks.Add(k, stack);
                line = lines.ElementAt(i - 1);
                k++;
                position = line.IndexOf(k.ToString());
            }



            for (int j = i + 1; j < lines.Count(); j++)
            {
                line = lines.ElementAt(j);
                int count = int.Parse(line.Substring(5, line.IndexOf(" from ") - 5)); // 5 is length of "move "

                int startIndex = line.IndexOf(" from ") + 6; // 6 is length of " from "
                int from = int.Parse(line.Substring(startIndex, line.IndexOf(" to ") - startIndex));

                int to = int.Parse(line.Substring(line.IndexOf(" to ") + 4)); // 4 is length of " to "

                for (k = 0; k < count; k++)
                {
                    stacks[to] += stacks[from].ElementAt(stacks[from].Length - 1);
                    stacks[from] = stacks[from].Substring(0, stacks[from].Length - 1);
                }
            }


            foreach (var pair in stacks)
            {
                Console.Write(pair.Value[pair.Value.Length - 1]);
            }
            Console.WriteLine();
        }

        internal static void Part2()
        {
            var lines = File.ReadLines(@"..\..\..\Day5\input.txt");
            int i = 0;
            string line = lines.ElementAt(i);
            while (!string.IsNullOrWhiteSpace(line))
            {
                line = lines.ElementAt(++i);
            }



            IDictionary<int, string> stacks = new Dictionary<int, string>();
            line = lines.ElementAt(i - 1);
            int k = 1;
            int position = line.IndexOf(k.ToString());

            while (position > -1)
            {
                string stack = "";
                for (int j = i - 2; 0 <= j; j--)
                {
                    line = lines.ElementAt(j);
                    if (line[position] != ' ')
                    {
                        stack += line[position];
                    }
                    else
                    {
                        break;
                    }
                }

                stacks.Add(k, stack);
                line = lines.ElementAt(i - 1);
                k++;
                position = line.IndexOf(k.ToString());
            }



            for (int j = i + 1; j < lines.Count(); j++)
            {
                line = lines.ElementAt(j);
                int count = int.Parse(line.Substring(5, line.IndexOf(" from ") - 5)); // 5 is length of "move "

                int startIndex = line.IndexOf(" from ") + 6; // 6 is length of " from "
                int from = int.Parse(line.Substring(startIndex, line.IndexOf(" to ") - startIndex));

                int to = int.Parse(line.Substring(line.IndexOf(" to ") + 4)); // 4 is length of " to "

                stacks[to] += stacks[from].Substring(stacks[from].Length - count, count);
                stacks[from] = stacks[from].Substring(0, stacks[from].Length - count);
            }


            foreach (var pair in stacks)
            {
                Console.Write(pair.Value[pair.Value.Length - 1]);
            }
            Console.WriteLine();
        }
    }
}
