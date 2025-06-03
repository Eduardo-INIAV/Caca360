using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace caca360.ViewModels;

public class Noticia
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public string? ImageUrl { get; set; }
}

public partial class NoticiasViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Noticia> noticias = new();
    public ObservableCollection<Noticia> Noticias
    {
        get => noticias;
        set
        {
            if (noticias != value)
            {
                noticias = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public async Task BuscarNoticiasAsync(string hashtag)
    {
        var apiKey = "b9ababd6fcf34185b1994e0cc35700ce";
        var url = $"https://newsapi.org/v2/everything?q={Uri.EscapeDataString(hashtag)}&language=pt&apiKey={apiKey}";

        try
        {
            using var http = new HttpClient();
            http.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");
            var response = await http.GetFromJsonAsync<NewsApiResponse>(url);

            System.Diagnostics.Debug.WriteLine($"Resposta: {System.Text.Json.JsonSerializer.Serialize(response)}");

            Noticias.Clear();
            if (response?.Articles != null)
            {
                foreach (var artigo in response.Articles)
                {
                    Noticias.Add(new Noticia
                    {
                        Title = artigo.Title,
                        Description = artigo.Description,
                        Url = artigo.Url,
                        ImageUrl = artigo.UrlToImage
                    });
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Nenhum artigo encontrado.");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Erro ao buscar notícias: {ex.Message}");
        }
    }

    private class NewsApiResponse
    {
        public List<Article>? Articles { get; set; }
    }
    private class Article
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public string? UrlToImage { get; set; }
    }
}
