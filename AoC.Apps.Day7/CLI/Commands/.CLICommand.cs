namespace AoC.Apps.Day7.CLI.Commands;

internal abstract partial class CLICommand
{
    public abstract void Invoke(string[] args, ref State state);

    public abstract void ParseOutputLine(string outputLine, ref State state);
}
