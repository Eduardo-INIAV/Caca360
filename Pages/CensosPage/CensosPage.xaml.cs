namespace caca360;

public partial class CensosPage : ContentPage
{
    public CensosPage()
    {
        InitializeComponent();

        var surveyUrl = "https://survey123.arcgis.com/share/3b6f0a96eb7444229ad7d84aec8b6e49?portalUrl=https://portalgeo.iniav.pt/portal";
        CensosWebView.Source = surveyUrl;
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = true });
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//MainPage");
        return true;
    }
}