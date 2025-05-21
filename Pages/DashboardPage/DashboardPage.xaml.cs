namespace caca360;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();

        var surveyUrl = "https://portalgeo.iniav.pt/portal/apps/opsdashboard/index.html#/0bbdae73f4184da5b88fe55d65b0394e";
        ArcGisWebView.Source = surveyUrl;

        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = true });
    }


    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//MainPage");
        return true;
    }
}