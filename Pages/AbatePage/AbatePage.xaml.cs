namespace caca360;

public partial class AbatePage : ContentPage
{
    public AbatePage()
    {
        InitializeComponent();

        var abateSurveyUrl = "https://portalgeo.iniav.pt/portal/sharing/rest/oauth2/authorize?client_id=survey123hub&response_type=token&expiration=20160&redirect_uri=https%3A%2F%2Fsurvey123.arcgis.com%2Fshare%2F70158155a7a54469a872cfdf63933f19%3FportalUrl%3Dhttps%3A%2F%2Fportalgeo.iniav.pt%2Fportal&resourceItemId=70158155a7a54469a872cfdf63933f19&canHandleCrossOrgSignIn=true";
        AbateSurveyWebView.Source = abateSurveyUrl;
    }
}

