namespace RPGhra;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        Console.WriteLine("Zadejte své jméno, dobrodruhu:");
        string playerName = Console.ReadLine();
        Console.Clear();

        Player player = new Player(playerName, 100, 20, 0, 5);
        int roomsCleared = 0;

        while (player.Health > 0)
        {
            Console.WriteLine("Vyber si dveře: 1, 2 nebo 3.");
            string choice = Console.ReadLine();
            Console.Clear();

            Room currentRoom = Room.GenerateRoom();

            Console.WriteLine(currentRoom.Description.ToUpper());

            if (currentRoom is TreasureRoom treasureRoom)
            {
                treasureRoom.Enter();
                player.Gold += treasureRoom.TreasureAmount;
            }
            else if (currentRoom is EnemyRoom enemyRoom)
            {
                enemyRoom.Enter();
                Enemy.Combat(player, enemyRoom.Enemy);
            }
            else if (currentRoom is TreasureAndEnemyRoom treasureAndEnemyRoom)
            {
                treasureAndEnemyRoom.Enter();
                Enemy.Combat(player, treasureAndEnemyRoom.Enemy);

                if (player.Health > 0)
                {
                    player.Gold += treasureAndEnemyRoom.TreasureAmount;
                }
            }

            if (player.Health > 0)
            {
                roomsCleared++;
                Console.Clear();
;               Console.WriteLine($"Pokračujeme dál! Počet vyčištěných místností: {roomsCleared}. Získané zlaťáky: {player.Gold}. Aktuální zdraví: {player.Health}.");
            }
        }

        Console.Clear();
        Console.WriteLine("Hra skončila! Zemřel jsi noobe...");
        Console.WriteLine($"Vyčištěné místnosti: {roomsCleared}");
        Console.WriteLine($"Celkový počet získaných zlaťáků: {player.Gold}");
    }
}
