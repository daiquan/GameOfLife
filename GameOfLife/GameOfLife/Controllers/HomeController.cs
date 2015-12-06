using GameOfLife.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Logging;
using GameOfLife.Models;
using GameOfLife.Bindings;

namespace GameOfLife.Controllers
{
    public class HomeController : Controller
    {
        // this is Castle.Core.Logging.ILogger, not log4net.Core.ILogger
        public ILogger Logger { get; set; }
        private IGameOfLifeService _game;
        public HomeController(IGameOfLifeService game, ILogger Logger)
        {
            this.Logger = Logger;
            _game = game;
        }
        public ActionResult Index()
        {
            var board = CreateBoard(12);
            return View(board);
        }

        public ActionResult About()
        {
            ViewBag.Message = _game.GameName;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public Board CreateBoard(int boardSize)
        {
           var board = _game.InitGame(boardSize);
            return board;
        }

        [HttpPost]
        public ActionResult StartGame([ModelBinder(typeof(CellBinder))]IEnumerable<Cell> cells)
        {
            // _game.StartGame(cells);
            return Json(true);
        }

        [HttpPost]
        public ActionResult UpdateGame()
        {
            _game.GetNextGeneration();
            return Json(true);
        }

        [HttpPost]
        public String TestPost()
        {
            return "Test Post!";
        }
    }
}