var students = [
	{first_name: "Michael", last_name:"Jordan"},
	{first_name: "John", last_name:"Rosales"},
	{first_name: "Mark", last_name:"Guillen"},
	{first_name: "KB", last_name:"Tonel"},
]

// function fullName(students){

	var arrFirst = [];
	var arrLast = [];
	for (var i in students){
		arrFirst.push(i);
		arrLast.push(students[i]);
	}
// }
console.log(students)
