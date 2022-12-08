using AdventOfCode;
using AdventOfCode.Parsing;
using AdventOfCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_03 {
    internal class Program : ProgramStructure<IEnumerable<string[]>> {

        Program() : base(new Parser()
            .Parse(new LineReader())
            .ForEach(
                x => {
                    return new string[] { x.Substring(0, x.Length / 2), x.Substring(x.Length / 2) };
                }
            )
        ) { }

        static void Main(string[] args) {
            new Program().Run(args);
        }

        protected override object SolvePart1(IEnumerable<string[]> input) {
            return input
                .Select( x => x[0].Intersect(x[1]).First())
                .Select(Priority)
                .Sum();
        }

        protected override object SolvePart2(IEnumerable<string[]> input) {
            return null;
        }

        public static int Priority(char c) {
            if (c >= 'a') {
                return (c - 'a') + 1;
            } else {
                return (c - 'A') + 27;
            }
        }

    }
}
