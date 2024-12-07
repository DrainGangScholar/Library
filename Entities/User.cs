using System.ComponentModel.DataAnnotations;

namespace api.Entities
{
    public class User
    {
        [Key]
        public required Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public List<Loan>? Loans { get; set; } = new List<Loan>();
    }
}
