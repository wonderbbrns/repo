namespace HW4
{
    class Character
    {
        private string name;
        private int hp;

        private int power;

        public string Name { get; set; }

        public int Hp { get; set {if (value <= 0) throw new ArgumentException("Здоровье не может быть нулевым или отрицательным"); } }
        public int Power { get; set{if (value < 0) throw new ArgumentException("Сила не может быть отрицательной"); } }
        public Character(string name, int hp, int power)
        {
            Name= this.name;
            Hp=this.hp;
            Power= this.power;
        }
        public void Attack(Character target)
        {
          target.Hp -=this.Power;
          Console.WriteLine($"{this.Name} атакует {target.Name} и наносит {this.Power} урона.");
        }
        public void GetStatus()
        {
            Console.WriteLine($"{this.Name} имеет {this.Hp} здоровья и {this.Power} силы.");
        }
        private static int count = 0;
        public static int Count
        {
            get { return count; }
        }
        private static void HowMany()
        {
            count++;
        }
        private static void IsValidStats(int hp, int power)
        {
            if (hp <= 0)
            {
                throw new ArgumentException("Здоровье не может быть нулевым или отрицательным");
            }
            if (power < 0)
            {
                throw new ArgumentException("Сила не может быть отрицательной");
            }
        }

    }
    class Player : Character
    {
        public Player(string name, int hp, int power) : base(name, hp, power)
        {
          
        }
    }
    class Enemy : Character
    {
        public Enemy(string name, int hp, int power) : base(name, hp, power)
        {
          
        }
    }
}