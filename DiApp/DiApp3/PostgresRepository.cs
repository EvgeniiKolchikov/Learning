namespace DiApp3;

public class PostgresRepository : IRepository
{
    public void Save(Player player)
    {
        Console.WriteLine($"Postgres {player.Age}");
    }
}