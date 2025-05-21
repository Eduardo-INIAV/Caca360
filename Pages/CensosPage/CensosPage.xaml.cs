namespace caca360;

public partial class CensosPage : ContentPage
{
    public CensosPage()
    {
        InitializeComponent();

        var surveyUrl = "https://survey123.arcgis.com/share/ff5a4ae4566444af9ec40943d89a3692?portalUrl=https://portalgeo.iniav.pt/portal";
        CensosWebView.Source = surveyUrl;
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = true });
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//MainPage");
        return true;
    }
}