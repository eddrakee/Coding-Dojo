using System;

namespace OopDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle1 = new Vehicle("Blue", 4);
            Vehicle vehicle2 = new Vehicle(2);
            System.Console.WriteLine(vehicle1.Color);
            System.Console.WriteLine(vehicle2.Color);

            Unicycle uni1 = new Unicycle();
            System.Console.WriteLine(uni1.numWheels);
            System.Console.WriteLine(uni1.Color);
            System.Console.WriteLine(uni1.odometer);
            uni1.Move(50);
            System.Console.WriteLine(uni1.odometer);



        }
    }
}
