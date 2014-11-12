namespace MinimalDistance
{
    using System;
    using System.Linq;

    public struct Position : IComparable<Position>
    {
        public int Col { get; set; }

        public int Row { get; set; }

        public int Value { get; set; }

        public int CompareTo(Position other)
        {
            if (this.Col == other.Col && this.Row == other.Row)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}