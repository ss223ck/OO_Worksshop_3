﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    class SimpleView : IView
    {
        private const char play = 'p';
        private const char hit = 'h';
        private const char stand = 's';
        private const char quit = 'q';
        public void DisplayWelcomeMessage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Hello Black Jack World");
            System.Console.WriteLine(string.Format("Type '{0}' to Play, '{1}' to Hit, '{2}' to Stand or '{3}' to Quit\n", play, hit, stand, quit));
        }

        public InputEvents GetInput()
        {
            char s = Console.ReadKey().KeyChar;
            switch(s)
            {
                case play:
                    return InputEvents.NewGame;
                case hit:
                    return InputEvents.Hit;
                case stand:
                    return InputEvents.Stand;
                case quit:
                    return InputEvents.Quit;
                default:
                    return InputEvents.WrongInput;
            }
        }

        public void DisplayCard(model.Card a_card)
        {
            System.Console.WriteLine("{0} of {1}", a_card.GetValue(), a_card.GetColor());
        }

        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Player", a_hand, a_score);
        }

        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Dealer", a_hand, a_score);
        }

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            System.Console.WriteLine("{0} Has: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            System.Console.WriteLine("Score: {0}", a_score);
            System.Console.WriteLine("");
        }

        public void DisplayGameOver(bool a_dealerIsWinner)
        {
            System.Console.Write("GameOver: ");
            if (a_dealerIsWinner)
            {
                System.Console.WriteLine("Dealer Won!");
            }
            else
            {
                System.Console.WriteLine("You Won!");
            }
            
        }
    }
}
