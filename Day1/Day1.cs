namespace AdventOfCode2022.Day1
{
    internal class Day1
    {
        internal static void Part1()
        {
            int total = 0;
            int maximum = 0;
            foreach (string line in File.ReadLines(@"..\..\..\Day1\input.txt"))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (total > maximum)
                    {
                        maximum = total;
                    }
                    total = 0;
                }
                else
                {

                    total += int.Parse(line);
                }
            }
            Console.WriteLine(maximum);
        }

        internal static void Part2()
        {
            int total = 0;
            int firstMaximum = 0;
            int secondMaximum = 0;
            int thirdMaximum = 0;
            foreach (string line in File.ReadLines(@"..\..\..\Day1\input.txt"))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    if (total > firstMaximum)
                    {
                        thirdMaximum = secondMaximum;
                        secondMaximum = firstMaximum;
                        firstMaximum = total;
                    }
                    else if (total > secondMaximum)
                    {
                        thirdMaximum = secondMaximum;
                        secondMaximum = total;
                    }
                    else if (total > thirdMaximum)
                    {
                        thirdMaximum = total;
                    }
                    total = 0;
                }
                else
                {
                    total += int.Parse(line);
                }
            }

            if (total > firstMaximum)
            {
                thirdMaximum = secondMaximum;
                secondMaximum = firstMaximum;
                firstMaximum = total;
            }
            else if (total > secondMaximum)
            {
                thirdMaximum = secondMaximum;
                secondMaximum = total;
            }
            else if (total > thirdMaximum)
            {
                thirdMaximum = total;
            }

            Console.WriteLine(firstMaximum + secondMaximum + thirdMaximum);
        }
    }
}
