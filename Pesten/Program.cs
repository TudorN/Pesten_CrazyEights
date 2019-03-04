using ShufleList;
using System;
using System.Collections.Generic;

namespace Pesten
{
    /*Spelletje: Pesten
     * 
     * Opdrachtomschrijving:
     * 
     * De appliecatie dient op de volgende manier te werken:
         
         * Het spel begint met 4 spelers.
         * Schud de 52 speelkaarten (geen jokers) random door elkaar.
         * Deel iedere speler 7 kaarten, het restant van de kaarten is de deel-stapel.
         * Neem een kaar van de deel-stapel en leg deze op de aflegstapel. Dit is de beginners kaart.
         * De spelers leggen om de beurt een kaart op aflegstapel. Deze kaart moet of hetzelfde symbool hebben (♠ ♣ ♦ ♥) 
           of hetzelfde getal hebben(2 t/m koning).
         * Als een speler niet kan pakt hij een kaart van de deel-stapel.
         * Waneer een speler geen kaarten meer heeft is het spel voorbij en wordt de winaar bekend gemaakt.
         * Het is niet de bedoeling dat je een interactief spel maakt. Je schrijft een programma die bovenstaande regels volgt.
    */



    class Program
    {
        private static void Main(string[] args)
        {
            //Changing console output to UTF8:
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Game S0: Init
            var game = new GameController();
      
            //Game S1: Load Players. Show The players.
            game.LoadComputerPlayers(6);
            game.LoadHumanPlayers(1);
            GameViews.ShowPlayersNames(game);
          
            //Game S2: Initialization.Loading and Shufling the cards       
            game.InitializeMainDeck();
           

            //Game S3: Loading and showing the cards per Player
            game.DealCardsPerPlayer();
            GameViews.ShowCardsPlayers(game);

            //Game S4: Get one card from the deck and put it in the middle. Show the card in the middle(the top card)
            game.InitializeMiddleDeck();
            GameViews.ShowTopCard(game);

            //Game S5: The Game begins
            game.Start();

            //Game S6: The Game is over:
        



        }
    }

 


   
}
