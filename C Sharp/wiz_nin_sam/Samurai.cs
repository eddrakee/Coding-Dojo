namespace Characters
{

    // Create Samurai with a default health of 200
    public class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            health = 200;
            // For the HowMany method, we need a counter for each Samurai created!
            counter ++;

        }
        // Create DeathBlow method. It should attack an objevt and decrease health to 0 if less than 50 health
        public void DeathBlow(object target)
        {
            Human enemy = target as Human;
            if (enemy == null)
            {
                System.Console.WriteLine("Failed Attack!");
            }
            else if (enemy != null)
            {
                if(enemy.health < 50){
                    enemy.health = 0;
                }
                else{
                    System.Console.WriteLine("Attack Failed! Enemy has too high of health!");
                }
            }
         
        }

        // Create Meditate method that heals it back to full health
        public void Meditate(){
            health = 200;
        }

        // Create a HowMany Method that tells how many Samurai exist
        // We have to use Static for this
        public static void HowMany(){
            System.Console.WriteLine(counter);
        }
    }

}