using api.Entities;
namespace api.DTOs
{
    public record UserDTO
    {
        public required Guid Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }

        public static UserDTO FromUser(User u)
        {
            return new UserDTO
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
            };
        }

        internal static List<UserDTO> EmptyList()
        {
            return new List<UserDTO> { };
        }
    }
}
