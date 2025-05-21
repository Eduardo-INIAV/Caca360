using caca360.ViewModels;
using Microsoft.Maui.ApplicationModel;

namespace caca360;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        SolicitarPermissoesAsync();
    }
    private async void SolicitarPermissoesAsync()
    {
        // Solicita permissão de localização
        var statusLocation = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        // Solicita permissão de câmera
        var statusCamera = await Permissions.RequestAsync<Permissions.Camera>();

        // Você pode exibir mensagens se desejar, dependendo do status retornado
        if (statusLocation != PermissionStatus.Granted)
            await DisplayAlert("Permissão", "Permissão de localização negada.", "OK");
        if (statusCamera != PermissionStatus.Granted)
            await DisplayAlert("Permissão", "Permissão de câmera negada.", "OK");
    }
}
