using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public interface IStoredCredential
{
    public List<StoredCredential> GetCredentialsByUser(User user);
}