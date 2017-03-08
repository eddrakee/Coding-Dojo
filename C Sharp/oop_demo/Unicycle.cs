namespace OopDemo
{
    // Unicycle will inheret from Vehicle
    public class Unicycle : Vehicle{
        // Running the base method - base looks to what the parent's have and it pass the needed variables to the parent class' constructor methods
        public Unicycle() : base(1){
            Color = "Red";
        }
         // Method Overwritting
        public void Move(int num){
            System.Console.WriteLine("SOMETHING DIFFERENT");
        }
    }
}