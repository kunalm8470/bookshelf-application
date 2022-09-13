using System.Text.Json.Serialization;

namespace BookShelf.Domain.DTO;

public record Auth0SignupResponseModel
{
    [JsonPropertyName("given_name")]
    public string GivenName { get; set; }

    [JsonPropertyName("family_name")]
    public string FamilyName { get; set; }

    [JsonPropertyName("_id")]
    public string Id { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("email_verified")]
    public bool EmailVerified { get; set; }

    [JsonPropertyName("user_metadata")]
    public IDictionary<string, object> UserMetadata { get; set; }
}
