var daysUntilMyBirthday = 60;


while (daysUntilMyBirthday>30) {
	console.log(daysUntilMyBirthday + " days until my birthday. Oh no, so long!");
	daysUntilMyBirthday --;
}
while (daysUntilMyBirthday<=30 && daysUntilMyBirthday>5) {
	console.log(daysUntilMyBirthday + " days until my birthday. It's almost my birthday!");
	daysUntilMyBirthday --;
}
while (daysUntilMyBirthday<=5 && daysUntilMyBirthday>0) {
	console.log(daysUntilMyBirthday + " days until my birthday. I'M SO EXCITED!");
	daysUntilMyBirthday --;
}
while (daysUntilMyBirthday==0){
	console.log(daysUntilMyBirthday + " days until my birthday. IT'S MY BIRTHDAY!!!!");
	break;
}