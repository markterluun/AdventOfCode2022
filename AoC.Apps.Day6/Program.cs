using System.Diagnostics;
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
            Console.WriteLine("Parse line blocks (LINQ)");
            Benchmark(() => Console.WriteLine(ParseLineBlocks(line, 4)));
            Console.WriteLine();

            Console.WriteLine("Parse line (array)");
            Benchmark(() => Console.WriteLine(ParseLine(line, 4)));
        }
    }

    static void Benchmark(Action action)
    {
        var startTime = Stopwatch.GetTimestamp();
        action.Invoke();
        var elapsed = Stopwatch.GetElapsedTime(startTime);

        Console.WriteLine($"{elapsed.TotalNanoseconds} ns");
    }

    static int ParseLineBlocks(string line, int blockLength) =>
        Enumerable.Range(blockLength, line.Length - (blockLength - 1))
            .Select(i => (value: line.Substring(i - blockLength, blockLength), index: i))
            .First(e => e.value.Distinct().Count() == blockLength)
            .index;

    static int ParseLine(string line, int blockLength)
    {
        var buffer = new char[blockLength];

        var index = 0;
        foreach (var chr in line)
        {
            buffer.Shift(-1, chr);

            index++;
            if (index < blockLength) continue;

            var isMarkerBlock = buffer.Distinct().Count() == blockLength;
            if (isMarkerBlock) return index;
        }

        return -1;
    }
}
