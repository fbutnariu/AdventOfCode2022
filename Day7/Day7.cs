using System.Xml.Schema;

namespace AdventOfCode2022.Day7
{
    internal class Day7
    {
        internal static void Part1()
        {
            DirectoryNode root = new DirectoryNode("/", null);
            DirectoryNode current = root;

            string[] lines = File.ReadAllLines(@"..\..\..\Day7\input.txt");
            int i = 0;
            while (i < lines.Count())
            {
                if (lines[i].StartsWith("$ cd .."))
                {
                    current = (DirectoryNode)current.parent;
                }
                else if (lines[i].StartsWith("$ cd "))
                {
                    string directoryName = lines[i].Substring(5);
                    if (directoryName.Equals("/"))
                    {
                        current = root;
                    }
                    else
                    {
                        current = current.FindChildDirectory(directoryName);
                    }
                }
                else if (lines[i].StartsWith("$ ls"))
                {
                    i++;
                    while (i < lines.Count() && !lines[i].StartsWith('$'))
                    {
                        if (lines[i].StartsWith("dir "))
                        {
                            // directory
                            string directoryName = lines[i].Substring(4);
                            DirectoryNode directoryNode = new DirectoryNode(directoryName, current);
                            current.AddChildDirectory(directoryNode);
                        }
                        else
                        {
                            // file
                            int whitespace = lines[i].IndexOf(' ');
                            long size = long.Parse(lines[i].Substring(0, whitespace));
                            string fileName = lines[i].Substring(whitespace + 1);
                            FileNode fileNode = new FileNode(fileName, size, current);
                            current.AddChildFile(fileNode);
                        }
                        i++;
                    }
                    i--;
                }
                i++;
            }

            Console.WriteLine(Total(root));
        }

        private static long Total(DirectoryNode root)
        {
            long size = root.Size();
            long total = size < 100000 ? size : 0;
            foreach (DirectoryNode directoryNode in root.childDirectories)
            {
                total += Total(directoryNode);
            }
            return total;
        }

        internal static void Part2()
        {
            DirectoryNode root = new DirectoryNode("/", null);
            DirectoryNode current = root;

            string[] lines = File.ReadAllLines(@"..\..\..\Day7\input.txt");
            int i = 0;
            while (i < lines.Count())
            {
                if (lines[i].StartsWith("$ cd .."))
                {
                    current = (DirectoryNode)current.parent;
                }
                else if (lines[i].StartsWith("$ cd "))
                {
                    string directoryName = lines[i].Substring(5);
                    if (directoryName.Equals("/"))
                    {
                        current = root;
                    }
                    else
                    {
                        current = current.FindChildDirectory(directoryName);
                    }
                }
                else if (lines[i].StartsWith("$ ls"))
                {
                    i++;
                    while (i < lines.Count() && !lines[i].StartsWith('$'))
                    {
                        if (lines[i].StartsWith("dir "))
                        {
                            // directory
                            string directoryName = lines[i].Substring(4);
                            DirectoryNode directoryNode = new DirectoryNode(directoryName, current);
                            current.AddChildDirectory(directoryNode);
                        }
                        else
                        {
                            // file
                            int whitespace = lines[i].IndexOf(' ');
                            long size = long.Parse(lines[i].Substring(0, whitespace));
                            string fileName = lines[i].Substring(whitespace + 1);
                            FileNode fileNode = new FileNode(fileName, size, current);
                            current.AddChildFile(fileNode);
                        }
                        i++;
                    }
                    i--;
                }
                i++;
            }

            long unusedSize = 70000000 - root.Size();
            long deleteSize = 30000000 - unusedSize;
            Console.WriteLine(Min(root, deleteSize));
        }

        private static long Min(DirectoryNode root, long deleteSize)
        {
            long min = root.Size();
            foreach (DirectoryNode directoryNode in root.childDirectories)
            {
                long tmp = Min(directoryNode, deleteSize);
                if (tmp < min && tmp >= deleteSize)
                {
                    min = tmp;
                }
            }
            return min;
        }
    }
}
