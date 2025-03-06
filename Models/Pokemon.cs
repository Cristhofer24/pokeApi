namespace PokemonApi.Models
{
    public class Pokemon
    {
        public int id { get; set; }
        public string name { get; set; }
        public double weight { get; set; }
        public double height { get; set; }
        public PokemonSprites sprites { get; set; }
        public List<PokemonType> types { get; set; }

    }



    public class PokemonSprites
    {
        public string front_default { get; set; }
        public string front_shiny { get; set; }
        public string front_female { get; set; }
        public string front_shiny_female { get; set; }
        public string back_default { get; set; }
        public string back_shiny { get; set; }
        public string back_female { get; set; }
        public string back_shiny_female { get; set; }
    }


    public class PokemonType
    {
        public int slot { get; set; }
        public PokemonTypeDetail type { get; set; }

    }

    public class PokemonTypeDetail
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class PokemonResponse
    {
        public int Count { get; set; }
        public string? Next { get; set; }
        public string? Previous { get; set; }
        public List<Pokemon> Results { get; set; }
    }
}
