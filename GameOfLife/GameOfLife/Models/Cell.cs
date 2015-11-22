using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfLife.Models
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool Live { get; set; }
    }
}