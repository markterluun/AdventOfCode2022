using AoC.Apps.Day7.CLI;
using AoC.Apps.Day7.FileSystem;

namespace AoC.Apps.Day7;

static class Program
{
    static void Main() {
        var input = File.ReadAllLines(".input.txt");
        var testInput = File.ReadAllLines(".testinput.txt");

        Part1(input);
    }

    static void Part1(string[] input) {
        var interpreter = new Interpreter();
        foreach (var line in input) {
            interpreter.Parse(line);
        }

        // Find directories of size <= 100.000
        var maxSize = 100000;
        var smallDirectories = FindSmallDirectories(interpreter.State.FSRoot, maxSize);
        var totalSize = smallDirectories.Sum(d => d.GetSize());

        Console.WriteLine(totalSize);
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
}
