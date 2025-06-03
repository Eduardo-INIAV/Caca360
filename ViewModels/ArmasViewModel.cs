using System.Collections.ObjectModel;
using System.Windows.Input;
using caca360.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace caca360.ViewModels;

public partial class ArmasViewModel : ObservableObject
{
    public ObservableCollection<Desc> Armas { get; }
    public string Categoria { get; } = "Armas";

    private Desc? _descSelecionado = null!;

    public Desc? DescSelecionado
    {
        get => _descSelecionado;
        set
        {
            if (_descSelecionado != value)
            {
                _descSelecionado = value;
                OnPropertyChanged(nameof(DescSelecionado)); // Notifica a UI da seleção
                if (_descSelecionado != null)
                {
                    SelecionarDesc(_descSelecionado);
                    _descSelecionado = null;
                    OnPropertyChanged(nameof(DescSelecionado)); // Notifica a UI da limpeza
                }
            }
        }
    }

    public ICommand SelecionarArmasCommand { get; }

    public ArmasViewModel()
    {
        Armas = new ObservableCollection<Desc>
        {
            new() { Nome = "Cartucho 12 GA ", Descricao = "As munições de calibre 12, também conhecidas como cartuchos 12 GA, são as mais utilizadas em espingardas de cano liso e destacam-se pela sua versatilidade na caça. Existem diferentes tipos de munição dentro deste calibre, adaptando-se a diversas espécies e estilos de caça.\n\nO tipo mais comum é o chumbo, que consiste em múltiplos pequenos projéteis (pellets) que se espalham ao sair do cano. Esta dispersão torna-o ideal para caça de animais em movimento, como aves (pombos, perdizes, patos) e pequenos mamíferos (coelhos). Os cartuchos variam no número e tamanho dos chumbos: quanto menor o número, maior o diâmetro de cada pellet. Por exemplo, o chumbo nº 6 ou 7½ é adequado para aves pequenas, enquanto o nº 4 oferece maior alcance e impacto para caça com penas maiores.\n\nPara caça maior, como o javali, utilizam-se slugs, que são balas únicas de grande diâmetro. Ao contrário do chumbo múltiplo, o slug proporciona mais energia e penetração, sendo eficaz a curta distância. Existem variantes como os slugs Foster, usados em canos lisos, e os sabot slugs, mais indicados para canos com raiamento ou com choques específicos.\n\nTambém existem os chamados buckshot (balote grosso), que contêm menos projéteis mas de maior dimensão. Embora menos comuns na caça em Portugal, são por vezes usados para caça grossa em situações específicas.\n\nEm resumo, o calibre 12 é extremamente polivalente, permitindo ao caçador adaptar-se a diferentes tipos de caça apenas mudando o tipo de cartucho utilizado.", Categoria = "Armas", Imagem = "cartucho12ga.png" },
            new() { Nome = "Brenner BF18", Descricao = "O Brenner BF18 Preto é um equipamento robusto e eficiente, ideal para quem procura desempenho e design num só produto. Com 71 cm de diâmetro, oferece uma ventilação poderosa, perfeita para espaços amplos, como cozinhas industriais, áreas de serviço ou ambientes que exijam circulação intensiva de ar.\r\n\r\nFabricado com materiais resistentes e acabamento em preto fosco, o BF18 alia durabilidade e elegância, adaptando-se facilmente a diferentes estilos de decoração. O seu motor de alto rendimento garante um funcionamento silencioso e eficaz, mesmo em longos períodos de uso.", Categoria = "Armas", Imagem = "bf18.png" },
            new() { Nome = "Beretta 686 Silver Pigeon I", Descricao = "A Beretta 686 Silver Pigeon I é uma das espingardas sobrepostas mais emblemáticas do mundo da caça. Com a sua estética refinada e desempenho técnico comprovado, é uma escolha popular entre caçadores experientes. Perfeita para caça menor, como aves e coelhos, proporciona um equilíbrio excecional e um disparo suave em qualquer situação.", Categoria = "Armas", Imagem = "beretta.png" },
            new() { Nome = "Benelli Montefeltro Black", Descricao = "A Benelli Montefeltro Black é uma espingarda semiautomática reconhecida pela sua leveza, equilíbrio e fiabilidade. Com um sistema de inércia extremamente eficaz e um design elegante em preto mate, é ideal para jornadas longas de caça. Seja para caça menor ou uso versátil no campo, oferece desempenho consistente aliado a um manuseamento confortável.", Categoria = "Armas", Imagem = "benelli.png" },
            new() { Nome = "Browning X-Bolt Hunter", Descricao = "O Browning X-Bolt Hunter é um rifle de ferrolho concebido para o caçador exigente. A sua coronha em madeira de nogueira e acabamento de alta qualidade unem-se a um sistema de disparo preciso e suave. Indicado para caça de animais de maior porte, oferece confiança em tiros de longa distância e uma ergonomia superior.", Categoria = "Armas", Imagem = "browning.png" },
            new() { Nome = "Remington 870 Express", Descricao = "A Remington 870 Express é uma espingarda de repetição manual (pump-action) amplamente reconhecida pela sua robustez e versatilidade. Ideal para a caça menor e tiro desportivo, apresenta um design clássico e um sistema de funcionamento fiável. Com uma vasta gama de acessórios disponíveis, adapta-se facilmente a diferentes necessidades e preferências do utilizador.", Categoria = "Armas", Imagem = "remington.png" },
            new() { Nome = ".308 Winchester – Bala Soft Point (SP)", Descricao = "A munição .308 Winchester é uma das mais populares entre caçadores em todo o mundo, especialmente para caça maior. Utiliza uma bala de calibre .30 (7,62 mm), com elevada velocidade e excelente precisão, sendo ideal para tiros a médias distâncias. Uma escolha comum é a bala Soft Point (SP), que tem a ponta exposta em chumbo, permitindo uma deformação controlada no impacto. Esta expansão aumenta o diâmetro da ferida e transfere mais energia ao animal, proporcionando um bom poder de paragem sem comprometer demasiadamente a penetração. É especialmente eficaz na caça de animais como javalis, corços e veados, sendo adequada tanto para emboscadas como para tiros mais técnicos em campo aberto. O recuo é relativamente moderado, o que contribui para boa repetição de disparo e conforto.", Categoria = "Armas", Imagem = "cartucho308.png" },
            new() { Nome = ".30-06 Springfield – Bala SP ou Nosler Ballistic Tip", Descricao = "A .30-06 Springfield é uma munição de referência no mundo da caça maior, conhecida pela sua potência, alcance e versatilidade. Com origem militar, foi adaptada com grande sucesso à caça civil. É uma escolha habitual para quem procura um cartucho capaz de abater animais de grande porte como veados, gamos ou javalis de maior dimensão, mesmo a distâncias consideráveis. Utiliza balas de calibre .30 (7,62 mm), mas com maior carga propulsora que a .308, oferecendo assim mais energia e penetração.\n\nA bala Soft Point (SP) é frequentemente usada pela sua capacidade de expansão controlada, eficaz em situações onde se pretende boa transferência de energia e ferida eficaz. Já a Nosler Ballistic Tip é uma bala de ponta plástica, desenhada para oferecer grande precisão e uma expansão rápida após o impacto – ideal para caçadas em que se privilegia tiros limpos e rápidos. A escolha entre SP e Ballistic Tip depende do tipo de animal, da distância esperada e do comportamento desejado da bala no impacto. A .30-06 é robusta, fiável e continua a ser uma das preferidas para caçadas exigentes em terrenos variados.", Categoria = "Armas", Imagem = "cartucho3006.png"}
        };

        SelecionarArmasCommand = new Command<Desc>(async desc =>
        {
            if (desc is null)
                return;

            // navega para página do desc
            await Shell.Current.GoToAsync($"{nameof(DescPage)}?nome={desc.Nome}&descricao={desc.Descricao}&imagem={desc.Imagem}&categoria={Categoria}");
        });
    }

    private void SelecionarDesc(Desc desc)
    {
        SelecionarArmasCommand.Execute(desc);
    }
}
