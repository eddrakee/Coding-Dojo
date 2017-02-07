// make functions!
function sumXY(x,y){
    var sum = 0
    for(var i = x; i<= y; i++){
        sum += i;
    }
    return sum;
}
sumXY(0,2);

function findMin(arr){
    var min = arr[0]
    for(var i = 0; i < arr.lenght; i++){
        if(arr[i] < min){
            min = arr[i];
        }
    }
    return min;
    // console.log(min);
}

function findAvg(arr){
    var sum = 0
    for (var i = 0; i<arr.length; i++){
        sum += arr[i];
    }
    return sum/arr.length;
}

// make them anonymous variables

var findSum = function(x,y){
    var sum = 0
    for(var i = x; i<= y; i++){
        sum += i;
    }
    return sum;
}

var findMin = function(arr){
    var min = arr[0]
    for(var i = 0; i < arr.lenght; i++){
        if(arr[i] < min){
            min = arr[i];
        }
    }
    return min;
}

var findAvg = function(arr){
    var sum = 0
    for (var i = 0; i<arr.length; i++){
        sum += arr[i];
    }
    return sum/arr.length;
}

// rewrite it as an object 

var myObject = {
    sumXY : findSum = function(x,y){
    var sum = 0
    for(var i = x; i<= y; i++){
        sum += i;
    }
    return sum;
    },

    findMin : findMin = function(arr){
    var min = arr[0]
    for(var i = 0; i < arr.lenght; i++){
        if(arr[i] < min){
            min = arr[i];
        }
    }
    return min;
    },

    findAvg = function(arr){
    var sum = 0
    for (var i = 0; i<arr.length; i++){
        sum += arr[i];
    }
    return sum/arr.length;
    }
}

// make a person object

var personObject = {
    name : elise,
    distanceTraveled: 0,
    sayName: function(){
        console.log(personObject.name);
    },
    saySomething: function(param){
        console.log('${person.name} says: ${phrase}');
    },
    walk : function(){
        console.log('${personObject.name} is walking');
        personObject.distanceTraveled += 3;
        return personObject;
    },
    run : function(){
        console.log('${personObject.name} is running');
        personObject.distanceTraveled += 10;
        return personObject;
    },
    crawl : function(){
        console.log('${personObject.name} is crawling');
        personObject.distanceTraveled += 1;
        return personObject;
    }
}