using System.Text.Json.Serialization;

namespace BookShelf.Domain.DTO
{
    public record Auth0ChangePasswordModel
    {
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("connection")]
        public string Connection { get; set; }
    }
}
