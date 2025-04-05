using System.Collections.Generic;
using System.Threading.Tasks;
using provaTemplete.Models;

namespace provaTemplete.Repositories
{
    public interface IPokemonRepository
    {
        Task<IEnumerable<Pokemon>> GetAllAsync();
        Task<Pokemon> GetByIdAsync(int id);
        Task<IEnumerable<Pokemon>> GetByTypeAsync(string type);
        Task AddAsync(Pokemon pokemon);
        Task UpdateAsync(Pokemon pokemon);
        Task DeleteAsync(int id);
    }
}