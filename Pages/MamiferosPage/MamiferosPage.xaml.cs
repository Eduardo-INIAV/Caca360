using caca360.ViewModels;

namespace caca360;
public partial class MamiferosPage : ContentPage
{
    public MamiferosPage()
    {
        InitializeComponent();
        BindingContext = new MamiferosViewModel();
        Shell.SetBackButtonBehavior(this, new BackButtonBehavior { IsVisible = false });
        var backButton = new ToolbarItem
        {
            Text = "Voltar",
            Priority = 0,
            Order = ToolbarItemOrder.Primary,
            Command = new Command(() =>
            {
                BackButtonBehavior();
            })
        };
        ToolbarItems.Add(backButton);
    }

    private void BackButtonBehavior()
    {
        // Faz a navegação para a página desejada
        this.Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//EspeciesPage");
        });
    }


    protected override bool OnBackButtonPressed()
    {
        // Faz a navegação para a página desejada
        this.Dispatcher.Dispatch(async () =>
        {
            await Shell.Current.GoToAsync("//EspeciesPage");
        });

        // Retorna true para impedir o comportamento padrão (fechar a página atual)
        return true;
    }

}
