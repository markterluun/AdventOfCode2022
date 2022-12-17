namespace AoC.Apps.Day7.CLI.Commands;

internal class CDCommand: CLICommand
{
    public override void Invoke(string[] args, ref State state) {
        var path = args[0];
        switch (path) {
            case "/": // navigate to root
                state.FSPath.Clear();
                break;

            case ".": // navigate to current directory
                // no-op
                break;

            case "..": // navigate one directory up
                state.FSPath.Pop();
                break;

            default: // navigate to the provided path
                state.FSPath.Push(path);
                break;
        }
    }

    public override void ParseOutputLine(string outputLine, ref State state) =>
        throw new InvalidOperationException("CD does not support output parsing.");
}
