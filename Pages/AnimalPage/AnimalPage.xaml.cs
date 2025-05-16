using caca360.ViewModels;
using caca360.Models;

namespace caca360;
[QueryProperty(nameof(Nome), "nome")]
[QueryProperty(nameof(Descricao), "descricao")]
[QueryProperty(nameof(Imagem), "imagem")]
public partial class AnimalPage : ContentPage
{
    public string Nome
    {
        set => Title = value;
    }

    public string Descricao
    {
        set => DescricaoLabel.Text = value;
    }

    public string Imagem
    {
        set => AnimalImage.Source = Uri.UnescapeDataString(value);
    }

    public AnimalPage()
    {
        InitializeComponent();
    }
}
