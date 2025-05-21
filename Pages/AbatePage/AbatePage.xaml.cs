namespace caca360;

public partial class AbatePage : ContentPage
{
    public AbatePage()
    {
        InitializeComponent();

        var abateSurveyUrl = "https://survey123.arcgis.com/share/70158155a7a54469a872cfdf63933f19?portalUrl=https://portalgeo.iniav.pt/portal";
        AbateSurveyWebView.Source = abateSurveyUrl;
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//MainPage");
        return true;
    }
}

