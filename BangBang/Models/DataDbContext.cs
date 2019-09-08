using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BangBang.Models
{

    public class DataDbContext : DbContext
    {
        //將使用LocalDB，因為感覺使用SQLserverExpress，放到GIThub上再下載到另一部機器會連不上
        public DataDbContext() : base("DefaultConnection")
        {

        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Walletrecord> Walletrecords { get; set; }
        public DbSet<GameRecord> GameRecords { get; set; }
        public DbSet<PlayerExperience> PlayerExperiences { get; set; }
        //public DbSet<IemPlayer> IemPlayers { get; set; }
    }

}