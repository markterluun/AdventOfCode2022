namespace AoC.Apps.Day4;

static class Program
{
    static void Main() {
        var input = File.ReadAllLines("input.txt");
        var testInput = File.ReadAllLines("input_test.txt");

        Day1(input);
    }

    static void Day1(IEnumerable<string> input)
    {
        var amountOfOverlaps = input
            .Select(SectionRangePair.Parse)
            .Select(rangePair => rangePair.FullyOverlap())
            .Where(e => e)
            .Count();

        Console.WriteLine(amountOfOverlaps);
    }
}

// Types

readonly struct SectionRange
{
    public int First { get; init; }
    public int Last { get; init; }

    public static SectionRange Parse(string input) {
        var range = input
            .Split('-')
            .Select(str => int.Parse(str))
            .ToArray();

        return new SectionRange {
            First = range[0],
            Last = range[1],
        };
    }

    public bool FullyContains(SectionRange other) =>
        other.First >= First &&
        other.First <= Last &&
        other.Last >= First &&
        other.Last <= Last;
}

readonly struct SectionRangePair
{
    public SectionRange First { get; init; }
    public SectionRange Second { get; init; }

    public static SectionRangePair Parse(string input)
    {
        var groups = input
            .Split(",")
            .Select(SectionRange.Parse)
            .ToArray();

        return new SectionRangePair
        {
            First = groups[0],
            Second = groups[1],
        };
    }

    public bool FullyOverlap() =>
        First.FullyContains(Second) || Second.FullyContains(First);
}
