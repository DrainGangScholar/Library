namespace api.DTOs
{
    public record CreateLoanDTO
    {
        public required Guid UserId { get; init; }
        public required Guid BookId { get; init; }
        public required int Interval { get; init; }
    }
}
