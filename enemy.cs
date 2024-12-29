namespace RPGhra;

public class Enemy
{
    public string Name;
    public int Health;
    public int AttackPower;

    public Enemy(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower; 
    }

    public void Attack()
    {
        Console.WriteLine($"{Name} útočí s sílou {AttackPower}!");
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
        Console.WriteLine($"{Name} obdržel {damage} poškození. Zbývající životy: {Health}.");
    }

    public static void Combat(Player player, Enemy enemy)
    {
        Console.WriteLine($"Boj začíná! {player.Name} vs {enemy.Name}");

        while (player.Health > 0 && enemy.Health > 0)
        {
            // Player's turn to attack
            Console.WriteLine("Co chceš udělat?");
            Console.WriteLine("1. Útok");
            Console.WriteLine("2. Použít léčivý lektvar");
            string action = Console.ReadLine();

            if (action == "1")
            {
                enemy.TakeDamage(player.AttackPower);
                if (enemy.Health <= 0)
                {
                    Console.WriteLine($"Porazil jsi {enemy.Name}!");
                    break;
                }
            }
            else if (action == "2")
            {
                player.UseHealthPotion();
            }
            else
            {
                Console.WriteLine("Neplatná akce!");
            }

            Console.WriteLine($"{enemy.Name} útočí!");
            player.Health -= enemy.AttackPower;
            Console.WriteLine($"{player.Name} obdržel {enemy.AttackPower} poškození. Zbývající životy: {player.Health}");

            if (player.Health <= 0)
            {
                Console.WriteLine("Byl jsi poražen lol");
                break;
            }
        }
    }
}

public class Goblin : Enemy
{
    public Goblin() : base("Goblin", 30, 5) { }

    public void Attack()
    {
        Console.WriteLine($"{Name} tě bije do nohy se sílou {AttackPower}!");
    }
}

public class Orc : Enemy
{
    public Orc() : base("Orc", 50, 10) { }

    public void Attack()
    {
        Console.WriteLine($"{Name} útočí se sílou {AttackPower}!");
    }
}

public class Skeleton : Enemy
{
    public Skeleton() : base("Skeleton", 40, 8) { }

    public void Attack()
    {
        Console.WriteLine($"{Name} na tebe mrdá šípy se sílou {AttackPower}!");
    }
}

public class Dragon : Enemy
{
    public Dragon() : base("Dragon", 100, 20)
    {
    }

    public void Attack()
    {
        Console.WriteLine($"{Name} šálí oheň s sílou {AttackPower}!");
    }
}

