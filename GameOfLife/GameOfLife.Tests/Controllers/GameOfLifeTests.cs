using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife;
using GameOfLife.Controllers;
using GameOfLife.Models;
using GameOfLife.GameService;

namespace GameOfLife.Tests.Controllers
{

    [TestClass]
    public class GameOfLifeTests:TestBase
    {
        private IGameOfLifeService _service;
        [TestInitialize]
        public void Startup() {
            _service = Resolve<IGameOfLifeService>();
            _service.InitGame(3);
        }
        [TestMethod]
        public void LiveCellsWithNoLiveNeighbours_Dies()
        {
            var cell = new Cell(1, 1, true);
            _service.StartGame(new[] { cell });
            _service.GetNextGeneration();
            var result = _service.GameBoard.BoardCells.First(c => c.Row == cell.Row && c.Column == cell.Column);

            Assert.AreEqual(false, result.Live);
        }

        [TestMethod]
        public void LiveCellsWithOneLiveNeighbours_Dies()
        {
            var cell = new Cell(1, 1, true);
            var n1 = new Cell(1, 2, true);
            _service.StartGame(new[] { cell,n1 });
            _service.GetNextGeneration();
            var result = _service.GameBoard.BoardCells.First(c => c.Row == cell.Row && c.Column == cell.Column);
            Assert.AreEqual(false, result.Live);
        }

        [TestMethod]
        public void LiveCellsWithTwoLiveNeighbours_Lives()
        {
            var cell = new Cell(1, 1, true);
            var n1 = new Cell(1, 2, true);
            var n2 = new Cell(2, 1, true);
            _service.StartGame(new[] { cell, n1,n2 });
            _service.GetNextGeneration();
            var result = _service.GameBoard.BoardCells.First(c => c.Row == cell.Row && c.Column == cell.Column);
            Assert.AreEqual(true, result.Live);
        }

        [TestMethod]
        public void LiveCellsWithThreeLiveNeighbours_Lives()
        {
            var cell = new Cell(1, 1, true);
            var n1 = new Cell(1, 2, true);
            var n2 = new Cell(2, 1, true);
            var n3 = new Cell(2, 2, true);
            _service.StartGame(new[] { cell, n1, n2,n3 });
            _service.GetNextGeneration();
            var result = _service.GameBoard.BoardCells.First(c => c.Row == cell.Row && c.Column == cell.Column);

            Assert.AreEqual(true, result.Live);
        }


        [TestMethod]
        public void LiveCellsWithFourLiveNeighbours_Dies()
        {
            var cell = new Cell(1, 2, true);
            var n1 = new Cell(1, 1, true);
            var n2 = new Cell(2, 1, true);
            var n3 = new Cell(2, 2, true);
            var n4 = new Cell(2, 3, true);
            _service.StartGame(new[] { cell, n1, n2, n3, n4 });
            _service.GetNextGeneration();
            var result = _service.GameBoard.BoardCells.First(c => c.Row == cell.Row && c.Column == cell.Column);

            Assert.AreEqual(false, result.Live);
        }

        [TestMethod]
        public void DieCellWithThreeLiveNeighbours_Lives()
        {
            var cell = new Cell(1, 1, false);
            var n1 = new Cell(1, 2, true);
            var n2 = new Cell(2, 1, true);
            var n3 = new Cell(2, 2, true);
            _service.StartGame(new[] { cell, n1, n2, n3 });
            _service.GetNextGeneration();
            var result = _service.GameBoard.BoardCells.First(c => c.Row == cell.Row && c.Column == cell.Column);

            Assert.AreEqual(true, result.Live);
        }
        [TestMethod]
        public void DeadCellWithTwoLiveNeighbours_Dies()
        {
            var cell = new Cell(1, 1, false);
            var n1 = new Cell(1, 2, true);
            var n2 = new Cell(2, 1, true);
            _service.StartGame(new[] { cell, n1, n2 });
            _service.GetNextGeneration();
            var result = _service.GameBoard.BoardCells.First(c => c.Row == cell.Row && c.Column == cell.Column);

            Assert.AreEqual(false, result.Live);
        }


    }
}
