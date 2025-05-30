using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
<<<<<<< HEAD
using Microsoft.Extensions.DependencyInjection;
using caca360.Models;

=======
>>>>>>> parent of c0511f0 (update)

namespace caca360.Services;

public class AuthService
{
<<<<<<< HEAD
    private readonly FirebaseAuthProvider _authProvider;
    private FirebaseAuth? _auth;

    public AuthService(FirebaseAuthProvider authProvider)
    {
        _authProvider = authProvider;
    }

    public string Token => _auth?.FirebaseToken ?? string.Empty;
    public string UserId => _auth?.User?.LocalId ?? string.Empty;
=======
    public string Token { get; private set; } = string.Empty;

    public void SetToken(string token) => Token = token;
>>>>>>> parent of c0511f0 (update)

    public async Task<string> LoginAsync(string email, string password)
    {
<<<<<<< HEAD
        _auth = await _authProvider.SignInWithEmailAndPasswordAsync(email, password);
=======
        var authProvider = MauiProgram.ServiceProvider.GetRequiredService<FirebaseAuthProvider>();
        var auth = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
        Token = auth.FirebaseToken;
>>>>>>> parent of c0511f0 (update)

        if (string.IsNullOrEmpty(Token))
        {
            throw new Exception("Falha ao obter o token de autenticação.");
        }

        return Token;
    }

    public async Task<FirebaseAuthLink> RegisterUserAsync(string username, string email, string password, string idade, string genero, string numeroCacador, string nif, string fotoPerfil)
    {
        var auth = await _authProvider.CreateUserWithEmailAndPasswordAsync(email, password, username, true);
        // Crie um novo FirebaseClient com o token do utilizador autenticado
        var firebaseClient = new FirebaseClient(
            "https://caca360-app-default-rtdb.europe-west1.firebasedatabase.app/",
            new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(auth.FirebaseToken)
            });

        var userProfile = new UserProfile
        {
            Username = username,
            Email = email,
            Age = idade,
            SelectedGender = genero,
            HuntingLicense = numeroCacador,
            NIF = nif,
            ProfileImagePath = fotoPerfil
        };

<<<<<<< HEAD
        await firebaseClient
            .Child("users")
            .Child(auth.User.LocalId)
            .PutAsync(userProfile);
        return auth;
=======
        // Salvar informações adicionais no Realtime Database
        var firebaseClient = MauiProgram.ServiceProvider.GetRequiredService<FirebaseClient>();
        await firebaseClient
            .Child("users") // Adiciona o nó "users"
            .Child(auth.User.LocalId) // Adiciona o ID único do usuário
            .PutAsync(new { Username = username, Email = email });
>>>>>>> parent of c0511f0 (update)
    }

}