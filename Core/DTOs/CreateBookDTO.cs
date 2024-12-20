namespace api.Core.DTOs
{
    public record CreateBookDTO
    {
        public required string ISBN { get; init; }
        public required string Name { get; init; }
        public string Description { get; init; } = string.Empty;
    }
}
