using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class DealerWinsStrategy : IWhoWinsRule
    {
        public bool IsDealerWinner(Player player, Player dealer, int maxScore)
        {
            if(player.CalcScore() > maxScore)
            {
                return true;
            } else if(dealer.CalcScore() > maxScore)
            {
                return false;
            }
            return dealer.CalcScore() >= player.CalcScore();
        }
    }
}
