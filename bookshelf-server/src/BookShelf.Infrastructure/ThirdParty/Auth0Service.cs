using BookShelf.Domain.Constants;
using BookShelf.Domain.DTO;
using BookShelf.Domain.Interfaces.ThirdParty;
using System.Net.Http.Json;
using System.Text.Json;

namespace BookShelf.Infrastructure.ThirdParty;

public class Auth0Service : IAuth0Service
{
    private readonly HttpClient _httpClient;

    public Auth0Service(HttpClient httpClient)
	{
        _httpClient = httpClient;
    }

    public async Task<Auth0SignupResponseModel> SignupUserAsync(Auth0SignupModel signupRequest, CancellationToken cancellationToken = default)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Auth0SignupModel>(Auth0APIConstants.SignupEndpoint, signupRequest, cancellationToken);

        response.EnsureSuccessStatusCode();

        Stream contentStream = await response.Content.ReadAsStreamAsync(cancellationToken);

        return await JsonSerializer.DeserializeAsync<Auth0SignupResponseModel>(contentStream, cancellationToken: cancellationToken);
    }

    public async Task<string> TriggerResetPasswordAsync(Auth0ChangePasswordModel changePasswordModel, CancellationToken cancellationToken = default)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync<Auth0ChangePasswordModel>(Auth0APIConstants.ChangePasswordEndpoint, changePasswordModel, cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync(cancellationToken);
    }
}
