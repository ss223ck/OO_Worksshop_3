using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory
    {
        public IHitStrategy GetHitRule()
        {
            return new AceHitStrategy();
            //return new BasicHitStrategy();
        }

        public INewGameStrategy GetNewGameRule()
        {
            //return new InternationalNewGameStrategy();
            return new AmericanNewGameStrategy();
        }

        public IWhoWinsRule GetWhoWinsRule()
        {
            //return new DealerWinsStrategy();
            return new PlayerWinsStrategy();
        }
    }
}
