namespace Human{
    public class Human
    {
        public string Name;
        public int Strength = 3;
        public int Intelligence = 3;
        public int Dexterity = 3;
        public int Health = 100;

        public Human(string name){
            Name = name;
        }

        public Human(string name,  int strength,  int intelligence, int dexterity, int health){
            Name = name;
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
            Health = health;

        }
        public void Attack(object target){
            Human enemy = target as Human;
            if( enemy != null ){
                enemy.Health -= 5 * Strength;
            }
        }
    }
}