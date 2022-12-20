namespace AoC.Apps.Day7.FileSystem;

internal class Node: FSObject
{
    #region Fields
    private readonly IList<FSObject> _children = new List<FSObject>();
    #endregion

    #region Properties
    public IEnumerable<FSObject> Children => _children;
    public IEnumerable<Node> Nodes => Children.OfType<Node>();
    public IEnumerable<Leaf> Leaves => Children.OfType<Leaf>();
    #endregion

    public Node(string name = "") : base(name, null) { }

    internal Node(string name, Node? parent) : base(name, parent) { }

    public Node AddNode(string name) {
        var node = new Node(name, this);
        _children.Add(node);
        return node;
    }

    public Leaf AddLeaf(string name, int size) {
        var leaf = new Leaf(name, size, this);
        _children.Add(leaf);
        return leaf;
    }

    public override int GetSize() =>
        Children.Sum(c => c.GetSize());

    public override string ToString(int level) =>
        $"{GetIndentString(level)}+ {Name}";
}
