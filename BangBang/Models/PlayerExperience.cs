using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BangBang.Models
{
    public class PlayerExperience
    {
        //玩家心得回饋(備用)
        [Key]
        [ForeignKey("Player")] //One-To-One關係中，EF對於兩個互相指定的表無法分辨誰是父誰是子，必須需要於子級表指定外鍵
        public int PlayerID { get; set; }
        [Required]
        public String Experience { get; set; }
        public virtual Player Player { get; set; }
    }
}