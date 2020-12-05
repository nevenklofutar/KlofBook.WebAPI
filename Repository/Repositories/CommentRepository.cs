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
    public class CommentRepository : ICommentRepository {
        
        private readonly IConfiguration _configuration;

        public CommentRepository(IConfiguration configuration) {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(Comment entity) {
            var sql = "INSERT INTO Comments (Body, CreatedBy, CreatedOn, PostId) VALUES (@Body, @CreatedBy, @CreatedOn, @PostId)";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("sqlConnection"))) {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id) {
            var sql = "DELETE FROM Comments WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("sqlConnection"))) {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Comment>> GetAllAsync() {
            var sql = "SELECT * FROM Comments";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("sqlConnection"))) {
                connection.Open();
                var result = await connection.QueryAsync<Comment>(sql);
                return result.ToList();
            }
        }

        public async Task<Comment> GetByIdAsync(int id) {
            var sql = "SELECT * FROM Comments WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("sqlConnection"))) {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Comment>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Comment entity) {
            var sql = "UPDATE Comments SET Body = @Body, CreatedBy = @CreatedBy, CreatedOn = @CreatedOn, PostId = @PostId WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("sqlConnection"))) {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
