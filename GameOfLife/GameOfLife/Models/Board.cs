using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfLife.Models
{
    public class Board
    {
        public int Size { get; set; }

        public IEnumerable<Cell> BoardCells { get; set; }

        public Board(int size)
        {
            //create board of size X size of die cells. LINQ
            var boardRange = Enumerable.Range(1, size);
            BoardCells = (from cr in boardRange
                           from cc in boardRange
                           select new Cell(cr, cc,false)).ToList();

            Size = size;
        }
    }
}