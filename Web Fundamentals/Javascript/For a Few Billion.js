var payment = 0.01;
var total = 0;

for (var day = 1; day <=30; day++) {
	total +=payment;
	payment+=payment;
	}
console.log(total);
