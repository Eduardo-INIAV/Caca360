using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caca360.Services;

public class AuthService
{
    public string Token { get; private set; } = string.Empty;
    public void SetToken(string token) => Token = token;

    public async Task RegisterUserAsync(string username, string email, string password)
    {
        var authProvider = MauiProgram.ServiceProvider.GetRequiredService<FirebaseAuthProvider>();
        var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password, username, true);

        // Opcional: Salvar informações adicionais no Realtime Database
        var firebaseClient = MauiProgram.ServiceProvider.GetRequiredService<FirebaseClient>();
        await firebaseClient
            .Child("users")
            .Child(auth.User.LocalId)
            .PutAsync(new { Username = username, Email = email });
    }
}
