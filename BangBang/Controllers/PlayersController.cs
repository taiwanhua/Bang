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
            return View();
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
            //GET: PlayersController/Create
            if (!ModelState.IsValid)
            {
                return View(player);
            }
            PlayerRepos.Add(player);
            PlayerRepos.Savechanges();
            return RedirectToAction("Index");
        }
    }
}