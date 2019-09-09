using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BangBang.Models
{
    public class Plzamountbox
    {
        [System.Web.Mvc.Remote("PlayerNameexistVaild", "Players", HttpMethod = "POST", ErrorMessage = "有人使用過這個暱稱了喔，換一個吧")]
        public int MyProperty { get; set; }
    }
}