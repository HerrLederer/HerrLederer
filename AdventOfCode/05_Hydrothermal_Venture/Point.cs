using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_
{
    internal class Point
    {
        public int X
        {
            get;
        }

        public int Y
        {
            get;
        }


        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(string inputAsInFile)
        {
            var tokens = inputAsInFile.Split(',');
            X = int.Parse(tokens[0]);
            Y = int.Parse(tokens[1]);
        }

        public static bool operator ==(Point a, Point b)
        {
            return a.X == b.X
                && a.Y == b.Y;

        }

        public override bool Equals(object o)
        {
            if (o == null || ! (o is Point))
                return false;

            Point p = o as Point;
            return this == p; ;
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public static bool operator !=(Point a, Point b)
        {
            return !(a == b);
        }
    }
}
