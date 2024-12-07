using System.ComponentModel.DataAnnotations;

namespace api.Core.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public List<Loan>? Loans { get; set; } = new List<Loan>();
    }
}
