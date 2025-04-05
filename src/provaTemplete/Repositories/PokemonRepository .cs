using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using provaTemplete.Models;

namespace provaTemplete.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private static List<Pokemon> _pokemons = new List<Pokemon>
        {
            // Pokémon iniciais (Kanto)
            new Pokemon { Id = 1, Name = "Bulbasaur", Type = "Grass/Poison", Level = 5, HP = 45, Attack = 49, Defense = 49, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/001.png" },
            new Pokemon { Id = 2, Name = "Ivysaur", Type = "Grass/Poison", Level = 16, HP = 60, Attack = 62, Defense = 63, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/002.png" },
            new Pokemon { Id = 3, Name = "Venusaur", Type = "Grass/Poison", Level = 32, HP = 80, Attack = 82, Defense = 83, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/003.png" },
            new Pokemon { Id = 4, Name = "Charmander", Type = "Fire", Level = 5, HP = 39, Attack = 52, Defense = 43, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/004.png" },
            new Pokemon { Id = 5, Name = "Charmeleon", Type = "Fire", Level = 16, HP = 58, Attack = 64, Defense = 58, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/005.png" },
            new Pokemon { Id = 6, Name = "Charizard", Type = "Fire/Flying", Level = 36, HP = 78, Attack = 84, Defense = 78, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/006.png" },
            new Pokemon { Id = 7, Name = "Squirtle", Type = "Water", Level = 5, HP = 44, Attack = 48, Defense = 65, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/007.png" },
            new Pokemon { Id = 8, Name = "Wartortle", Type = "Water", Level = 16, HP = 59, Attack = 63, Defense = 80, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/008.png" },
            new Pokemon { Id = 9, Name = "Blastoise", Type = "Water", Level = 36, HP = 79, Attack = 83, Defense = 100, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/009.png" },
            
            // Pokémon populares
            new Pokemon { Id = 10, Name = "Pikachu", Type = "Electric", Level = 10, HP = 35, Attack = 55, Defense = 40, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/025.png" },
            new Pokemon { Id = 11, Name = "Raichu", Type = "Electric", Level = 30, HP = 60, Attack = 90, Defense = 55, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/026.png" },
            new Pokemon { Id = 12, Name = "Jigglypuff", Type = "Normal/Fairy", Level = 8, HP = 115, Attack = 45, Defense = 20, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/039.png" },
            new Pokemon { Id = 13, Name = "Meowth", Type = "Normal", Level = 7, HP = 40, Attack = 45, Defense = 35, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/052.png" },
            new Pokemon { Id = 14, Name = "Psyduck", Type = "Water", Level = 12, HP = 50, Attack = 52, Defense = 48, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/054.png" },
            new Pokemon { Id = 15, Name = "Machop", Type = "Fighting", Level = 15, HP = 70, Attack = 80, Defense = 50, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/066.png" },
            new Pokemon { Id = 16, Name = "Geodude", Type = "Rock/Ground", Level = 9, HP = 40, Attack = 80, Defense = 100, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/074.png" },
            new Pokemon { Id = 17, Name = "Gastly", Type = "Ghost/Poison", Level = 11, HP = 30, Attack = 35, Defense = 30, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/092.png" },
            
            // Lendários
            new Pokemon { Id = 18, Name = "Articuno", Type = "Ice/Flying", Level = 70, HP = 90, Attack = 85, Defense = 100, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/144.png" },
            new Pokemon { Id = 19, Name = "Zapdos", Type = "Electric/Flying", Level = 70, HP = 90, Attack = 90, Defense = 85, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/145.png" },
            new Pokemon { Id = 20, Name = "Moltres", Type = "Fire/Flying", Level = 70, HP = 90, Attack = 100, Defense = 90, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/146.png" },
            new Pokemon { Id = 21, Name = "Mewtwo", Type = "Psychic", Level = 80, HP = 106, Attack = 110, Defense = 90, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/150.png" },
            new Pokemon { Id = 22, Name = "Mew", Type = "Psychic", Level = 75, HP = 100, Attack = 100, Defense = 100, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/151.png" },
            
            // Mais alguns populares
            new Pokemon { Id = 23, Name = "Eevee", Type = "Normal", Level = 15, HP = 55, Attack = 55, Defense = 50, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/133.png" },
            new Pokemon { Id = 24, Name = "Vaporeon", Type = "Water", Level = 30, HP = 130, Attack = 65, Defense = 60, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/134.png" },
            new Pokemon { Id = 25, Name = "Jolteon", Type = "Electric", Level = 30, HP = 65, Attack = 65, Defense = 60, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/135.png" },
            new Pokemon { Id = 26, Name = "Flareon", Type = "Fire", Level = 30, HP = 65, Attack = 130, Defense = 60, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/136.png" },
            new Pokemon { Id = 27, Name = "Snorlax", Type = "Normal", Level = 50, HP = 160, Attack = 110, Defense = 65, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/143.png" },
            new Pokemon { Id = 28, Name = "Dragonite", Type = "Dragon/Flying", Level = 55, HP = 91, Attack = 134, Defense = 95, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/149.png" },
            new Pokemon { Id = 29, Name = "Gengar", Type = "Ghost/Poison", Level = 40, HP = 60, Attack = 65, Defense = 60, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/094.png" },
            new Pokemon { Id = 30, Name = "Gyarados", Type = "Water/Flying", Level = 45, HP = 95, Attack = 125, Defense = 79, ImageUrl = "https://assets.pokemon.com/assets/cms2/img/pokedex/full/130.png" }
        };

        private readonly IConfiguration _configuration;

        public PokemonRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Pokemon>> GetAllAsync()
        {
            // Simula uma operação assíncrona
            return await Task.FromResult(_pokemons);
        }

        public async Task<Pokemon> GetByIdAsync(int id)
        {
            // Simula uma operação assíncrona
            return await Task.FromResult(_pokemons.FirstOrDefault(p => p.Id == id));
        }

        public async Task<IEnumerable<Pokemon>> GetByTypeAsync(string type)
        {
            // Simula uma operação assíncrona
            return await Task.FromResult(_pokemons.Where(p => p.Type.Contains(type, StringComparison.OrdinalIgnoreCase)));
        }

        public async Task AddAsync(Pokemon pokemon)
        {
            // Gera um novo ID se não for fornecido
            if (pokemon.Id <= 0)
            {
                pokemon.Id = _pokemons.Count == 0 ? 1 : _pokemons.Max(p => p.Id) + 1;
            }

            _pokemons.Add(pokemon);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Pokemon pokemon)
        {
            var existingPokemon = _pokemons.FirstOrDefault(p => p.Id == pokemon.Id);
            if (existingPokemon != null)
            {
                existingPokemon.Name = pokemon.Name;
                existingPokemon.Type = pokemon.Type;
                existingPokemon.Level = pokemon.Level;
                existingPokemon.HP = pokemon.HP;
                existingPokemon.Attack = pokemon.Attack;
                existingPokemon.Defense = pokemon.Defense;
                existingPokemon.ImageUrl = pokemon.ImageUrl;
            }

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var pokemon = _pokemons.FirstOrDefault(p => p.Id == id);
            if (pokemon != null)
            {
                _pokemons.Remove(pokemon);
            }

            await Task.CompletedTask;
        }
    }
}