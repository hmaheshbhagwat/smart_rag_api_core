using Microsoft.EntityFrameworkCore;
using smart_rag_api_core.Data.Configuration;
using smart_rag_api_core.Models.Data;

namespace smart_rag_api_core.Data
{
    public class RagDBContext : DbContext
    {
        public RagDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
