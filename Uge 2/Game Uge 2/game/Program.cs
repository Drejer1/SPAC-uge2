// See https://aka.ms/new-console-template for more information
using game;
using game.Models;



IBlackJackUI ui = new BlackJackUI();
BlackJack game = new BlackJack(ui);
game.RunGame();