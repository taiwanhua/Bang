using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BangBang.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "暱稱")]
        [System.Web.Mvc.Remote("PlayerNameexistVaild", "Players", HttpMethod = "POST", ErrorMessage = "有人使用過這個暱稱了喔，換一個吧")]
        public String PlayerName { get; set; }
        [Display(Name ="推薦人")]
        public int PlayerVipLevel { get; set; }
      
        public virtual List<Walletrecord> Walletrecords { get; set; }
        
        public virtual List<GameRecord> GameRecords { get; set; }
      
        public virtual PlayerExperience PlayerExperience { get; set; }
    }
}