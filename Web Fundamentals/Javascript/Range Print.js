var start = 2
var end = 10
var move = 2

function printRange (min, max, skip){


for(var i = min; i<max; i+=skip){
	console.log(i);
}
}
printRange(start,end,move);