// #1  - 
console.log(first_variable);
var first_variable = "Yipee I was first!";
function firstFunc() {
  first_variable = "Not anymore!!!";
  console.log(first_variable);
}
console.log(first_variable);

// #2 - 
var food;
function eat(){
    var food;
    food = "half-chicken";
    console.log(food);
    food = "gone";
    console.log(food);
}
food = "Chicken";
eat();
console.log(food);

//  #3 - 
var new_word;
function lastFunc(){
    new_word = "old";
}
new_word = "NEW!";
console.log(new_word);

