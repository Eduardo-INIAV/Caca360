using System.Collections.ObjectModel;
using System.Windows.Input;
using caca360.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace caca360.ViewModels;

public partial class AvesViewModel : ObservableObject
{
    public ObservableCollection<Animal> Aves { get; }

    private Animal? _animalSelecionado= null!;

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



    public ICommand SelecionarAveCommand { get; }

    public AvesViewModel()
    {
        Aves = new ObservableCollection<Animal>
        {
            new() { Nome = "Perdiz-vermelha", Descricao = "A perdiz-vermelha é uma ave terrestre sedentária pertencente à família Phasianidae, ordem Galliformes, que inclui também as codornizes e os faisões.\r\n\r\nCom o seu aspeto de galináceo de corpo arredondado, é uma excelente andarilha, de porte médio, rondando os 35 a 40 cm de comprimento. O bico e as patas são vermelhos, assim como o anel ocular, daí o nome de perdiz-vermelha. Tem uma plumagem de cor parda acastanhada na zona dorsal do corpo e cabeça e a sua zona ventral apresenta um tom acinzentado. Apresenta uma linha preta que contorna a porção branca da cabeça e desce até ao peito, onde forma um colar negro característico da espécie, de donde irradiam estrias da mesma cor que salpicam o cinzento do peito. Os flancos são caracteristicamente estriados de castanho e branco, que ajudam a camuflar-se no chão. O dimorfismo sexual é pouco acentuado nesta espécie, contudo subsistem algumas características que, em observação simultânea, permitem distinguir os machos das fêmeas com relativa segurança:\r\n\r\n    Geralmente, o macho é maior e mais pesado do que a fêmea, com um peso médio de 483 g e 395 g para o macho e fêmea, respetivamente.\r\n    Normalmente, os machos têm também uma cabeça mais volumosa.\r\n    Os machos têm os tarsos mais compridos e grossos, esporões com base larga e arredondada, enquanto as fêmeas apresentam tarsos mais curtos e delgados e, quando desenvolvem esporões, estes têm a base estreita e são bicudos.\r\n\r\nOs juvenis (menos de 1 ano) são essencialmente acastanhados e podem distinguir-se dos animais adultos pela observação das rémiges primárias (i.e., as dez penas da extremidade da asa):\r\n\r\n    O juvenil inicia a muda durante o primeiro mês de vida, a qual se prolonga até outubro e novembro, porém não ocorre substituição das últimas duas rémiges. Estas duas penas caracterizam-se por uma extremidade pontiaguda que pode apresentar uma pequena pinta branca.\r\n    O adulto inicia a muda de todas as rémiges primárias duas ou três semanas antes dos juvenis e as suas duas últimas penas, independentemente de já terem sido mudadas ou não, têm a extremidade arredondada.\r\n\r\nA perdiz-vermelha é uma espécie cinegética de caça menor com estatuto considerado pouco preocupante (LC), pela União Internacional da Conservação da Natureza, embora no presente se verifique uma tendência de declínio populacional desta espécie.", Categoria = "Aves", Imagem = "perdiz2.png" },
            new() { Nome = "Rola-Comum", Descricao = "A rola-comum é uma ave da família dos columbídeos, onde se inserem também as três espécies de pombos que ocorrem em Portugal, pombo-torcaz, pombo-da-rocha e pombo-bravo.\r\n\r\nEsta espécie é uma migradora estival no continente europeu, que nidifica na Europa e inverna no continente africano. Trata-se do columbídeo mais pequeno da Europa, medindo cerca de 28 cm de comprimento e tendo um peso que varia entre 85 e 186 gramas, de acordo com a época do ano. É uma ave esbelta, de corpo delgado e compacto, com peito proeminente e arredondado, cabeça relativamente pequena, asas largas e pontiagudas.\r\n\r\nNos adultos, a sua plumagem vistosa é caracterizada por apresentar uma coloração castanho-acinzentada na cabeça e dorso e, rosada na face ventral. A cauda é arredondada e apresenta uma coloração característica negra com uma barra terminal branca. O pescoço possui, de ambos os lados, um conjunto de riscas brancas e pretas, vulgarmente designadas por colarinho. Quando as asas se encontram fechadas, as penas apresentam um padrão característico formado por um tom castanho-dourado manchado de preto na zona central. As patas e o anel orbital são de cor vermelho-púrpura.\r\n\r\nO juvenil é idêntico ao adulto, embora a coloração da plumagem seja mais baça, uniforme e não possua riscas brancas e pretas no pescoço. O dimorfismo sexual é pouco acentuado nesta espécie, com os machos aparentemente maiores e com uma plumagem com tons mais brilhantes, intensos e definidos do que as fêmeas.\r\n\r\nO padrão de coloração da plumagem conjuntamente com o seu menor tamanho, permitem distingui-la facilmente da rola-turca (Streptopelia decaocto), quando em simpatria no Paleártico ocidental. A rola-turca é uma espécie não nativa na Europa, que começou a migrar de forma mais intensa a partir da Turquia para o continente europeu no início do século XX. Por oposição à rola-comum, a rola-turca apresenta uma plumagem acastanhada, com um tom mais uniforme e menos malhado e, nos dois lados do pescoço, possui uma barra estreita delineada a branco (por este motivo também é conhecida pelo nome de rola-de-colar).\r\n\r\nA rola-comum é uma espécie cinegética de caça menor, com estatuto considerado como vulnerável (VU) pela União Internacional da Conservação da Natureza, decorrente da constatação do declínio significativo das suas populações. Na Europa, estima-se ter ocorrido uma redução drástica na sua densidade populacional entre 30% a 49% em três gerações (aproximadamente 15,9 anos). Nos últimos 50 anos, estima-se uma redução global de cerca de 80% das populações.", Categoria = "Aves", Imagem = "rola2.png" },
            new() { Nome = "Codorniz", Descricao = "A codorniz é uma ave da família dos fasianídeos (tal como as perdizes, faisões, pavões e galinhas).\r\n\r\nTrata-se do mais pequeno galináceo europeu, similar a um perdigoto, com cerca de 19 a 25 cm de comprimento, 32 a 35 cm de envergadura e um peso que oscila entre os 85 a 120 g.\r\n\r\nCaracteriza-se por uma plumagem de cor parda, extremamente mimética, com o dorso e flancos listados, sendo geralmente muito semelhante em ambos os sexos.\r\n\r\nA cabeça é pequena e robusta, com um bico grosso. Quando se encontra em repouso, o seu corpo arredondado e cauda muito curta ajudam esta ave a camuflar-se no meio da vegetação.\r\n\r\nA codorniz é uma ave migradora parcial. Como tal, as suas asas são compridas e estreitas em relação ao corpo, estando perfeitamente adaptadas a voos de longas distâncias, como acontece nos movimentos nómadas ou erráticos e nas migrações intercontinentais.\r\n\r\nA distinção entre sexos pode ser feita através da plumagem no peito e pela presença de uma mancha na garganta que só existe nos machos. Concretamente, o peito das fêmeas apresenta penas de cor pálida e salpicadas de manchas escuras, enquanto o dos machos apresenta penas de cor vermelho-ferrugem uniforme e sem manchas escuras. Ao nível da garganta, o macho adulto apresenta uma mancha escura longitudinal que se prolonga para ambos os lados e, com a idade, vai tomando uma forma que faz lembrar uma âncora.", Categoria = "Aves", Imagem = "coderniz1.png" },
            new() { Nome = "Narcejas", Descricao = "As narcejas são um grupo de aves limícolas (i.e., ocorrem em zonas húmidas), pertencentes à mesma família das galinholas, a família Scolopacidae.\r\n\r\nEm Portugal, ocorrem 3 espécies, nomeadamente Narceja-galega (Lymnocryptes minimus), a Narceja-comum (Gallinago gallinago) e Narceja-grande ou Narceja-real (Gallinago media). Só a narceja-comum e a narceja-galega são espécies cinegéticas, dado que a narceja-grande (Gallinago media) é extremamente rara em Portugal e, como tal, é uma espécie protegida.\r\n\r\nSalvo algumas exceções, estas aves são espécies migradoras invernantes em território nacional, que habitam zonas alagadiças e apresentam uma plumagem mosqueada de castanho, amarelo e preto, ideal para se camuflarem no meio natural. O mimetismo da sua plumagem torna-as difíceis de observar, pelo que passam despercebidas mesmo aos olhares mais treinados. Caracterizam-se por um extenso bico, muito útil para sondar lamas à procura de alimento, e pernas e pescoço relativamente curtos. Os olhos grandes posicionados na parte superior da cabeça proporcionam-lhes uma extraordinária visão. São animais pouco sociáveis e, quando perturbadas, baixam-se no solo e ficam imóveis, mas atentas. A narceja-grande distingue-se das restantes espécies pela grande envergadura alar, pela plumagem de coloração preta com riscas brancas, na porção exterior das asas, e plumagem uniforme escura, no interior das asas, enquanto a plumagem da face interna das asas da narceja-comum exibe um padrão.", Categoria = "Aves", Imagem = "narceja.png" },
            new() { Nome = "Galinhola", Descricao = "A galinhola é uma ave limícola (i.e., ocorre em zonas húmidas) que, tal como as narcejas, pertence à família Scolopacidae. É uma espécie sobretudo migradora, contudo, em algumas regiões da sua área de distribuição, parte do seu efetivo populacional é residente ou sedentário.\r\n\r\nA sua plumagem em tom castanho avermelhado no dorso serve-lhe de camuflagem perfeita, confundindo-se com as folhas secas no solo, tornando-se, desta forma, uma ave muito difícil de observar se não for especificamente procurada. O ventre desta ave é bege, estriado de preto e, na cabeça, apresenta espessas barras transversais pretas.\r\n\r\nÉ uma espécie de tamanho médio, com um comprimento que pode variar entre 30 e 35 cm, uma envergadura alar entre 56 e 60 cm e um peso corporal que pode variar entre 220 a 420 g. Apresenta um corpo de aspeto maciço e, apesar de morfologicamente semelhante a uma narceja, é dotada de maior corpulência em relação a esta, mas possui um batimento de asas mais lento. Ao nível de envergadura, a galinhola aproxima-se mais a uma perdiz.\r\n\r\nO bico da galinhola é comprido (± 7 cm), flexível, extremamente sensível, de cor amarelo-acinzentado na base, vai tornando-se progressivamente mais escuro à medida que avança para a ponta de coloração castanho escura. A extremidade da maxila superior do bico é branda e móvel, funcionando como uma pinça para capturar o alimento.\r\n\r\nOs olhos são escuros e, graças à sua posição lateral na cabeça, proporcionam uma visão de quase 360º, permitindo a estes animais ver a totalidade do espaço envolvente sem movimentar a cabeça. O pescoço, as patas e a cauda são curtas e as suas asas são compridas e arredondadas.\r\n\r\nA galinhola não apresenta dimorfismo sexual, não sendo possível distinguir o macho e a fêmea através da observação da plumagem ou de qualquer outra característica morfológica externa. Os indivíduos jovens são semelhantes aos adultos sendo, por isso, de difícil distinção.\r\n\r\nA galinhola é uma espécie cinegética de caça menor, com estatuto considerado pouco preocupante (LC) pela União Internacional da Conservação da Natureza, dado que apresenta uma larga área de ocorrência e a tendência da população mantém-se estável.", Categoria = "Aves", Imagem = "galinhola.png" }
        };

        SelecionarAveCommand = new Command<Animal>(async animal =>
        {
            if (animal is null)
                return;

            // navega para página do animal
            await Shell.Current.GoToAsync($"{nameof(AnimalPage)}?nome={animal.Nome}&descricao={animal.Descricao}&imagem={animal.Imagem}");
        });
    }

    private void SelecionarAnimal(Animal animal)
    {
        SelecionarAveCommand.Execute(animal);
    }
}
