using Microsoft.Maui.Controls;

namespace caca360;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();

        var surveyUrl = "https://survey123.arcgis.com/share/EXEMPLO_ID_DO_FORMULARIO";
        ArcGisWebView.Source = surveyUrl;
    }
}