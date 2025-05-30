using System.Collections.ObjectModel;
using System.Windows.Input;
using caca360.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace caca360.ViewModels;

public partial class UnguladosViewModel : ObservableObject
{
    public ObservableCollection<Animal> Ungulados { get; }
    public string Especie { get; } = "Ungulados";

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



    public ICommand SelecionarUnguladosCommand { get; }

    public UnguladosViewModel()
    {
        Ungulados = new ObservableCollection<Animal>
        {
            new() { Nome = "Javali", Descricao = "O javali é um mamífero da família Suidae que, na fase adulta, se caracteriza por uma silhueta compacta e robusta, cabeça grande e afunilada, ausência aparente de pescoço, membros curtos e fortes, com um comprimento total de 1,25 a 1,70 m e peso que pode atingir os 140 Kg nos machos.  \r\nNo javali adulto, os machos podem ser facilmente distinguidos das fêmeas através da sua maior corpulência e presença de caninos ou presas extremamente desenvolvidas numa cabeça mais larga e menos afunilada. Estes dentes, muito característicos da espécie, designam-se por navalhas (caninos inferiores) e amoladeiras (caninos superiores) e constituem o troféu do javali. A pelagem típica de animais adultos é composta por cerdas grossas de tom cinzento ou pardo e, normalmente, é mais escura e densa no Inverno.\r\nPresentemente, o javali ocupa um espaço de relevo entre as espécies de caça maior, sobretudo devido à deslocalização progressiva em Portugal do exercício da caça menor para a prática de caça maior, que se deve, sobretudo, à diminuição progressiva, mas muito marcada, de efetivos de caça menor, tais como o coelho-bravo, a perdiz-vermelha e a rola-comum.", Categoria = "Ungulados", Imagem = "javali.png", Link="http://especiescinegeticas.pt/especies-cinegeticas/ungulados/javali" },
            new() { Nome = "Veado", Descricao = "O veado é um mamífero artiodáctilo ruminante da família Cervidae que integra espécies de tamanhos muito diferentes, mas, em geral, com membros e pescoço compridos, caudas curtas e cabeças angulares.\r\nO veado é um animal de grande porte, forte, mas ágil e prudente, sendo o maior dos cervídeos da Península Ibérica. Estudos recentes demonstram que os veados da Península Ibérica têm características genéticas únicas e diferentes das presentes nos veados das outras regiões da Europa. Apresentam menor porte e, a sua pelagem é mais clara, acinzentada e menos vermelha. A pelagem dos veados da Península Ibérica apresenta ainda variação sazonal na tonalidade e brilho, sendo castanho-avermelhada durante o Verão e castanho escura no Inverno. No primeiro ano de vida, os veados juvenis apresentam pelagem de um castanho mais escuro, com manchas brancas amareladas distribuídas pelo pescoço e dorso. A cauda do veado é curta e acastanhada e o escudo anal apresenta uma cor amarelada. O comprimento total varia entre os 1,65 m e os 2,5 m. O peso destes animais é variável consoante a região, podendo atingir 250 Kg na Península Ibérica.", Categoria = "Ungulados", Imagem = "veado.png", Link="http://especiescinegeticas.pt/especies-cinegeticas/ungulados/veado" },
            new() { Nome = "Gamo", Descricao = "Atualmente, em todo o mundo, estão descritas duas subespécies de gamo, o gamo europeu (Dama dama dama) e o gamo persa (Dama dama mesopotamica), que apresentam algumas diferenças morfológicas entre si.\r\nO gamo é um cervídeo de porte médio, mais pequeno que o veado, porém, à semelhança deste, apresenta um grande dimorfismo sexual, não apenas caracterizado pelo porte, mas também pela presença de uma estrutura óssea (armação) nos machos. Esta estrutura, no macho adulto, é constituída por duas hastes espalmadas, arredondadas na base. Na parte superior de cada haste, na área espalmada, desenvolvem-se várias pontas. Além disso, a armação é mudada num ciclo anual, caindo entre março e maio, voltando a crescer novas hastes imediatamente. A cabeça do gamo atinge a sua forma característica aos 7 anos de idade.\r\nNestes cervídeos, a altura do garrote média é de 85 cm nos machos e 75 cm nas fêmeas. O peso corporal nos machos varia entre 50 a 70 Kg, nunca ultrapassando os 120 Kg de peso, enquanto o peso das fêmeas varia entre os 28 e 41 Kg. A nível de comprimento total, este varia entre 1,30 a 1,50 m.\r\nOs gamos apresentam duas pelagens diferentes ao longo do ano. Na Primavera e no Verão, a pelagem base apresenta uma coloração geral castanha clara, um pouco arruivada, com manchas brancas distribuídas pelo dorso. No Outono e no Inverno, as manchas brancas desaparecem por completo e a pelagem torna-se mais escura, tendo um tom, em geral, castanho-escuro um pouco acinzentado. No entanto, o ventre e a face interna dos membros conservam sempre a mesma cor esbranquiçada ao longo do ano, embora com uma tonalidade mais escura no Outono e no Inverno. A cauda, relativamente comprida (cerca de 15 cm), é branca com uma risca central negra na face exterior, enquanto o escudo anal, também conhecido por espelho e, que desempenha um papel primordial na comunicação e interação entre indivíduos, é branco e ladeado por duas faixas negras.\r\nO gamo é uma espécie cinegética de caça maior, com estatuto considerado pouco preocupante (LC) pela União Internacional da Conservação da Natureza.", Categoria = "Ungulados", Imagem = "gamo.png", Link="http://especiescinegeticas.pt/especies-cinegeticas/ungulados/gamo"},
         
        };

        SelecionarUnguladosCommand = new Command<Animal>(async animal =>
        {
            if (animal is null)
                return;

            // nUnguladosga para página do animal
            await Shell.Current.GoToAsync($"{nameof(AnimalPage)}?nome={animal.Nome}&descricao={animal.Descricao}&imagem={animal.Imagem}&especie={Especie}&link={animal.Link}");
        });
    }

    private void SelecionarAnimal(Animal animal)
    {
        SelecionarUnguladosCommand.Execute(animal);
    }
}
