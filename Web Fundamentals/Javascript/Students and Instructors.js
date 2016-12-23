var students = [
	{first_name: "Michael", last_name:"Jordan"},
	{first_name: "John", last_name:"Rosales"},
	{first_name: "Mark", last_name:"Guillen"},
	{first_name: "KB", last_name:"Tonel"},
]

function fullName(arr){

	for(var key in arr){
		console.log(arr[key].first_name, arr[key].last_name);
	}
}
fullName(students);