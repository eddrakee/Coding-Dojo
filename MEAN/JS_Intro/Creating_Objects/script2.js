// Creating Objects II

// Have the Vehicle constructor take in "speed" and store it as an attribute
// Create a private variable called distance_travelled that starts as 0
// Create a private method called updateDistanceTravelled that increments distance traveled by speed
// Add a method to the Vehicle called "move" that calls updateDistanceTravelled and then makeNoise
// Add a method called checkMiles that console.logs the distance_travelled

function VehicleConstructor(name, numWheels, numPassengers, speed) {
    var self = this;
    var distance_travelled = 0;
    var updateDistanceTravelled = function () {
        distance_travelled += self.speed;
        console.log(distance_travelled);
    }
    this.name = name;
    this.wheels = numWheels;
    this.people = numPassengers;
    this.speed = speed;
    this.makeNoise = function (noise) {
        var noise = "honk!"
        console.log(noise)
    }
    this.move = function () {
        this.makeNoise();
        updateDistanceTravelled();
       
    }
    this.checkMiles = function () {
        console.log(distance_travelled);
    }
 
}

var bike = new VehicleConstructor('Bike', 2, 1, 20);

bike.move();
bike.checkMiles();
console.log(bike.speed);
bike.move();
bike.checkMiles();
console.log(bike.speed);

