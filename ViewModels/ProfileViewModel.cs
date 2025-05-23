using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Maui.Media;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Storage;

namespace caca360.ViewModels;

public partial class ProfileViewModel : INotifyPropertyChanged
{
    private string _huntingLicense = string.Empty;
    private string _selectedType = string.Empty;
    private string _selectedGender = string.Empty;
    private string _age = string.Empty;
    private string _selectedHuntingZoneType = string.Empty;
    private string _number = string.Empty;
    private string _profileImagePath = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;

    public string HuntingLicense
    {
        get => _huntingLicense;
        set
        {
            _huntingLicense = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HuntingLicense)));
        }
    }

    public ObservableCollection<string> Types { get; } = new ObservableCollection<string> { "Tipo 1", "Tipo 2", "Tipo 3" };
    public string SelectedType
    {
        get => _selectedType;
        set
        {
            _selectedType = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedType)));
        }
    }

    public ObservableCollection<string> Genders { get; } = new ObservableCollection<string> { "Masculino", "Feminino", "Outro" };
    public string SelectedGender
    {
        get => _selectedGender;
        set
        {
            _selectedGender = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedGender)));
        }
    }

    public string Age
    {
        get => _age;
        set
        {
            _age = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Age)));
        }
    }

    public ObservableCollection<string> HuntingZoneTypes { get; } = new ObservableCollection<string> { "Zona 1", "Zona 2", "Zona 3" };
    public string SelectedHuntingZoneType
    {
        get => _selectedHuntingZoneType;
        set
        {
            _selectedHuntingZoneType = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedHuntingZoneType)));
        }
    }

    public string Number
    {
        get => _number;
        set
        {
            _number = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Number)));
        }
    }

    public string ProfileImagePath
    {
        get => _profileImagePath;
        set
        {
            if (_profileImagePath != value)
            {
                _profileImagePath = value;
                Preferences.Default.Set(nameof(ProfileImagePath), value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProfileImagePath)));
            }
        }
    }

    // Comandos para o UI
    public ICommand SaveCommand { get; }
    public ICommand RemovePhotoCommand { get; }
    public ICommand PickPhotoCommand { get; }
    public ICommand TakePhotoCommand { get; }

    public ProfileViewModel()
    {
        _profileImagePath = Preferences.Default.Get(nameof(ProfileImagePath), string.Empty);

        SaveCommand = new Command(async () => await SaveProfile());
        RemovePhotoCommand = new Command(RemovePhoto);
        PickPhotoCommand = new Command(async () => await PickPhotoAsync());
        TakePhotoCommand = new Command(async () => await TakePhotoAsync());
    }

    private void RemovePhoto()
    {
        ProfileImagePath = string.Empty;
    }

    private async Task PickPhotoAsync()
    {
        try
        {
            var photo = await MediaPicker.PickPhotoAsync();

            if (photo != null)
            {
                var newPath = Path.Combine(FileSystem.AppDataDirectory, Path.GetFileName(photo.FullPath));
                File.Copy(photo.FullPath, newPath, true);
                ProfileImagePath = newPath;
            }
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Erro", $"Erro ao escolher a foto: {ex.Message}", "OK");
        }
    }

    public async Task TakePhotoAsync()
    {
        try
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                var photo = await MediaPicker.CapturePhotoAsync();

                if (photo != null)
                {
                    var newPath = Path.Combine(FileSystem.AppDataDirectory, Path.GetFileName(photo.FullPath));
                    File.Copy(photo.FullPath, newPath, true);
                    ProfileImagePath = newPath;
                }
                else
                {
                    Console.WriteLine("Foto cancelada.");
                }
            });
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Operação cancelada pelo utilizador.");
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Erro", $"Erro ao tirar a foto: {ex.Message}", "OK");
        }
    }

    private async Task SaveProfile()
    {
        // Aqui colocas o teu código para salvar no Firebase ou outro serviço
        await App.Current.MainPage.DisplayAlert("Sucesso", "Perfil salvo com sucesso!", "OK");
    }
}
