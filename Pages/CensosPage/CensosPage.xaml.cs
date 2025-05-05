using Microsoft.Maui.Controls;

namespace caca360;

public partial class CensosPage : ContentPage
{
    public CensosPage()
    {
        InitializeComponent();

        var surveyUrl = "https://survey123.arcgis.com/share/EXEMPLO_ID_DO_FORMULARIO";
        CensosWebView.Source = surveyUrl;
    }
}