namespace DiApp;

public class Factory
{
    public IRepository CreateDBContext(int id)
    {
        switch (id)
        {
            case 1:
                return new PostgresDbContext();
            case 2:
                return new MsSqlDbContext();
            default:
                throw new Exception("Fail");
        }
    }
}