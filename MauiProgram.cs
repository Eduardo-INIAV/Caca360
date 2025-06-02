// Projeto base MAUI para "Caça 360"
using Firebase.Database;
using Firebase.Auth;
using caca360.Services;
using caca360.ViewModels;
using CommunityToolkit.Maui;

namespace caca360;
public static class MauiProgram
{
    public static IServiceProvider? ServiceProvider { get; private set; }



    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Serviços
        builder.Services.AddSingleton<AuthService>();
        builder.Services.AddSingleton<LocationService>();
        builder.Services.AddSingleton<WeatherService>();
        builder.Services.AddSingleton<FirebaseAuthProvider>(s =>
             new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAcl1PATG5MD_bL3E3He5AjAUJrrscnMoU")));
        builder.Services.AddSingleton<ProfileService>(s =>
        {
            var authService = s.GetRequiredService<AuthService>();
            return new ProfileService(() =>
                new FirebaseClient(
                    "https://caca360-app-default-rtdb.europe-west1.firebasedatabase.app/",
                    new FirebaseOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(authService.Token)
                    }));
        });


        // ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<CategoriasViewModel>();
        builder.Services.AddTransient<MamiferosViewModel>();
        builder.Services.AddTransient<CaesViewModel>();
        builder.Services.AddTransient<AvesViewModel>();
        builder.Services.AddTransient<LagoViewModel>();
        builder.Services.AddTransient<EspeciesViewModel>();
        builder.Services.AddTransient<ArmasViewModel>();
        builder.Services.AddTransient<NoticiasViewModel>();
        builder.Services.AddTransient<WeatherViewModel>();
        builder.Services.AddTransient<UnguladosViewModel>();

        // Páginas
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<AbatePage>();
        builder.Services.AddTransient<CensosPage>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<ZonasPage>();
        builder.Services.AddTransient<InfosPage>();
        builder.Services.AddTransient<AnimalPage>();
        builder.Services.AddTransient<AvesPage>();
        builder.Services.AddTransient<MamiferosPage>();
        builder.Services.AddTransient<CaesPage>();
        builder.Services.AddTransient<LagoPage>();
        builder.Services.AddTransient<EspeciesPage>();
        builder.Services.AddTransient<ArmasPage>();
        builder.Services.AddTransient<NoticiasPage>();
        builder.Services.AddTransient<WeatherPage>();
        builder.Services.AddTransient<DescPage>();
        builder.Services.AddTransient<UnguladosPage>();

        var app = builder.Build();
        ServiceProvider = app.Services;
        return app;
    }

}
