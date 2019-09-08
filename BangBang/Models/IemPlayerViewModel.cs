using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangBang.Models
{
    public class IemPlayerViewModel
    {
        public IEnumerable<Player> players { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "暱稱")]
        [System.Web.Mvc.Remote("PlayerNameexistVaild", "Players", HttpMethod = "POST", ErrorMessage = "PlayerName already exists")]
        public String PlayerName { get; set; }
        [Display(Name = "推薦人")]
        public int PlayerVipLevel { get; set; }
        public virtual List<Walletrecord> Walletrecords { get; set; }
        public virtual List<GameRecord> GameRecords { get; set; }
        public virtual PlayerExperience PlayerExperience { get; set; }
    }
}