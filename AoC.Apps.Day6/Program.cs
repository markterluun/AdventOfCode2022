using AoC.Shared;

namespace AoC.Apps.Day6;

static class Program
{
    static void Main()
    {
        var input = File.ReadAllLines(".input.txt").Where(line => !string.IsNullOrWhiteSpace(line));
        var testInput = File.ReadAllLines(".testinput.txt").Where(line => !string.IsNullOrWhiteSpace(line));

        Part1(input);
    }

    static void Part1(IEnumerable<string> input) {
        foreach (var line in input)
        {
            Console.WriteLine(ParseLine(line, 4));
        }
    }

    static int ParseLine(string line, int blockLength) =>
        Enumerable.Range(blockLength, line.Length - (blockLength - 1))
            .Select(i => (value: line.Substring(i - blockLength, blockLength), index: i))
            .First(e => e.value.Distinct().Count() == blockLength)
            .index;
}
