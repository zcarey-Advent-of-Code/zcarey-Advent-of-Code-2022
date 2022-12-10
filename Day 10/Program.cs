using AdventOfCode;
using AdventOfCode.Parsing;
using AdventOfCode.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_10 {
    internal class Program : ProgramStructure<IEnumerable<Instruction>> {

        Program() : base(new Parser()
            .Parse(new LineReader())
            .ForEach(x => x.Split())
            .FilterCreate<Instruction>()
        ) { }

        static void Main(string[] args) {
            new Program().Run(args);
            //new Program().Run(args, "Large.txt");
        }

        protected override object SolvePart1(IEnumerable<Instruction> input) {
            int registerX = 1;
            int cycleCount = 0;
            List<int> signalStrengths = new();

            foreach(Instruction instruction in input) {
                int tempReg = registerX;
                int cycles = instruction.Execute(ref tempReg);

                for (int i = cycleCount + 1; i <= (cycleCount + cycles); i++) {
                    if ((i - 20) % 40 == 0) {
                        // Track the singal! Write that down. Write that down!
                        signalStrengths.Add(i * registerX);
                    }
                }
                // Finish the instruction
                cycleCount += cycles;
                registerX = tempReg;
            }

            return signalStrengths.Sum();
        }

        protected override object SolvePart2(IEnumerable<Instruction> input) {
            return null;
        }

    }
}
