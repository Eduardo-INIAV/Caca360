using caca360.ViewModels;

namespace caca360;

public partial class WeatherPage : ContentPage
{
    private readonly WeatherViewModel _viewModel;

    public WeatherPage()
    {
        InitializeComponent();
        _viewModel = new WeatherViewModel();
        BindingContext = _viewModel;
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

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            await _viewModel.LoadCurrentWeatherAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message + (ex.InnerException != null ? "\nDetalhes: " + ex.InnerException.Message : ""), "OK");
        }
    }

    private void BackButtonBehavior()
    {
        // Faz a navegação para a página desejada
        this.Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//InfosPage");
        });
    }

    protected override bool OnBackButtonPressed()
    {
        Shell.Current.GoToAsync("//InfosPage");
        return true;
    }
}
