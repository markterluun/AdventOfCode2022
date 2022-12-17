using AoC.Shared;

namespace AoC.Apps.Day7.FileSystem;

internal abstract class FSObject
{
    public string Name { get; }
    
    private readonly WeakReference<Node?> _parent;
    public Node? Parent => _parent.TryGetTarget(out var parent)
        ? parent
        : null;

    protected FSObject(string name, Node? parent) {
        Name = name;
        _parent = new(parent);
    }

    public abstract int GetSize();

    public abstract string ToString(int level);

    protected static string GetIndentString(int level) =>
        $"{Enumerable.Repeat($"  ", level).AsString()}";
}
