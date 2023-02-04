using DiApp.models;

namespace DiApp;

public interface IRepository
{
    void Save(User user);
}