

namespace DiApp2;

public class Factory
{
    private IRepository _repository;
    
    public void Save(User user, int id)
    {
        switch (id)
        {
            case 1:
                _repository = new PostgresDbContext();
                break;
            case 2:
                _repository = new MsSqlDbContext();
                break;
            default:
                throw new Exception("Fail");
        }
        _repository.Save(user);
    }

    public void Save(IRepository repository, User user)
    {
        repository.Save(user);
    }
    
    
}