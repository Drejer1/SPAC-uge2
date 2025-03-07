using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game.Models
{
    interface IBlackJackUI
    {
        string readPlayerInput();
        void showDealerFirstCard(Dealer dealer);
        void showPlayerHand(Player player);
        void ShowStateOfGameBeforeReveal(Player player, Dealer dealer);
        void ShowStateOfGameAfterReveal(Player player, Dealer dealer);
        void playerBusts(Player player);
        void FinalWinner(Player player);
        bool PlayAgain();
        void FinalScore(params Player[] players);
    }
}
