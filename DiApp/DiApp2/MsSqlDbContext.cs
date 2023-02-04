

namespace DiApp2;

public class MsSqlDbContext : IRepository
{
    public void Save(User user)
    {
        Console.WriteLine($"{user.Name} saved to MsSql DB");
    }
}