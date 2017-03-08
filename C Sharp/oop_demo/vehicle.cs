namespace OopDemo
{
    public class Vehicle
    {
        // get and set let us retreive and reset
        // best practice to use for something that you need to publicly retreive from
        public string Color {get; set; }
        public int numWheels {get; set; }
        public int odometer {get; set; }

        public void Move(int distance){
            odometer += distance;
        }

        // As soon as the object is created, this will run
        public Vehicle(string color, int wheels){
            // repeat the name as a method inside the class and it will be initiated
            Color = color;
            numWheels = wheels;
            odometer = 0;
        }

        public Vehicle(int wheels){
            Color = "Black";
            numWheels = wheels;
            odometer = 0;
        }
    }
    
}