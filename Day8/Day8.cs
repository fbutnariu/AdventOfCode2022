namespace AdventOfCode2022.Day8
{
    internal class Day8
    {
        internal static void Part1()
        {
            string[] lines = File.ReadAllLines(@"..\..\..\Day8\input.txt");
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < lines.Count(); i++)
            {
                set.Add(i + ",0");
                set.Add(i + "," + (lines[i].Length - 1));
            }

            for (int j = 1; j < lines[0].Length - 1; j++)
            {
                set.Add("0," + j);
                set.Add(lines.Count() - 1 + "," + j);
            }

            for (int i = 1; i < lines.Count(); i++)
            {
                char maxLine = lines[i][0];
                char maxColumn = lines[0][i];
                for (int j = 1; j < lines[i].Length; j++)
                {
                    if (maxLine < lines[i][j])
                    {
                        maxLine = lines[i][j];
                        set.Add(i + "," + j);
                    }
                    if (maxColumn < lines[j][i])
                    {
                        maxColumn = lines[j][i];
                        set.Add(j + "," + i);
                    }
                }

                maxLine = lines[i][lines[i].Length - 1];
                maxColumn = lines[lines[i].Length - 1][i];
                for (int j = lines[i].Length - 2; 0 <= j; j--)
                {
                    if (maxLine < lines[i][j])
                    {
                        maxLine = lines[i][j];
                        set.Add(i + "," + j);
                    }
                    if (maxColumn < lines[j][i])
                    {
                        maxColumn = lines[j][i];
                        set.Add(j + "," + i);
                    }
                }
            }
            Console.WriteLine(set.Count());
        }

        internal static void Part2()
        {
            string[] lines = File.ReadAllLines(@"..\..\..\Day8\input.txt");
            int max = 0;
            for (int i = 1; i < lines.Count() - 1; i++)
            {
                for (int j = 1; j < lines[i].Length -1 ; j++)
                {
                    int score = 1;

                    // up
                    int see = 0;
                    for (int k = i - 1; 0 <= k; k--)
                    {
                        see++;
                        if (lines[i][j] <= lines[k][j])
                        {
                            break;
                        }
                    }
                    score *= see;

                    // left
                    see = 0;
                    for (int k = j - 1; 0 <= k; k--)
                    {
                        see++;
                        if (lines[i][j] <= lines[i][k])
                        {
                            break;
                        }
                    }
                    score *= see;

                    // down
                    see = 0;
                    for (int k = i + 1; k < lines.Count(); k++)
                    {
                        see++;
                        if (lines[i][j] <= lines[k][j])
                        {
                            break;
                        }
                    }
                    score *= see;

                    // right
                    see = 0;
                    for (int k = j + 1; k < lines[i].Length; k++)
                    {
                        see++;
                        if (lines[i][j] <= lines[i][k])
                        {
                            break;
                        }
                    }
                    score *= see;

                    if (score > max)
                    {
                        max = score;
                    }
                }
            }
            Console.WriteLine(max);
        }
    }
}
