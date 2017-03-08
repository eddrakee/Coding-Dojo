namespace Characters{
    public class Human
    {
        // Use the { get; set; } to create accesspr methods for the specified fields
        // this will make it more flexible
        public string name;
        public int health {get; set; }
        public int strength {get; set; }
        public int intelligence {get; set; }
        public int dexterity {get; set; }
        
        public Human(string person){
            name = person;
            strength = 3;
            intelligence = 3; 
            dexterity = 3;
            health = 100;
        }

        public Human(string person,  int strength,  int intelligence, int dexterity, int health){
            name = person;
            strength = strength;
            intelligence = intelligence;
            dexterity = dexterity;
            health = health;

        }
        public void Attack(object target){
            Human enemy = target as Human;
            if( enemy == null ){
                System.Console.WriteLine("Failed Attack!");
            }
            else{
                enemy.health -= strength * 5;
                System.Console.WriteLine("Successful Attack!");
            }
        }
    }
}