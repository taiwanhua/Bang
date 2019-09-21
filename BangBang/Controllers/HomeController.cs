using BangBang.Models;
using BangBang.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            var playergetid = context.Players.SqlQuery("select p.* from dbo.Players as p where playerName = @playername", new SqlParameter("playername", playername)).ToList();
            var playid = (from playerid in playergetid select playerid.PlayerID).SingleOrDefault();
            var playidWalletrecords = context.Walletrecords.SqlQuery("select a.* from dbo.Walletrecords as a where playerId=@playerid", new SqlParameter("playerid", playid)).ToList();
            var playidGameRecords = context.GameRecords.SqlQuery("select a.* from dbo.GameRecords as a where playerId=@playerid", new SqlParameter("playerid", playid)).ToList();

            var linqt = (from w in playidWalletrecords join g in playidGameRecords on w.Timestamp equals g.Timestamp select new joinresult {Timestamp=w.Timestamp, PreviousAmount=w.PreviousAmount, LatestAmount=w.LatestAmount, Stake=g.Stake }).ToList();


            if (linqt.Count() > 0)
            {
                //List<Walletrecord> result = QueryResult[0].Walletrecords;
                // String jsonn=JsonConvert.SerializeObject(result, Formatting.Indented);
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                var jsons = javaScriptSerializer.Serialize(linqt);
                //string f = "[\"Date\": \"2019/7/10\",\"Time\": \"15:00:59\"}]";
                return Json(jsons);
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