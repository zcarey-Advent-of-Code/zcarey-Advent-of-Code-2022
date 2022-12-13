using AdventOfCode.Parsing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_12 {
    public class HeightMap : IObjectParser<int[][]> {

        private int[][] map;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Point Start { get; private set; }
        public Point End { get; private set; }
        public Rectangle Region => new Rectangle(0, 0, Width, Height);

        public int[] this[int index] {
            get => map[index];
        }

        public int GetDistance(Point A, Point B) {
            return Math.Abs(A.X - B.X) + Math.Abs(A.Y - B.Y);
        }

        public IEnumerable<Point> ClimableNeighbors(Point p) {
            return p.NeighborsWithinGrid(Region).Where(x => (map[x.Y][x.X] - map[p.Y][p.X]) <= 1);
        }

        public void Parse(int[][] input) {
            this.map = input;
            this.Height = input.Length;
            this.Width = input[0].Length;

            this.Start = new Point(-1, -1);
            this.End = new Point(-1, -1);

            for(int y = 0; y < Height; y++) {
                for (int x = 0; x < Width; x++) {
                    if (map[y][x] == 'S' - 'a') {
                        Start = new Point(x, y);
                        map[y][x] = -1;
                    } else if (input[y][x] == 'E' - 'a') {
                        End = new Point(x, y);
                        map[y][x] = ('z' - 'a') + 1;
                    }
                }
            }

            if (Start.X == -1 || End.X == -1) {
                throw new Exception("Could not find start or end location.");
            }
        }
    }
}
