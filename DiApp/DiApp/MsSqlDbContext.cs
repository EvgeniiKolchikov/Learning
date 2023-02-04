using DiApp.models;

namespace DiApp;

public class MsSqlDbContext : IRepository
{
    public void Save(User user)
    {
        Console.WriteLine($"{user.Name} saved to MsSql DB");
    }
}