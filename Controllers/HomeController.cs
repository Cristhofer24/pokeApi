using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PokemonApi.Models;
using PokemonApi.Services;

namespace PokemonApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PokemonServices _pokemonServices;
        
        public HomeController(ILogger<HomeController> logger, PokemonServices pokemonServices)
        {
            _logger = logger;
            _pokemonServices = pokemonServices;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _pokemonServices.GetPokemonsAsync();

            // Extraer la lista de Pokémon
            var pokemons = new List<Pokemon>();
            foreach (var result in response.results)
            {
                var pokemon = await _pokemonServices.GetPokemonAsync(result.name);
                pokemons.Add(pokemon);
            }

            return View(pokemons);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
