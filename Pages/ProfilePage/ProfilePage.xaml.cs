using caca360.Services; // para ProfileService
using caca360.ViewModels;

namespace caca360;

public partial class ProfilePage : ContentPage
{
    private readonly ProfileViewModel _viewModel;

    public ProfilePage()
    {
        InitializeComponent();

        var profileService = MauiProgram.ServiceProvider.GetRequiredService<ProfileService>();
        var authService = MauiProgram.ServiceProvider.GetRequiredService<AuthService>();
        var userId = authService.UserId;

        _viewModel = new ProfileViewModel(profileService, authService);
        BindingContext = _viewModel;

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

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ProfileViewModel vm)
        {
            await vm.InitializeAsync();
        }
    }

    private void BackButtonBehavior()
    {
        this.Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//MainPage");
        });
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//MainPage");
        return true;
    }
}
