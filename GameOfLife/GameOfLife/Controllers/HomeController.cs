using GameOfLife.GameService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameOfLife.Controllers
{
    public class HomeController : Controller
    {
        private IGameOfLifeService _game;
        public HomeController(IGameOfLifeService game)
        {
            _game = game;
        }
        public ActionResult Index()
        {
            return View();
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

        public ActionResult CreateBoard(int boardSize)
        {
           var board = _game.InitGame(boardSize);
            return View("Index", board);
        }
    }
}