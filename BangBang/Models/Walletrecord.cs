using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BangBang.Models
{
    public class Walletrecord
    {
        //餘額變化明細
        public int WalletrecordID { get; set; }
        public long Timestamp { get; set; }
        public int PreviousAmount { get; set; }
        public int LatestAmount { get; set; }
        //添加外鍵(Many-to-One) Walletrecord ------> Player
        public int PlayerID { get; set; }
        public virtual Player Player { get; set; }
    }
}