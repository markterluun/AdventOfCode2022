using AoC.Apps.Day7.FileSystem;
using AoC.Shared;

namespace AoC.Apps.Day7.CLI;

internal readonly struct State
{
    public Node FSRoot { get; }
    public Stack<string> FSPath { get; }
    public Node FSPathNode => GetNodeFromPath();

    public State() {
        FSRoot = new();
        FSPath = new();
    }

    public State(Node fSRoot, Stack<string> fSPath) {
        FSRoot = fSRoot;
        FSPath = fSPath;
    }

    public void PrintDirectoryListing() {
        foreach (var obj in FSRoot.Children) {
            PrintFSObject(obj, 0);
        }
    }

    // Utility methods

    private Node GetNodeFromPath() {
        var node = FSRoot;

        foreach (var dir in FSPath.Reverse()) {
            node = node.Nodes.First(node => node.Name == dir);
        }
        return node;
    }

    private void PrintFSObject(FSObject obj, int level) {
        Console.WriteLine(obj.ToString(level));

        if (obj is Node node) {
            foreach (var child in node.Children) {
                PrintFSObject(child, level + 1);
            }
        }
    }
}
