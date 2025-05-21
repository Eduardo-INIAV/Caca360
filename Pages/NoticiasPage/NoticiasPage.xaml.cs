namespace caca360;

public partial class NoticiasPage : ContentPage
{
    public NoticiasPage()
    {
        InitializeComponent();

        var noticiasUrl = "https://www.dn.pt/topic/ca%C3%A7a";
        NoticiasWebView.Source = noticiasUrl;
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = true });

    }
}

