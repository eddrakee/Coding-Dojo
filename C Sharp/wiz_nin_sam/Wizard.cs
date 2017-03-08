namespace Characters{

    // Creating a Wizard character that inherits from Human, but has different health and intelligence
    public class Wizard : Human{
        public Wizard(string name) : base(name){
            health = 50;
            intelligence = 25;
        }

        // Heal method. It doesn't need to return anything
        public void Heal(){
            health += 10 * intelligence;
        }
        // Fireball method. It decreases health of whomever attacked by a random int between 20 and 50
        public void Fireball(object target){
            Human enemy = target as Human;
            if( enemy == null ){
                System.Console.WriteLine("Failed Attack!");
            }
            else{
                Random rand = new Random();
                enemy.health -= rand.Next(20, 51);
            }
        }


    }
}
      
    
