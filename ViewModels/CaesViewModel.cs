using System.Collections.ObjectModel;
using System.Windows.Input;
using caca360.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace caca360.ViewModels;

public partial class CaesViewModel : ObservableObject


{
    public ObservableCollection<Desc> Caes { get; }
    public string Categoria { get; } = "Caes";

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

    public ICommand SelecionarCaesCommand { get; }

    public CaesViewModel()
    {
        Caes = new ObservableCollection<Desc>
        {
            new() { Nome = "Springer Inglês", Descricao = "A raça Springer Inglês têm o corpo forte e musculoso, e foram criados dessa forma para caçarem com os humanos, pelos quais a raça tem muito apreço e anseio em agradar.\r\n \r\nO cão foi desenvolvido para que durante a caça, ele levantasse a presa para ser caçada. Assim como o Pointer, podia trabalhar juntamente com outros cães. Hoje em dia essa raça, além de localizar e levantar a presa, traz o abate para a mão do caçador.", Categoria = "desc", Imagem = "springer1.png" },
            new() { Nome = "Pointers", Descricao = "Os Pointers são cães cheios de energia, agilidade e ótimos para corridas, ou seja, possuem qualidades incríveis para uma boa caçada. Não só para isso, mas também como companheiro.\r\n \r\nNo passado a raça caçava juntamente com outros cachorros. O seu papel, como o nome sugere, era de apontar a caça para que outros cães a capturassem. Após 1700, com a popularização da caça de aves, o Pointer ficou ainda mais famoso como cão para caça.", Categoria = "desc", Imagem = "pointer1.png" },
            new() { Nome = "Beagle", Descricao = "Pequeno, mas determinado, o Beagle é um cão de matilha especializado na caça ao coelho e à lebre. O seu faro aguçado, resistência e natureza sociável tornam-no ideal para caçadas em grupo. É também muito popular como cão de companhia devido ao seu temperamento amigável.", Categoria = "desc", Imagem = "beagle.png" }, 
            new() { Nome = "Cão de Santo Humberto", Descricao = "Famoso pelo seu faro extraordinário, o Cão de Santo Humberto é especialista na procura e seguimento de trilhos, mesmo horas depois da presa ter passado. Calmo, persistente e metódico, é muito utilizado na caça de rastreamento e também em buscas de salvamento devido à sua precisão.", Categoria = "desc", Imagem = "bloodhound.png" },
            new() { Nome = "Braco Alemão de Pelo Curto ", Descricao = "Versátil e altamente treinável, o Braco Alemão adapta-se a vários tipos de caça, desde aves até animais de médio porte. Combinando resistência, energia e inteligência, é excelente tanto no campo como na água, sendo um dos cães de caça mais completos e valorizados na Europa.", Categoria = "desc", Imagem = "kurzhaar.png" }
        };

        SelecionarCaesCommand = new Command<Desc>(async desc =>
        {
            if (desc is null)
                return;

            // navega para página do desc
            await Shell.Current.GoToAsync($"{nameof(DescPage)}?nome={desc.Nome}&descricao={desc.Descricao}&imagem={desc.Imagem}&categoria={Categoria}");
        });
    }

    private void SelecionarDesc(Desc desc)
    {
        SelecionarCaesCommand.Execute(desc);
    }
}
