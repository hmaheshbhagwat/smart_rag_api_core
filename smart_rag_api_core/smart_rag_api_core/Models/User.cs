using System.ComponentModel.DataAnnotations;

namespace smart_rag_api_core.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
