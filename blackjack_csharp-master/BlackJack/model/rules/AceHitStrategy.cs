using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AceHitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            if(a_dealer.CalcScore() < g_hitLimit)
            {
                return true;
            }
                //checks to see if the amount of ace is atleast of half the dealers cards to make sure the dealer doesnt hit at a hard 17. Example ace + 6 + 10
            else if (a_dealer.GetHand().Count(x => x.GetValue() == Card.Value.Ace)*2 >= a_dealer.GetHand().Count() && a_dealer.CalcScore() <= g_hitLimit)
            {
                return true;
            }
            return false;
        }
    }
}
