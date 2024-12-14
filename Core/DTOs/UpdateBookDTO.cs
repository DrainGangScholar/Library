namespace api.Core.DTOs
{
    public record UpdateBookDTO
    {
        public required Guid id { get; init; }
        public string ISBN { get; init; } = String.Empty;
        public string Name { get; init; } = String.Empty;
        public string Description { get; init; } = string.Empty;
    }
}
