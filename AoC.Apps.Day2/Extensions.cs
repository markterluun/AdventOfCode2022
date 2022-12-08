namespace AoC.Apps.Day2;

internal static class Extensions
{
    internal static RockPaperScissors.Hand ToHand(this char character) => character switch {
        'A' or 'X' => RockPaperScissors.Hand.Rock,
        'B' or 'Y' => RockPaperScissors.Hand.Paper,
        'C' or 'Z' => RockPaperScissors.Hand.Scissors,
        _ => throw new NotImplementedException()
    };

    internal static RockPaperScissors.Outcome Compare(this RockPaperScissors.Hand a, RockPaperScissors.Hand b) {
        /*
         * Rock defeats Scissors
         * Scissors defeats Paper
         * Paper defeats Rock
         * 
         * Rock         1
         * Paper        2
         * Scissors     3
         * 
         * You         |Other      |Outcome|Relative score
         * -----------------------------------------------
         * Rock        |Rock       |Tie    |1 - 1 =  0
         * Rock        |Paper      |Lose   |1 - 2 = -1
         * Rock        |Scissors   |Win    |1 - 3 = -2
         *             |           |       |
         * Paper       |Rock       |Win    |2 - 1 =  1
         * Paper       |Paper      |Tie    |2 - 2 =  0
         * Paper       |Scissors   |Lose   |2 - 3 = -1
         *             |           |       |
         * Scissors    |Rock       |Lose   |3 - 1 =  2
         * Scissors    |Paper      |Win    |3 - 2 =  1
         * Scissors    |Scissors   |Tie    |3 - 3 =  0
         * -----------------------------------------------
         * 
         * -2 win
         * -1 lose
         *  0 tie
         *  1 win
         *  2 lose
         */

        var relativeScore = a - b;
        return relativeScore switch {
            0 => RockPaperScissors.Outcome.Tie,
            -1 or 2 => RockPaperScissors.Outcome.Lose,
            -2 or 1 => RockPaperScissors.Outcome.Win,
            _ => throw new NotImplementedException()
        };
    }
}
