using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts {
    public interface IUserRepository {

        Task<User> GetByIdAsync(string id);
        Task<IReadOnlyList<User>> GetAllAsync();
        Task<int> AddAsync(User entity);
        Task<int> UpdateAsync(User entity);
        Task<int> DeleteAsync(string id);
    }
}
