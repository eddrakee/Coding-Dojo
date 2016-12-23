var newArray = []
var arr = [1,"dog",2,4,"cat"]

function numbersOnly(arr){
	for(var i=0; i<arr.length;i++){
		if(typeof arr[i] === "number"){
			newArray.push(arr[i]);
		}
	}
}
numbersOnly(arr);
console.log(newArray);