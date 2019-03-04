using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesten
{
    public static class GameViews
    {



        public static void ShowPlayersNames(GameController game)
        {
            Console.Write("Starting game with: ");
            foreach (var player in game.GetPlayers())
            {
                Console.Write("{0}, ", player.name);
            }
            Console.WriteLine();

            
        }

        private static void ShowCardsPlayer(IPlayer player)
        {
            if (player.cards.Count != 0)
            {
                Console.Write("{0} has: ", player.name);
                foreach (var card in player.cards)
                {
                    Console.Write("{0}{1} ", card.Number, card.Shape);
                }
                Console.WriteLine();
            }
        }
        public static void ShowCardsPlayers(GameController game)
        {

            foreach (var player in game.GetPlayers())
            {
                ShowCardsPlayer(player);
            }
            
        }
        public static void ShowTopCard(GameController game)
        {

            Console.Write("The top card is {0}{1}", 
                game.middleDeck[game.middleDeck.Count - 1].Number, game.middleDeck[game.middleDeck.Count - 1].Shape);
            Console.WriteLine();
        }
        public static void ShowPlayedCard(IPlayer player, Card card)
        {
            Console.WriteLine("{0} plays the {1} of {2}", player.name, card.Number, card.Shape);
        }
        public static void ShowDealtCard(IPlayer player, Card card)
        {
            Console.WriteLine("{0} doesn't have a suitable card so he gets from the pack the {1} of {2}", player.name, card.Number, card.Shape);
        }
        public static void ShowMainDeckStatus(int currentAmountOfCardsInTheDeck)
        {
            Console.WriteLine("Main deck was reloaded with {0} cards", currentAmountOfCardsInTheDeck);
        }
        public static void ShowGameStatus(int gameStatus)
        {
            switch (gameStatus)
            {
                case 0: Console.WriteLine("Players Take Turns!!!");
                        break;
                case 1: Console.WriteLine("Game Over!!!");
                        break;
                default:
                    break;
            }
        }

    }
}
