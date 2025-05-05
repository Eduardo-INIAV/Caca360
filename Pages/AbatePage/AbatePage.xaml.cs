using Microsoft.Maui.Controls;

namespace caca360;

public partial class AbatePage : ContentPage
{
    public AbatePage()
    {
        InitializeComponent();

        var abateSurveyUrl = "https://survey123.arcgis.com/share/EXEMPLO_ID_FORMULARIO_ABATE";
        AbateSurveyWebView.Source = abateSurveyUrl;
    }
}

