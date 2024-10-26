using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public class StoredCredentialRepository(MealPlannerContext _dbContext) : IStoredCredentialRepository
{
    
    public List<StoredCredential> GetCredentialsByUser(User user)
    {
        return _dbContext.StoredCredentials.Where(c => c.UserId.SequenceEqual(user.UsernameEncoded)).ToList();
    }
}