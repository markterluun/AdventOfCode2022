using AoC.Apps.Day7.FileSystem;
using AoC.Shared;

namespace AoC.Apps.Day7.CLI.Commands;

internal class LSCommand: CLICommand
{
    private readonly Node _node;

    public LSCommand(State state) {
        _node = state.FSPathNode;
    }

    public override void Invoke(string[] args, ref State state) {
        // no-op
    }

    public override void ParseOutputLine(string outputLine, ref State state) {
        var args = outputLine
            .Split(' ', StringSplitOptions.TrimEntries & StringSplitOptions.RemoveEmptyEntries)
            .ToQueue();
        var indicator = args.Dequeue();

        if (indicator == "dir") {
            var nodeName = args.Dequeue();
            _node.AddNode(nodeName);
        }
        else if (int.TryParse(indicator, out var leafSize)) {
            var leafName = args.Dequeue();
            _node.AddLeaf(leafName, leafSize);
        }
    }
}
