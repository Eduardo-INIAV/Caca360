namespace caca360;

public partial class TempoPage : ContentPage
{
    public TempoPage()
    {
        InitializeComponent();

        var TempoUrl = "https://www.accuweather.com/pt/pt/oeiras/274023/weather-forecast/274023";
        TempoWebView.Source = TempoUrl;
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = true });

    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//CategoriaPage");
        return true;
    }

}

