using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BangBang.Models
{
    public class GameRecord
    {
        //遊戲明細
        public int GameRecordID { get; set; }
        public long Timestamp { get; set; }
        public int Stake { get; set; }
        //添加外鍵(Many-to-One) GameRecord ------> Player
        public int PlayerID { get; set; }
        [JsonIgnore()]
        public virtual Player Player { get; set; }
    }
}