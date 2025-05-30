namespace caca360;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();

        var surveyUrl = "https://portalgeo.iniav.pt/portal/apps/opsdashboard/index.html#/0bbdae73f4184da5b88fe55d65b0394e";
        ArcGisWebView.Source = surveyUrl;

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