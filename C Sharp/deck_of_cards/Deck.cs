// Make sure to put this in since we are using a list
using System.Collections.Generic;
using System;

namespace DeckOfCards{
    public class Deck{
        // Since you don't want anyone to manipulate the deck while it's in play, so we should set it to private
        private List<Card> cards;

        // CREATE A DECK METHOD
        public Deck(){
            Reset();
        }
        // DEAL METHOD
        // This will return a card, the method is called Deal. We need to take the top card and flip it!
        public Card Deal(){
            if(cards.Count > 0){
                 // since when we remove, the value goes away, so we need to use a temp to store the value
                Card temp = cards[0];
                cards.RemoveAt(0);
                return temp;
            }
            // this is your error!
            // null is a sorta allowed value of objects
           return null;
        }

        // SHUFFLE METHOD
        // we don't have to return something because it's just shuffling, but in this case, we will. And it will only work if we use "this"
        public Deck Shuffle(){
            Random rand = new Random();
            // may need to "use System" at the top for the shuffle algorithm
            // We are using the Fischer-Yates shuffle
            for(int i = cards.Count - 1; i > 0; i --){
                int randIdx = rand.Next(i);
                Card temp = cards[randIdx];
                cards[randIdx] = cards[i];
                cards[i] = temp;
            }
            // for chaining! Also, this returns the deck
            return this;
        }

        // RESET METHOD - this will return a deck for chaining
        // NOTE: Originally, the create a deck method had these for loops etc that are below. This is non-static and therefore cannot call upon constructor methods. So what we did was take the code from the Create Deck constructor, and call the Reset in the Create method!
        public Deck Reset(){
            // want to create a regular deck of 52 cards. We do this by first making a list of cards!
            cards = new List<Card>();
            // We are going to pull from this suit array
            string[] suits = new string[4] {"Hearts", "Spades", "Clubs", "Diamonds"};
            // the foreach will iterate through the four decks
            foreach(string suit in suits){
                // this for loop will populate the cards for each suit type
                for(int val = 1; val <= 13; val ++){
                    // "suit" refers to the one in the foreach
                    // also this will add the card we created
                    cards.Add(new Card(suit, val));
                }
            }
            // this we use for chaining. This was not in the original Create Deck method
            return this;
        }

        // How to print out the deck
        public override string ToString(){
            string info = "";
            foreach(Card card in cards){
                // This will only work when you've overriden the ToString
                info += card + "\n";
            }
            // This returns a single string to the console.writeline which passes it back further
            return info;
        }
    }
}