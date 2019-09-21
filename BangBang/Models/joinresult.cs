using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BangBang.Models
{
    public class joinresult
    {
        public long Timestamp { get; set; }
        public int PreviousAmount { get; set; }
        public int Stake { get; set; }
        public int LatestAmount { get; set; }
        
    }
}