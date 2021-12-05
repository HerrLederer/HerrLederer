using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_
{
    class Line
    {
        public Line(string inputAsInFile)
        {
            var rx = new System.Text.RegularExpressions.Regex(" -> ");
            string[] tokens = rx.Split(inputAsInFile);
            Point start = new Point(tokens[0]);
            Point end = new Point(tokens[1]);
            CreateLine(start, end);
        }

        public Line(Point start, Point end)
        {
            CreateLine(start, end);
        }

        private void CreateLine(Point start, Point end)
        {
            if (start.X == end.X)
                CreatePointsForVerticalLine(start, end);
            else if (start.Y == end.Y)
            {
                CreatePointsForHorizontalLine(start, end);
            }
            else
            {
                // we ignore this case
            }
        }

        private void CreatePointsForVerticalLine(Point start, Point end)
        {
            for( int i = Min(start.Y, end.Y); i <= Max(start.Y, end.Y); i++)
            {
                PointStorage.Add(new Point(start.X, i));
            }
        }

        private void CreatePointsForHorizontalLine(Point start, Point end)
        {
            for (int i = Min(start.X, end.X); i <= Max(start.X, end.X); i++)
            {
                PointStorage.Add(new Point(i, start.Y));
            }
        }

        private int Max(int a, int b)
        {
            return a > b ? a : b;
        }
        private int Min(int a, int b)
        {
            return a < b ? a : b;
        }
    }
}
