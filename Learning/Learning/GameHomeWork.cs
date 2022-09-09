namespace Learning;

public class GameHomeWork { }

public abstract class Unit
{
    protected int AttackPower { get; set; }
    protected int Health { get; set; }

    public Unit(int health, int attackPower)
    {
        Health = health;
        AttackPower = attackPower;
    }

    public virtual int Attack()
    {
        Console.WriteLine($"Юнит анес удар с силой {AttackPower}");
        return AttackPower;
    }

    public virtual bool TakeDamage(int damage)
    {
        var health = Health - damage;
        if (health <= 0)
        {
            return false;
        }

        return true;
    }
    
}

public class Warrior : Unit
{
    public Warrior(int health, int attackPower) : base(health, attackPower) {}

    public override int Attack()
    {
        Console.WriteLine($"Воин нанес удар с силой {AttackPower}");
        return AttackPower;
    }

    public override bool TakeDamage(int damage)
    {
        Health -= damage / 2;
        Console.WriteLine($"Воин получил урон {damage/2}");
        return Health > 0;
    }
}

public class Slayer : Unit
{
    public Slayer(int health, int attackPower) : base(health, attackPower) {}

    public override int Attack()
    {
        var rnd = new Random().Next(1,3);
        Console.WriteLine($"Убийца нанес удар с силой {AttackPower * rnd}");
        return AttackPower * rnd;
    }

    public override bool TakeDamage(int damage)
    {
        var rnd = new Random().Next(1,5);
        Health -= damage / rnd;
        Console.WriteLine($"Убийца получил урон с силой {damage / rnd}");
        return Health > 0;
    }
}

public class Archer : Unit
{
    public Archer(int health, int attackPower) : base(health, attackPower) {}

    public override int Attack()
    {
        var rnd = new Random().Next(1, 3); 
        Console.WriteLine($"Лучник нанес удар с силой {AttackPower * rnd}");
        return AttackPower * rnd;
    }

    public override bool TakeDamage(int damage)
    {
        var rnd = new Random().Next(1, 4);
        Health -= damage / rnd;
        Console.WriteLine($"Лучник получил урон {damage/rnd}");
        return Health > 0;
    }
}