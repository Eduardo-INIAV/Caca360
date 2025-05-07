namespace caca360;

public partial class ZonasPage : ContentPage
{
    public ZonasPage()
    {
        InitializeComponent();

        var surveyUrl = "https://portalgeo.iniav.pt/portal/home/webmap/viewer.html?webmap=cc2cc17065014b6baa1c04b5aac0b507";
        MapWebView.Source = surveyUrl;
    }
}