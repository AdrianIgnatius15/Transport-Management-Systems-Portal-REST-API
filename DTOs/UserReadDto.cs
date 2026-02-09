namespace Transport_Management_Systems_Portal_REST_API.DTOs
{
    public record UserReadDto
    {
        public int Id { get; init; }
        public string Username { get; init; }
        public string Email { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }
    }
}