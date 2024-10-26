using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public interface IStoredCredentialRepository
{
    public List<StoredCredential> GetCredentialsByUser(User user);
}