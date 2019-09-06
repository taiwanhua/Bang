using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BangBang.Models
{
    public class DatabaseInitalizer : DropCreateDatabaseAlways<DataDbContext>
    {
        //DB環境初始化，至Global.asax啟用
        protected override void Seed(DataDbContext context)
        {
            Player player1 = new Player { PlayerName = "Arhua" };
            Player player2 = new Player { PlayerName = "yuan" };
            Walletrecord walletrecord1 = new Walletrecord { Timestamp = 20190906211200, PreviousAmount = 100000, LatestAmount = 101000, Player = player1 };
            Walletrecord walletrecord2 = new Walletrecord { Timestamp = 20190906211300, PreviousAmount = 100000, LatestAmount = 98000, Player = player2 };
            Walletrecord walletrecord3 = new Walletrecord { Timestamp = 20190906211510, PreviousAmount = 101000, LatestAmount = 101500, Player = player1 };
            //PlayerExperience playerExperience1 = new PlayerExperience { Player = player1, Experience = "fun" };
            //PlayerExperience playerExperience2 = new PlayerExperience { Player = player2, Experience = "fun1" };

            context.Players.Add(player1);
            context.Players.Add(player2);
            context.Walletrecords.Add(walletrecord1);
            context.Walletrecords.Add(walletrecord2);
            context.Walletrecords.Add(walletrecord3);
            //context.PlayerExperiences.Add(playerExperience1);
            //context.PlayerExperiences.Add(playerExperience2);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}