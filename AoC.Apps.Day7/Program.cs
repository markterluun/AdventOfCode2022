using AoC.Apps.Day7.CLI;

namespace AoC.Apps.Day7;

static class Program
{
    static void Main() {
        var input = File.ReadAllLines(".input.txt");
        var testInput = File.ReadAllLines(".testinput.txt");

        Part1(testInput);
    }

    static void Part1(string[] input) {
        var interpreter = new Interpreter();

        foreach (var line in input) {
            interpreter.Parse(line);
        }

        interpreter.State.PrintDirectoryListing();
        Console.WriteLine();
        Console.WriteLine($"Total size: {interpreter.State.FSRoot.GetSize()}");
    }
}
