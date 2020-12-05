using Contracts;
using Dapper;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories {
    public class PostRepository : IPostRepository {
        
        private readonly IConfiguration _configuration;

        public PostRepository(IConfiguration configuration) {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(Post entity) {
            var sql = "INSERT INTO Posts (Body, CreatedBy, CreatedOn) VALUES (@Body, @CreatedBy, @CreatedOn)";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("sqlConnection"))) {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id) {
            var sql = "DELETE FROM Posts WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("sqlConnection"))) {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Post>> GetAllAsync() {
            var sql = "SELECT * FROM Posts";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("sqlConnection"))) {
                connection.Open();
                var result = await connection.QueryAsync<Post>(sql);
                return result.ToList();
            }
        }

        public async Task<Post> GetByIdAsync(int id) {
            var sql = "SELECT * FROM Posts WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("sqlConnection"))) {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Post>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Post entity) {
            var sql = "UPDATE Posts SET Body = @Body, CreatedBy = @CreatedBy, CreatedOn = @CreatedOn WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("sqlConnection"))) {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
