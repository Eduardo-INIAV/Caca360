using System.Collections.ObjectModel;
using System.Windows.Input;
using caca360.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace caca360.ViewModels;

public partial class ArmasViewModel : ObservableObject
{
    public ObservableCollection<Animal> Armas { get; }

    private Animal? _animalSelecionado = null!;

    public Animal? AnimalSelecionado
    {
        get => _animalSelecionado;
        set
        {
            if (_animalSelecionado != value)
            {
                _animalSelecionado = value;
                if (_animalSelecionado != null)
                {
                    SelecionarAnimal(_animalSelecionado);
                    _animalSelecionado = null; // para permitir nova seleção
                }
            }
        }
    }



    public ICommand SelecionarArmasCommand { get; }

    public ArmasViewModel()
    {
        Armas = new ObservableCollection<Animal>
        {
            new() { Nome = "Caçadeira", Descricao = "Uma caçadeira de canos paralelos, também conhecida como \"paralela\", é uma espingarda com dois canos dispostos lado a lado, geralmente usados para caça e tiro esportivo. Essas espingardas são apreciadas por sua precisão e facilidade de uso, permitindo ao usuário disparar dois projéteis simultaneamente ou escolher qual cano disparar. \r\n", Categoria = "Armas", Imagem = "cacadeira1.png" },
            new() { Nome = "Águia", Descricao = "A águia tem visão aguçada.", Categoria = "Armas", Imagem = "aguia.png" }
        };

        SelecionarArmasCommand = new Command<Animal>(async animal =>
        {
            if (animal is null)
                return;

            // nArmasga para página do animal
            await Shell.Current.GoToAsync($"{nameof(AnimalPage)}?nome={animal.Nome}&descricao={animal.Descricao}&imagem={animal.Imagem}");
        });
    }

    private void SelecionarAnimal(Animal animal)
    {
        SelecionarArmasCommand.Execute(animal);
    }
}
