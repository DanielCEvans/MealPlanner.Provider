using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public interface IUserRepository
{
    public User GetOrAddUser(string username, Func<User> addCallback);
}