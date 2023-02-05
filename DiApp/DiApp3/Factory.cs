using System.Diagnostics;

namespace DiApp3;

public static class Factory
{
    public static IRepository SelectDb(int idRepo)
    {
        switch (idRepo)
        {
            case 1 :
                return new PostgresRepository();
            case 2:
                return new SQLiteRepository();
            default:
                throw new Exception("dfds");
        }
    }
}