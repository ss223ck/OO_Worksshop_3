using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface IWhoWinsRule
    {
        bool IsDealerWinner(Player player, Player dealer, int maxScore);
    }
}
