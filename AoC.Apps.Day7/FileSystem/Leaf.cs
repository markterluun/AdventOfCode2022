namespace AoC.Apps.Day7.FileSystem;

internal class Leaf: FSObject
{
    public int Size { get; }

    internal Leaf(string name, int size, Node? parent) : base(name, parent) {
        Size = size;
    }

    public override int GetSize() => Size;

    public override string ToString(int level) =>
        $"{GetIndentString(level)}- {Name}; {Size}";
}
