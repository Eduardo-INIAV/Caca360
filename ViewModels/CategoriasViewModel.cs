using System.Collections.ObjectModel;
using caca360.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace caca360.ViewModels;

public partial class CategoriasViewModel : ObservableObject
{
    public ObservableCollection<Categoria> Categorias { get; }

    private Categoria? _categoriaSelecionada;

    public Categoria? CategoriaSelecionada
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
                    _categoriaSelecionada = null;
                    OnPropertyChanged(nameof(CategoriaSelecionada));
                }
            }
        }
    }

    public CategoriasViewModel()
    {
        Categorias = new ObservableCollection<Categoria>
        {
            new() { Nome = "Espécies Cinegéticas", Imagem = "todos.png" },
            new() { Nome = "Cães", Imagem = "caes1.png" },
            new() { Nome = "Armas", Imagem = "cacadeira1.png" },
            new() { Nome = "Noticias", Imagem = "noticias1.png" },
            new() { Nome = "Tempo", Imagem = "meteo2.png" }

        };
    }

    private async void SelecionarCategoria(Categoria categoria)
    {
        switch (categoria.Nome)
        {
            case "Espécies Cinegéticas":
                await Shell.Current.GoToAsync(nameof(EspeciesPage));
                break;
            case "Cães":
                await Shell.Current.GoToAsync(nameof(CaesPage));
                break;
            case "Armas":
                await Shell.Current.GoToAsync(nameof(ArmasPage));
                break;
            case "Noticias":
                await Shell.Current.GoToAsync(nameof(NoticiasPage));
                break;
            case "Tempo":
                await Shell.Current.GoToAsync(nameof(TempoPage));
                break;
        }
    }
}
