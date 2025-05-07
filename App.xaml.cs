namespace caca360;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Define o AppShell como a página principal
        MainPage = new AppShell();
    }

    protected override void OnStart()
    {
        base.OnStart();

        // Verifica se o token de autenticação está armazenado
        var token = Preferences.Default.Get("auth_token", string.Empty);

        if (string.IsNullOrEmpty(token))
        {
            // Redireciona para a página de login
            Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
