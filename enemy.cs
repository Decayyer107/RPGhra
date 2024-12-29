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
}

public class Goblin : Enemy
{
    public Goblin() : base("Goblin", 30, 5) { }

    public void Attack()
    {
        Console.WriteLine($"{Name} rychle útočí s sílou {AttackPower}!");
    }
}

public class Orc : Enemy
{
    public Orc() : base("Orc", 50, 10) { }

    public void Attack()
    {
        Console.WriteLine($"{Name} útočí silně s sílou {AttackPower}!");
    }
}

public class Skeleton : Enemy
{
    public Skeleton() : base("Skeleton", 40, 8) { }

    public void Attack()
    {
        Console.WriteLine($"{Name} útočí ze stínu s sílou {AttackPower}!");
    }
}

public class Dragon : Enemy
{
    public Dragon() : base("Dragon", 100, 20)
    {
    }

    public void Attack()
    {
        Console.WriteLine($"{Name} chrlí oheň s sílou {AttackPower}!");
    }
}
