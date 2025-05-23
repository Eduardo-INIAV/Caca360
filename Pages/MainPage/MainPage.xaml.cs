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
        var statusLocation = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        var statusCamera = await Permissions.RequestAsync<Permissions.Camera>();

        PermissionStatus statusMedia = PermissionStatus.Granted;
        PermissionStatus statusStorage = PermissionStatus.Granted;

        // Android 13 ou superior: READ_MEDIA_IMAGES
        if (DeviceInfo.Platform == DevicePlatform.Android && DeviceInfo.Version.Major >= 13)
        {
            statusMedia = await Permissions.RequestAsync<Permissions.Photos>();
        }
        else // Android 12 ou inferior: READ_EXTERNAL_STORAGE
        {
            statusStorage = await Permissions.RequestAsync<Permissions.StorageRead>();
        }

        if (statusLocation != PermissionStatus.Granted)
            await DisplayAlert("Permissão", "Permissão de localização negada.", "OK");

        if (statusCamera != PermissionStatus.Granted)
            await DisplayAlert("Permissão", "Permissão de câmera negada.", "OK");

        if (DeviceInfo.Version.Major >= 13 && statusMedia != PermissionStatus.Granted)
            await DisplayAlert("Permissão", "Permissão de fotos (galeria) negada.", "OK");

        if (DeviceInfo.Version.Major < 13 && statusStorage != PermissionStatus.Granted)
            await DisplayAlert("Permissão", "Permissão de armazenamento negada.", "OK");
    }

}
