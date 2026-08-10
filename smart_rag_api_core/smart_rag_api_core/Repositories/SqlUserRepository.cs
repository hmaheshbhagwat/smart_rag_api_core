using Microsoft.EntityFrameworkCore;
using smart_rag_api_core.Data;
using smart_rag_api_core.Models.Data;

namespace smart_rag_api_core.Repositories
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly RagDBContext dbContext;
        public SqlUserRepository(RagDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public async Task<List<User>> AllUsersAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateAsync(Guid id, User user)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser == null) return null;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            await dbContext.SaveChangesAsync();
            return existingUser;

        }

        public async Task<User?> DeleteAsync(Guid id)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (existingUser == null) return null;
            dbContext.Users.Remove(existingUser); 
            await dbContext.SaveChangesAsync();
            return existingUser;
        }
    }
}
