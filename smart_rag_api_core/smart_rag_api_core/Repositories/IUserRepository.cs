using Microsoft.AspNetCore.Mvc;
using smart_rag_api_core.Models.Data;

namespace smart_rag_api_core.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> AllUsersAsync();

        Task<User?> GetUserByIdAsync(Guid id);

        Task<User> CreateUserAsync(User user);


        Task<User?> UpdateAsync(Guid id, User user);

        Task<User?> DeleteAsync(Guid id);

    }
}
