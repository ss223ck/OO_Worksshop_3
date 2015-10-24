﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWhoWinsRule m_winRule;

        private List<BlackJackObserver> m_BlackJackObserver;

        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winRule = a_rulesFactory.GetWhoWinsRule();
            m_BlackJackObserver = new List<BlackJackObserver>();
        }
        public void AddSubscriber(BlackJackObserver observer)
        {
            m_BlackJackObserver.Add(observer);
        }
        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                GetCard(a_player);

                return true;
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            return m_winRule.IsDealerWinner(a_player, this, g_maxScore);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        public bool Stand()
        {
            if(m_deck != null)
            {
                ShowHand();
                foreach(Card c in GetHand())
                {
                    c.Show(true);
                }
            }
            while(m_hitRule.DoHit(this))
            {
                GetCard(this);
            }
            return true;
        }
        public void GetCard(Player player, bool showCard = true)
        {
            Card c = m_deck.GetCard();
            c.Show(showCard);
            player.DealCard(c);
            foreach(BlackJackObserver observer in m_BlackJackObserver)
            {
                observer.CardDisplayed();
            }
        }
    }
}
