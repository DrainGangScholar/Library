namespace api.DTOs
{
    public record CreateUserDTO
    {
        public required string FistName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }
        public required string Password { get; init; }
    }
}
