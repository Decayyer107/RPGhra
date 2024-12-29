namespace RPGhra
{
    public class Room
    {
        public string Description;

        public Room(string description)
        {
            Description = description;
        }

        public static Room GenerateRoom()
        {
            Random random = new Random();
            int roomType = random.Next(1, 4);
            Room generatedRoom;

            switch (roomType)
            {
                case 1:
                    generatedRoom = new TreasureRoom(random.Next(1, 11));
                    break;

                case 2:
                    Enemy enemy = GenerateRandomEnemy();
                    generatedRoom = new EnemyRoom(enemy);
                    break;

                case 3:
                    Enemy enemyForComboRoom = GenerateRandomEnemy();
                    generatedRoom = new TreasureAndEnemyRoom(random.Next(1, 11), enemyForComboRoom);
                    break;

                default:
                    throw new InvalidOperationException("nn bro");
            }

            return generatedRoom;
        }

        private static Enemy GenerateRandomEnemy()
        {
            Random random = new Random();
            int enemyType = random.Next(1, 5);

            switch (enemyType)
            {
                case 1:
                    return new Goblin();
                case 2:
                    return new Orc();
                case 3:
                    return new Skeleton();
                case 4:
                    return new Dragon();
                default:
                    throw new Exception("nn bro");
                    break;
                    
            }
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