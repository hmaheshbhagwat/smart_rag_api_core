using Microsoft.EntityFrameworkCore;

namespace smart_rag_api_core.Data
{
    public class RagDBContext : DbContext
    {
        public RagDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
    }
}
