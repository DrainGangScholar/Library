using System.ComponentModel.DataAnnotations;

namespace api.Core.Entities
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public required string ISBN { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid? LoanId { get; set; }
        public Loan? Loan { get; set; }
    }
}
