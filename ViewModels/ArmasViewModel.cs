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
            new() { Nome = "Brenner BF18", Descricao = "O Brenner BF18 Preto é um equipamento robusto e eficiente, ideal para quem procura desempenho e design num só produto. Com 71 cm de diâmetro, oferece uma ventilação poderosa, perfeita para espaços amplos, como cozinhas industriais, áreas de serviço ou ambientes que exijam circulação intensiva de ar.\r\n\r\nFabricado com materiais resistentes e acabamento em preto fosco, o BF18 alia durabilidade e elegância, adaptando-se facilmente a diferentes estilos de decoração. O seu motor de alto rendimento garante um funcionamento silencioso e eficaz, mesmo em longos períodos de uso.", Categoria = "Armas", Imagem = "bf18.png" },
            new() { Nome = "Beretta 686 Silver Pigeon I", Descricao = "A Beretta 686 Silver Pigeon I é uma das espingardas sobrepostas mais emblemáticas do mundo da caça. Com a sua estética refinada e desempenho técnico comprovado, é uma escolha popular entre caçadores experientes. Perfeita para caça menor, como aves e coelhos, proporciona um equilíbrio excecional e um disparo suave em qualquer situação.", Categoria = "Armas", Imagem = "beretta.png" },
            new() { Nome = "Benelli Montefeltro Black", Descricao = "A Benelli Montefeltro Black é uma espingarda semiautomática reconhecida pela sua leveza, equilíbrio e fiabilidade. Com um sistema de inércia extremamente eficaz e um design elegante em preto mate, é ideal para jornadas longas de caça. Seja para caça menor ou uso versátil no campo, oferece desempenho consistente aliado a um manuseamento confortável.", Categoria = "Armas", Imagem = "benelli.png" },
            new() { Nome = "Browning X-Bolt Hunter", Descricao = "O Browning X-Bolt Hunter é um rifle de ferrolho concebido para o caçador exigente. A sua coronha em madeira de nogueira e acabamento de alta qualidade unem-se a um sistema de disparo preciso e suave. Indicado para caça de animais de maior porte, oferece confiança em tiros de longa distância e uma ergonomia superior.", Categoria = "Armas", Imagem = "browning.png" },
            new() { Nome = "Remington 870 Express", Descricao = "A Remington 870 Express é uma espingarda de repetição manual (pump-action) amplamente reconhecida pela sua robustez e versatilidade. Ideal para a caça menor e tiro desportivo, apresenta um design clássico e um sistema de funcionamento fiável. Com uma vasta gama de acessórios disponíveis, adapta-se facilmente a diferentes necessidades e preferências do utilizador.", Categoria = "Armas", Imagem = "remington.png" },
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
