using PokemonApi.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace PokemonApi.Services
{
    public class PokemonServices
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://pokeapi.co/api/v2/pokemon/";

        public PokemonServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PokemonResponse> GetPokemonsAsync(int offset = 0, int limit = 20)
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}?offset={offset}&limit={limit}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PokemonResponse>(json);
        }

        public async Task<Pokemon> GetPokemonAsync(string param)
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}{param}");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Pokemon>(json);
        }


    }
}
