using game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class BlackJack
    {
        int delay = 500;
        private readonly IBlackJackUI _ui;
        public BlackJack(IBlackJackUI ui)
        {
            _ui = ui;
        }

        private void RestartGame(Deck deck, params Player[] players)
        {
            deck.resetDeck();
            deck.shuffleDeck();
            foreach (Player player in players)
            {
                player.EmptyHand();
            }
        }


        public void RunGame()
        {
            bool playAgain = true;
            Deck deck = new Deck();
            deck.shuffleDeck();
            Player player1 = new Player("Player");
            Dealer dealer = new Dealer("Dealer");

            do
            {
                deck.hit(player1);
                deck.hit(dealer);
                deck.hit(player1);
                deck.hit(dealer);
                bool playersTurn = true;
                bool playerbusts = false;
                bool dealerbusts = false;
                
                _ui.ShowStateOfGameBeforeReveal(player1, dealer);
                while (playersTurn)
                {
                    string input = _ui.readPlayerInput();
                    if (input.ToLower() == "hit")
                    {
                        deck.hit(player1);
                        _ui.ShowStateOfGameBeforeReveal(player1, dealer);
                        if (player1.Points > 21)
                        {
                            playerbusts = true;
                            break;
                        }
                    }
                    else if (input.ToLower() == "stand")
                    {
                        playersTurn = false;
                    }
                }
                _ui.ShowStateOfGameAfterReveal(player1, dealer);
                while (dealer.Points < 17 && !playerbusts)
                {
                    Thread.Sleep(delay);
                    deck.hit(dealer);
                    _ui.ShowStateOfGameAfterReveal(player1, dealer);
                    if (dealer.Points > 21)
                    {
                        dealerbusts = true;
                        break;
                    }
                }
                if (playerbusts)
                {
                    Thread.Sleep(delay);
                    _ui.playerBusts(player1);
                    Thread.Sleep(delay);
                    _ui.FinalWinner(dealer);
                }
                else if (dealerbusts)
                {
                    Thread.Sleep(delay);
                    _ui.playerBusts(dealer);
                    Thread.Sleep(delay);
                    _ui.FinalWinner(player1);

                }
                else
                {
                    if (player1.Points >= dealer.Points)
                    {
                        Thread.Sleep(delay);
                        _ui.FinalScore(dealer, player1);
                        Thread.Sleep(delay);
                        _ui.FinalWinner(player1);
                    }
                    else
                    {
                        Thread.Sleep(delay);
                        _ui.FinalScore(dealer, player1);
                        Thread.Sleep(delay);
                        _ui.FinalWinner(player1);
                    }
                }
                Thread.Sleep(delay);
                playAgain = _ui.PlayAgain();
                if (playAgain)
                {
                    RestartGame(deck, player1, dealer);
                }
            } while (playAgain);
        }

    }
}
