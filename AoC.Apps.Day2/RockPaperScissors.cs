namespace AoC.Apps.Day2;

internal class RockPaperScissors
{
    public enum Hand
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3,
    }

    public enum Outcome {
        Lose = 0,
        Tie = 3,
        Win = 6,
    }

    public static int Play(Hand you, Hand other) {
        var outcome = you.Compare(other);

        var handValue = (int)you;
        var outcomeValue = (int)outcome;
        var score = handValue + outcomeValue;
        return score;
    }
}
