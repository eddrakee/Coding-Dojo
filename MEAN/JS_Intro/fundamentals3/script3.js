function PersonConstructor(name){
    var personObject = {
        name : name,
        distanceTraveled: 0,
        sayName: function(){
        console.log(name);
        },
        saySomething: function(param){
        console.log('${name} says: ${param}');
        },
        walk : function(){
        console.log(name, 'is walking');
        personObject.distanceTraveled += 3;
        return personObject;
        },
        run : function(){
        console.log(name, 'is running');
        personObject.distanceTraveled += 10;
        return personObject;
        },
        crawl : function(){
        console.log(name, 'is crawling');
        personObject.distanceTraveled += 1;
        return personObject;
        }
    }
    return personObject;
}
PersonConstructor('Elise').run();

// ANSWER KEY - 
var person = {
  name : "Charlie",
  distance_traveled : 0,
  say_name : function(){
    console.log(person.name);
  },
  say_something : function(phrase){
    console.log(`${person.name} says: ${phrase}`);
  },
  walk : function(){
    console.log(`${person.name} is walking!`);
    person.distance_traveled += 3;
    return person;
  },
  run : function(){
    console.log(`${person.name} is running!`);
    person.distance_traveled += 10;
    return person;
  },
  crawl : function(){
    console.log(`${person.name} is crawling!`);
    person.distance_traveled += 1;
    return person;
  },
  chewGum:function(){
    console.log("I can walk and chew gum, but I can't chew gum and walk...");
  }
}

/* This is not the only way to do this.
  Specifically: the beltArray, and the levelUp strategy.
  Notice that the function returns an object literal and to reference/update internal object pieces we call the object by name.
*/
function ninjaConstructor(name, cohort){
  var ninja = {}
  var belts = ["yellow", "red", "black"]
  ninja.name = name;
  ninja.cohort = cohort;
  ninja.beltLevel = 0;
  ninja.levelUp = function(){
    if (ninja.beltLevel < 2){
      ninja.beltLevel += 1;
      ninja.belt = belts[ninja.beltLevel];
    }
    return ninja
  }
  ninja.belt = belts[ninja.beltLevel];
  return ninja;
}

