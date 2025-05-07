using System.Windows.Input;

namespace caca360.ViewModels
{
    public class InfosViewModel
    {
        public ICommand OpenLinkCommand { get; }

        public InfosViewModel()
        {
            OpenLinkCommand = new Command(() =>
            {
                // Lógica para abrir o link
                Browser.Default.OpenAsync("http://especiescinegeticas.pt/areas-acao/especies-cinegeticas", BrowserLaunchMode.SystemPreferred);
            });
        }
    }
}
