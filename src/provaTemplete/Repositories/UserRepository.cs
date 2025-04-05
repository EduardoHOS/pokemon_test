using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using provaTemplete.Models;

namespace provaTemplete.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryAsync<User>("SELECT * FROM users");
        }

        public async Task<User> GetByIdAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM users WHERE id = @Id", new { Id = id });
        }

        public async Task AddAsync(User user)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.ExecuteAsync("INSERT INTO users (name, email) VALUES (@Name, @Email)", user);
        }

        public async Task UpdateAsync(User user)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.ExecuteAsync("UPDATE users SET name = @Name, email = @Email WHERE id = @Id", user);
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            await connection.ExecuteAsync("DELETE FROM users WHERE id = @Id", new { Id = id });
        }
    }
}