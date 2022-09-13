﻿using System.Text.Json.Serialization;

namespace BookShelf.Domain.DTO;

public record Auth0ManagementAPITokenModel
{
    [JsonPropertyName("client_id")]
    public string ClientId { get; set; }

    [JsonPropertyName("client_secret")]
    public string ClientSecret { get; set; }

    [JsonPropertyName("audience")]
    public string Audience { get; set; }

    [JsonPropertyName("grant_type")]
    public string GrantType { get; set; }
}
