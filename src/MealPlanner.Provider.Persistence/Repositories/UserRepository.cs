using MealPlanner.Provider.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.Provider.Persistence.Repositories;

public class UserRepository(MealPlannerContext _dbContext) : IUserRepository
{
    public User GetOrAddUser(string username, Func<User> addCallback)
    {
        // Attempt to retrieve the user from the database
        var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);

        // If the user is found, return it
        if (user != null)
        {
            return user;
        }

        // If not found, create a new user using the callback
        user = addCallback();
    
        // Add the new user to the database and save changes
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        return user;
    }
}