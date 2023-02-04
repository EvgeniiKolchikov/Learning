namespace DiApp2;

public class CustomDb : IRepository
{
    public void Save(User user)
    {
        Console.WriteLine($"{user.Name} to Custom DB");
    }
}