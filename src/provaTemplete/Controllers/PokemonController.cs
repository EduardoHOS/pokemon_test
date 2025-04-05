using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using provaTemplete.Models;
using provaTemplete.Services;

namespace provaTemplete.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetAllPokemons()
        {
            var pokemons = await _pokemonService.GetAllPokemonsAsync();
            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetPokemonById(int id)
        {
            var pokemon = await _pokemonService.GetPokemonByIdAsync(id);
            if (pokemon == null) return NotFound();
            return Ok(pokemon);
        }

        [HttpGet("type/{type}")]
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemonsByType(string type)
        {
            var pokemons = await _pokemonService.GetPokemonsByTypeAsync(type);
            return Ok(pokemons);
        }

        [HttpPost]
        public async Task<ActionResult<Pokemon>> CreatePokemon([FromBody] Pokemon pokemon)
        {
            await _pokemonService.AddPokemonAsync(pokemon);
            return CreatedAtAction(nameof(GetPokemonById), new { id = pokemon.Id }, pokemon);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePokemon(int id, [FromBody] Pokemon pokemon)
        {
            if (id != pokemon.Id) return BadRequest();

            var existingPokemon = await _pokemonService.GetPokemonByIdAsync(id);
            if (existingPokemon == null) return NotFound();

            await _pokemonService.UpdatePokemonAsync(pokemon);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            var pokemon = await _pokemonService.GetPokemonByIdAsync(id);
            if (pokemon == null) return NotFound();

            await _pokemonService.DeletePokemonAsync(id);
            return NoContent();
        }
    }
}