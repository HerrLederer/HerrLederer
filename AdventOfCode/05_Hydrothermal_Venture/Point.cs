using System;

namespace _05_Hydrothermal_Venture
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

        public static Point CreateFromInput(string inputAsInFile)
        {
            var tokens = inputAsInFile.Split(',');
            return new Point( int.Parse(tokens[0]), int.Parse(tokens[1]));
        }

        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public Point GetNeightbor(Direction direction)
        {
            switch (direction)
            {
                case Direction.HorizontalLeftwards:
                    return new Point(X - 1, Y);

                case Direction.HorizontalRightwards:
                    return new Point(X + 1, Y);

                case Direction.VerticalDownwards:
                    return new Point(X, Y + 1);

                case Direction.VerticalUpwards:
                    return new Point(X, Y - 1);

                case Direction.DiagonalRightDownwards:
                    return new Point(X + 1, Y + 1);

                case Direction.DiagonalRightUpwards:
                    return new Point(X + 1, Y - 1);

                case Direction.DiagonalLeftDownwards:
                    return new Point(X - 1, Y + 1);

                case Direction.DiagonalLeftUpwards:
                    return new Point(X - 1, Y - 1);

                case Direction.None:
                    throw new Exception("Direction: None. Might be the same point?");

                default:
                    throw new Exception("unsupported direction of line");
            }
        }

        public override string ToString()
        {
            return "( " + X + " / " + Y + " )";
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
