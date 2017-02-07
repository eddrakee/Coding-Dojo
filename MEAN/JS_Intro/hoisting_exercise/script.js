// // Example (before):
var hello = "interesting";
function example() {
  var hello = "hi!";
  console.log(hello);
}
example();
console.log(hello);

// // Example (after):
// //declarations get hoisted
var hello;                 
function example() {       
  var hello;               
  hello = "hi";            
  console.log(hello);       
}
//assignments and invocation maintain order
hello = "interesting";     
example();                        
console.log(hello);

// #1 Before - 
console.log(first_variable);
var first_variable = "Yipee I was first!";
function firstFunc() {
  first_variable = "Not anymore!!!";
  console.log(first_variable);
}
console.log(first_variable);

// #1 After - 
var first_variable;
function firstFunc() {
    var first_variable 
    first_variable = "Not anymore";
    console.log(first_variable);
}
console.log(first_variable);
first_variable = "Yipee I was first!";
console.log(first_variable);

// #2 Before - 
var food = "Chicken";
function eat() {
  food = "half-chicken";
  console.log(food);
  var food = "gone";       // CAREFUL!
  console.log(food);
}
eat();
console.log(food);

// #2 After - 
var food; // Declare an outer scope food variable
function eat() {
  var food;
  food = "half-chicken";
  console.log(food); // half-chicken console.log, since there is a LOCAL food
  food = "gone";       // CAREFUL! LOCAL food is set to gone
  console.log(food); // LOCAL food is logged ('gone')l
}
food = "Chicken"; //outer food is set to "chicken"
eat(); // eat is invoked and the half_chicken and gone are logged (the local foods!)
console.log(food); // outer food is logged('chicken')

//  #3 Before - 
var new_word = "NEW!";
function lastFunc() {
  new_word = "old";
}
console.log(new_word);

// #3 After - 


var new_word; //outer scope new_word variable
function lastFunc(){
  new_word = 'old'; // still references the outer scope new_word variable
}
new_word = "NEW!";
console.log(new_word); //lastFunc wasn't invoked so console.log's "New"