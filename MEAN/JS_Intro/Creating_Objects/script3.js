// Creating Objects III
// Modify the code from Part II to use Prototype and the recommended way of OOP we showed in the previous chapter
// ...You may have to change some private variables.methods to attributes to make all of the functionality to work...
// Then, have each vehicle generat a random VIN number 

function VehicleConstructor(name, numWheels, numPassengers, speed) {
    // this needs to be invoked before the function createVin()!
    var char = '0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ'

    this.distance_traveled = 0;
    this.name = name;
    this.wheels = numWheels;
    this.people = numPassengers;
    this.speed = speed;

    // invoke createVin to generate a random vin Number
    this.vin = createVin();

    function createVin(){
        var vin = '';
        for (var i = 0; i <17; i++){
            // use floor and random to generate a random index to then access a character from our character string
            vin += char[Math.floor(Math.random()*35)]; 
        }
        return vin;
    }
}
// now we move our functions outside of the constructor!
VehicleConstructor.prototype.makeNoise = function(noise){
    var noise = noise || "beep! beep!";
    console.log(noise);
    return this;
}

VehicleConstructor.prototype.move = function(){
    this.makeNoise();
    // you have to use this.updateDistanceTraveled so you can access the variable since it's no longer private
    this.updateDistanceTraveled();
    return this;
}

VehicleConstructor.prototype.checkMiles = function(){
    this.distance_traveled = 0;
    console.log(this.distance_traveled);
    return this;
}

VehicleConstructor.prototype.updateDistanceTraveled = function(){
    this.distance_traveled+= this.speed;
    console.log(this.distance_traveled);
    return this;
}

var car = new VehicleConstructor('car', 4, 4, 80)

car.move().makeNoise().checkMiles().updateDistanceTraveled()
// car.vin will look odd in node, so be sure to check it in chrome's console
car.vin

