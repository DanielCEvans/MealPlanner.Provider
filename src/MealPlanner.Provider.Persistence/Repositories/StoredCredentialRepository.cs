using MealPlanner.Provider.Persistence.Models;
using Fido2NetLib.Objects;

namespace MealPlanner.Provider.Persistence.Repositories;

public class StoredCredentialRepository(MealPlannerContext _dbContext) : IStoredCredentialRepository
{
    
    public List<StoredCredential> GetCredentialsByUser(User user)
    {
        var credentials = _dbContext.StoredCredentials.Where(c => c.Fido2Id.SequenceEqual(user.Fido2Id)).ToList();
        return credentials;
    }

    public void AddCredentialToUser(User user, StoredCredential credential)
    {
        // Is this correct?!?!
        credential.Fido2Id = user.Fido2Id;
        
        _dbContext.StoredCredentials.Add(credential);
        _dbContext.SaveChanges();
    }
    
    public Task<List<User>> GetUsersByCredentialIdAsync(byte[] credentialId, CancellationToken cancellationToken = default)
    {
        // our in-mem storage does not allow storing multiple users for a given credentialId. Yours shouldn't either.
        var cred = _dbContext.StoredCredentials.FirstOrDefault(c => c.Id.SequenceEqual(credentialId));

        if (cred is null)
            return Task.FromResult(new List<User>());

        return Task.FromResult(_dbContext.Users.Where(u => u.Fido2Id.SequenceEqual(cred.Fido2Id)).Select(u => u).ToList());
    }
    
}