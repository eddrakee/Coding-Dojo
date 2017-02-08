function DeckConstructor (){
    var deck = []
    for (var i = 1; i <53; i ++){
        deck.push(i);
    }
    this.deck = deck;

    this.shuffle = function(){
        // since our deck goes to 53 because we start with 0, we need to make it 52 with length-1
        var pointer = this.deck.length-1 
        var temp;
        var idx;
        // This while statement says, while pointer is larger than 0 (since we are decrementing from the end)
        while(pointer > 0){
            // This will find a random number between 0-(decklength-1), in the beginning, it will be 0-52
            // we use this to find which index to swap the last value in the array with (aka 52)
            idx = Math.floor(Math.random()* pointer);
            // now we know which index to swap with. So we must use temp to save the value of the array[array.length-1]
            // temp saves our number so we know what to insert into the new index
            temp = deck[pointer];
            // this takes the array[random number] and moves it to the pointer spot in the array
            this.deck[pointer] = this.deck[idx];
            // this makes the array[random number] = the temp number
            this.deck[idx] = temp;
            // we have to decrement since we are shuffling from the back to the front
            pointer --; 
        }
        console.log(this.deck);
        return this.deck;
    }
    this.reset = function(){
        var newDeck = []
        for (var i = 1; i <53; i ++){
        newDeck.push(i);
        }
        this.deck = newDeck;
        console.log(this.deck);
        return this.deck;
    }
    this.deal = function(){
        var cardDealt = this.deck.pop();
        return cardDealt;
        }
    }

var deckOne = new DeckConstructor();
deckOne.shuffle();

var x = deckOne.deal();
console.log(x);
console.log(deckOne.deck.length)

function PlayerConstructor(name){
    this.name = name;
    this.hand = [];
    // deck is just what we called the variable, not a specific deck from the DeckConstructor
    this.draw = function(deck){
        this.hand.push(deck.deal());
        console.log(this.hand);
        return this.hand;
    }
    // this discard function will let us discard a specific card out of your hand
    this.discard = function(cardToDiscard){
        // cardToDiscard is the index of which card you want to discard
        temp = this.hand[cardToDiscard];
        this.hand[cardToDiscard] = this.hand[this.hand.length-1];
        this.hand[this.hand.length-1] = temp;
        this.hand.pop();
        console.log(this.hand);
        return this.hand;
    }
}

var deckTwo = new DeckConstructor();
var playerOne = new PlayerConstructor();
playerOne.draw(deckTwo);

playerOne.draw(deckOne);
playerOne.discard(1);
