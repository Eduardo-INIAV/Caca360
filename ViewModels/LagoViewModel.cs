using System.Collections.ObjectModel;
using System.Windows.Input;
using caca360.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace caca360.ViewModels;

public partial class LagoViewModel : ObservableObject
{
    public ObservableCollection<Animal> Lago { get; }

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



    public ICommand SelecionarLagoCommand { get; }

    public LagoViewModel()
    {
        Lago = new ObservableCollection<Animal>
        {
            new() { Nome = "Papagaio", Descricao = "O papagaio é uma ave colorida.", Categoria = "Lago", Imagem = "papagaio.png" },
            new() { Nome = "Águia", Descricao = "A águia tem visão aguçada.", Categoria = "Lago", Imagem = "aguia.png" }
        };

        SelecionarLagoCommand = new Command<Animal>(async animal =>
        {
            if (animal is null)
                return;

            // navega para página do animal
            await Shell.Current.GoToAsync($"{nameof(AnimalPage)}?nome={animal.Nome}&descricao={animal.Descricao}&imagem={animal.Imagem}");
        });
    }

    private void SelecionarAnimal(Animal animal)
    {
        SelecionarLagoCommand.Execute(animal);
    }
}
