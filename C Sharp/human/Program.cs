using System;

namespace Human
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human EliseHuman = new Human("Elise", 2, 500, 100, 100);
            Human LeahHuman = new Human ("Leah");
            System.Console.WriteLine(EliseHuman.Dexterity);
            System.Console.WriteLine(LeahHuman.Dexterity);
             System.Console.WriteLine(LeahHuman.Health);
            EliseHuman.Attack(LeahHuman);
            System.Console.WriteLine($"After being attacked by {EliseHuman.Name}, {LeahHuman.Name} has {LeahHuman.Health} health!");
        }
    }
}
