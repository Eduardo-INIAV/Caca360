using caca360.ViewModels;
using caca360.Models;

namespace caca360;
[QueryProperty(nameof(Nome), "nome")]
[QueryProperty(nameof(Descricao), "descricao")]
[QueryProperty(nameof(Imagem), "imagem")]
[QueryProperty(nameof(Especie), "especie")]
[QueryProperty(nameof(Link), "link")]


public partial class AnimalPage : ContentPage
{
    public string Especie { get; set; } = string.Empty;

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

    private string? _link;
    public string Link
    {
        get => _link ?? string.Empty;
        set
        {
            _link = value;
        }
    }

    public AnimalPage()
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
                VoltarParaEspecie();
            })
        };
        ToolbarItems.Add(backButton);
    }
    private async void OnLinkTapped(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(_link))
            await Launcher.Default.OpenAsync(_link);
    }

    private async void VoltarParaEspecie()
    {
        if (!string.IsNullOrEmpty(Especie))
        {
            // Voltar para página da espécie
            await Shell.Current.GoToAsync($"//{Especie}Page");
        }
        else
        {
            // Se não houver espécie, volta para página anterior padrão
            await Shell.Current.GoToAsync("//InfosPage");
        }
    }

    protected override bool OnBackButtonPressed()
    {
        if (!string.IsNullOrEmpty(Especie))
        {
            // Voltar para a página da espécie (ex: AvesPage)
            Shell.Current.GoToAsync($"//{Especie}Page");
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
