using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;

namespace caca360.Services;

public class AuthService
{
    public string Token { get; private set; } = string.Empty;

    public void SetToken(string token) => Token = token;

    public async Task<string> LoginAsync(string email, string password)
    {
        var authProvider = MauiProgram.ServiceProvider.GetRequiredService<FirebaseAuthProvider>();
        var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
        Token = auth.FirebaseToken;

        if (string.IsNullOrEmpty(Token))
        {
            throw new Exception("Falha ao obter o token de autenticação.");
        }

        return Token;
    }

    public static async Task RegisterUserAsync(string username, string email, string password)
    {
        var authProvider = MauiProgram.ServiceProvider.GetRequiredService<FirebaseAuthProvider>();
        var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password, username, true);

        // Salvar informações adicionais no Realtime Database
        var firebaseClient = MauiProgram.ServiceProvider.GetRequiredService<FirebaseClient>();
        await firebaseClient
            .Child("users") // Adiciona o nó "users"
            .Child(auth.User.LocalId) // Adiciona o ID único do usuário
            .PutAsync(new { Username = username, Email = email });
    }

}