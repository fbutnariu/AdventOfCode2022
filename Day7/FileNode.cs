namespace AdventOfCode2022.Day7
{
    internal class FileNode : Node
    {
        internal long size;

        internal FileNode(string name, long size, DirectoryNode parent)
        {
            base.name = name;
            this.size = size;
            base.parent = parent;
        }
    }
}
