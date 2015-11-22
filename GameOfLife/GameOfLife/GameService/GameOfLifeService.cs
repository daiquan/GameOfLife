using GameOfLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfLife.GameService
{
    public interface IGameOfLifeService
    {
        string GameName { get;  }
        void InitGame(IEnumerable<Cell> cells);
    }
    public class GameOfLifeService : IGameOfLifeService
    {
        public  string GameName
        {
            get
            {
                return "Game of Life";
            }

        }
        public void InitGame(IEnumerable<Cell> cells)
        {
            
        }


    }
}