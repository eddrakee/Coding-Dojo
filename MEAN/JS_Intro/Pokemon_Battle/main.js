var game = {
  players: [],
  addPlayer: function(){
      players.push
  }
};

function playerConstructor(name){
  player = {};
  player.name = name;
  player.card = null;
  player.addCard = function(card){
    player.hand.push(card);
  };
  return player;
};
