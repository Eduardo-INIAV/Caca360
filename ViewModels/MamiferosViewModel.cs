using System.Collections.ObjectModel;
using System.Windows.Input;
using caca360.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace caca360.ViewModels;

public partial class MamiferosViewModel : ObservableObject
{
    public ObservableCollection<Animal> Mamiferos { get; }

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



    public ICommand SelecionarMamiferosCommand { get; }

    public MamiferosViewModel()
    {
        Mamiferos = new ObservableCollection<Animal>
        {
            new() { Nome = "Papagaio", Descricao = "O papagaio é uma ave colorida.", Categoria = "Mamiferos", Imagem = "papagaio.png" },
            new() { Nome = "Águia", Descricao = "A águia tem visão aguçada.", Categoria = "Mamiferos", Imagem = "aguia.png" }
        };

        SelecionarMamiferosCommand = new Command<Animal>(async animal =>
        {
            if (animal is null)
                return;

            // navega para página do animal
            await Shell.Current.GoToAsync($"{nameof(AnimalPage)}?nome={animal.Nome}&descricao={animal.Descricao}&imagem={animal.Imagem}");
        });
    }

    private void SelecionarAnimal(Animal animal)
    {
        SelecionarMamiferosCommand.Execute(animal);
    }
}
