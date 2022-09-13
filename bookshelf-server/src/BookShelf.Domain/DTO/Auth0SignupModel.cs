using System.Text.Json.Serialization;

namespace BookShelf.Domain.DTO;

public record Auth0SignupModel
{
    [JsonPropertyName("client_id")]
    public string ClientId { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("given_name")]
    public string GivenName { get; set; }

    [JsonPropertyName("family_name")]
    public string FamilyName { get; set; }

    [JsonPropertyName("picture")]
    public string Picture { get; set; }

    [JsonPropertyName("user_metadata")]
    public IDictionary<string, object> UserMetadata { get; set; }
}
