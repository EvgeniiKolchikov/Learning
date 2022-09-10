namespace Learning;

public class GameHomeWork { }

public abstract class Unit
{
    protected int AttackPower { get; set; }
    public int Health { get; set; }

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
        Console.WriteLine($"Здоровье воина {Health}");
        return Health > 0;
    }
}

public class Slayer : Unit
{
    public Slayer(int health, int attackPower) : base(health, attackPower) {}

    public override int Attack()
    {
        var rnd = new Random().Next(1,4);
        Console.WriteLine($"Убийца нанес удар с силой {AttackPower * rnd}");
        return AttackPower * rnd;
    }

    public override bool TakeDamage(int damage)
    {
        var rnd = new Random().Next(1,5);
        Health -= damage / rnd;
        Console.WriteLine($"Убийца получил урон с силой {damage / rnd}");
        Console.WriteLine($"Здоровье убийцы {Health}");
        return Health > 0;
    }
}

public class Archer : Unit
{
    public Archer(int health, int attackPower) : base(health, attackPower) {}

    public override int Attack()
    {
        var rnd = new Random().Next(1, 4); 
        Console.WriteLine($"Лучник нанес удар с силой {AttackPower * rnd}");
        return AttackPower * rnd;
    }

    public override bool TakeDamage(int damage)
    {
        var rnd = new Random().Next(1, 4);
        Health -= damage / rnd;
        Console.WriteLine($"Лучник получил урон {damage/rnd}");
        Console.WriteLine($"Здоровье лучника {Health}");
        return Health > 0;
    }
}

public enum WeaponTypeEnum { Axe = 1, Dagger = 2 }
public class Player : Unit
{
    private int _weaponType;
    private int WeaponType
    {
        
        set
        {
            if (value >= 1 || value <= 2)
            {
                _weaponType = value;
                return;
            }
            value = 1;
            _weaponType = value;
        }
    }
    public Player(int health, int attackPower, WeaponTypeEnum weaponType) : base(health, attackPower)
    {
        _weaponType = (int)weaponType;
    }

    public override int Attack()
    {
        if (_weaponType == (int)WeaponTypeEnum.Axe)
        {
            var rnd = new Random().Next(1, 3);
            Console.WriteLine($"Игрок нанес удар топором с силой {AttackPower * rnd}");
            return AttackPower * rnd;
        }

        var rand = new Random().Next(1, 11);
        Console.WriteLine($"Игрок нанес удар кинжалом с силой {AttackPower / 2 * rand}");
        return AttackPower / 2 * rand;
    }

    public override bool TakeDamage(int damage)
    {
        var rnd = new Random().Next(1, 3);
        Health -= damage/rnd;
        Console.WriteLine($"Игрок получил урон {damage/rnd}");
        Console.WriteLine($"Здоровье игрока: {Health}");
        return Health > 0;
    }
}

public class BattleField
{
    private Unit[] _enemies;
    private Player _player;

    public BattleField(Unit[] enemies, Player player)
    {
        foreach (var enemy in enemies)
        {
            if (enemy is not Warrior && enemy is not Slayer && enemy is not Archer)
            {
                throw new ArgumentException("Необходим массив врагов");
            }
        }
        _enemies = enemies;
        _player = player;
    }

    public void Fight()
    {
        var playerAlive = true;
        var enemyAlive = true;
        while (playerAlive && _enemies.Length != 0)
        {
            var rnd = new Random().Next(0, _enemies.Length);
            
            Console.Read();
            var damage = _enemies[rnd].Attack();
            playerAlive = _player.TakeDamage(damage);
            if (!playerAlive) { break;}
            
            var playerDamage = _player.Attack();
            enemyAlive = _enemies[rnd].TakeDamage(playerDamage);
            
            if (enemyAlive is false)
            {
                Console.WriteLine($"{_enemies[rnd]} погиб");
                DeleteEnemyFromEnemies(ref _enemies,rnd);
            }
            Console.Read();
        }

        if (playerAlive == false) { Console.WriteLine("########### Игрок Погиб ############"); }

        if (_enemies.Length == 0){ Console.WriteLine("########### Игрок Победил ############"); }
        
        
    }

    private void DeleteEnemyFromEnemies(ref Unit[] enemies, int index)
    {
        var newArray = new Unit[enemies.Length - 1];
        enemies[index] = null!;
        var temp =  enemies.Where(x => x != null).ToArray();
        Array.Copy(temp,newArray,newArray.Length);
        enemies = newArray;
    }
}

