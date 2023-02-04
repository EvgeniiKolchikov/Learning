using DiApp.models;

namespace DiApp;

public class PostgresDbContext : IRepository
{
    public void Save(User user)
    {
        Console.WriteLine($"{user.Name} saved to Postgres DB");
    }
}