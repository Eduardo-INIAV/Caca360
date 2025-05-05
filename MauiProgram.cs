// Projeto base MAUI para "Caça 360º"
using Firebase.Database;
using Firebase.Auth;
using caca360.Services;

namespace caca360;

public static class MauiProgram
{
    public static IServiceProvider ServiceProvider { get; private set; }

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Configuração do Firebase
        var firebaseConfig = new FirebaseConfig("SUA_API_KEY");
        var firebaseAuthProvider = new FirebaseAuthProvider(firebaseConfig);
        var firebaseClient = new FirebaseClient(
            "SUA_URL_DO_FIREBASE",
            new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult("SEU_TOKEN_DE_AUTENTICAÇÃO")
            });

        // Registrar no DI
        builder.Services.AddSingleton(firebaseAuthProvider);
        builder.Services.AddSingleton(firebaseClient);

        // Serviços
        builder.Services.AddSingleton<ApiService>();
        builder.Services.AddSingleton<AuthService>();

        // ViewModels
        builder.Services.AddTransient<LoginViewModel>();

        // Páginas
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<AbatePage>();
        builder.Services.AddTransient<CensosPage>();



        var app = builder.Build();
        ServiceProvider = app.Services;
        return app;
    }

}
