using BangBang.Models;
using BangBang.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BangBang.Controllers
{
    public class PlayersController : Controller
    {
        //注入接口層
        PlayerRepository PlayerRepos = new PlayerRepository();

        // GET: Players
        public ActionResult Index()
        {
            return View(PlayerRepos.GetAll());
        }

        public ActionResult Create()
        {
            //GET: PlayersController/Create
            //IEnumerable<Player> m = PlayerRepos.GetAll();
            //return View(m);
            var IemPlayer = PlayerRepos.GetAll();
            IemPlayerViewModel model = new IemPlayerViewModel { players = IemPlayer };
            return View(model);

        }


        public ActionResult Details(int id)
        {
            //GET: PlayersController/Details
            Player player = PlayerRepos.Get(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(player);
            }
        }

        [HttpPost]

        public ActionResult Create(Player player)
        {
            //POST: PlayersController/Create
            if (!ModelState.IsValid)
            {
                return View(player);
            }
            PlayerRepos.Add(player);
            PlayerRepos.Savechanges();
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public ActionResult PlayerNameexistVaild(String playername)
        {
            //POST: PlayersController/PlayerNameexistVaild

            List<Player> QueryResult = PlayerRepos.GetByPlayerName(playername);
            if (QueryResult.Count > 0)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }


        }

        public ActionResult Login()
        {
            //GET: PlayersController/Login
            PlayerLogin playerLogin = new PlayerLogin();
            return View(playerLogin);
        }

        [HttpPost]

        public ActionResult Login(PlayerLogin playerLogin)
        {
            //POST: PlayersController/Login
            if (!ModelState.IsValid)
            {
                return View(playerLogin);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult PlayerNameexist(String playername)
        {
            //POST: PlayersController/PlayerNameexistVaild

            List<Player> QueryResult = PlayerRepos.GetByPlayerName(playername);
            if (QueryResult.Count > 0)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }


        }
    }

}