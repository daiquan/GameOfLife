using GameOfLife.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.GameService
{
    public interface IGameOfLifeService
    {
        string GameName { get;  }
        Board InitGame(int size);
        void StartGame(IEnumerable<Cell> cells);
        void GetNextGeneration();
    }
    public class GameOfLifeService : IGameOfLifeService
    {

        public Board GameBoard { get; set; }
        public  string GameName
        {
            get
            {
                return "Game of Life";
            }

        }

        public Board InitGame(int size)
        {
            GameBoard = new Board(size);
            return GameBoard;
        }

        public void StartGame(IEnumerable<Cell> cells)
        {
            foreach (var lc in cells)
            {
                
                var bc = GameBoard.BoardCells.FirstOrDefault(c => c.Row == lc.Row && c.Column == lc.Column);
                bc.Live = true;
            }
        }

        public void GetNextGeneration()
        {
            GameBoard.BoardCells.ToList().ForEach(c => GoNextGen(c));
        }

        private void GoNextGen(Cell cell)
        {
            var nbCount = NeighboursCount(cell, GameBoard.BoardCells.GetEnumerator(), 0);
            bool nextStatus = nbCount == 2 && cell.Live || nbCount == 3;
            cell.Live = nextStatus;
        }

        private int NeighboursCount(Cell cell, IEnumerator<Cell> enumerator, int count)
        {
            if (!enumerator.MoveNext()) return count;
            var n = enumerator.Current;

            if (cell.IsNeighbor(n))
            {
                count++;
            }

            return NeighboursCount(cell, enumerator, count);
        }
    }
}