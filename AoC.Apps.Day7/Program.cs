using AoC.Apps.Day7.CLI;
using AoC.Apps.Day7.FileSystem;

namespace AoC.Apps.Day7;

static class Program
{
    static void Main() {
        var input = File.ReadAllLines(".input.txt");
        var testInput = File.ReadAllLines(".testinput.txt");

        var interpreter = new Interpreter();
        foreach (var line in input) {
            interpreter.Parse(line);
        }

        Part1(interpreter.State);
        Part2(interpreter.State);
    }

    static void Part1(State state) {
        // Find directories of size <= 100.000
        var maxSize = 100000;
        var smallDirectories = FindSmallDirectories(state.FSRoot, maxSize);
        var totalSize = smallDirectories.Sum(d => d.GetSize());

        Console.WriteLine(totalSize);
    }

    static void Part2(State state) {
        var diskSpace = 70000000;
        var requiredSpace = 30000000;
        var usedSpace = state.FSRoot.GetSize();
        var freeSpace = diskSpace - usedSpace;
        var cleanup = requiredSpace - freeSpace;

        // Find directories of size >= {cleanup}
        var directories = FindLargeDirectories(state.FSRoot, cleanup)
            .OrderBy(e => e.GetSize());

        foreach (var dir in directories) {
            var _dir = dir;
            var path = new Stack<string>();

            while (_dir != null) {
                if (!string.IsNullOrEmpty(_dir.Name)) {
                    path.Push(_dir.Name);
                }

                _dir = _dir.Parent;
            }

            var pathString = string.Join('/', path);
            Console.WriteLine($"/{pathString}; {dir.GetSize()}");
        }
    }

    static IEnumerable<Node> FindSmallDirectories(Node root, int maxSize) {
        foreach (var node in root.Nodes) {
            if (node.GetSize() <= maxSize) {
                yield return node;
            }

            foreach (var subNode in FindSmallDirectories(node, maxSize)) {
                yield return subNode;
            }
        }
    }

    static IEnumerable<Node> FindLargeDirectories(Node root, int minSize) {
        if (root.GetSize() < minSize) yield break;

        yield return root;

        foreach (var subNode in root.Nodes) {
            foreach (var result in FindLargeDirectories(subNode, minSize)) {
                yield return result;
            }
        }
    }
}
