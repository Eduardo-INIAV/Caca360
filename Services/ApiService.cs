namespace caca360.Services
{
    public class ApiService
    {
        private readonly HttpClient _http = new();

        public async Task<string> LoginAsync(string username, string password)
        {
            // chamada de login (mock)
            return await Task.FromResult("token_simulado");
        }
    }
}
