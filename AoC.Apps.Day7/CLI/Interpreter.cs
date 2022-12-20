using AoC.Apps.Day7.CLI.Commands;
using AoC.Shared;

namespace AoC.Apps.Day7.CLI;

internal partial class Interpreter
{
    private CLICommand? currentCommand = null;

    private State _state = new();
    public State State => _state;

    public void Parse(string commandLine) {
        if (commandLine.StartsWith("$ ")) {
            ParseCommandLine(commandLine);
            return;
        }

        currentCommand?.ParseOutputLine(commandLine, ref _state);
    }

    private void ParseCommandLine(string commandLine) {
        var args = commandLine
            .Split(' ', StringSplitOptions.TrimEntries & StringSplitOptions.RemoveEmptyEntries)
            .Skip(1) // skip the command indicator ("$")
            .ToQueue();

        var command = args.Dequeue().ToLower();
        currentCommand = command switch {
            "cd" => new CDCommand(),
            "ls" => new LSCommand(_state),
            _ => throw new Exception($"unrecognized command: {command}")
        };

        currentCommand.Invoke(args.ToArray(), ref _state);
    }
}
