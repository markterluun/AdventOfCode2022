using System.Diagnostics;
using AoC.Shared;
using BenchmarkDotNet.Running;

namespace AoC.Apps.Day6;

static class Program
{
    static void Main()
    {
#if DEBUG
        var input = File.ReadAllLines(".input.txt")[0];
        var testInput = File.ReadAllLines(".testinput.txt")[0];

        Part1(input);
        Part2(input);
#else
        BenchmarkRunner.Run<Benchmarks>();
#endif
    }

    static void Part1(string input) {
        Console.WriteLine("Parse line blocks (LINQ)");
        Benchmark(() => Console.WriteLine(ParseLineBlocks(input, 4)));
        Console.WriteLine();

        Console.WriteLine("Parse line (array)");
        Benchmark(() => Console.WriteLine(ParseLine(input, 4)));
    }

    static void Part2(string input)
    {
        Console.WriteLine(ParseLine(input, 14));
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
