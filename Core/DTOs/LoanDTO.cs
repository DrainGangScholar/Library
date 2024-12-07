using api.Core.Entities;

namespace api.Core.DTOs
{
    public record LoanDTO
    {
        public Guid Id { get; init; }
        public required string FullName { get; init; } = string.Empty;
        public required string Email { get; init; } = string.Empty;
        public required string BookName { get; init; } = string.Empty;
        public required DateOnly BorrowedDate { get; init; }
        public required DateOnly DueDate { get; init; }
        public DateOnly? ReturnedDate { get; set; }
        public required bool IsReturned { get; init; }
        public static LoanDTO From(Loan loan)
        {
            var user = loan.User;
            var FullName = String.Empty;
            var Email = String.Empty;
            if (user != null)
            {
                FullName = $"{user.FirstName} {user.LastName}";
                Email = user.Email;
            }
            var book = loan.Book;
            var BookName = String.Empty;
            if (book != null)
            {
                BookName = book.Name;
            }
            var BorrowedDate = DateOnly.FromDateTime(loan.BorrowedDate);
            var DueDate = DateOnly.FromDateTime(loan.DueDate);
            var response = new LoanDTO
            {
                Id = loan.Id,
                FullName = FullName,
                Email = Email,
                BookName = BookName,
                BorrowedDate = BorrowedDate,
                DueDate = DueDate,
                IsReturned = loan.IsReturned
            };
            if (loan.ReturnedDate != null)
            {
                response.ReturnedDate = DateOnly.FromDateTime((DateTime)loan.ReturnedDate);
            }
            return response;
        }
        public static List<LoanDTO> EmptyList()
        {
            return new List<LoanDTO>
            {
            };
        }
    }
}
