namespace HW4
{
    class Character
    {
        private string name;
        private int hp;

        private int power;

        public string Name => name;

        public int Hp => hp;
        public int Power => power;
        public Character(string name, int hp, int power)
        {
            if (!IsValidStats(hp, power))
            {
                throw new ArgumentException("Здоровье и сила удара должны быть положительными");
            }
            this.name = name;
            this.hp = hp;
            this.power = power;
            count++;
        }
        public virtual void Attack(Character target)
        {
            target.TakeDamage(this.power);
            Console.WriteLine($"{this.Name} атакует {target.Name} и наносит {this.Power} урона.");
        }
        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                throw new ArgumentException("Урон не может быть отрицательным");
            }
            hp -= damage;
            if (hp < 0)
            {
                hp = 0;
            }
        }
        public bool IsAlive()
        {
            return hp > 0;
        }
        private static int count = 0;
        public static int Count
        {
            get { return count; }
        }
        public static int HowMany()
        {
            return count;
        }
        public static bool IsValidStats(int hp, int power)
        {
            return hp > 0 && power > 0;
        }
        public override string ToString()
        {
            return $"{this.Name} (HP: {this.Hp})";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Character other)
            {
                return this.name == other.name;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

    }
    class Player : Character
    {
        public Player(string name, int hp, int power) : base(name, hp, power)
        {
          
        }
        public override void Attack(Character target)
        {
            target.TakeDamage(this.Power);
            Console.WriteLine($"Игрок {this.Name} бьёт {target.Name} и наносит {this.Power} урона.");
        }
    }
    class Enemy : Character
    {
        public Enemy(string name, int hp, int power) : base(name, hp, power)
        {
          
        }
        public override void Attack(Character target)
        {
            target.TakeDamage(this.Power);
            Console.WriteLine($"Враг {this.Name} атакует {target.Name} и наносит {this.Power} урона.");
        }
    }
    class Program
    {
        static void Main()
        {
            List<Character> characters = new List<Character>
            {
                new Player("Фродо", 30, 7),
                new Enemy("Голлум", 25, 5),
                new Player("Сэм", 28, 6 )
            };

            Console.WriteLine($"Создано персонажей: {Character.HowMany()}");
            Console.WriteLine(characters[0]);
            Console.WriteLine(characters[1]);
            Console.WriteLine(characters[2]);
            bool fight = true;
            while (fight)
            {
                for (int i = 0; i < characters.Count; i++)
                {
                    Character attacker = characters[i];
                    Character target = characters[(i + 1) % characters.Count];

                    attacker.Attack(target);
                    Console.WriteLine(target);

                    if (!target.IsAlive())
                    {
                        Console.WriteLine($"Победил {attacker.Name}!");
                        fight = false;
                        break;
                    }
                }
            }
        }
    }
}