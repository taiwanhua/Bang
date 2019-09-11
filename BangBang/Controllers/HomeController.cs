using BangBang.Models;
using BangBang.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BangBang.Controllers
{
    public class HomeController : Controller
    {
        PlayerRepository PlayerRepos = new PlayerRepository();

        WalletrecordsRepository WalletrecordsRepos = new WalletrecordsRepository();

        GameRecordRepository GameRecordRepos = new GameRecordRepository();
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult StoretoDB(String playername, int previousAmount, int latestAmount)
        {

            List<Player> QueryResult = PlayerRepos.GetByPlayerName(playername);
            if (QueryResult.Count > 0)
            {
                string result = QueryResult[0].PlayerName;
                Player player = new Player { PlayerName = result };
                long ts = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
                Walletrecord walletrecord = new Walletrecord { Timestamp = ts, PreviousAmount = previousAmount, LatestAmount = (previousAmount + latestAmount), PlayerID = QueryResult[0].PlayerID };
                WalletrecordsRepos.Add(walletrecord);
                GameRecord gameRecord = new GameRecord { Timestamp = ts, Stake = latestAmount, PlayerID = QueryResult[0].PlayerID };
                GameRecordRepos.Add(gameRecord);
                WalletrecordsRepos.Savechanges();
                GameRecordRepos.Savechanges();
                return Json(result);
            }
            else
            {
                return Json(false);
            }
        }



        public ActionResult About(string name)
        {
            ViewBag.Message = name;

            return View(PlayerRepos.GetAll());
        }
        [HttpPost]
        public ActionResult GetWalleteinfo(string playername)
        {
            var context = new DataDbContext();
            var product = context.Walletrecords.SqlQuery("select a.* from dbo.Walletrecords as a where playerId=1").ToList();
          
            if (product.Count() > 0)
            {
                //List<Walletrecord> result = QueryResult[0].Walletrecords;
                // String jsonn=JsonConvert.SerializeObject(result, Formatting.Indented);
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                var jsons = javaScriptSerializer.Serialize(product);
                string f = "[\"Date\": \"2019/7/10\",\"Time\": \"15:00:59\"}]";
                return Json(f);
            }
            else
            {
                return Json(false);
            }


        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}