using AdventOfCode;
using AdventOfCode.Parsing;
using AdventOfCode.Utils;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Day_11 {
	class Program : ProgramStructure<Monkey[]> {

		Program() : base(new Parser()
			.Parse(new LineReader())
			.Filter(new TextBlockFilter())
			.FilterCreate<Monkey>()
			.ToArray()
		) { }

		static void Main(string[] args) {
			new Program().Run(args);
		}

		protected override object SolvePart1(Monkey[] input) {
			int[] inspections = new int[input.Length];
			for(int round = 0; round < 20; round++) {
				SimulateRound(input, inspections);
            }
			int[] TopTwoMonkeys = inspections.OrderByDescending(x => x).Take(2).ToArray();
			return TopTwoMonkeys[0] * TopTwoMonkeys[1];
		}

		private void SimulateRound(Monkey[] monkeys, int[] inspections = null) {
			for(int i = 0; i < monkeys.Length; i++) {
				if (inspections == null) {
					int temp = 0;
					monkeys[i].Simulate(monkeys, ref temp);
                } else {
					monkeys[i].Simulate(monkeys, ref inspections[i]);
                }
            }
        }

		protected override object SolvePart2(Monkey[] input) {
			return null;
		}

	}
}
