using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BangBang.Models
{
    public class PlayerLogin
    {
        [Display(Name = "暱稱")]
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [System.Web.Mvc.Remote("PlayerNameexist", "Players", HttpMethod = "POST", ErrorMessage = "暱稱不存在，登入失敗，請前往註冊")]
        public String PlayerName { get; set; }
    }
}