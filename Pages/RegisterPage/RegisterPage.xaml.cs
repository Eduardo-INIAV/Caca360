using caca360.ViewModels;

namespace caca360;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });
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

