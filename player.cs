public class Player
{
    public string Name;
    public int Health;
    public int AttackPower;
    public int Gold;
    public int Potions;

    public Player(string name, int health, int attackPower, int gold, int potions)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
        Gold = gold;
        Potions = potions;
    }

    public void Attack()
    {
        Console.WriteLine($"{Name} útočí s sílou {AttackPower}!");
    }

    public void UseHealthPotion()
    {
        if (Potions > 0)
        {
            Health += 20;
            Potions--;
            Console.WriteLine($"{Name} použil léčivý lektvar. Aktuální životy: {Health}. Aktuální lektvary: {Potions}.");
        }
        else
        {
            Console.WriteLine("Už nemáš žádné lektvary blbečku.");
        }
    }
}