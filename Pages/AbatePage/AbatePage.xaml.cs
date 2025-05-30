namespace caca360;

public partial class AbatePage : ContentPage
{
    public AbatePage()
    {
        InitializeComponent();

        var abateSurveyUrl = "https://survey123.arcgis.com/share/70158155a7a54469a872cfdf63933f19?portalUrl=https://portalgeo.iniav.pt/portal";
        AbateSurveyWebView.Source = abateSurveyUrl;

        var backButton = new ToolbarItem
        {
            Text = "Voltar",
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

