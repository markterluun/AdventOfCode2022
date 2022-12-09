namespace AoC.Apps.Day2;

static class Program
{
    static void Main() {
        var input = File.ReadAllLines("input.txt");

        Part1(input);
        Part2(input);
    }

    static void Part1(IEnumerable<string> input) {
        var score = 0;

        Console.WriteLine($"{"other",-12}{"you",-12}{"outcome"}");
        Console.WriteLine();

        foreach (var line in input) {
            var other = line.First().ToHand();
            var you = line.Last().ToHand();
            var outcome = RockPaperScissors.Play(you, other, out var roundScore);

            Console.WriteLine($"{other,-12}{you,-12}{outcome}");

            score += roundScore;
        }
        Console.WriteLine(score);
    }

    static void Part2(IEnumerable<string> input) {
        var score = 0;

        Console.WriteLine($"{"other",-12}{"strategy",-12}{"you",-12}{"outcome",-12}{"strategic result"}");
        Console.WriteLine();

        foreach (var line in input) {
            var other = line.First().ToHand();
            var strategy = line.Last().ToOutcome();
            var you = strategy.ToHand(other);
            var outcome = RockPaperScissors.Play(you, other, out var roundScore);

            Console.WriteLine($"{other,-12}{strategy,-12}{you,-12}{outcome,-12}{(outcome == strategy ? "correct strategy" : "strategic failure")}");

            score += roundScore;
        }
        Console.WriteLine(score);
    }
}
