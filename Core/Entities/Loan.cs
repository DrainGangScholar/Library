using System.ComponentModel.DataAnnotations;
using api.Core.DTOs;
namespace api.Core.Entities
{
    public class Loan
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User? User { get; set; }
        public Guid BookId { get; set; }
        public Book? Book { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public bool IsReturned { get; set; } = false;

        internal static Loan From(CreateLoanDTO request,User user,Book book)
        {
            return new Loan
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                User = user,
                BookId = book.Id,
                Book = book,
                BorrowedDate = DateTime.Today,
                DueDate = DateTime.Today.AddDays(request.Interval),
            };
        }
    }
}
