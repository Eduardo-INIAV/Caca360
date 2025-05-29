using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using caca360.Services;

namespace caca360.ViewModels
{
    public partial class RegisterViewModel : INotifyPropertyChanged
    {
        private readonly AuthService _authService;

        private string _username = string.Empty;
        private string _email = string.Empty;
        private string _password = string.Empty;
        private string _age = string.Empty;
        private string _selectedGender = string.Empty;
        private string _huntingLicense = string.Empty;
        private string _nif = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Username
        {
            get => _username;
            set { if (_username != value) { _username = value; OnPropertyChanged(nameof(Username)); } }
        }

        public string Email
        {
            get => _email;
            set { if (_email != value) { _email = value; OnPropertyChanged(nameof(Email)); } }
        }

        public string Password
        {
            get => _password;
            set { if (_password != value) { _password = value; OnPropertyChanged(nameof(Password)); } }
        }

        public string Age
        {
            get => _age;
            set { if (_age != value) { _age = value; OnPropertyChanged(nameof(Age)); } }
        }

        public string SelectedGender
        {
            get => _selectedGender;
            set { if (_selectedGender != value) { _selectedGender = value; OnPropertyChanged(nameof(SelectedGender)); } }
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

        public ObservableCollection<string> Genders { get; } = new ObservableCollection<string> { "Masculino", "Feminino", "Outro" };

        public ICommand RegisterCommand { get; }

        public RegisterViewModel(AuthService authService)
        {
            _authService = authService;
            RegisterCommand = new Command(async () => await RegisterAsync());
        }

        private async Task RegisterAsync()
        {
            try
            {
                await _authService.RegisterUserAsync(
                    Username,
                    Email,
                    Password,
                    Age,
                    SelectedGender,
                    HuntingLicense,
                    NIF,
                    string.Empty // Não envia foto de perfil no registo
                );

                await App.Current.MainPage.DisplayAlert("Sucesso", "Registo efetuado com sucesso!", "OK");
                await Shell.Current.GoToAsync("//LoginPage");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", $"Erro ao registar: {ex.Message}", "OK");
            }
        }

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}