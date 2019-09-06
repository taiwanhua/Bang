using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BangBang.Models.Repositories
{
    public class PlayerRepository : Repository<Player>
    {
        //繼承自泛類型接口，class Typy 為 Player
        public List<Player> GetByPlayerName(String playerName) {
            return Dbset.Where(itemlist => itemlist.PlayerName.Contains(playerName)).ToList();
        }
 
    }
}