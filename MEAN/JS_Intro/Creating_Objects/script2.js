// Creating Objects II
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
