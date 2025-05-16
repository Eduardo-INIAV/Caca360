using System.Collections.ObjectModel;
using caca360.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace caca360.ViewModels;

public partial class CategoriasViewModel : ObservableObject
{
    public ObservableCollection<string> Categorias { get; }

    private string? _categoriaSelecionada;

    public string? CategoriaSelecionada
    {
        get => _categoriaSelecionada;
        set
        {
            if (_categoriaSelecionada != value)
            {
                _categoriaSelecionada = value;
                if (_categoriaSelecionada != null)
                {
                    SelecionarCategoria(_categoriaSelecionada);
                    _categoriaSelecionada = null; // permite selecionar novamente
                    OnPropertyChanged(nameof(CategoriaSelecionada)); // necessário se não estiveres a usar [ObservableProperty]
                }
            }
        }
    }

    public CategoriasViewModel()
    {
        Categorias = new ObservableCollection<string>
        {
            "Aves",
            "Cães",
            "Mamíferos",
            "Lagos"
        };
    }

    private async void SelecionarCategoria(string categoria)
    {
        // Exemplo de navegação, ajusta conforme as tuas rotas
        switch (categoria)
        {
            case "Aves":
                await Shell.Current.GoToAsync(nameof(AvesPage));
                break;
            case "Cães":
                await Shell.Current.GoToAsync(nameof(CaesPage));
                break;
            case "Mamíferos":
                await Shell.Current.GoToAsync(nameof(MamiferosPage));
                break;
            case "Lagos":
                await Shell.Current.GoToAsync(nameof(LagoPage));
                break;
        }
    }
}
