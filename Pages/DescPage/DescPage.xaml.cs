using caca360.ViewModels;
using caca360.Models;

namespace caca360;
[QueryProperty(nameof(Nome), "nome")]
[QueryProperty(nameof(Descricao), "descricao")]
[QueryProperty(nameof(Imagem), "imagem")]
[QueryProperty(nameof(Categoria), "categoria")]

public partial class DescPage : ContentPage
{

    public string Categoria { get; set; } = string.Empty;
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
        set => DescImage.Source = Uri.UnescapeDataString(value);
    }

    public DescPage()
    {
        InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });
        var backButton = new ToolbarItem
        {
            Text="Voltar",
            Priority = 0,
            Order = ToolbarItemOrder.Primary,
            Command = new Command(() =>
            {
                VoltarParaCategoria();
            })
        };
        ToolbarItems.Add(backButton);
    }

    private async void VoltarParaCategoria()
    {
        if (!string.IsNullOrEmpty(Categoria))
        {
            // Voltar para a página da espécie (ex: AvesPage)
            await Shell.Current.GoToAsync($"//{Categoria}Page");
        }
        else
        {
            // Se não houver espécie, volta para página anterior padrão
            await Shell.Current.GoToAsync("//InfosPage");
        }
    }

    protected override bool OnBackButtonPressed()
    {
        if (!string.IsNullOrEmpty(Categoria))
        {
            // Voltar para a página da espécie (ex: AvesPage)
            Shell.Current.GoToAsync($"//{Categoria}Page");
            return true; // cancela o back padrão
        }
        else
        {
            // Se não houver espécie, volta para página anterior padrão
            Shell.Current.GoToAsync("//InfosPage");
        }
        return base.OnBackButtonPressed();
    }
}
