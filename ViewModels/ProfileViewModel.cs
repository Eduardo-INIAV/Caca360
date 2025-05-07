using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace caca360.ViewModels;

public class ProfileViewModel : INotifyPropertyChanged
{
    private string _huntingLicense = string.Empty;
    private string _selectedType = string.Empty;
    private string _selectedGender = string.Empty;
    private string _age = string.Empty;
    private string _selectedHuntingZoneType = string.Empty;
    private string _number = string.Empty;

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

    public ICommand SaveCommand { get; }

    public ProfileViewModel()
    {
        SaveCommand = new Command(SaveProfile);
    }

    private async void SaveProfile()
    {
        // Salvar as informações no Firebase ou outro serviço
        await App.Current.MainPage.DisplayAlert("Sucesso", "Perfil salvo com sucesso!", "OK");
    }
}