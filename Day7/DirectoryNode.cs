using System.Collections;

namespace AdventOfCode2022.Day7
{
    internal class DirectoryNode : Node
    {
        internal ArrayList childDirectories = new ArrayList();
        internal ArrayList childFiles = new ArrayList();
        internal DirectoryNode(string name, DirectoryNode parent)
        {
            base.name = name;
            base.parent = parent;
        }

        internal void AddChildDirectory(DirectoryNode childDirectory)
        {
            childDirectories.Add(childDirectory);
        }

        internal void AddChildFile(FileNode childFile)
        {
            childFiles.Add(childFile);
        }

        internal DirectoryNode FindChildDirectory(string directoryName)
        {
            foreach (DirectoryNode childDirectory in childDirectories)
            {
                if (childDirectory.name.Equals(directoryName))
                {
                    return childDirectory;
                }
            }
            return null;
        }

        internal long Size()
        {
            long total = 0;
            foreach (DirectoryNode directoryNode in childDirectories)
            {
                total += directoryNode.Size();
            }
            foreach (FileNode fileNode in childFiles)
            {
                total += fileNode.size;
            }
            return total;
        }
    }
}
