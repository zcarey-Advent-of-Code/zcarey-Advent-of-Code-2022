using AdventOfCode.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_02 {
    internal struct StrategyGuideEntry : IObjectParser<string[]> {

        public RockPaperScissors Opponent;
        public RockPaperScissors Choice;

        public void Parse(string[] input) {
            if (input.Length != 2)
                throw new ArgumentException("Invalid number of inputs.");

            switch (input[0]) {
                case "A":
                    Opponent = RockPaperScissors.Rock;
                    break;
                case "B":
                    Opponent = RockPaperScissors.Paper;
                    break;
                case "C":
                    Opponent = RockPaperScissors.Scissors;
                    break;
                default:
                    throw new ArgumentException("Invalid first argument.");
            }

            switch (input[1]) {
                case "X":
                    Choice = RockPaperScissors.Rock;
                    break;
                case "Y":
                    Choice = RockPaperScissors.Paper;
                    break;
                case "Z":
                    Choice = RockPaperScissors.Scissors;
                    break;
                default:
                    throw new ArgumentException("Invalid second argument.");
            }
        }

        public int Score() {
            return Choice.ScoreValue() + (Choice.Beats(Opponent) * 3);
        }
    }
}
