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
            new() { Nome = "Coelho-bravo", Descricao = "O coelho-bravo é um pequeno herbívoro que pertence à família Leporidae, ordem Lagomorpha, de coloração geral acinzentada, cor branca na face inferior da cauda e orelhas relativamente curtas. Estão descritas duas subespécies, Oryctolagus cuniculus subs. algirus e Oryctolagus cuniculus subsp. cuniculus, que divergiram há cerca de dois milhões de anos, apresentando atualmente diferenças a nível genético, morfológico, ecológico e comportamental. Morfologicamente, distinguem-se, sobretudo, pelo tamanho: a subespécie O. c. algirus é mais pequena que O. c. cuniculus, apresentando também orelhas e patas posteriores mais pequenas e um peso adulto médio de 1,0 kg, enquanto O. c. cuniculus apresenta um peso adulto médio de 1,2 kg. O peso varia entre machos e fêmeas, sendo as fêmeas ligeiramente mais pesadas.\r\n\r\nO coelho-bravo é uma espécie de caça menor, muito emblemática para o caçador Português, com relevante impacto nos sistemas sócio-económicos subjacentes à atividade cinegética na Península Ibérica.\r\n\r\nEm resultado do declínio progressivo das populações, com episódios de diminuição drástica dos efetivos, o coelho-bravo foi classificado, em 2019, como uma espécie em perigo, pelos critérios da União Internacional da Conservação da Natureza (IUCN), figurando na edição de 2005 do Livro Vermelho dos Vertebrados de Portugal com o estatuto de espécie quase-ameaçada.", Categoria = "Lago", Imagem = "coelho1.png", Link="http://especiescinegeticas.pt/especies-cinegeticas/lagomorfos/coelho-bravo"},
            new() { Nome = "Lebre-Ibérica", Descricao = "A lebre-ibérica pertence ao género Lepus da família Leporidae, ordem Lagomorpha, que inclui mais de 30 outras espécies, como a lebre-europeia ou lebre-castanha (Lepus europaeus). lebre-do-cabo (Lepus capensis), lebre-de-piornal (Lepus castroviejoi), lebre-italiana (Lepus corsicanus), ou a lebre-alpina (Lepus timidus).\r\n\r\nA lebre-ibérica caracteriza-se por pelagem com coloração amarelo-acastanhada e a presença de pêlos pretos no dorso que se destacam do resto da pelagem. Na zona ventral e parte das patas, o pêlo é branco. A cauda é negra na zona superior e branca na zona inferior. Possui grandes olhos, de coloração âmbar ou castanha, e orelhas muito longas, de extremidades escuras. O comprimento total e o peso médio nos adultos variam entre os 44,0 a 47,0 cm e os 2 a 3 kg, respetivamente. Os membros posteriores são muito desenvolvidos, mais compridos que os dianteiros e, notoriamente, mais longos quando comparados com os do coelho-bravo, proporcionando grande velocidade e resistência de corrida.\r\n\r\nA lebre-ibérica é uma espécie de caça menor, emblemática para o caçador Português, com impacto sócio-económico na atividade cinegética da Península Ibérica. Diversos fatores podem ameaçar a distribuição e abundância da lebre-ibérica, nomeadamente uma elevada pressão de caça, predação natural, alterações de habitat, e algumas doenças infeciosas. Até muito recentemente, antes da ocorrência de surtos de mixomatose (ver abaixo), as populações de lebre-ibérica eram consideradas estáveis, figurando na lista vermelha da União Internacional da Conservação da Natureza (IUCN) na categoria de “menor preocupação” (LC). Apesar da perceção generalizada ser de grande redução dos efetivos, desconhece-se com rigor o atual estatuto da espécie. Por esse motivo, o esforço de caça deve ser reduzido e adaptado a cada zona de caça e inferior à taxa de crescimento das populações locais.", Categoria = "Lago", Imagem = "lebre2.png", Link="http://especiescinegeticas.pt/especies-cinegeticas/lagomorfos/lebre-iberica"}
        };

        SelecionarLagoCommand = new Command<Animal>(async animal =>
        {
            if (animal is null)
                return;

            // navega para página do animal
            await Shell.Current.GoToAsync($"{nameof(AnimalPage)}?nome={animal.Nome}&descricao={animal.Descricao}&imagem={animal.Imagem}&especie=Lago&link={animal.Link}");
        });
    }

    private void SelecionarAnimal(Animal animal)
    {
        SelecionarLagoCommand.Execute(animal);
    }
}
