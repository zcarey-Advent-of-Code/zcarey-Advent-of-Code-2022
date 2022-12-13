using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_12 {
    public static class PointUtils {

        public static IEnumerable<Point> Neighbors(this Point p) {
            yield return new Point(p.X + 1, p.Y);
            yield return new Point(p.X, p.Y + 1);
            yield return new Point(p.X - 1, p.Y);
            yield return new Point(p.X, p.Y - 1);
        }

        public static IEnumerable<Point> NeighborsWithinGrid(this Point p, Rectangle size) {
            return p.Neighbors().Where(x => x.X >= size.Left && x.X < size.Right && x.Y >= size.Top && x.Y < size.Bottom);
        }

    }
}
