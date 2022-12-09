using static AoC.Apps.Day2.RockPaperScissors;

namespace AoC.Apps.Day2;

internal static class Extensions
{
    internal static Hand ToHand(this char character) => character switch {
        'A' => Hand.Rock,
        'B' => Hand.Paper,
        'C' => Hand.Scissors,
        _ => throw new NotImplementedException()
    };

    internal static Outcome ToOutcome(this char character) => character switch {
        'X' => Outcome.Lose,
        'Y' => Outcome.Tie,
        'Z' => Outcome.Win,
        _ => throw new NotImplementedException()
    };

    internal static Outcome Compare(this Hand a, Hand b) {
        /*
         * Rock defeats Scissors
         * Scissors defeats Paper
         * Paper defeats Rock
         * 
         * Rock         1
         * Paper        2
         * Scissors     3
         * 
         * 
         * # Matrix score: you - other
         * 
         * You          |Other      |Outcome|Matrix score
         * ----------------------------------------------
         * Rock         |Rock       |Tie    |1 - 1 =  0
         * Rock         |Paper      |Lose   |1 - 2 = -1
         * Rock         |Scissors   |Win    |1 - 3 = -2
         *              |           |       |
         * Paper        |Rock       |Win    |2 - 1 =  1
         * Paper        |Paper      |Tie    |2 - 2 =  0
         * Paper        |Scissors   |Lose   |2 - 3 = -1
         *              |           |       |
         * Scissors     |Rock       |Lose   |3 - 1 =  2
         * Scissors     |Paper      |Win    |3 - 2 =  1
         * Scissors     |Scissors   |Tie    |3 - 3 =  0
         * ----------------------------------------------
         * 
         * -2 win
         * -1 lose
         *  0 tie
         *  1 win
         *  2 lose
         */

        var relativeScore = a - b;
        return relativeScore switch {
            0 => Outcome.Tie,
            -1 or 2 => Outcome.Lose,
            -2 or 1 => Outcome.Win,
            _ => throw new NotImplementedException()
        };
    }

    internal static Hand ToHand(this Outcome strategy, Hand other) {
        /*
         * Rock defeats Scissors
         * Scissors defeats Paper
         * Paper defeats Rock
         * 
         * Rock         1
         * Paper        2
         * Scissors     3
         * 
         * Lose         0
         * Tie          3
         * Win          6
         * 
         * 
         * # Matrix score: strategy - hand
         * 
         *          |Rock           |Paper          |Scissors
         * ----------------------------------------------------
         * Lose     |0 - 1 = -1     |0 - 2 = -2     |0 - 3 = -3
         * Tie      |3 - 1 =  2     |3 - 2 =  1     |3 - 3 =  0
         * Win      |6 - 1 =  5     |6 - 2 =  4     |6 - 3 =  3
         * ----------------------------------------------------
         * 	
         * 
         * # Determining the value to return
         * 
         * Desired hand: rock
         * Strategy     |Other      |Matrix score
         * --------------------------------------
         * Lose         |Paper      |-2
         * Tie          |Rock       | 2
         * Win          |Scissors   | 3
         * --------------------------------------
         * 
         * Desired hand: paper
         * Strategy     |Other      |Matrix score
         * --------------------------------------
         * Lose         |Scissors   |-3
         * Tie          |Paper      | 1
         * Win          |Rock       | 5
         * --------------------------------------
         * 
         * Desired hand: scissors
         * Strategy     |Other      |Matrix score
         * --------------------------------------
         * Lose         |Rock       |-1
         * Tie          |Scissors   | 0
         * Win          |Paper      | 4
         * --------------------------------------
         */

        var handHint = (int)strategy - (int)other;
        return handHint switch {
            -2 or 2 or 3 => Hand.Rock,
            -3 or 1 or 5 => Hand.Paper,
            -1 or 0 or 4 => Hand.Scissors,
            _ => throw new NotImplementedException(),
        };
    }
}
