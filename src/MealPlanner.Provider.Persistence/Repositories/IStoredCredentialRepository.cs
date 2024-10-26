using MealPlanner.Provider.Persistence.Models;

namespace MealPlanner.Provider.Persistence.Repositories;

public interface IStoredCredentialRepository
{
    public List<StoredCredential> GetCredentialsByUser(User user);

    public void AddCredentialToUser(User user, StoredCredential credential);

    public Task<List<User>> GetUsersByCredentialIdAsync(byte[] credentialId,
        CancellationToken cancellationToken = default);
}