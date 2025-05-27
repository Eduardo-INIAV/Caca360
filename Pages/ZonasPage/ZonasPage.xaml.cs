namespace caca360;

public partial class ZonasPage : ContentPage
{
    public ZonasPage()
    {
        InitializeComponent();

        var surveyUrl = "https://portalgeo.iniav.pt/portal/home/webmap/viewer.html?webmap=cc2cc17065014b6baa1c04b5aac0b507";
        MapWebView.Source = surveyUrl;
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