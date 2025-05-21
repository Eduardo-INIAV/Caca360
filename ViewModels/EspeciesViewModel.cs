using System.Collections.ObjectModel;
using caca360.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace caca360.ViewModels;

public partial class EspeciesViewModel : ObservableObject
{
    public ObservableCollection<Especies> Especies { get; }

    private Especies? _EspeciesSelecionada;

    public Especies? EspeciesSelecionada
    {
        get => _EspeciesSelecionada;
        set
        {
            if (_EspeciesSelecionada != value)
            {
                _EspeciesSelecionada = value;
                if (_EspeciesSelecionada != null)
                {
                    SelecionarEspecies(_EspeciesSelecionada);
                    _EspeciesSelecionada = null;
                    OnPropertyChanged(nameof(EspeciesSelecionada));
                }
            }
        }
    }

    public EspeciesViewModel()
    {
        Especies = new ObservableCollection<Especies>
        {
            new() { Nome = "Aves", Imagem = "rola1.png" },
            new() { Nome = "Mamiferos", Imagem = "rapousa1.png" },
            new() { Nome = "Lagomorfos", Imagem = "coelho1.png" },
            
        };
    }

    private async void SelecionarEspecies(Especies Especies)
    {
        switch (Especies.Nome)
        {
            case "Aves":
                await Shell.Current.GoToAsync(nameof(AvesPage));
                break;
            case "Mamiferos":
                await Shell.Current.GoToAsync(nameof(MamiferosPage));
                break;
            case "Lagomorfos":
                await Shell.Current.GoToAsync(nameof(LagoPage));
                break;

        }
    }
}
