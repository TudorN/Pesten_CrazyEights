using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesten
{
    public interface IPlayer
    {
        string name { get; set; }
        List<Card> cards { get; set; }
        
        Card IsLookingForAmatch(Card topCard);
        bool IsAtHisLastCard();
        bool HasWon();
 
    }
}
