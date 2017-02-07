// Creating Objects I

// Create a vehicleConstructor that takes in the name, number of wheels, and number of passengers
// Each vehicle should have a makeNoise method
// Using the constructor, create a Bike
// redefine the Bike’s makeNoise method to print “ring ring!”
// Using the constructor, create a Sedan
// redefine the Sedan’s makeNoise method to print “Honk Honk!”
// Using the constructor, create a Bus
// Give the bus a pickUpPassengers method that takes in the number of passengers to pick up and adds them to the passenger count 
function VehicleConstructor(name,numWheels,numPassengers){
    this.name = name;
    this.wheels = numWheels;
    this.people = numPassengers;
    this.makeNoise = function(){
        console.log('beep! beep!')
    }
}

var bike = new VehicleConstructor('Bike', 2, 1);
bike.makeNoise = function(){
    console.log('ring! ring!')
}
bike.makeNoise();

var sedan = new VehicleConstructor('Sedan', 4, 6);
sedan.makeNoise = function(){
    console.log('honk! honk!')
}
sedan.makeNoise();

var bus = new VehicleConstructor('Bus', 8, 30);

bus.passengers = function pickUp(numPeople){
    bus.people += numPeople;
}

console.log(bus.people);
bus.passengers(4);
console.log(bus.people);
bus.passengers(5);
console.log(bus.people);
