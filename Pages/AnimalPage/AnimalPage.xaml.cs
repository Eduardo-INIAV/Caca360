using caca360.ViewModels;
using caca360.Models;

namespace caca360;
[QueryProperty(nameof(Nome), "nome")]
[QueryProperty(nameof(Descricao), "descricao")]
[QueryProperty(nameof(Imagem), "imagem")]
[QueryProperty(nameof(Especie), "especie")]


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

    public AnimalPage()
    {
        InitializeComponent();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });
        var backButton = new ToolbarItem
        {
            IconImageSource = "back_arrow.png",
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
        string url = "http://especiescinegeticas.pt/"; // muda para o link que quiseres
        try
        {
            await Launcher.OpenAsync(url);
        }
        catch (Exception)
        {
            await DisplayAlert("Erro", "Não foi possível abrir o link.", "OK");
        }
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
            await Shell.Current.GoToAsync("..");
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
        return base.OnBackButtonPressed();
    }
}
