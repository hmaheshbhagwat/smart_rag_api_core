using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using smart_rag_api_core.Models.Data;

namespace smart_rag_api_core.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(x => x.Id);

            builder.HasData(
                new User
                {
                    Id = Guid.Parse("550e8400-e29b-41d4-a716-446655440000"), FirstName = "John", LastName = "Doe", Email = "John.Doe@example.com", Password = 
                    "password"
                }
                );
        }
    }
}
