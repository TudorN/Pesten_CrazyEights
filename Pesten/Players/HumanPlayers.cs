using System;
using System.Collections.Generic;

namespace Pesten
{
    public class HumanPlayer:IPlayer
    {
        
        public string name { get; set; }
        public List<Card> cards { get; set; }

        public Card IsLookingForAmatch(Card topCard)
        {
            var matchingCard = new Card();

            Console.WriteLine("Please enter the number and the shape of the card you want to play.");
            Console.WriteLine("Number: "); matchingCard.Number = Console.ReadLine();
            Console.WriteLine("Shape ( 1 = ♠, 2 = ♣, 3 = ♥, 4 = ♦ ): ");

            var playedShape = Console.ReadKey().KeyChar;
            switch (playedShape)
            {
                case '1':
                    matchingCard.Shape = '♠';
                    break;
                case '2':
                    matchingCard.Shape = '♣';
                    break;
                case '3':
                    matchingCard.Shape = '♥';
                    break;
                case '4':
                    matchingCard.Shape = '♦';
                    break;
                default:
                    Console.WriteLine("Not a suitable character.Try again next time. Game must go on!");
                    break;
            }
            Console.WriteLine();

            if (matchingCard.Number == topCard.Number || 
                matchingCard.Shape  == topCard.Shape)
            {
                return matchingCard;
            }


            return null;
        }

        public bool IsAtHisLastCard()
        {

            if (this.cards.Count == 1)
            {
                Console.WriteLine("{0} is at his last card ", name);
                return true;
            }

            return false;
        }
        public bool HasWon()
        {

            if (cards.Count == 0)
            {
                Console.WriteLine("{0} has Won ", name);
                return true;
            }

            return false;
        }
    }
}