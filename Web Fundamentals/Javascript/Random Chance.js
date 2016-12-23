var numCoins = Math.trunc(Math.random()*25)+1;
var winning = 100;

function playSlots(money){

	while (money> 0){
		var chance = Math.trunc(Math.random()*100)+1;
		if(chance!=winning){
			money--;
		}

		else{
			var coinsWon = Math.trunc(Math.random()*51)+50;
			money+=coinsWon;
		}
	}
	console.log("you have " + numCoins);
	console.log("coins won " + coinsWon);
	console.log("money " +money);

}
playSlots(numCoins);