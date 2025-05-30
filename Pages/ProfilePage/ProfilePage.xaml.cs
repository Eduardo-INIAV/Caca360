<<<<<<< HEAD
﻿using caca360.Services;
using caca360.ViewModels;
=======
﻿using caca360.ViewModels;
>>>>>>> parent of c0511f0 (update)

namespace caca360;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
<<<<<<< HEAD

        var profileService = MauiProgram.ServiceProvider.GetRequiredService<ProfileService>();
        var authService = MauiProgram.ServiceProvider.GetRequiredService<AuthService>();

        _viewModel = new ProfileViewModel(profileService, authService);
        BindingContext = _viewModel;

=======
        BindingContext = new ProfileViewModel();
>>>>>>> parent of c0511f0 (update)
        var backButton = new ToolbarItem
        {
            IconImageSource = "back_arrow.png",
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
            await Shell.Current.GoToAsync("//MainPage");
        });
    
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//MainPage");
        return true;
    }
}