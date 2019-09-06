using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BangBang.Models
{

    public class DataDbContext:DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Walletrecord> Walletrecords { get; set; }
        public DbSet<GameRecord> GameRecords { get; set; }
        public DbSet<PlayerExperience> PlayerExperiences { get; set; }

    }

}