using AdventOfCode;
using AdventOfCode.Parsing;
using AdventOfCode.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Day_12 {
    internal class Program : ProgramStructure<HeightMap> {

        Program() : base(new Parser()
            .Parse(new LineReader())
            .ForEach(s => s.Select(c => c - 'a').ToArray())
            .ToArray()
            .Create<HeightMap>()
        ) { }

        static void Main(string[] args) {
            new Program().Run(args);
            //new Program().Run(args, "Example.txt");
        }

        protected override object SolvePart1(HeightMap input) {
            return Dijkstra(input).Count - 1;
        }

        public static Stack<Point> Dijkstra(HeightMap map) {
            int[][] dist = new int[map.Height][];
            Point?[][] prev = new Point?[map.Height][];
            PriorityQueue<Point, int> queue = new();

            for(int y = 0; y < map.Height; y++) {
                dist[y] = new int[map.Width];
                prev[y] = new Point?[map.Width];
                for (int x = 0; x < map.Width; x++) {
                    Point v = new Point(x, y);
                    dist[y][x] = int.MaxValue;
                    prev[y][x] = null;
                    if (v == map.Start) {
                        dist[y][x] = 0; // Make sure it's processed first
                    }
                    queue.Enqueue(v, dist[y][x]);
                }
            }

            while(queue.Count > 0) {
                Point u = queue.Dequeue();

                if (u == map.End) {
                    // Woohoo! Return the path!
                    Stack<Point> path = new();
                    path.Push(u);
                    while(u != map.Start) {
                        u = (Point)prev[u.Y][u.X];
                        path.Push(u);
                    }
                    return path;
                }

                foreach(Point v in map.ClimableNeighbors(u)) {
                    int alt = dist[u.Y][u.X] + map.GetDistance(u, v);
                    if (alt < dist[v.Y][v.X]) {
                        dist[v.Y][v.X] = alt;
                        prev[v.Y][v.X] = u;

                        // Due to a limitation in the C# PriorityQueue, we cant change the priority of an already queued item.
                        // However, due to the relatively small size of this problem we can afford calculating again if it pops
                        // up in the queue again. Wastes a bit of memory, but considering this is Advent of Code and I have to
                        // finish this up tonight I dont feel like writing my own PriorityQueue :)
                        queue.Enqueue(v, alt); 
                    }
                }
            }

            throw new Exception("Unable to find path.");
        }

        protected override object SolvePart2(HeightMap input) {
            return null;
        }

    }
}
