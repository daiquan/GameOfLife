using System;

namespace GameOfLife.Models
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Live { get; set; }

        public Cell(int r,int c,bool l)
        {
            Row = r;
            Column = c;
            Live = l;
        }

        public bool Dead
        {
            get { return !Live; }
        }

        public bool NextLive { get; set; }

        public bool IsNeighbor(Cell c)
        {
            return Math.Abs(Row - c.Row) < 2
                   && Math.Abs(Column - c.Column) < 2
                   && Math.Abs(Row - c.Row) + Math.Abs(Column - c.Column) > 0;
        }
    }
}