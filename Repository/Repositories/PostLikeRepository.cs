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
    public class PostLikeRepository : IPostLikeRepository {
        
        private readonly IConfiguration _configuration;

        public PostLikeRepository(IConfiguration configuration) {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(PostLike entity) {
            var sql = "INSERT INTO PostLikes (Body, CreatedBy, CreatedOn, PostId) VALUES (@Body, @CreatedBy, @CreatedOn, @PostId)";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("sqlConnection"))) {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id) {
            var sql = "DELETE FROM PostLikes WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("sqlConnection"))) {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<PostLike>> GetAllAsync() {
            var sql = "SELECT * FROM PostLikes";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("sqlConnection"))) {
                connection.Open();
                var result = await connection.QueryAsync<PostLike>(sql);
                return result.ToList();
            }
        }

        public async Task<PostLike> GetByIdAsync(int id) {
            var sql = "SELECT * FROM PostLikes WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("sqlConnection"))) {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<PostLike>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(PostLike entity) {
            var sql = "UPDATE PostLikes SET Body = @Body, CreatedBy = @CreatedBy, CreatedOn = @CreatedOn, PostId = @PostId WHERE Id = @Id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("sqlConnection"))) {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
