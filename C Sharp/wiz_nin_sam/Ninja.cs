
namespace Characters
{

    // Create a Ninja and update the dexerity from Human
    public class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            dexterity = 175;

        }
    
    // Create a Steal method
    public void Steal(object target)
    {
        Human enemy = target as Human;
        if (enemy == null)
        {
            System.Console.WriteLine("Failed Steal!");
        }
        else
        {
            Attack(enemy);
            health += 10;
        }
    }
    public void GetAway()
    {
        health -= 15;
    }

    }
}