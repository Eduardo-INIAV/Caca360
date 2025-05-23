namespace caca360;

public partial class TempoPage : ContentPage
{
    public TempoPage()
    {
        InitializeComponent();

        var TempoUrl = "https://www.accuweather.com/pt/pt/oeiras/274023/weather-forecast/274023";
        TempoWebView.Source = TempoUrl;
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });
        var backButton = new ToolbarItem
        {
            IconImageSource = "back_arrow.png",
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
            await Shell.Current.GoToAsync("//InfosPage");
        });
    }


    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//InfosPage");
        return true;
    }

}

