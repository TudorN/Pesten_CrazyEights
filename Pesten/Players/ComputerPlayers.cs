using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesten
{

    public class ComputerPlayer:IPlayer
    {
        public string name { get; set; }      
        public List<Card> cards { get; set; }

        

        public Card IsLookingForAmatch(Card topCard)
        {
            var matchingCard = cards.Find(card => card.Number == topCard.Number || card.Shape == topCard.Shape);

            if (matchingCard != null)
            {
                return matchingCard;
            }
            return null;
        }
        public bool IsAtHisLastCard()
        {

            if (cards.Count == 1)
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
