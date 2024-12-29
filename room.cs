namespace RPGhra
{
    public class Room
    {
        public string Description;

        public Room(string description)
        {
            Description = description;
        }
        
    }

    public class TreasureRoom : Room
    {
        private Random random = new Random();
        public int TreasureAmount;

        public TreasureRoom(int treasureAmount) : base("Tato místnost obsahuje poklad!")
        {
            TreasureAmount =  random.Next(1, 11);
        }

        public void Enter()
        {
            Console.WriteLine($"Našel jsi poklad v hodnotě {TreasureAmount} zlaťáků!");
        }
    }

    public class EnemyRoom : Room
    {
        public Enemy Enemy { get; set; }

        public EnemyRoom(Enemy enemy) : base("Tato místnost obsahuje nepřítele!")
        {
            Enemy = enemy;
        }

        public void Enter()
        {
            Console.WriteLine($"Narazil jsi na nepřítele: {Enemy.Name}!");
        }
    }

    public class TreasureAndEnemyRoom : Room
    {
        private Random random = new Random();

        public int TreasureAmount;
        public Enemy Enemy;

        public TreasureAndEnemyRoom(int treasureAmount, Enemy enemy) 
            : base("Tato místnost obsahuje poklad i nepřítele!")
        {
            TreasureAmount = random.Next(1, 11);
            Enemy = enemy;
        }

        public void Enter()
        {
            Console.WriteLine($"Našel jsi poklad v hodnotě {TreasureAmount} zlaťáků!");
            Console.WriteLine($"Narazil jsi na nepřítele: {Enemy.Name}!");
        }
    }
}