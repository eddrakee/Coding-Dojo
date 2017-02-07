
//  Hard: Write a function named caller2 that has one parameter. Have it console.log the string 'starting', wait 2 seconds, and then invokes the argument if the argument is a function. (setTimeout may be useful for this one.) The function should then console.log ‘ending?’ and return “interesting”. Invoke this function by passing it myDoubleConsoleLog.

// #1
function runningLogger(){
    console.log('I am running!');
}
runningLogger();

// #2
var num;
function multiplyByTen(num){
    return num * 10;
}
num = multiplyByTen(5);
console.log(num);

// #3
function stringReturnOne(){
    console.log('I return one!');
}
function stringReturnTwo(){
    console.log('I return two!');
}
stringReturnOne();
stringReturnTwo();

// #4
function caller(f_name){
    if (typeof f_name == "function") {
        f_name();
    }
}
console.log('Using caller');
caller(stringReturnTwo);

// #5
function myDoubleConsoleLog(f_one, f_two){
    if (typeof f_one == "function" && typeof f_two == "function") {
        console.log(f_one(2));
        console.log(f_two(3));
    }
}
myDoubleConsoleLog(multiplyByTen, multiplyByTen);

// ANSWER BELOW
/*
  Goal for these first 'easy' difficulty level assignments:
  returns versus void returns
*/

function runningLogger(){
  console.log("I am running");
}

function multiplyBy10(numb){
  if (typeof(numb) == "number"){
    return numb*10;
  }
}

function stringReturnOne(){
  return "cat";
}

function stringReturnTwo(){
  return "dog";
}

function myFunctionRunner(param){
  if (typeof(param)=='function'){
    param();
  }
}
// Somewhat interesting right?
myFunctionRunner(stringReturnOne);

function myDoubleConsoleLog(param1,param2){
  if (typeof(param1) == 'function' && typeof(param2) == 'function'){
    console.log(param1(), param2());
  }
}
myDoubleConsoleLog(stringReturnOne, stringReturnTwo);

// more interesting, we hope!
function caller2(param){
  console.log('starting');
  var x = setTimeout(function(){
    if (typeof(param)=='function'){
      // notice the passed parameters...
      param(stringReturnOne, stringReturnTwo);
    }
  }, 2000);
  console.log('ending');
  return "interesting";
}

caller2(myDoubleConsoleLog);
