namespace caca360;

public partial class CensosPage : ContentPage
{
    public CensosPage()
    {
        InitializeComponent();

        var surveyUrl = "https://survey123.arcgis.com/share/ff5a4ae4566444af9ec40943d89a3692?portalUrl=https://portalgeo.iniav.pt/portal";
        CensosWebView.Source = surveyUrl;

        var backButton = new ToolbarItem
        {
            Text="Voltar",
            Priority = 0,
            Order = ToolbarItemOrder.Primary,
            Command = new Command(() =>
            {
                BackButtonBehavior();
            })
        };
        ToolbarItems.Add(backButton);
    }

    private void BackButtonBehavior()
    {
        // Faz a navegação para a página desejada
        this.Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//MainPage");
        });
    
        
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//MainPage");
        return true;
    }
}