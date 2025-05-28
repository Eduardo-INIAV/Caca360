using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using caca360.Models;

namespace caca360.Services;

public class ProfileService
{
    private readonly Func<FirebaseClient> _firebaseClientFactory;

    public ProfileService(Func<FirebaseClient> firebaseClientFactory)
    {
        _firebaseClientFactory = firebaseClientFactory;
    }

    public async Task<UserProfile?> GetUserProfileAsync(string userId)
    {
        try
        {
            var client = _firebaseClientFactory();
            return await client
                .Child("users")
                .Child(userId)
                .OnceSingleAsync<UserProfile>();
        }
        catch
        {
            return null;
        }
    }

    public async Task SaveUserProfileAsync(string userId, UserProfile profile)
    {
        var client = _firebaseClientFactory();
        await client
            .Child("users")
            .Child(userId)
            .PutAsync(profile);
    }
}

