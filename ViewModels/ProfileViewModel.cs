using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using caca360.Models;
using caca360.Services;

namespace caca360.ViewModels
{
    public partial class ProfileViewModel : INotifyPropertyChanged
    {
        private readonly ProfileService _profileService;
        private readonly AuthService _authService;

        private string _username = string.Empty;
        private string _email = string.Empty;
        private string _selectedGender = string.Empty;
        private string _age = string.Empty;
        private string _huntingLicense = string.Empty;
        private string _nif = string.Empty;
        private string _profileImagePath = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Username
        {
            get => _username;
            set { if (_username != value) { _username = value; OnPropertyChanged(nameof(Username)); } }
        }

        public string Email
        {
            get => _email;
            private set { if (_email != value) { _email = value; OnPropertyChanged(nameof(Email)); } }
        }

        public ObservableCollection<string> Genders { get; } = new() { "Masculino", "Feminino", "Outro" };

        public string SelectedGender
        {
            get => _selectedGender;
            set { if (_selectedGender != value) { _selectedGender = value; OnPropertyChanged(nameof(SelectedGender)); } }
        }

        public string Age
        {
            get => _age;
            set { if (_age != value) { _age = value; OnPropertyChanged(nameof(Age)); } }
        }

        public string HuntingLicense
        {
            get => _huntingLicense;
            set { if (_huntingLicense != value) { _huntingLicense = value; OnPropertyChanged(nameof(HuntingLicense)); } }
        }

        public string NIF
        {
            get => _nif;
            set { if (_nif != value) { _nif = value; OnPropertyChanged(nameof(NIF)); } }
        }

        public string ProfileImagePath
        {
            get => _profileImagePath;
            set
            {
                if (_profileImagePath != value)
                {
                    _profileImagePath = value;
                    OnPropertyChanged(nameof(ProfileImagePath));
                }
            }
        }

        // Comandos
        public ICommand SaveCommand { get; }
        public ICommand RemovePhotoCommand { get; }
        public ICommand PickPhotoCommand { get; }
        public ICommand TakePhotoCommand { get; }

        public ProfileViewModel(ProfileService profileService, AuthService authService)
        {
            _profileService = profileService;
            _authService = authService;

            SaveCommand = new Command(async () => await SaveProfileAsync());
            RemovePhotoCommand = new Command(RemovePhoto);
            PickPhotoCommand = new Command(async () => await PickPhotoAsync());
            TakePhotoCommand = new Command(async () => await TakePhotoAsync());
        }

        public async Task InitializeAsync()
        {
            await LoadProfileAsync();

            if (!string.IsNullOrEmpty(ProfileImagePath) && !File.Exists(ProfileImagePath))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Imagem não encontrada",
                    "A imagem de perfil não foi encontrada neste dispositivo. Por favor, selecione ou tire uma nova foto.",
                    "OK"
                );
                await PickPhotoAsync(); // Ou TakePhotoAsync, conforme preferir
            }
        }

        private void RemovePhoto()
        {
            ProfileImagePath = string.Empty;
        }

        private async Task PickPhotoAsync()
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Selecione uma nova foto de perfil"
            });

            if (result != null)
            {
                var newFile = Path.Combine(FileSystem.AppDataDirectory, result.FileName);
                using (var stream = await result.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                ProfileImagePath = newFile;
                OnPropertyChanged(nameof(ProfileImagePath));

                // Atualize o perfil no banco de dados
                await SaveProfileAsync();
            }
        }

        private async Task TakePhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                if (photo != null)
                {
                    var newPath = Path.Combine(FileSystem.AppDataDirectory, Path.GetFileName(photo.FullPath));
                    File.Copy(photo.FullPath, newPath, true);
                    ProfileImagePath = newPath;
                    OnPropertyChanged(nameof(ProfileImagePath));
                    await SaveProfileAsync();
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", $"Erro ao tirar a foto: {ex.Message}", "OK");
            }
        }

        public async Task LoadProfileAsync()
        {
            var userId = _authService.UserId;
            await App.Current.MainPage.DisplayAlert("Debug", $"userId: {userId}", "OK");

            if (string.IsNullOrEmpty(userId))
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Utilizador não autenticado.", "OK");
                return;
            }

            try
            {
                var profile = await _profileService.GetUserProfileAsync(userId);
                if (profile != null)
                {
                    Username = profile.Username;
                    Email = profile.Email;
                    SelectedGender = profile.SelectedGender;
                    Age = profile.Age;
                    HuntingLicense = profile.HuntingLicense;
                    NIF = profile.NIF;
                    ProfileImagePath = profile.ProfileImagePath;
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Aviso", "Perfil não encontrado.", "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", $"Erro ao carregar perfil: {ex.Message}", "OK");
            }
        }

        public async Task SaveProfileAsync()
        {
            try
            {
                var userId = _authService.UserId;
                var profile = new UserProfile
                {
                    Username = Username,
                    Email = Email,
                    SelectedGender = SelectedGender,
                    Age = Age,
                    HuntingLicense = HuntingLicense,
                    NIF = NIF,
                    ProfileImagePath = ProfileImagePath // Use a propriedade do ViewModel!
                };

                await _profileService.SaveUserProfileAsync(userId, profile);
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
}
