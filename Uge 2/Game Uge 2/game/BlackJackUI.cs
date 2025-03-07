// See https://aka.ms/new-console-template for more information
using game.Models;
using System.Drawing;

public class BlackJackUI : IBlackJackUI
{
    public BlackJackUI()
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.Clear();
    }

    public void showPlayerHand(Player player)
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("|=============================|");
        Console.WriteLine($"|{player.Name}'s Hand:".PadRight(30)+"|");
        Console.WriteLine("|-----------------------------|");
        foreach (Card card in player.Hand)
        {
            WriteCard(card);
        }
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine(("|Points: " + player.Points).PadRight(30)+"|");
     
    }

    public void showDealerFirstCard(Dealer dealer)
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("|=============================|");
        Console.WriteLine("|Dealer's Hand".PadRight(30) + "|");
        Console.WriteLine("|-----------------------------|");
        Card card = dealer.showOneCard();
        WriteCard(card);
        Console.WriteLine("|Hidden".PadRight(30) + "|");
        Console.WriteLine(("|(Known)Points:" + dealer.pointsOfOneCard()).PadRight(30) + "|");
    }
    private void padRight(string str)
    {
        Console.WriteLine(str.PadRight(30));
    }

    private void WriteCard(Card card) 
    {
        Console.Write("|");
        if (card.Color == "Heart" || card.Color == "Diamond")
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else if (card.Color == "Spade" || card.Color == "Club")
        {
            Console.ForegroundColor = ConsoleColor.Black;
        }
        Console.Write((card.Number + " of " + card.Color + "s ").PadRight(29));
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("|");
    }
    public string readPlayerInput()
    {
        return Console.ReadLine();
    }

    public void ShowStateOfGameBeforeReveal(Player player1, Dealer dealer)
    {
        Console.Clear();
        showDealerFirstCard(dealer);
        showPlayerHand(player1);
        Console.WriteLine("|=============================|");
    }
    public void ShowStateOfGameAfterReveal(Player player1, Dealer dealer)
    {
        Console.Clear();
        showPlayerHand(dealer);
        showPlayerHand(player1);
        Console.WriteLine("|=============================|");
    }

    public void playerBusts(Player player)
    {
        Console.WriteLine($"|{player.Name} busts!".PadRight(30)+"|");
    }

    public void FinalWinner(Player player)
    {
        Console.WriteLine($"|{player.Name} Wins!!".PadRight(30)+"|");
        Console.WriteLine("|=============================|");
    }

    public bool PlayAgain()
    {
        Console.WriteLine("Play again?".PadLeft(20));
        string input;
        while (true)
        {
            input = Console.ReadLine();
            if (input.ToLower() == "yes")
            {
                return true;
            } else if (input.ToLower() == "no")
            {
                return false;
            }
            Console.WriteLine("Please write yes or no");
        }

    }

    public void FinalScore(params Player[] players)
    {
        Console.Write("|");
        string str = "";
        foreach(Player player in players)
        {
            str += $"{player.Name}: {player.Points}.";
        }
        Console.WriteLine(str.PadRight(29)+"|");
    }
}