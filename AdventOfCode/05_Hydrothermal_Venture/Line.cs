namespace _05_Hydrothermal_Venture
{
    public enum Direction
    {
        None,
        HorizontalLeftwards,
        HorizontalRightwards,
        VerticalDownwards,
        VerticalUpwards,
        DiagonalRightDownwards,
        DiagonalRightUpwards,
        DiagonalLeftDownwards,
        DiagonalLeftUpwards
    }

    internal class Line
    {
        Point Start
        {
            get;
        }

        Point End
        {
            get;
        }

        public static Line CreateLineFromInput(string inputAsInFile)
        {
            var rx = new System.Text.RegularExpressions.Regex(" -> ");
            string[] tokens = rx.Split(inputAsInFile);
            return new Line(Point.CreateFromInput(tokens[0]),
                            Point.CreateFromInput(tokens[1]));
        }

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
            CreatePointsOnLine();
        }

        Direction LineDirection
        {
            get
            {
                if (Start.X < End.X)
                {
                    if (Start.Y < End.Y)
                        return Direction.DiagonalRightDownwards;
                    else if (Start.Y > End.Y)
                        return Direction.DiagonalRightUpwards;
                    else
                        return Direction.HorizontalRightwards;
                }
                else if (Start.X > End.X)
                {
                    if (Start.Y < End.Y)
                        return Direction.DiagonalLeftDownwards;
                    else if (Start.Y > End.Y)
                        return Direction.DiagonalLeftUpwards;
                    else
                        return Direction.HorizontalLeftwards;
                }
                else // start.X == end.X -> Vertical
                {
                    if (Start.Y < End.Y)
                        return Direction.VerticalDownwards;
                    else if (Start.Y > End.Y)
                        return Direction.VerticalUpwards;
                    else // both X and Y are identical -> no direction
                        return Direction.None;
                }
            }
        }

        private void CreatePointsOnLine()
        {
            Point p = new Point(Start);
            while (p != End)
            {
                PointStorage.Add(p);
                p = p.GetNeightbor(LineDirection);
            }

            // don't forget the end of the line.
            PointStorage.Add(p);
        }
    }
}
