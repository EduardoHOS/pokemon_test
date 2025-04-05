using System.Collections.Generic;
using System.Threading.Tasks;
using provaTemplete.Models;

namespace provaTemplete.Services
{
    public interface IPokemonService
    {
        Task<IEnumerable<Pokemon>> GetAllPokemonsAsync();
        Task<Pokemon> GetPokemonByIdAsync(int id);
        Task<IEnumerable<Pokemon>> GetPokemonsByTypeAsync(string type);
        Task AddPokemonAsync(Pokemon pokemon);
        Task UpdatePokemonAsync(Pokemon pokemon);
        Task DeletePokemonAsync(int id);
    }
}