using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Maui.Media;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Storage;
using caca360.Models;
using caca360.Services;

namespace caca360.ViewModels;

public partial class ProfileViewModel : INotifyPropertyChanged
{
    private readonly ProfileService _profileService;
    private readonly string _userId;

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
            if (_huntingLicense != value)
            {
                _huntingLicense = value;
                OnPropertyChanged(nameof(HuntingLicense));
            }
        }
    }

    public ObservableCollection<string> Types { get; } = new ObservableCollection<string> { "Tipo 1", "Tipo 2", "Tipo 3" };
    public string SelectedType
    {
        get => _selectedType;
        set
        {
            if (_selectedType != value)
            {
                _selectedType = value;
                OnPropertyChanged(nameof(SelectedType));
            }
        }
    }

    public ObservableCollection<string> Genders { get; } = new ObservableCollection<string> { "Masculino", "Feminino", "Outro" };
    public string SelectedGender
    {
        get => _selectedGender;
        set
        {
            if (_selectedGender != value)
            {
                _selectedGender = value;
                OnPropertyChanged(nameof(SelectedGender));
            }
        }
    }

    public string Age
    {
        get => _age;
        set
        {
            if (_age != value)
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }
    }

    public ObservableCollection<string> HuntingZoneTypes { get; } = new ObservableCollection<string> { "Zona 1", "Zona 2", "Zona 3" };
    public string SelectedHuntingZoneType
    {
        get => _selectedHuntingZoneType;
        set
        {
            if (_selectedHuntingZoneType != value)
            {
                _selectedHuntingZoneType = value;
                OnPropertyChanged(nameof(SelectedHuntingZoneType));
            }
        }
    }

    public string Number
    {
        get => _number;
        set
        {
            if (_number != value)
            {
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
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
                OnPropertyChanged(nameof(ProfileImagePath));
            }
        }
    }

    // Comandos para a UI
    public ICommand SaveCommand { get; }
    public ICommand RemovePhotoCommand { get; }
    public ICommand PickPhotoCommand { get; }
    public ICommand TakePhotoCommand { get; }


    public ProfileViewModel(ProfileService profileService, string userId)
    {
        _profileService = profileService;
        _userId = userId;

        _profileImagePath = Preferences.Default.Get(nameof(ProfileImagePath), string.Empty);

        SaveCommand = new Command(async () => await SaveProfileAsync());
        RemovePhotoCommand = new Command(RemovePhoto);
        PickPhotoCommand = new Command(async () => await PickPhotoAsync());
        TakePhotoCommand = new Command(async () => await TakePhotoAsync());

        // NÃO carregar perfil aqui no construtor
    }

    public async Task InitializeAsync()
    {
        await LoadProfileAsync();
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
            });
        }
        catch (OperationCanceledException)
        {
            // Utilizador cancelou
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Erro", $"Erro ao tirar a foto: {ex.Message}", "OK");
        }
    }

    public async Task LoadProfileAsync()
    {
        try
        {
            var profile = await _profileService.GetUserProfileAsync(_userId);
            if (profile != null)
            {
                System.Diagnostics.Debug.WriteLine($"Perfil carregado: {profile.HuntingLicense}, {profile.SelectedType}");

                HuntingLicense = profile.HuntingLicense;
                SelectedType = profile.SelectedType;
                SelectedGender = profile.SelectedGender;
                Age = profile.Age;
                SelectedHuntingZoneType = profile.SelectedHuntingZoneType;
                Number = profile.Number;
                ProfileImagePath = profile.ProfileImagePath;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Perfil não encontrado (null).");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Erro ao carregar perfil: {ex.Message}");
            await App.Current.MainPage.DisplayAlert("Erro", $"Erro ao carregar perfil: {ex.Message}", "OK");
        }
    }


    public async Task SaveProfileAsync()
    {
        try
        {
            var profile = new UserProfile
            {
                HuntingLicense = this.HuntingLicense,
                SelectedType = this.SelectedType,
                SelectedGender = this.SelectedGender,
                Age = this.Age,
                SelectedHuntingZoneType = this.SelectedHuntingZoneType,
                Number = this.Number,
                ProfileImagePath = this.ProfileImagePath
            };

            await _profileService.SaveUserProfileAsync(_userId, profile);
            await App.Current.MainPage.DisplayAlert("Sucesso", "Perfil salvo com sucesso!", "OK");
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("Erro", $"Erro ao salvar perfil: {ex.Message}", "OK");
        }
    }

    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
