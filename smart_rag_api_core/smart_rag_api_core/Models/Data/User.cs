using System.ComponentModel.DataAnnotations;

namespace smart_rag_api_core.Models.Data
{
    public class User
    {

        [Key]
        public Guid Id { get; set; } = new Guid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
