using ShufleList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesten
{
    public class Deck
    {

        public readonly int numberOfcards = 52;
        public readonly int numberOfcardGroups = 13;
        public readonly int numberOfshapes = 4;

        
        private char[] _shapes;
        private string[] _numbers;
        private List<Card> _deck;

        public Deck()
        {
            GenDeck();
        }
        private void GenDeck()
        {
            _shapes = new char[] { '♠', '♣', '♥', '♦' };
            _numbers = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "As", "J", "Q", "K" };


            _deck = new List<Card>();
            foreach (var shape in _shapes)
            {
                foreach (var number in _numbers)
                {
                    _deck.Add(new Card { Shape = shape, Number = number });
                }
            }
        }
        public List<Card> Shufle()
        {
            _deck.Shuffle();
            return _deck;
        }


     

    }
}
