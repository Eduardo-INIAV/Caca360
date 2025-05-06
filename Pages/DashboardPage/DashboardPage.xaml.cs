using Microsoft.Maui.Controls;

namespace caca360;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();

        var surveyUrl = "https://portalgeo.iniav.pt/portal/apps/opsdashboard/index.html#/90bec55361f245a4bf2d238159e1b7fd";
        ArcGisWebView.Source = surveyUrl;
    }
}