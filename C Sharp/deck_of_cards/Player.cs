using System.Collections.Generic;

namespace DeckOfCards{
    public class Player{
        public string name;
        private List<Card> hand;
        public Player(string name){
            hand = new List<Card>();
            name = name;
        }

        // DRAWING A CARD
        // It needs a deck object, and we are calling this one currentDeck 
        public void DrawFrom(Deck currentDeck){
            hand.Add(currentDeck.Deal());
        }
        // DISCARD 
        // This one will return a "Card" 
        public Card Discard(int i){
            Card temp = hand[i];
            hand.RemoveAt(i);
            return temp;
        }
    }
}