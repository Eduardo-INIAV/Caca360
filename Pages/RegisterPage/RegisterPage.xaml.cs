using caca360.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace caca360;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = true });
        var backButton = new ToolbarItem
        {
            Text = "Voltar",
            Priority = 0,
            Order = ToolbarItemOrder.Primary,
            Command = new Command(() =>
            {
                BackButtonBehavior();
            })
        };
    ToolbarItems.Add(backButton);
    }

    private void BackButtonBehavior()
    {
        // Faz a navegação para a página desejada
        this.Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//LoginPage");
        });

    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//LoginPage");
        return true;
    }

}

