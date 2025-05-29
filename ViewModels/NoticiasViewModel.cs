using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Json;

namespace caca360.ViewModels;

public class Noticia
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public string? ImageUrl { get; set; }
}

public partial class NoticiasViewModel

{
    public ObservableCollection<Noticia> Noticias { get; set; } = new();

    public async Task BuscarNoticiasAsync(string hashtag)
    {
        // Exemplo com NewsAPI (substitua pela API desejada)
        var apiKey = "b9ababd6fcf34185b1994e0cc35700ce";
        var url = $"https://newsapi.org/v2/everything?q={Uri.EscapeDataString(hashtag)}&language=pt&apiKey={apiKey}";

        using var http = new HttpClient();
        http.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");
        var response = await http.GetFromJsonAsync<NewsApiResponse>(url);

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
