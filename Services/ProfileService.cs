using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using caca360.Models;

namespace caca360.Services;

public class ProfileService(FirebaseClient firebaseClient)
{
    private readonly FirebaseClient _firebaseClient = firebaseClient;

    public async Task<UserProfile?> GetUserProfileAsync(string userId)
    {
        try
        {
            return await _firebaseClient
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
        await _firebaseClient
            .Child("users")
            .Child(userId)
            .Child("profile") // Guardar dentro de "profile"
            .PutAsync(profile);
    }
}
