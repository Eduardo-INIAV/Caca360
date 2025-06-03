using System.Collections.ObjectModel;
using System.Windows.Input;
using caca360.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace caca360.ViewModels;

public partial class MamiferosViewModel : ObservableObject
{
    public ObservableCollection<Animal> Mamiferos { get; }

    private Animal? _AnimalSelecionado = null!;

    public Animal? AnimalSelecionado
    {
        get => _AnimalSelecionado;
        set
        {
            if (_AnimalSelecionado != value)
            {
                _AnimalSelecionado = value;
                OnPropertyChanged(nameof(AnimalSelecionado)); // Notifica a UI da seleção
                if (_AnimalSelecionado != null)
                {
                    SelecionarAnimal(_AnimalSelecionado);
                    _AnimalSelecionado = null;
                    OnPropertyChanged(nameof(AnimalSelecionado)); // Notifica a UI da limpeza
                }
            }
        }
    }


    public ICommand SelecionarMamiferosCommand { get; }

    public MamiferosViewModel()
    {
        Mamiferos = new ObservableCollection<Animal>
        {
            new() { Nome = "Raposa", Descricao = "É um mamífero carnívoro, generalista, de porte médio, pertencente à família Canidae, que também inclui o cão, o lobo, o coiote, o chacal ou o mabeco. Atualmente, estão descritas cerca de vinte espécies de raposas, sendo que algumas delas estão confinadas a regiões muito restritas.\r\n\r\nEm Portugal, existe apenas uma espécie, a raposa vermelha ou raposa comum, que é a espécie mais abundante e comum no mundo.\r\n\r\nA sua pelagem é castanho-escura nos primeiros 6 meses de vida e, depois, torna-se geralmente castanho-avermelhada, com o peito e o abdómen esbranquiçados. De focinho pontiagudo, orelhas grandes e cauda longa, na idade adulta, atinge um peso corporal de 5 a 7 Kg, com um comprimento total próximo de um metro de comprimento. A sua cauda longilínea, com extremidade de coloração branca ou preta, atinge cerca de 40 cm. As extremidades das patas e a parte de trás das orelhas são pretas. A proporção dos seus membros posteriores relativamente ao peso é consideravelmente superior à das restantes espécies de canídeos, dotando-a de grande agilidade e permitindo-lhe dar saltos de grande amplitude durante a predação. Não apresenta um dimorfismo sexual marcado, no entanto, tal como noutros carnívoros, as fêmeas são, geralmente, mais pequenas do que os machos.\r\n\r\nEm Portugal, a raposa é uma espécie cinegética com estatuto de conservação considerado não preocupante.", Categoria = "Mamiferos", Imagem = "rapousa1.png", Link="http://especiescinegeticas.pt/especies-cinegeticas/mamiferos-carnivoros/raposa"},
            new() { Nome = "Sacarrabos", Descricao = "É um mamífero carnívoro generalista da família Herpestidae, que, em termos evolutivos, é próxima da família Viverridae, a qual inclui genetas e civetas.\r\n\r\nNa Península Ibérica, existe apenas uma espécie de herpestídios, denominada cientificamente de Herpestes ichneumon, que apresenta porte médio, silhueta esguia acinzentada, cabeça afunilada, orelhas pequenas e arredondadas, pupilas horizontais, patas com cinco dedos munidas de garras não retrácteis, e cauda longilínea que termina num pincel de pêlos negros.  \r\n\r\nO dimorfismo sexual em animais adultos não é muito evidente, embora os machos apresentem maior dimensão corporal e cranial relativamente às fêmeas. Num estudo conduzido em Portugal por Bandeira e colaboradores, verificou-se que os machos apresentam, em média, 98,53 cm de comprimento e 2,417 Kg de peso, enquanto as fêmeas apresentam um comprimento total e peso corporal médios de 95,50 cm e 2,145 Kg, respetivamente.\r\n\r\nEm Portugal, o sacarrabos é uma espécie cinegética com estatuto de conservação considerado não preocupante.", Categoria = "Mamiferos", Imagem = "sacarabos1.png", Link="http://especiescinegeticas.pt/especies-cinegeticas/mamiferos-carnivoros/sacarrabos"}
        };

        SelecionarMamiferosCommand = new Command<Animal>(async animal =>
        {
            if (animal is null)
                return;

            // navega para página do animal
            await Shell.Current.GoToAsync($"{nameof(AnimalPage)}?nome={animal.Nome}&descricao={animal.Descricao}&imagem={animal.Imagem}&especie=Mamiferos&link={ animal.Link}");
        });
    }

    private void SelecionarAnimal(Animal animal)
    {
        SelecionarMamiferosCommand.Execute(animal);
    }
}
