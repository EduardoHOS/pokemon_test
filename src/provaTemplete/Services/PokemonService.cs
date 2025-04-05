using System.Collections.Generic;
using System.Threading.Tasks;
using provaTemplete.Models;
using provaTemplete.Repositories;

namespace provaTemplete.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<IEnumerable<Pokemon>> GetAllPokemonsAsync()
        {
            return await _pokemonRepository.GetAllAsync();
        }

        public async Task<Pokemon> GetPokemonByIdAsync(int id)
        {
            return await _pokemonRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Pokemon>> GetPokemonsByTypeAsync(string type)
        {
            return await _pokemonRepository.GetByTypeAsync(type);
        }

        public async Task AddPokemonAsync(Pokemon pokemon)
        {
            await _pokemonRepository.AddAsync(pokemon);
        }

        public async Task UpdatePokemonAsync(Pokemon pokemon)
        {
            await _pokemonRepository.UpdateAsync(pokemon);
        }

        public async Task DeletePokemonAsync(int id)
        {
            await _pokemonRepository.DeleteAsync(id);
        }
    }
}