using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Extensions.DependencyInjection;

namespace caca360.Services;

public class AuthService
{
    private FirebaseAuth? _auth;

    public string Token => _auth?.FirebaseToken ?? string.Empty;
    public string UserId => _auth?.User?.LocalId ?? string.Empty;

    public async Task LoginAsync(string email, string password)
    {
        var authProvider = MauiProgram.ServiceProvider.GetRequiredService<FirebaseAuthProvider>();
        _auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);

        if (_auth == null || string.IsNullOrEmpty(_auth.FirebaseToken))
        {
            throw new Exception("Falha ao obter o token de autenticação.");
        }
    }

    public static async Task RegisterUserAsync(string username, string email, string password)
    {
        var authProvider = MauiProgram.ServiceProvider.GetRequiredService<FirebaseAuthProvider>();
        var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password, username, true);

        var firebaseClient = MauiProgram.ServiceProvider.GetRequiredService<FirebaseClient>();
        await firebaseClient
            .Child("users")
            .Child(auth.User.LocalId)
            .PutAsync(new { Username = username, Email = email });
    }
}
