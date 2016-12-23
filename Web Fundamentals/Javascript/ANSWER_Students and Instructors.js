// How to get the first name and last name to line up, even if we don't know the name of the key in the object.
// So we are looping through objects, then looping again to get out that specific key in the object
var students = [
	{first_name: "Michael", last_name:"Jordan"},
	{first_name: "John", last_name:"Rosales"},
	{first_name: "Mark", last_name:"Guillen"},
	{first_name: "KB", last_name:"Tonel"},
]

// Loop through the whole array of objects
for(var i =0; i<students.length; i++){

	var str ="";
	// for each object loop through and print out the values of that object
	for(var key in students[i]){
		str += students[i][key] + " ";
	}
	console.log(str)
}

// Want to print out the names with the number of letters in their name next to it

var users = {

	"Students" :[
	{first_name: "Michael", last_name:"Jordan"},
	{first_name: "John", last_name:"Rosales"},
	{first_name: "Mark", last_name:"Guillen"},
	{first_name: "KB", last_name:"Tonel"},
],

	"Instructors" :[
	{first_name: "Michael", last_name:"Choi"},
	{first_name: "Martin", last_name:"Puryear"},
	]
}
// ?loop through each key in our object
for (var category in users){
	console.log(category);
	// using that key to loop through the array of that value
	for(var i =0; i <users[category].length; i++){

		// looping through the values associated to that object
		for(var person in users[category][i]){
			console.log(users [category] [i] [person]);
		}
	}
}