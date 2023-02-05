namespace DiApp3;

public class SQLiteRepository : IRepository
{
    public void Save(Player player)
    {
        Console.WriteLine($"SQLite {player.Age}");
    }
}