namespace RPGhra;

public class Player
{
    public string Name;
    public int Health = 100;
    public int AttackPower  = 20;
    public int Gold = 0;
    public int Potions = 5;

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
        int healAmount = 20;
        if (Potions > 0)
        {
            Health += healAmount;
            Potions--;
            Console.WriteLine($"{Name} použil léčivý lektvar a obnovil {healAmount} životů. Aktuální životy: {Health}. Aktuální lektvary: {Potions}.");   
        }
        else
        {
            Console.WriteLine("Už nemáš žádné lektvary zdraví!");
        }
    }
}