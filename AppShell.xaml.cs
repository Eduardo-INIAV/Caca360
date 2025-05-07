namespace caca360;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(CensosPage), typeof(CensosPage));
        Routing.RegisterRoute(nameof(DashboardPage), typeof(DashboardPage));
        Routing.RegisterRoute(nameof(AbatePage), typeof(AbatePage));
        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(ZonasPage), typeof(ZonasPage));
        Routing.RegisterRoute(nameof(InfosPage), typeof(InfosPage));
    }

    protected override bool OnBackButtonPressed()
    {
        // Navega para a MainPage
        Shell.Current.GoToAsync("//MainPage");
        return true; // Impede o comportamento padrão do botão "back"
    }


}
