using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AoC.Apps.Day5;

static class Program
{
    static void Main() {
        var input = File.ReadAllLines("input.txt");
        var testInput = File.ReadAllLines("inputTest.txt");

        Run(input, false);
        Run(input, true);
    }

    static void Run(IEnumerable<string> input, bool part2) {
        var stacks = ProcessInput(input, part2);
        var output = stacks
            .Select(stack => stack.Peek())
            .Select(topItem => topItem[1])
            .AsString();
        Console.WriteLine(output);
    }

    // Utility methods

    static List<Stack<string>> ProcessInput(IEnumerable<string> input, bool pickupMultiple) {
        var mode = 0; // Should *technically* be an enum but fuck it
        var lists = new List<List<string>>();
        var stacks = new List<Stack<string>>();

        foreach (var line in input) {
            // Next mode
            if (string.IsNullOrWhiteSpace(line)) {
                mode++;
                continue;
            }

            // Parse line according to the current mode
            switch (mode) {
                case 0: // Stack
                    var stackLine = ParseStackLine(line);

                    // Initialize lists
                    if (lists.Count == 0) {
                        lists = stackLine
                            .Select(_ => new List<string>())
                            .ToList();
                    }

                    ProcessStackLine(stackLine, ref lists);
                    break;

                case 1: // Instruction
                    // Initialize stacks
                    if (stacks.Count == 0) {
                        stacks = lists
                            .Select(l => new Stack<string>(l))
                            .ToList();
                    }

                    ParseInstruction(line, ref stacks, pickupMultiple);
                    break;

                default:
                    throw new InvalidOperationException("Entered unsupported mode.");
            }
        }

        return stacks;
    }

    static string[] ParseStackLine(string line) => line
        .Chunk(4)
        .Select(chunk => chunk.AsString()[..3])
        .ToArray();

    static void ProcessStackLine(string[] stackLine, ref List<List<string>> lists) {
        var filteredIndexedStackLine = stackLine
            .Select((item, i) => (item, i)) // index
            .Where(e => !string.IsNullOrWhiteSpace(e.item)); // filter

        foreach (var (e, i) in filteredIndexedStackLine) {
            lists[i].Insert(0, e);
        }
    }

    static void ParseInstruction(string instruction, ref List<Stack<string>> stacks, bool pickupMultiple) {
        var parameters = new Regex(@"\d+")
            .Matches(instruction)
            .Cast<Match>()
            .Select(m => m.Value)
            .Select(int.Parse)
            .ToArray();

        var amt = parameters[0];
        var src = parameters[1] - 1;
        var dst = parameters[2] - 1;

        var pickup = stacks[src].Pop(amt);
        stacks[dst].Push(pickup, pickupMultiple);
    }
}
