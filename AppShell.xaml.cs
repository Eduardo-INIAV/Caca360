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
        Routing.RegisterRoute(nameof(AnimalPage), typeof(AnimalPage));
        Routing.RegisterRoute(nameof(CaesPage), typeof(CaesPage));
        Routing.RegisterRoute(nameof(AvesPage), typeof(AvesPage));
        Routing.RegisterRoute(nameof(MamiferosPage), typeof(MamiferosPage));
        Routing.RegisterRoute(nameof(LagoPage), typeof(LagoPage));
        Routing.RegisterRoute(nameof(EspeciesPage), typeof(EspeciesPage));
        Routing.RegisterRoute(nameof(ArmasPage), typeof(ArmasPage));
        Routing.RegisterRoute(nameof(NoticiasPage), typeof(NoticiasPage));
        Routing.RegisterRoute(nameof(DescPage), typeof(DescPage));
        Routing.RegisterRoute(nameof(WeatherPage), typeof(WeatherPage));


    }

}
