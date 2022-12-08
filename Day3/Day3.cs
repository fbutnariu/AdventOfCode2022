using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3
{
    internal class Day3
    {
        internal static void Part1()
        {
            string priority = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int total = 0;
            foreach (string line in File.ReadLines(@"..\..\..\Day3\input.txt"))
            {
                string first = line.Substring(0, line.Length / 2);
                string second = line.Substring(line.Length / 2);

                foreach (char c in first)
                {
                    if (second.IndexOf(c) > -1)
                    {
                        total += priority.IndexOf(c) + 1;
                        break;
                    }
                }
            }
            Console.WriteLine(total);
        }

        internal static void Part2()
        {
            string priority = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int total = 0;
            var lines = File.ReadLines(@"..\..\..\Day3\input.txt");
            for (int i = 0; i < lines.Count(); i += 3)
            {
                string first = lines.ElementAt(i);
                string second = lines.ElementAt(i + 1);
                string third = lines.ElementAt(i + 2);
                foreach (char c in first)
                {
                    if (second.IndexOf(c) > -1 && third.IndexOf(c) > -1)
                    {
                        total += priority.IndexOf(c) + 1;
                        break;
                    }
                }
            }
            Console.WriteLine(total);
        }
    }
}
