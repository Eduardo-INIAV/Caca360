using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Microsoft.Extensions.DependencyInjection;
using caca360.Models;


namespace caca360.Services;

public class AuthService
{
    private readonly FirebaseAuthProvider _authProvider;
    private FirebaseAuth? _auth;

    public AuthService(FirebaseAuthProvider authProvider)
    {
        _authProvider = authProvider;
    }

    public string Token => _auth?.FirebaseToken ?? string.Empty;
    public string UserId => _auth?.User?.LocalId ?? string.Empty;

    public async Task LoginAsync(string email, string password)
    {
        _auth = await _authProvider.SignInWithEmailAndPasswordAsync(email, password);

        if (_auth == null || string.IsNullOrEmpty(_auth.FirebaseToken))
        {
            throw new Exception("Falha ao obter o token de autenticação.");
        }

        await SecureStorage.SetAsync("auth_token", _auth.FirebaseToken);
    }

    public async Task RegisterUserAsync(string username, string email, string password, string idade, string genero, string numeroCacador, string nif, string fotoPerfil)
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

        await firebaseClient
            .Child("users")
            .Child(auth.User.LocalId)
            .PutAsync(userProfile);
    }
}




