using Microsoft.EntityFrameworkCore;
using smart_rag_api_core.Models;

namespace smart_rag_api_core.Data
{
    public class RagDBContext : DbContext
    {
        public RagDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
