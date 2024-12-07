using api.Core.Entities;

namespace api.Core.DTOs
{
    public record BookDTO
    {
        public Guid Id { get; init; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ISBN { get; set; }
        public required bool IsBorrowed { get; set; }
        public static BookDTO From(Book book)
        {
            var IsBorrowed = book.LoanId != null;
            return new BookDTO
            {
                Id = book.Id,
                Name = book.Name,
                Description = book.Description,
                ISBN = book.ISBN,
                IsBorrowed = IsBorrowed
            };
        }

        internal static List<BookDTO> EmptyList()
        {
            return new List<BookDTO> { };
        }
    }
}
