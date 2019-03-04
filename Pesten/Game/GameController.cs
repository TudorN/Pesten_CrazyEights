using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesten
{
    [System.Runtime.InteropServices.Guid("F183B32B-2CB5-4527-A7BB-A8565BC669E1")]
    public class GameController
    {
        public readonly int defaulAmountOfComPlayers = 6;
        public readonly int defaulAmountOfHumanPlayers = 1;
        public readonly int minAmountOfCompPlayers = 1;
        public readonly int maxAmountOfCompPlayers = 6;
        public readonly int minAmountOfHumanPlayers = 1;
        public readonly int maxAmountOfHumanPlayers = 1;
        public readonly int cardsPerPlayer = 7;
        public readonly int cardsPerPlayerEachTurn = 1;
        public readonly int cardsInTheMiddle = 1;
        public List<Card> middleDeck;

        //game states
        private const int playersTakeTurns = 0;
        private const int gameOver = 1;

        private readonly string[] _computerNames = { "Jan", "Robert", "Wilbert", "Stijn", "Jessica", "Jane", "Linda" };
        private Deck _deck = new Deck();
        private List<Card> _mainDeck;
        private int _gameStatus = playersTakeTurns;
        private IList<IPlayer> _players = new List<IPlayer>();



        /// <summary>
        /// Loads the number of computer players into a generic list of type IPlayer.
        /// The list gets filled with objects of the typle ComputerPlayer.
        /// </summary>
        /// <param name="NumberOfPlayers">Represents the number of players in total. This number must be between 1 and 7</param>
        public void LoadComputerPlayers(int NumberOfPlayers)
        {
            //limit the number of players between 1 and 4
            if (NumberOfPlayers < minAmountOfCompPlayers || NumberOfPlayers > maxAmountOfCompPlayers)
                NumberOfPlayers = defaulAmountOfComPlayers;
  
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                _players.Add(new ComputerPlayer { name =_computerNames[i] });
            }

        }


        public void LoadHumanPlayers(int NumberOfPlayers)
        {
            //limit the number of players between 1 and 4
            if (NumberOfPlayers < minAmountOfHumanPlayers    || NumberOfPlayers > maxAmountOfHumanPlayers)
                NumberOfPlayers = defaulAmountOfHumanPlayers;

            for (int i = 0; i < NumberOfPlayers; i++)
            {
                Console.WriteLine("Please fill in your name:");
                _players.Add(new HumanPlayer { name = Console.ReadLine() });
            }

        }

        //Load Human Players to be implemented.

        public IList<IPlayer> GetPlayers()
        {
            return _players;
        }

        public void InitializeMainDeck()
        {
            _mainDeck = _deck.Shufle();
        }

        public void InitializeMiddleDeck()
        {
            middleDeck = DealCards(cardsInTheMiddle);
        }

        private List<Card> DealCards(int amountOfCards)
        {

            List<Card> cardsDealt = new List<Card>();
            cardsDealt.AddRange(_mainDeck.Take(amountOfCards));
            _mainDeck.RemoveRange(0, amountOfCards);

            return cardsDealt;
        }

        public void DealCardsPerPlayer()
        {

            foreach (var player in _players)
            {
                player.cards = DealCards(cardsPerPlayer);
            }
            
        }

        public void Start()
        {               
            GameViews.ShowGameStatus(_gameStatus);
            while (!(Console.KeyAvailable || _gameStatus == gameOver))
            {


                foreach (var player in _players)
                {

                    var topCard = middleDeck[middleDeck.Count - 1];
                    var playedCard = player.IsLookingForAmatch(topCard);

                    CheckAndUpdateDecks(playedCard, topCard, player);
                    player.IsAtHisLastCard();
                    if (player.HasWon())
                    {
                        End();
                        break;
                    }
                    CheckAndReloadMainDeck();
                }
           

            }
            GameViews.ShowGameStatus(_gameStatus);
        }



        public bool IsThePlayerHuman(IPlayer player)
        {
            if (player.GetType()==typeof(HumanPlayer))
            {
                return true;
            }

            return false;
        }

        private Card IsThePlayersCardReal(Card playedCard, IPlayer player)
        {
            if (playedCard != null)
            {
                playedCard = player.cards.Find(card => card.Number == playedCard.Number
                                                   || card.Shape == playedCard.Shape);

                return playedCard;
            }
            return null;
        }

        private Card IsThePlayersCardAmatch(Card playedCard, Card topCard, IPlayer player)
        {

            if (playedCard.Shape == topCard.Shape || playedCard.Number == topCard.Number)
                return playedCard;

            return null;
        }

        private Card CheckCardsHumanPlayer(Card playedCard, Card topCard, IPlayer player)
        {

            if (IsThePlayersCardReal(playedCard, player) != null)
            {
                return IsThePlayersCardAmatch(playedCard, topCard, player);
            }

            return null;
        }
        private void UpdateMiddleDeckAndPlayersCards(Card playedCard, List<Card> middleDeck, IPlayer player)
        {
            middleDeck.Add(playedCard);
            player.cards.Remove(playedCard);
            GameViews.ShowPlayedCard(player, playedCard);
        }
        
        private void UpdateMainDeckAndPlayersCards(List<Card> mainDeck, IPlayer player)
        {
            var dealtCard = DealCards(cardsPerPlayerEachTurn)[0];
            player.cards.Add(dealtCard);
            GameViews.ShowDealtCard(player, dealtCard);
        }
        private void CheckAndUpdateDecks(Card playedCard, Card topCard, IPlayer player)
        {


            if (IsThePlayerHuman(player))
                playedCard = CheckCardsHumanPlayer(playedCard, topCard, player);


            if (playedCard != null)
            {
                UpdateMiddleDeckAndPlayersCards(playedCard, middleDeck, player);
            }
            else
            {
                UpdateMainDeckAndPlayersCards(_mainDeck, player);
            }              
        }



        private void CheckAndReloadMainDeck()
        {
            if (_mainDeck.Count == 0)
            {
                _mainDeck.AddRange( middleDeck.Take(middleDeck.Count-1));
                GameViews.ShowMainDeckStatus(_mainDeck.Count);
            }
        }
 
        private void End()
        {
            _gameStatus = gameOver;
        }

    }
}
